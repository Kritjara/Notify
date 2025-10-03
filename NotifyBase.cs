using System.Collections.Immutable;

namespace Kritjara.Collections.Notify;

/// <summary>Представляет базовый класс, оповещающий о добавлении/удалении/перемещении элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
/// <remarks>По умолчанию не является списком</remarks>
public abstract class NotifyBase<T> : INotify<T>
{
    /// <inheritdoc/>
    public event ItemAddedEventHandler<T>? ItemAdded;
    /// <inheritdoc/>
    public event RangeAddedEventHandler<T>? RangeAdded;
    /// <inheritdoc/>
    public event ItemRemovedEventHandler<T>? ItemRemoved;
    /// <inheritdoc/>
    public event RangeRemovedEventHandler<T>? RangeRemoved;
    /// <inheritdoc/>
    public event ItemReplacedEventHandler<T>? ItemReplaced;
    /// <inheritdoc/>
    public event ItemMovedEventHandler<T>? ItemMoved;
    /// <inheritdoc/>
    public event CollectionResetEventHandler<T>? Reset;

    /// <summary>
    /// Вызывает событие <see cref="ItemAdded"/> при добавлении нового элемента в коллекцию
    /// </summary>
    /// <param name="index">Индекс, по которому был добавлен элемент</param>
    /// <param name="newItem">Новый добавленный элемент</param>
    protected virtual void RaiseItemAdded(int index, T newItem) => ItemAdded?.Invoke(this, new ItemAddedEventArgs<T>(newItem, index));

    /// <summary>
    /// Вызывает событие <see cref="RangeAdded"/> при добавлении диапазона элементов в коллекцию
    /// </summary>
    /// <param name="index">Начальный индекс, с которого были добавлены элементы</param>
    /// <param name="newItems">Коллекция добавленных элементов</param>
    protected virtual void RaiseRangeAdded(int index, IReadOnlyList<T> newItems) => RangeAdded?.Invoke(this, new RangeAddedEventArgs<T>(newItems, index));

    /// <summary>
    /// Вызывает событие <see cref="ItemRemoved"/> при удалении элемента из коллекции
    /// </summary>
    /// <param name="index">Индекс, с которого был удален элемент</param>
    /// <param name="removedItem">Удаленный элемент</param>
    protected virtual void RaiseItemRemoved(int index, T removedItem) => ItemRemoved?.Invoke(this, new ItemRemovedEventArgs<T>(removedItem, index));

    /// <summary>
    /// Вызывает событие <see cref="RangeRemoved"/> при удалении диапазона элементов из коллекции
    /// </summary>
    /// <param name="index">Начальный индекс, с которого были удалены элементы</param>
    /// <param name="removedItems">Коллекция удаленных элементов</param>
    protected virtual void RaiseRangeRemoved(int index, IReadOnlyList<T> removedItems) => RangeRemoved?.Invoke(this, new RangeRemovedEventArgs<T>(removedItems, index));

    /// <summary>
    /// Вызывает событие <see cref="ItemReplaced"/> при замене элемента в коллекции
    /// </summary>
    /// <param name="index">Индекс замененного элемента</param>
    /// <param name="oldItem">Старый элемент, который был заменен</param>
    /// <param name="newItem">Новый элемент, который заменил старый</param>
    protected virtual void RaiseItemReplaced(int index, T oldItem, T newItem) => ItemReplaced?.Invoke(this, new ItemReplacedEventArgs<T>(oldItem, newItem, index));

    /// <summary>
    /// Вызывает событие <see cref="ItemMoved"/> при перемещении элемента внутри коллекции
    /// </summary>
    /// <param name="oldIndex">Исходный индекс элемента</param>
    /// <param name="newIndex">Новый индекс элемента</param>
    /// <param name="movedItem">Перемещенный элемент</param>
    protected virtual void RaiseItemMoved(int oldIndex, int newIndex, T movedItem) => ItemMoved?.Invoke(this, new ItemMovedEventArgs<T>(oldIndex, newIndex, movedItem));

    /// <summary>
    /// Вызывает событие <see cref="Reset"/> при полной очистке коллекции
    /// </summary>
    /// <param name="removedItems">Коллекция всех удаленных элементов при очистке</param>
    protected virtual void RaiseReset(IReadOnlyList<T> removedItems) => Reset?.Invoke(this, new CollectionResetEventArgs<T>(removedItems));


    /// <summary>
    /// Вызывает событие <see cref="ItemAdded"/> при добавлении нового элемента в коллекцию
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemAdded(IItemAddedEventArgs<T> e) => ItemAdded?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="RangeAdded"/> при добавлении диапазона элементов в коллекцию
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseRangeAdded(IRangeAddedEventArgs<T> e) => RangeAdded?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemRemoved"/> при удалении элемента из коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemRemoved(IItemRemovedEventArgs<T> e) => ItemRemoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="RangeRemoved"/> при удалении диапазона элементов из коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseRangeRemoved(IRangeRemovedEventArgs<T> e) => RangeRemoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemReplaced"/> при замене элемента в коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemReplaced(IItemReplacedEventArgs<T> e) => ItemReplaced?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemMoved"/> при перемещении элемента внутри коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemMoved(IItemMovedEventArgs<T> e) => ItemMoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="Reset"/> при полной очистке коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseReset(ICollectionResetEventArgs<T> e) => Reset?.Invoke(this, e);
}