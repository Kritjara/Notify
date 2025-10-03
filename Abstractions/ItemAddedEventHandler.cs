namespace Kritjara.Collections.Notify;

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
/// <param name="newItem">Добавленный в коллекцию элемент.</param>
/// <param name="index">Индекс добавленного элемента.</param>
public class ItemAddedEventArgs<T>(T newItem, int index) : EventArgs, IItemAddedEventArgs<T>
{
    /// <inheritdoc/>
    public T NewItem { get; } = newItem;

    /// <inheritdoc/>
    public int Index { get; } = index;
}
