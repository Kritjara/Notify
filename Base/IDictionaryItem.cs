#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

namespace Kritjara.Collections;

/// <summary>Представляет затронутый элемент словаря в событиях интрефейса <see cref="INotify{TKey, TValue}"/>.</summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public interface IDictionaryItem<TKey, out TValue>
    where TKey : notnull
{
    /// <summary>Ключ элемента.</summary>
    TKey Key { get; }

    /// <summary>Элемент, содержащийся в словаре.</summary>
    TValue Value { get; }
}


internal record class DictionaryItem<TKey, TValue>(TKey Key, TValue Value) 
    : IDictionaryItem<TKey, TValue>
        where TKey : notnull;
