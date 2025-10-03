namespace Kritjara.Collections.Notify;

/// <summary>Представляет события, оповещающие об изменении состава элементов коллекции.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
public interface INotify<out T>
{
    /// <summary>Происходит при добавлении <see langword="одного"/> элемента в коллекицию.</summary>
    event ItemAddedEventHandler<T> ItemAdded;

    /// <summary>Происходит при добавлении <see langword="нескольких"/> элементов в коллекицию.</summary>
    event RangeAddedEventHandler<T> RangeAdded;

    /// <summary>Происходит при удалении <see langword="одного"/> элемента из коллекиции.</summary>
    event ItemRemovedEventHandler<T> ItemRemoved;

    /// <summary>Происходит при удалении <see langword="нескольких"/> элементов из коллекиции.</summary>
    event RangeRemovedEventHandler<T> RangeRemoved;

    /// <summary>Происходит при замене элемента в коллекиции.</summary>
    event ItemReplacedEventHandler<T> ItemReplaced;

    /// <summary>Происходит перемещенни элемента внутри коллекиции.</summary>
    event ItemMovedEventHandler<T> ItemMoved;

    /// <summary>Происходит при очищении коллекции.</summary>
    event CollectionResetEventHandler<T> Reset;
}