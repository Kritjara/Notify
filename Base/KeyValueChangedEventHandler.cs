#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет метод, обрабатывающий событие <see cref="INotify{TKey, TValue}.KeyValueChanged"/>.</summary>
/// <param name="sender">Источник события.</param>
/// <param name="e">Данные события</param>
public delegate void KeyValueChangedEventHandler<TKey, in TValue>(object sender, IKeyValueChangedEventArgs<TKey, TValue> e)
    where TKey : notnull;

/// <summary>Представляет данные события <see cref="INotify{TKey, TValue}.KeyValueChanged"/>.</summary>
public interface IKeyValueChangedEventArgs<TKey, out TValue>
    where TKey : notnull
{    
    /// <summary>Ключ заменённого/добавленного элемента.</summary>
    TKey Key { get; }
    /// <summary>Удалённый из словаря элемент.</summary>
    TValue OldItem { get; }
    /// <summary>Добавленный в словарь элемент.</summary>
    TValue NewItem { get; }
}

/// <inheritdoc cref="IKeyValueChangedEventArgs{TKey, TValue}"/>
/// <param name="key">Ключ заменённого/добавленного элемента.</param>
/// <param name="oldItem">Удалённый из коллекции элемент.</param>
/// <param name="newItem">Добавленный в коллекцию элемент.</param>
public class KeyValueChangedEventArgs<TKey, TValue>(TKey key, TValue oldItem, TValue newItem)
    : EventArgs, IKeyValueChangedEventArgs<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public TKey Key { get; } = key;

    /// <inheritdoc/>
    public TValue OldItem { get; } = oldItem;

    /// <inheritdoc/>
    public TValue NewItem { get; } = newItem;
}
