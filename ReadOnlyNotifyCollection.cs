using System.Collections;

namespace Kritjara.Collections.Notify;

/// <summary>Представляет коллекцию только для чтения с оповещением о добавлении/удалении элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
public class ReadOnlyNotifyCollection<T> : IReadOnlyCollection<T>, IReadOnlyNotifyCollection<T>, IReadOnlyList<T>
{
    public event ItemAddedEventHandler<T>? ItemAdded;
    public event RangeAddedEventHandler<T>? RangeAdded;
    public event ItemRemovedEventHandler<T>? ItemRemoved;
    public event RangeRemovedEventHandler<T>? RangeRemoved;
    public event ItemReplacedEventHandler<T>? ItemReplaced;
    public event ItemMovedEventHandler<T>? ItemMoved;
    public event CollectionResetEventHandler<T>? Reset;

    protected virtual void OnItemAdded(IItemAddedEventArgs<T> e) => ItemAdded?.Invoke(this, e);
    protected virtual void OnRangeAdded(IRangeAddedEventArgs<T> e) => RangeAdded?.Invoke(this, e);
    protected virtual void OnItemRemoved(IItemRemovedEventArgs<T> e) => ItemRemoved?.Invoke(this, e);
    protected virtual void OnRangeRemoved(IRangeRemovedEventArgs<T> e) => RangeRemoved?.Invoke(this, e);
    protected virtual void OnItemReplaced(IItemReplacedEventArgs<T> e) => ItemReplaced?.Invoke(this, e);
    protected virtual void OnItemMoved(IItemMovedEventArgs<T> e) => ItemMoved?.Invoke(this, e);
    protected virtual void OnReset(ICollectionResetEventArgs<T> e) => Reset?.Invoke(this, e);


    protected readonly INotifyCollection<T> Items;

 
    public ReadOnlyNotifyCollection(INotifyCollection<T> items)
    {
        Items = items;
        Items.ItemAdded += Source_ItemAdded;
        Items.ItemRemoved += Source_ItemRemoved;
        Items.RangeAdded += Source_RangeAdded;
        items.RangeRemoved += Items_RangeRemoved;
        Items.ItemReplaced += Source_ItemReplaced;
        Items.ItemMoved += Source_ItemMoved;
        Items.Reset += Source_Cleared;
    }

    private void Source_ItemAdded(object sender, IItemAddedEventArgs<T> e) => OnItemAdded(e);
    private void Source_ItemRemoved(object sender, IItemRemovedEventArgs<T> e) => OnItemRemoved(e);
    private void Source_RangeAdded(object sender, IRangeAddedEventArgs<T> e) => OnRangeAdded(e);
    private void Items_RangeRemoved(object sender, IRangeRemovedEventArgs<T> e) => OnRangeRemoved(e);
    private void Source_ItemReplaced(object sender, IItemReplacedEventArgs<T> e) => OnItemReplaced(e);
    private void Source_ItemMoved(object sender, IItemMovedEventArgs<T> e) => OnItemMoved(e);
    private void Source_Cleared(object sender, ICollectionResetEventArgs<T> e) => OnReset(e);

    public T this[int index] => Items[index];

    public int Count => Items.Count;

    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

}
