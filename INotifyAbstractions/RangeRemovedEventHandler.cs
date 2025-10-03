namespace Kritjara.Collections.Notify;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.RangeRemoved"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void RangeRemovedEventHandler<in T>(object sender, IRangeRemovedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.RangeRemoved"/>.</summary>
public interface IRangeRemovedEventArgs<out T>
{
    /// <summary>Диапазон удаленных из коллекции элементов.</summary>
    public IReadOnlyList<T> RemovedItems { get; }
    /// <summary>Индекс первого удалённого элемента.</summary>
    public int Index { get; }
}

/// <inheritdoc cref="IRangeRemovedEventArgs{T}"/>
/// <param name="removedItems">Диапазон удаленных из коллекции элементов.</param>
/// <param name="index">Индекс первого удалённого элемента.</param>
public class RangeRemovedEventArgs<T>(IReadOnlyList<T> removedItems, int index) : EventArgs, IRangeRemovedEventArgs<T>
{
    /// <summary>Диапазон удаленных из коллекции элементов.</summary>
    public IReadOnlyList<T> RemovedItems { get; } = removedItems;
    /// <summary>Индекс первого удалённого элемента.</summary>
    public int Index { get; } = index;
}
