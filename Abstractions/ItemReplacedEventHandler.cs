namespace Kritjara.Collections.Notify;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{T}.ItemReplaced"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void ItemReplacedEventHandler<in T>(object sender, IItemReplacedEventArgs<T> e);

/// <summary>Представляет данные события <see cref="INotify{T}.ItemReplaced"/>.</summary>
public interface IItemReplacedEventArgs<out T>
{
    /// <summary>Удалённый из коллекции элемент.</summary>
    T OldItem { get; }
    /// <summary>Добавленный в коллекцию элемент.</summary>
    T NewItem { get; }
    /// <summary>Индекс замененного/добавленного элемента.</summary>
    int Index { get; }
}

/// <inheritdoc cref="IItemReplacedEventArgs{T}"/>
/// <param name="oldItem">Удалённый из коллекции элемент.</param>
/// <param name="newItem">Добавленный в коллекцию элемент.</param>
/// <param name="index">Индекс замененного/добавленного элемента.</param>
public class ItemReplacedEventArgs<T>(T oldItem, T newItem, int index) : EventArgs, IItemReplacedEventArgs<T>
{
    /// <inheritdoc/>
    public T OldItem { get; } = oldItem;

    /// <inheritdoc/>
    public T NewItem { get; } = newItem;

    /// <inheritdoc/>
    public int Index { get; } = index;
}
