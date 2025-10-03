using System.Collections;

namespace Kritjara.Collections.Notify;

/// <summary>Представляет коллекцию только для чтения с оповещением о добавлении/удалении элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
internal class ReadOnlyNotifyCollectionShell<T> : NotifyBase<T>, IReadOnlyNotifyCollection<T>
{
    private readonly Func<int> func_getcount;
    private readonly Func<int, T> func_getitem;


    private int ReadOnlyList_GetCount() => ((IReadOnlyList<T>)Items).Count;
    private T ReadOnlyList_GetItem(int index) => ((IReadOnlyList<T>)Items)[index];

    private int List_GetCount() => ((IList<T>)Items).Count;
    private T List_GetItem(int index) => ((IList<T>)Items)[index];
      
    private int ReadOnlyCollection_GetCount() => ((IReadOnlyCollection<T>)Items).Count;

    private int Collection_GetCount() => ((ICollection<T>)Items).Count;
     
    private int Enumerable_GetCount() => ((IEnumerable<T>)Items).Count();
    private T Enumerable_GetItem(int index) => ((IEnumerable<T>)Items).ElementAt(index);


    /// <summary>
    /// Основной источник элементов
    /// </summary>
    protected readonly INotify<T> Items;

    /// <summary>
    /// Инициализирует новый только для чтения экземпляр коллекции с оповещениями <see cref="INotify{T}"/>"/>
    /// </summary>
    /// <param name="items">Основной источник элементов</param>
    public ReadOnlyNotifyCollectionShell(INotify<T> items)
    {
        if (items is IReadOnlyList<T>)
        {
            func_getcount = ReadOnlyList_GetCount;
            func_getitem = ReadOnlyList_GetItem;
        }
        else if (items is IList<T>)
        {
            func_getcount = List_GetCount;
            func_getitem = List_GetItem;
        }
        else if (items is IReadOnlyCollection<T>)
        {
            func_getcount = ReadOnlyCollection_GetCount;
            func_getitem = Enumerable_GetItem;
        }
        else if (items is ICollection<T>)
        {
            func_getcount = Collection_GetCount;
            func_getitem = Enumerable_GetItem;
        }
        else if (items is IEnumerable<T>)
        {
            func_getcount = Enumerable_GetCount;
            func_getitem = Enumerable_GetItem;
        }
        else
        {
            throw new ArgumentException($"{nameof(items)} не является коллекцией элементов типа {typeof(T)}", nameof(items));
        }
        Items = items;
        Items.ItemAdded += Source_ItemAdded;
        Items.ItemRemoved += Source_ItemRemoved;
        Items.RangeAdded += Source_RangeAdded;
        Items.RangeRemoved += Items_RangeRemoved;
        Items.ItemReplaced += Source_ItemReplaced;
        Items.ItemMoved += Source_ItemMoved;
        Items.Reset += Source_Cleared;
    }

    private void Source_ItemAdded(object sender, IItemAddedEventArgs<T> e) => RaiseItemAdded(e);
    private void Source_ItemRemoved(object sender, IItemRemovedEventArgs<T> e) => RaiseItemRemoved(e);
    private void Source_RangeAdded(object sender, IRangeAddedEventArgs<T> e) => RaiseRangeAdded(e);
    private void Items_RangeRemoved(object sender, IRangeRemovedEventArgs<T> e) => RaiseRangeRemoved(e);
    private void Source_ItemReplaced(object sender, IItemReplacedEventArgs<T> e) => RaiseItemReplaced(e);
    private void Source_ItemMoved(object sender, IItemMovedEventArgs<T> e) => RaiseItemMoved(e);
    private void Source_Cleared(object sender, ICollectionResetEventArgs<T> e) => RaiseReset(e);

    /// <inheritdoc/>
    public T this[int index] => func_getitem(index);

    /// <inheritdoc/>
    public int Count => func_getcount();

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Items).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
