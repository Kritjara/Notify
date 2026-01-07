#pragma warning disable IDE0130 // Пространство имен (namespace) не соответствует структуре папок.

using System.Runtime.CompilerServices;

namespace Kritjara.Collections;

/// <summary>Представляет коллекцию, оповещающую о добавлении/удалении ее элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
[CollectionBuilder(typeof(NotifyFactory), nameof(NotifyFactory.CreateNotifyCollection))]
public interface INotifyCollection<T> : INotify<T>, IList<T>
{       
    /// <summary>Добавляет диапазон элементов в коллекцию.</summary>
    /// <param name="items">Источник, содержащий элементы для добавления.</param>
    void AddRange(IEnumerable<T> items);

    /// <summary>Добавляет диапазон элементов в указанную позицию коллекции.</summary>
    /// <param name="index">Индекс, которому будет размещен первый элемент.</param>
    /// <param name="items">Источник, содержащий элементы для добавления.</param>
    void InsertRange(int index, IEnumerable<T> items);

    /// <summary>Перемещает элемент по указанному индексу в новое место в коллекции.</summary>
    /// <param name="oldIndex">Индекс перемещаемого элемента.</param>
    /// <param name="newIndex">Индекс, по которому следует разместить перемещаемый элемент.</param>
    void Move(int oldIndex, int newIndex);
          
    /// <inheritdoc cref="List{T}.RemoveRange(int, int)"/>
    void RemoveRange(int index, int length);

    /// <summary>Заменяет все текущие элементы коллекции на указанные.</summary>
    /// <param name="enumerable">Диапазон новых элементов коллекции.</param>
    void Reset(IEnumerable<T> enumerable);
}
