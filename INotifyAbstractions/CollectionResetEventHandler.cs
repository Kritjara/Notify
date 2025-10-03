namespace Kritjara.Collections.Notify;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.Reset"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void CollectionResetEventHandler<in T>(object sender, ICollectionResetEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.Reset"/>.</summary>
public interface ICollectionResetEventArgs<out T>
{  
    /// <summary>Удаленные из коллекции элементы.</summary>
    public IReadOnlyList<T> RemovedItems { get; } 
}

/// <inheritdoc cref="ICollectionResetEventArgs{T}"/>
/// <param name="removedItems">Удаленные из коллекции элементы.</param>
public class CollectionResetEventArgs<T>(IReadOnlyList<T> removedItems) : EventArgs, ICollectionResetEventArgs<T>
{ 
    /// <summary>Удаленные из коллекции элементы.</summary>
    public IReadOnlyList<T> RemovedItems { get; } = removedItems;
}
