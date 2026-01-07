#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет базовый класс, оповещающий о добавлении/удалении/перемещении элементов.</summary>
/// <typeparam name="TValue">Тип объектов, содержащихся в коллекции.</typeparam>
/// <remarks>По умолчанию не является списком</remarks>
public abstract class NotifyBase<TValue> : INotify<TValue>
{
    /// <inheritdoc/>
    public event ItemAddedEventHandler<TValue>? ItemAdded;
    /// <inheritdoc/>
    public event RangeAddedEventHandler<TValue>? RangeAdded;
    /// <inheritdoc/>
    public event ItemRemovedEventHandler<TValue>? ItemRemoved;
    /// <inheritdoc/>
    public event RangeRemovedEventHandler<TValue>? RangeRemoved;
    /// <inheritdoc/>
    public event ItemReplacedEventHandler<TValue>? ItemReplaced;
    /// <inheritdoc/>
    public event ItemMovedEventHandler<TValue>? ItemMoved;
    /// <inheritdoc/>
    public event CollectionClearedEventHandler<TValue>? CollectionCleared;

    /// <summary>
    /// Вызывает событие <see cref="ItemAdded"/> при добавлении нового элемента в коллекцию
    /// </summary>
    /// <param name="index">Индекс, по которому был добавлен элемент</param>
    /// <param name="newItem">Новый добавленный элемент</param>
    protected virtual void RaiseItemAdded(int index, TValue newItem) => ItemAdded?.Invoke(this, new ItemAddedEventArgs<TValue>(newItem, index));

    /// <summary>
    /// Вызывает событие <see cref="RangeAdded"/> при добавлении диапазона элементов в коллекцию
    /// </summary>
    /// <param name="index">Начальный индекс, с которого были добавлены элементы</param>
    /// <param name="newItems">Коллекция добавленных элементов</param>
    protected virtual void RaiseRangeAdded(int index, IReadOnlyList<TValue> newItems) => RangeAdded?.Invoke(this, new RangeAddedEventArgs<TValue>(newItems, index));

    /// <summary>
    /// Вызывает событие <see cref="ItemRemoved"/> при удалении элемента из коллекции
    /// </summary>
    /// <param name="index">Индекс удалённого элемента</param>
    /// <param name="removedItem">Удаленный элемент</param>
    protected virtual void RaiseItemRemoved(int index, TValue removedItem) => ItemRemoved?.Invoke(this, new ItemRemovedEventArgs<TValue>(removedItem, index));

    /// <summary>
    /// Вызывает событие <see cref="RangeRemoved"/> при удалении диапазона элементов из коллекции
    /// </summary>
    /// <param name="index">Начальный индекс, с которого были удалены элементы</param>
    /// <param name="removedItems">Коллекция удаленных элементов</param>
    protected virtual void RaiseRangeRemoved(int index, IReadOnlyList<TValue> removedItems) => RangeRemoved?.Invoke(this, new RangeRemovedEventArgs<TValue>(removedItems, index));

    /// <summary>
    /// Вызывает событие <see cref="ItemReplaced"/> при замене элемента в коллекции
    /// </summary>
    /// <param name="index">Индекс замененного элемента</param>
    /// <param name="oldItem">Старый элемент, который был заменен</param>
    /// <param name="newItem">Новый элемент, который заменил старый</param>
    protected virtual void RaiseItemReplaced(int index, TValue oldItem, TValue newItem) => ItemReplaced?.Invoke(this, new ItemReplacedEventArgs<TValue>(oldItem, newItem, index));

    /// <summary>
    /// Вызывает событие <see cref="ItemMoved"/> при перемещении элемента внутри коллекции
    /// </summary>
    /// <param name="oldIndex">Исходный индекс элемента</param>
    /// <param name="newIndex">Новый индекс элемента</param>
    /// <param name="movedItem">Перемещенный элемент</param>
    protected virtual void RaiseItemMoved(int oldIndex, int newIndex, TValue movedItem) => ItemMoved?.Invoke(this, new ItemMovedEventArgs<TValue>(oldIndex, newIndex, movedItem));

    /// <summary>
    /// Вызывает событие <see cref="CollectionCleared"/> при полной очистке коллекции
    /// </summary>
    /// <param name="removedItems">Коллекция всех удаленных элементов при очистке</param>
    protected virtual void RaiseCollectionCleared(IReadOnlyList<TValue> removedItems) => CollectionCleared?.Invoke(this, new CollectionClearedEventArgs<TValue>(removedItems));


    /// <summary>
    /// Вызывает событие <see cref="ItemAdded"/> при добавлении нового элемента в коллекцию
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemAdded(IItemAddedEventArgs<TValue> e) => ItemAdded?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="RangeAdded"/> при добавлении диапазона элементов в коллекцию
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseRangeAdded(IRangeAddedEventArgs<TValue> e) => RangeAdded?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemRemoved"/> при удалении элемента из коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemRemoved(IItemRemovedEventArgs<TValue> e) => ItemRemoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="RangeRemoved"/> при удалении диапазона элементов из коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseRangeRemoved(IRangeRemovedEventArgs<TValue> e) => RangeRemoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemReplaced"/> при замене элемента в коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemReplaced(IItemReplacedEventArgs<TValue> e) => ItemReplaced?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemMoved"/> при перемещении элемента внутри коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemMoved(IItemMovedEventArgs<TValue> e) => ItemMoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="CollectionCleared"/> при полной очистке коллекции
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseCollectionCleared(ICollectionClearedEventArgs<TValue> e) => CollectionCleared?.Invoke(this, e);


    private NotifyEventsBridge? Bridge;
    /// <summary>События текущего экземпляра <see cref="NotifyBase{T}"/> будут подниматься автоматически после каждого события в указанном <see cref="INotify{T}"/>.</summary>
    /// <param name="sourse">Объект-источник событий для поднятия событий текущего экземпляра.</param>
    /// <remarks>Если мост уже установлен с другой коллекцией, тогда будет создан новый, а предыдущий - будет уничтожен.</remarks>
    protected void CreateBridge(INotify<TValue> sourse)
    {
        Bridge?.Dispose();
        Bridge = new NotifyEventsBridge(this, sourse);
    }

    /// <summary>События текущего экземпляра <see cref="NotifyBase{T}"/> больше не будут подниматься автоматически после каждого события источника <see cref="INotify{T}"/>.</summary>
    /// <remarks>Если не был создан, ничего не произойдет.</remarks>
    protected void DestroyBridge()
    {
        Bridge?.Dispose();
    }

    internal class NotifyEventsBridge : IDisposable
    {
        private readonly INotify<TValue> sourse;
        private readonly NotifyBase<TValue> target;

        public NotifyEventsBridge(NotifyBase<TValue> target, INotify<TValue> sourse)
        {
            this.sourse = sourse;
            this.target = target;
            sourse.ItemAdded += Items_ItemAdded;
            sourse.ItemRemoved += Items_ItemRemoved;
            sourse.RangeAdded += Items_RangeAdded;
            sourse.RangeRemoved += Items_RangeRemoved;
            sourse.ItemReplaced += Items_ItemReplaced;
            sourse.ItemMoved += Items_ItemMoved;
            sourse.CollectionCleared += Items_CollectionCleared;
        }


        private void Items_ItemAdded(object sender, IItemAddedEventArgs<TValue> e)
        {
            target.RaiseItemAdded(e);
        }

        private void Items_ItemRemoved(object sender, IItemRemovedEventArgs<TValue> e)
        {
            target.RaiseItemRemoved(e);
        }

        private void Items_RangeAdded(object sender, IRangeAddedEventArgs<TValue> e)
        {
            target.RaiseRangeAdded(e);
        }

        private void Items_RangeRemoved(object sender, IRangeRemovedEventArgs<TValue> e)
        {
            target.RaiseRangeRemoved(e);
        }

        private void Items_ItemReplaced(object sender, IItemReplacedEventArgs<TValue> e)
        {
            target.RaiseItemReplaced(e);
        }

        private void Items_ItemMoved(object sender, IItemMovedEventArgs<TValue> e)
        {
            target.RaiseItemMoved(e);
        }

        private void Items_CollectionCleared(object sender, ICollectionClearedEventArgs<TValue> e)
        {
            target.RaiseCollectionCleared(e);
        }

        public void Dispose()
        {
            sourse.ItemAdded -= Items_ItemAdded;
            sourse.ItemRemoved -= Items_ItemRemoved;
            sourse.RangeAdded -= Items_RangeAdded;
            sourse.RangeRemoved -= Items_RangeRemoved;
            sourse.ItemReplaced -= Items_ItemReplaced;
            sourse.ItemMoved -= Items_ItemMoved;
            sourse.CollectionCleared -= Items_CollectionCleared;
        }
    }
}




/// <summary>Представляет базовый класс, оповещающий о добавлении/удалении/перемещении элементов.</summary>
/// <typeparam name="TKey">Тип ключа.</typeparam>
/// <typeparam name="TValue">Тип объектов, содержащихся в словаре.</typeparam>
/// <remarks>По умолчанию не является списком</remarks>
public abstract class NotifyBase<TKey, TValue> : INotify<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public event ItemAddedEventHandler<TKey, TValue>? ItemAdded;

    /// <inheritdoc/>
    public event ItemRemovedEventHandler<TKey, TValue>? ItemRemoved;

    /// <inheritdoc/>
    public event KeyValueChangedEventHandler<TKey, TValue>? KeyValueChanged;

    /// <inheritdoc/>
    public event DictionaryClearedEventHandler<TKey, TValue>? DictionaryCleared;

    /// <summary>
    /// Вызывает событие <see cref="ItemAdded"/> при добавлении нового элемента в словарь
    /// </summary>
    /// <param name="key">Ключ добавленного элемента</param>
    /// <param name="newItem">Добавленный элемент</param>
    protected virtual void RaiseItemAdded(TKey key, TValue newItem) => ItemAdded?.Invoke(this, new ItemAddedEventArgs<TKey, TValue>(key, newItem));

    ///// <summary>
    ///// Вызывает событие <see cref="RangeAdded"/> при добавлении диапазона элементов в коллекцию
    ///// </summary>
    ///// <param name="key">Начальный индекс, с которого были добавлены элементы</param>
    ///// <param name="newItems">Коллекция добавленных элементов</param>
    //protected virtual void RaiseRangeAdded(int key, IReadOnlyList<TValue> newItems) => RangeAdded?.Invoke(this, new RangeAddedEventArgs<TValue>(newItems, key));

    /// <summary>
    /// Вызывает событие <see cref="ItemRemoved"/> при удалении элемента из словаря
    /// </summary>
    /// <param name="key">Ключ удалённого элемента</param>
    /// <param name="removedItem">Удаленный элемент</param>
    protected virtual void RaiseItemRemoved(TKey key, TValue removedItem) => ItemRemoved?.Invoke(this, new ItemRemovedEventArgs<TKey, TValue>(key, removedItem));

    ///// <summary>
    ///// Вызывает событие <see cref="RangeRemoved"/> при удалении диапазона элементов из коллекции
    ///// </summary>
    ///// <param name="key">Начальный индекс, с которого были удалены элементы</param>
    ///// <param name="removedItems">Коллекция удаленных элементов</param>
    //protected virtual void RaiseRangeRemoved(int key, IReadOnlyList<TValue> removedItems) => RangeRemoved?.Invoke(this, new RangeRemovedEventArgs<TValue>(removedItems, key));

    /// <summary>
    /// Вызывает событие <see cref="KeyValueChanged"/> при замене элемента в словаре
    /// </summary>
    /// <param name="key">Ключ замещенного элемента</param>
    /// <param name="oldItem">Удалённый элемент</param>
    /// <param name="newItem">Добавленный элемент</param>
    protected virtual void RaiseKeyValueChanged(TKey key, TValue oldItem, TValue newItem) => KeyValueChanged?.Invoke(this, new KeyValueChangedEventArgs<TKey, TValue>(key, oldItem, newItem));


    /// <summary>
    /// Вызывает событие <see cref="DictionaryCleared"/> при полной очистке словаря
    /// </summary>
    /// <param name="removedItems">Коллекция всех удаленных элементов при очистке</param>
    protected virtual void RaiseDictionaryCleared(IReadOnlyList<IDictionaryItem<TKey, TValue>> removedItems) => DictionaryCleared?.Invoke(this, new DictionaryClearedEventArgs<TKey, TValue>(removedItems));


    /// <summary>
    /// Вызывает событие <see cref="ItemAdded"/> при добавлении нового элемента в словарь
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemAdded(IItemAddedEventArgs<TKey, TValue> e) => ItemAdded?.Invoke(this, e);

    ///// <summary>
    ///// Вызывает событие <see cref="RangeAdded"/> при добавлении диапазона элементов в коллекцию
    ///// </summary>
    ///// <param name="e">Данные события</param>
    //protected virtual void RaiseRangeAdded(IRangeAddedEventArgs<TValue> e) => RangeAdded?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="ItemRemoved"/> при удалении элемента из словаря
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseItemRemoved(IItemRemovedEventArgs<TKey, TValue> e) => ItemRemoved?.Invoke(this, e);

    ///// <summary>
    ///// Вызывает событие <see cref="RangeRemoved"/> при удалении диапазона элементов из коллекции
    ///// </summary>
    ///// <param name="e">Данные события</param>
    //protected virtual void RaiseRangeRemoved(IRangeRemovedEventArgs<TValue> e) => RangeRemoved?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="KeyValueChanged"/> при замене элемента в словаре
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseKeyValueChanged(IKeyValueChangedEventArgs<TKey, TValue> e) => KeyValueChanged?.Invoke(this, e);

    /// <summary>
    /// Вызывает событие <see cref="DictionaryCleared"/> при полной очистке словаря
    /// </summary>
    /// <param name="e">Данные события</param>
    protected virtual void RaiseDictionaryCleared(IDictionaryClearedEventArgs<TKey, TValue> e) => DictionaryCleared?.Invoke(this, e);


    private NotifyEventsBridge? Bridge;
    /// <summary>События текущего экземпляра <see cref="NotifyBase{T}"/> будут подниматься автоматически после каждого события в указанном <see cref="INotify{T}"/>.</summary>
    /// <param name="sourse">Объект-источник событий для поднятия событий текущего экземпляра.</param>
    /// <remarks>Если мост уже установлен с другой коллекцией, тогда будет создан новый, а предыдущий - будет уничтожен.</remarks>
    protected void CreateBridge(INotify<TKey, TValue> sourse)
    {
        Bridge?.Dispose();
        Bridge = new NotifyEventsBridge(this, sourse);
    }

    /// <summary>События текущего экземпляра <see cref="NotifyBase{T}"/> больше не будут подниматься автоматически после каждого события источника <see cref="INotify{T}"/>.</summary>
    /// <remarks>Если не был создан, ничего не произойдет.</remarks>
    protected void DestroyBridge()
    {
        Bridge?.Dispose();
    }

    internal class NotifyEventsBridge : IDisposable
    {
        private readonly INotify<TKey, TValue> sourse;
        private readonly NotifyBase<TKey, TValue> target;

        public NotifyEventsBridge(NotifyBase<TKey, TValue> target, INotify<TKey, TValue> sourse)
        {
            this.sourse = sourse;
            this.target = target;
            sourse.ItemAdded += Items_ItemAdded;
            sourse.ItemRemoved += Items_ItemRemoved;
            //sourse.RangeAdded += Items_RangeAdded;
            //sourse.RangeRemoved += Items_RangeRemoved;
            sourse.KeyValueChanged += Items_KeyValueChanged;
            sourse.DictionaryCleared += Items_DictionaryCleared;
        }


        private void Items_ItemAdded(object sender, IItemAddedEventArgs<TKey, TValue> e)
        {
            target.RaiseItemAdded(e);
        }

        private void Items_ItemRemoved(object sender, IItemRemovedEventArgs<TKey, TValue> e)
        {
            target.RaiseItemRemoved(e);
        }

        //private void Items_RangeAdded(object sender, IRangeAddedEventArgs<TValue> e)
        //{
        //    target.RaiseRangeAdded(e);
        //}

        //private void Items_RangeRemoved(object sender, IRangeRemovedEventArgs<TValue> e)
        //{
        //    target.RaiseRangeRemoved(e);
        //}

        private void Items_KeyValueChanged(object sender, IKeyValueChangedEventArgs<TKey, TValue> e)
        {
            target.RaiseKeyValueChanged(e);
        }

        private void Items_DictionaryCleared(object sender, IDictionaryClearedEventArgs<TKey, TValue> e)
        {
            target.RaiseDictionaryCleared(e);
        }

        public void Dispose()
        {
            sourse.ItemAdded -= Items_ItemAdded;
            sourse.ItemRemoved -= Items_ItemRemoved;
            //sourse.RangeAdded += Items_RangeAdded;
            //sourse.RangeRemoved += Items_RangeRemoved;
            sourse.KeyValueChanged -= Items_KeyValueChanged;
            sourse.DictionaryCleared -= Items_DictionaryCleared;
        }
    }
}