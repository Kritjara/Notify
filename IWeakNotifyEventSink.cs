namespace Kritjara.Collections;

/// <summary>
/// Определяет методы для обработки событий объекта типа <see cref="INotify{T}"/>. 
/// Предназначен для использования как приемник (sink) событий в менеджере слабых событий <see cref="NotifyWeakEventManager{T}"/>.
/// </summary>
public interface IWeakNotifyEventSink<T>
{
    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.ItemAdded"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void ItemAdded(INotify<T> sender, IItemAddedEventArgs<T> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.ItemRemoved"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void ItemRemoved(INotify<T> sender, IItemRemovedEventArgs<T> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.RangeAdded"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void RangeAdded(INotify<T> sender, IRangeAddedEventArgs<T> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.RangeRemoved"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void RangeRemoved(INotify<T> sender, IRangeRemovedEventArgs<T> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.ItemReplaced"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void ItemReplaced(INotify<T> sender, IItemReplacedEventArgs<T> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.ItemMoved"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void ItemMoved(INotify<T> sender, IItemMovedEventArgs<T> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{T}.CollectionCleared"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void CollectionCleared(INotify<T> sender, ICollectionClearedEventArgs<T> e);
}



/// <summary>
/// Определяет методы для обработки событий объекта типа <see cref="INotify{TKey, TValue}"/>. 
/// Предназначен для использования как приемник (sink) событий в менеджере слабых событий <see cref="NotifyWeakEventManager{TKey, TValue}"/>.
/// </summary>
public interface IWeakNotifyEventSink<TKey, TValue> where TKey : notnull
{
    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{TKey, TValue}.ItemAdded"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void ItemAdded(INotify<TKey, TValue> sender, IItemAddedEventArgs<TKey, TValue> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{TKey, TValue}.ItemRemoved"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void ItemRemoved(INotify<TKey, TValue> sender, IItemRemovedEventArgs<TKey, TValue> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{TKey, TValue}.KeyValueChanged"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void KeyValueChanged(INotify<TKey, TValue> sender, IKeyValueChangedEventArgs<TKey, TValue> e);

    /// <summary>Уведомляет получаля о произошедшем событии <see cref="INotify{TKey, TValue}.DictionaryCleared"/> в источнике</summary>
    /// <param name="sender">Объект - источник события</param>
    /// <param name="e">Данные события.</param>
    void DictionaryCleared(INotify<TKey, TValue> sender, IDictionaryClearedEventArgs<TKey, TValue> e);
}
