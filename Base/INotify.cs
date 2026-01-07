#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Предоставляет события, оповещающие об изменении состава элементов коллекции.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
public interface INotify<out T>
{
    /// <summary>Происходит при добавлении <see langword="одного"/> элемента в коллекцию.</summary>
    event ItemAddedEventHandler<T> ItemAdded;

    /// <summary>Происходит при добавлении <see langword="нескольких"/> элементов в коллекцию.</summary>
    event RangeAddedEventHandler<T> RangeAdded;

    /// <summary>Происходит при удалении <see langword="одного"/> элемента из коллекции.</summary>
    event ItemRemovedEventHandler<T> ItemRemoved;

    /// <summary>Происходит при удалении <see langword="нескольких"/> элементов из коллекции.</summary>
    event RangeRemovedEventHandler<T> RangeRemoved;

    /// <summary>Происходит при замене элемента в коллекции.</summary>
    event ItemReplacedEventHandler<T> ItemReplaced;

    /// <summary>Происходит перемещенни элемента внутри коллекции.</summary>
    event ItemMovedEventHandler<T> ItemMoved;

    /// <summary>Происходит при очищении коллекции.</summary>
    event CollectionClearedEventHandler<T> CollectionCleared;
}


/// <summary>Предоставляет события, оповещающие об изменении состава элементов словаря.</summary>
/// <typeparam name="TKey">Тип ключа.</typeparam>
/// <typeparam name="TValue">Тип объектов, содержащихся в словаре.</typeparam>
public interface INotify<TKey, out TValue>
    where TKey : notnull
{
    /// <summary>Происходит при добавлении <see langword="одного"/> элемента в словарь.</summary>
    event ItemAddedEventHandler<TKey, TValue> ItemAdded;

    // <summary>Происходит при добавлении <see langword="нескольких"/> элементов в словарь.</summary>
    //event RangeAddedEventHandler<TKey, TValue> RangeAdded;

    /// <summary>Происходит при удалении <see langword="одного"/> элемента из словаря.</summary>
    event ItemRemovedEventHandler<TKey, TValue> ItemRemoved;

    // <summary>Происходит при удалении <see langword="нескольких"/> элементов из словаря.</summary>
    //event RangeRemovedEventHandler<TKey, TValue> RangeRemoved;

    /// <summary>Происходит при замене элемента в словаре по ключу.</summary>
    event KeyValueChangedEventHandler<TKey, TValue> KeyValueChanged;

    /// <summary>Происходит при очищении словаря.</summary>
    event DictionaryClearedEventHandler<TKey, TValue> DictionaryCleared;
}