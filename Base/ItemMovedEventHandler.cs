#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.ItemMoved"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemMovedEventHandler<in T>(object sender, IItemMovedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.ItemMoved"/>.</summary>
public interface IItemMovedEventArgs<out T>
{
    /// <summary>Индекс, по которому элемент располагался в коллекции ранее.</summary>
    public int OldIndex { get; } 
    /// <summary>Индекс, по которому элемент размещен в коллекции сейчас.</summary>
    public int NewIndex { get; } 
    /// <summary>Перемещенный элемент.</summary>
    public T MovedItem { get; } 
}

/// <inheritdoc cref="IItemMovedEventArgs{T}"/>
/// <param name="oldIndex">Индекс, по которому элемент располагался в коллекции ранее.</param>
/// <param name="newIndex">Индекс, по которому элемент размещен в коллекции сейчас.</param>
/// <param name="movedItem">Перемещенный элемент.</param>
public class ItemMovedEventArgs<T>(int oldIndex, int newIndex, T movedItem) : EventArgs, IItemMovedEventArgs<T>
{
    /// <inheritdoc/>
    public int OldIndex { get; } = oldIndex;
   
    /// <inheritdoc/>
    public int NewIndex { get; } = newIndex;
    
    /// <inheritdoc/>
    public T MovedItem { get; } = movedItem;
}