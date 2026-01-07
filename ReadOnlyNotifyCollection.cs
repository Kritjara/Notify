using System.Collections;

namespace Kritjara.Collections;

/// <summary>Представляет коллекцию только для чтения с оповещением о добавлении/удалении элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
public class ReadOnlyNotifyCollection<T> : NotifyBase<T>, IReadOnlyNotifyCollection<T>, IReadOnlyCollection<T>,  IReadOnlyList<T>
{
    /// <summary>
    /// Основной источник элементов
    /// </summary>
    protected readonly INotifyCollection<T> Items;

    /// <summary>
    /// Инициализирует новый только для чтения экземпляр коллекции с оповещениями <see cref="INotify{T}"/>"/>
    /// </summary>
    /// <param name="items">Основной источник элементов</param>
    public ReadOnlyNotifyCollection(INotifyCollection<T> items)
    {
        Items = items;
        Items.ItemAdded += Source_ItemAdded;
        Items.ItemRemoved += Source_ItemRemoved;
        Items.RangeAdded += Source_RangeAdded;
        Items.RangeRemoved += Items_RangeRemoved;
        Items.ItemReplaced += Source_ItemReplaced;
        Items.ItemMoved += Source_ItemMoved;
        Items.CollectionCleared += Source_Cleared;
    }

    private void Source_ItemAdded(object sender, IItemAddedEventArgs<T> e) => RaiseItemAdded(e);
    private void Source_ItemRemoved(object sender, IItemRemovedEventArgs<T> e) => RaiseItemRemoved(e);
    private void Source_RangeAdded(object sender, IRangeAddedEventArgs<T> e) => RaiseRangeAdded(e);
    private void Items_RangeRemoved(object sender, IRangeRemovedEventArgs<T> e) => RaiseRangeRemoved(e);
    private void Source_ItemReplaced(object sender, IItemReplacedEventArgs<T> e) => RaiseItemReplaced(e);
    private void Source_ItemMoved(object sender, IItemMovedEventArgs<T> e) => RaiseItemMoved(e);
    private void Source_Cleared(object sender, ICollectionClearedEventArgs<T> e) => RaiseCollectionCleared(e);

    /// <inheritdoc/>
    public T this[int index] => Items[index];

    /// <inheritdoc/>
    public int Count => Items.Count;

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

}
