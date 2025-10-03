namespace Kritjara.Collections.Notify;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.ItemRemoved"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemRemovedEventHandler<in T>(object sender, IItemRemovedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.ItemRemoved"/>.</summary>
/// <param name="removedItem">Удаленный из коллекции элемент.</param>
/// <param name="index">Индекс удалённого элемента.</param>
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
    public T RemovedItem { get; } = removedItem;
    public int Index { get; } = index;
}
