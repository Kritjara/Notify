using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Kritjara.Collections;

internal class NotifyDictionary<TKey, TValue> : NotifyBase<TKey, TValue>, IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
    where TKey : notnull
{
    public NotifyDictionary()
    {
        Items = [];
    }

    private readonly Dictionary<TKey, TValue> Items;


    public TValue this[TKey key]
    {
        get => Items[key];
        set
        {
            if (Items.TryGetValue(key, out TValue? current))
            {
                Items[key] = value;
                RaiseKeyValueChanged(key, current, value);
            }
            else
            {
                Items[key] = value;
                RaiseItemAdded(key, value);
            }
        }
    }

    public int Count => Items.Count;

    public void Add(TKey key, TValue value)
    {
        Items.Add(key, value);
        RaiseItemAdded(key, value);
    }

    public bool ContainsKey(TKey key) => Items.ContainsKey(key);

    public bool Remove(TKey key)
    {
        if (Items.Remove(key, out TValue? value))
        {
            RaiseItemRemoved(key, value);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) => Items.TryGetValue(key, out value);


    public ICollection<TKey> Keys => Items.Keys;
    public ICollection<TValue> Values => Items.Values;

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        Add(item.Key, item.Value);
    }

    public void Clear()
    {
        IReadOnlyList<DictionaryItem<TKey, TValue>> removedItems = [.. Items.Select(pair => new DictionaryItem<TKey, TValue>(pair.Key, pair.Value))];
        Items.Clear();
        if (removedItems.Count != 0)
        {
            RaiseDictionaryCleared(removedItems);
        }
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        return Items.Contains(item);
    }

    void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<TKey, TValue>>)Items).CopyTo(array, arrayIndex);

    bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)Items).Remove(item);

    bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)Items).IsReadOnly;

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Items.Keys;
    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Items.Values;
}
