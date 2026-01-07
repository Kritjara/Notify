#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.ItemRemoved"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemRemovedEventHandler<in T>(object sender, IItemRemovedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.ItemRemoved"/>.</summary>
public interface IItemRemovedEventArgs<out T>
{
    /// <summary>Удаленный из коллекции элемент.</summary>
    T RemovedItem { get; } 
    /// <summary>Индекс удалённого элемента.</summary>
    int Index { get; } 
}

/// <inheritdoc cref="IItemRemovedEventArgs{T}"/>
/// <param name="removedItem">Удаленный из коллекции элемент.</param>
/// <param name="index">Индекс удалённого элемента.</param>
public class ItemRemovedEventArgs<T>(T removedItem, int index) : EventArgs, IItemRemovedEventArgs<T>
{
    /// <inheritdoc/>
    public T RemovedItem { get; } = removedItem;

    /// <inheritdoc/>
    public int Index { get; } = index;
}


/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{TKey, TValue}.ItemRemoved"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemRemovedEventHandler<TKey, in TValue>(object sender, IItemRemovedEventArgs<TKey, TValue> e)
    where TKey : notnull;

/// <summary>Представляет данные события <see cref="INotify{TKey, TValue}.ItemRemoved"/>.</summary>
public interface IItemRemovedEventArgs<TKey, out TValue>
    where TKey : notnull
{
    /// <summary>Ключ удалённого элемента.</summary>
    TKey Key { get; }

    /// <summary>Удаленный из словаря элемент.</summary>
    TValue RemovedItem { get; }
}

/// <inheritdoc cref="IItemRemovedEventArgs{TKey, TValue}"/>
/// <param name="key">Ключ удалённого элемента.</param>
/// <param name="removedItem">Удаленный из словаря элемент.</param>
public class ItemRemovedEventArgs<TKey, TValue>(TKey key, TValue removedItem)
    : EventArgs, IItemRemovedEventArgs<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public TKey Key{ get; } = key;

    /// <inheritdoc/>
    public TValue RemovedItem { get; } = removedItem;
}
