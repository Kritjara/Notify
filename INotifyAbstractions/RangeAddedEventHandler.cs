namespace Kritjara.Collections.Notify;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.RangeAdded"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void RangeAddedEventHandler<in T>(object sender, IRangeAddedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.RangeAdded"/>.</summary>
public interface IRangeAddedEventArgs<out T>
{
    /// <summary>Добавленный в коллекцию диапазон элементов.</summary>
    IReadOnlyList<T> AddedItems { get; }
    /// <summary>Индекс диапазона элементов.</summary>
    int Index { get; }
}

/// <inheritdoc cref="IRangeAddedEventArgs{T}"/>
/// <param name="addedItems">Добавляемый в коллекцию диапазон элементов.</param>
/// <param name="index">Индекс диапазона элементов.</param>
public class RangeAddedEventArgs<T>(IReadOnlyList<T> addedItems, int index) : EventArgs, IRangeAddedEventArgs<T>
{
    public IReadOnlyList<T> AddedItems { get; } = addedItems;
    public int Index { get; } = index;
}
