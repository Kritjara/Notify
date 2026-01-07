#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.ItemAdded"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemAddedEventHandler<in T>(object sender, IItemAddedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.ItemAdded"/>.</summary>
public interface IItemAddedEventArgs<out T>
{
    /// <summary>Добавленный в коллекцию элемент.</summary>
    T NewItem { get; } 
    /// <summary>Индекс добавленного элемента.</summary>
    int Index { get; } 
}

/// <inheritdoc cref="IItemAddedEventArgs{T}"/>
/// <param name="addedItem">Добавленный в коллекцию элемент.</param>
/// <param name="index">Индекс добавленного элемента.</param>
public class ItemAddedEventArgs<T>(T addedItem, int index) : EventArgs, IItemAddedEventArgs<T>
{
    /// <inheritdoc/>
    public T NewItem { get; } = addedItem;

    /// <inheritdoc/>
    public int Index { get; } = index;
}


/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{TKey, TValue}.ItemAdded"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemAddedEventHandler<TKey, in TValue>(object sender, IItemAddedEventArgs<TKey, TValue> e)
    where TKey : notnull;

/// <summary>Представляет данные события <see cref="INotify{TKey, TValue}.ItemAdded"/>.</summary>
public interface IItemAddedEventArgs<TKey, out TValue>
    where TKey : notnull
{
    /// <summary>Ключ добавленного элемента.</summary>
    TKey Key { get; }

    /// <summary>Добавленный в словарь элемент.</summary>
    TValue NewItem { get; }
}

/// <inheritdoc cref="IItemAddedEventArgs{TKey, TValue}"/>
/// <param name="key">Ключ добавленного элемента.</param>
/// <param name="addedItem">Добавленный в словарь элемент.</param>
public class ItemAddedEventArgs<TKey, TValue>(TKey key, TValue addedItem) 
    : EventArgs, IItemAddedEventArgs<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public TKey Key { get; } = key;

    /// <inheritdoc/>
    public TValue NewItem { get; } = addedItem;
}
