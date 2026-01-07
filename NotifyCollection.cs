using System.Collections;
using System.ComponentModel;

namespace Kritjara.Collections;

/// <summary>Представляет <see cref="IList{T}"/>, оповещающий о добавлении/удалении/перемещении элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
[System.Runtime.CompilerServices.CollectionBuilder(typeof(NotifyFactory), nameof(NotifyFactory.CreateNotifyCollection))]
public class NotifyCollection<T> : NotifyBase<T>, INotifyCollection<T>, IList<T>, IReadOnlyList<T>, IList 
{

    /// <summary>Список элементов.</summary>
    protected List<T> Items;

    ///<summary>Инициализирует новый экземпляр класса <see cref="NotifyCollection{T}"/>.</summary>
    public NotifyCollection()
    {
        Items = [];
    }

    ///<summary>Инициализирует новый экземпляр класса <see cref="NotifyCollection{T}"/>.</summary>
    public NotifyCollection(int capacity)
    {
        Items = new List<T>(capacity);
    }

    ///<summary>Инициализирует новый экземпляр класса <see cref="NotifyCollection{T}"/>.</summary>
    public NotifyCollection(IEnumerable<T> items)
    {
        Items = [.. items];
    }

    ///<summary>Инициализирует новый экземпляр класса <see cref="NotifyCollection{T}"/>.</summary>
    public NotifyCollection(ReadOnlySpan<T> items)
    {
        Items = [.. items];
    }


    /// <summary>Получает или задает элемент элемент по указанному индексу.</summary>
    /// <param name="index">Индекс элемента.</param>
    /// <returns></returns>
    public virtual T this[int index]
    {
        get => Items[index];
        set
        {
            OnReplace(index, value);
        }
    }

    /// <inheritdoc/>
    public virtual void Add(T item)
    {
        int index = Items.Count;
        OnAdd(index, item);
    }


    /// <inheritdoc/>
    public virtual void AddRange(IEnumerable<T> items)
    {
        int index = Items.Count;
        OnAddRange(index, [.. items]);
    }

    /// <inheritdoc/>
    public virtual void Insert(int index, T item)
    {
        OnAdd(index, item);
    }


    /// <inheritdoc/>
    public void InsertRange(int index, IEnumerable<T> items)
    {
        OnAddRange(index, [.. items]);
    }

    /// <inheritdoc/>
    public void Move(int oldIndex, int newIndex)
    {
        OnMoveItem(oldIndex, newIndex);
    }

    /// <inheritdoc/>
    public virtual bool Remove(T item)
    {
        return OnRemove(item);
    }

    /// <inheritdoc/>
    public virtual void RemoveRange(int index, int count)
    {
        OnRemoveRange(index, count);
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        OnRemoveAt(index);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        OnClearItems();
    }

    /// <inheritdoc/>
    public void Reset(IEnumerable<T> enumerable) 
    {
        OnClearItems();
        OnAddRange(0, [..enumerable]);
    }

    /// <inheritdoc/>
    public int IndexOf(T item) => Items.IndexOf(item);

    /// <inheritdoc/>
    public bool Contains(T item) => Items.Contains(item);

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        Items.CopyTo(array, arrayIndex);
    }

    /// <inheritdoc cref="List{T}.CopyTo(int, T[], int, int)"/>
    public void CopyTo(int index, T[] array, int arrayIndex, int count)
    {
        Items.CopyTo(index, array, arrayIndex, count);
    }

    /// <inheritdoc/>
    public T? Find(Predicate<T> match) => Items.Find(match);
   
    /// <inheritdoc cref="List{T}.FindIndex(Predicate{T})"/>
    public int FindIndex(Predicate<T> match) => Items.FindIndex(match);

    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    public int FindIndex(int startIndex, Predicate<T> match) => Items.FindIndex(startIndex, match);

    /// <inheritdoc cref="List{T}.FindIndex(int, int, Predicate{T})"/>
    public int FindIndex(int startIndex, int count, Predicate<T> match) => Items.FindIndex(startIndex, count, match);

    /// <inheritdoc cref="List{T}.ConvertAll{TOutput}(Converter{T, TOutput})"/>
    public NotifyCollection<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter) where TOutput : notnull
    {
        NotifyCollection<TOutput> newColl = new NotifyCollection<TOutput>()
        {
            Items = Items.ConvertAll(converter)
        };
        return newColl;
    }

    /// <inheritdoc/>
    public int Count => Items.Count;

    bool ICollection<T>.IsReadOnly => false;

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();



    /// <summary>Заменяет элемент в коллекции и вызывает событие <see cref="INotify{T}.ItemReplaced"/>.</summary>
    /// <param name="index">Индекс элемента, который будет заменен.</param>
    /// <param name="item">Новый элемент.</param>
    protected virtual void OnReplace(int index, T item)
    {
        T oldItem = Items[index];
        Items[index] = item;
        RaiseItemReplaced(index, oldItem, item);
    }

    /// <summary>Добавляет элемент в коллекцию в указанную позицию и вызывает событие <see cref="INotify{T}.ItemAdded"/>.</summary>
    /// <param name="index">Индекс, по которому будет добавлен элемент.</param>
    /// <param name="item">Добавляемый элемент.</param>
    protected virtual void OnAdd(int index, T item)
    {
        Items.Insert(index, item);
        RaiseItemAdded(index, item);
    }

    /// <summary>Добавялет диапазон элементов в указанную позицию и вызывает событие <see cref="INotify{T}.RangeAdded"/>.</summary>
    /// <param name="index">Индекс, по которому будет добавлен диапазон.</param>
    /// <param name="items">Элементы для добавления в коллекцию.</param>
    protected virtual void OnAddRange(int index, IReadOnlyList<T> items)
    {
        Items.InsertRange(index, items);
        RaiseRangeAdded(index, items);
    }

    /// <summary>Удаляет элемент из коллекции по указанному индексу и вызывает событие <see cref="INotify{T}.ItemRemoved"/>.</summary>
    /// <param name="index">Индекс элемента, который требуется удалить</param>
    protected virtual void OnRemoveAt(int index)
    {
        T item = Items[index];
        Items.RemoveAt(index);
        RaiseItemRemoved(index, item);
    }

    /// <summary>Удаляет указанный элемент из коллекции и вызывает событие <see cref="INotify{T}.ItemRemoved"/>, если элемент присутствовал в коллекици.</summary>
    /// <param name="item">Элемент для удаления.</param>
    /// <returns></returns>
    protected virtual bool OnRemove(T item)
    {
        int index = Items.IndexOf(item);
        if (index > -1)
        {
            Items.RemoveAt(index);
            RaiseItemRemoved(index, item);
            return true;
        }
        return false;
    }

    /// <summary>Удаляет из коллекции диапазон элементов начиная и вызывает событие <see cref="INotify{T}.RangeRemoved"/>.</summary>
    /// <param name="index">Отсчитываемый от нуля индекс начала диапазона элементов, которые требуется удалить.</param>
    /// <param name="countToRemove">Количество удаляемых элементов.</param>
    /// <returns></returns>
    protected virtual void OnRemoveRange(int index, int countToRemove)
    {
        T[] removedItems = new T[countToRemove];
        Items.CopyTo(index, removedItems, 0, countToRemove);
        Items.RemoveRange(index, countToRemove);
        RaiseRangeRemoved(index, [.. removedItems]);
    }

    /// <summary>Перемещает элемент c указанным индексом в новое место в коллекции и вызывает событие <see cref="INotify{T}.ItemMoved"/>.</summary>
    /// <param name="oldIndex">Индекс перемещаемого элемента.</param>
    /// <param name="newIndex">Новое расположение элемента.</param>
    protected virtual void OnMoveItem(int oldIndex, int newIndex)
    {
        if (oldIndex == newIndex) return;

        T movedItem = Items[oldIndex];

        Items.RemoveAt(oldIndex);
        Items.Insert(newIndex, movedItem);

        RaiseItemMoved(oldIndex, newIndex, movedItem);
    }

    /// <summary>Удаляет все элементы из коллекции и вызывает событие <see cref="INotify{T}.CollectionCleared"/>.</summary>
    protected virtual void OnClearItems()
    {
        IReadOnlyList<T> removedItems = [.. Items];
        Items.Clear();
        RaiseCollectionCleared(removedItems);
    }


    #region [ IList ]

    int IList.Add(object? value)
    {
        ArgumentNullException.ThrowIfNull(value);

        try
        {
            Add((T)value);
        }
        catch (InvalidCastException ex)
        {
            ImplementsListHelper<T>.ThrowWrongValueTypeArgumentException(value, ex);
        }

        return Count - 1;
    }

    bool IList.Contains(object? item)
    {
        if (ImplementsListHelper<T>.IsCompatibleObject(item))
        {
            return Items.Contains((T)item);
        }
        return false;
    }

    int IList.IndexOf(object? item)
    {
        if (ImplementsListHelper<T>.IsCompatibleObject(item))
        {
            return Items.IndexOf((T)item);
        }
        return -1;
    }

    void IList.Insert(int index, object? value)
    {
        ArgumentNullException.ThrowIfNull(value);

        try
        {
            OnAdd(index, (T)value);
        }
        catch (InvalidCastException ex)
        {
            ImplementsListHelper<T>.ThrowWrongValueTypeArgumentException(value, ex);
        }
    }

    void IList.Remove(object? value)
    {
        if (ImplementsListHelper<T>.IsCompatibleObject(value))
        {
            OnRemove((T)value!);
        }
    }

    bool IList.IsFixedSize => ((IList)Items).IsFixedSize;
    bool IList.IsReadOnly => ((IList)Items).IsReadOnly;

    object? IList.this[int index]
    {
        get => ((IList)Items)[index];
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            try
            {
                this[index] = (T)value!;
            }
            catch (InvalidCastException ex)
            {
                ImplementsListHelper<T>.ThrowWrongValueTypeArgumentException(value, ex);
            }
        }
    }

    void ICollection.CopyTo(Array array, int index) => ((ICollection)Items).CopyTo(array, index);

 

    bool ICollection.IsSynchronized => ((ICollection)Items).IsSynchronized;

    object ICollection.SyncRoot => ((ICollection)Items).SyncRoot;

    #endregion

}

internal static class ImplementsListHelper<T>
{
    public static void ThrowWrongValueTypeArgumentException(object value, Exception innerException)
    {
        throw new ArgumentException($"The value '{value.GetType().FullName}' is not of type '{typeof(T).FullName}' and cannot be used in this generic collection.", nameof(value), innerException);
    }

    public static bool IsCompatibleObject([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object? value)
    {
        // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
        // Note that default(T) is not equal to null for value types except when T is Nullable<U>.
        return value is T || value == null && default(T) == null;
    }
}