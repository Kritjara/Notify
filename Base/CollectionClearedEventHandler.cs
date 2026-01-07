#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.CollectionCleared"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void CollectionClearedEventHandler<in T>(object sender, ICollectionClearedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.CollectionCleared"/>.</summary>
public interface ICollectionClearedEventArgs<out T>
{  
    /// <summary>Удаленные из коллекции элементы.</summary>
    public IReadOnlyList<T> RemovedItems { get; } 
}

/// <inheritdoc cref="ICollectionClearedEventArgs{T}"/>
/// <param name="removedItems">Удаленные из коллекции элементы.</param>
public class CollectionClearedEventArgs<T>(IReadOnlyList<T> removedItems) : EventArgs, ICollectionClearedEventArgs<T>
{
    /// <inheritdoc/>
    public IReadOnlyList<T> RemovedItems { get; } = removedItems;
}


/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{TKey, TValue}.DictionaryCleared"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void DictionaryClearedEventHandler<TKey, in TValue>(object sender, IDictionaryClearedEventArgs<TKey, TValue> e)
    where TKey : notnull;

/// <summary>Представляет данные события <see cref="INotify{TKey, TValue}.DictionaryCleared"/>.</summary>
public interface IDictionaryClearedEventArgs<TKey, out TValue>
    where TKey : notnull
{
    /// <summary>Удаленные из коллекции элементы.</summary>
    public IReadOnlyList<IDictionaryItem<TKey, TValue>> RemovedItems { get; }
}



/// <inheritdoc cref="IDictionaryClearedEventArgs{TKey, TValue}"/>
/// <param name="removedItems">Удаленные из коллекции элементы.</param>
public class DictionaryClearedEventArgs<TKey, TValue>(IReadOnlyList<IDictionaryItem<TKey, TValue>> removedItems) 
    : EventArgs, IDictionaryClearedEventArgs<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public IReadOnlyList<IDictionaryItem<TKey, TValue>> RemovedItems { get; } = removedItems;
}