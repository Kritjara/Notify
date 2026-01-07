namespace Kritjara.Collections;

/// <summary>Класс расширений для объектов сборки Notify</summary>
public static class Extensions
{
    /// <summary>Возвращает коллекцию только для чтения с сохранением уведомлений.</summary>
    /// <returns>Объект <see cref="IReadOnlyNotifyCollection{T}"/>. Может вернуть ссылку на <paramref name="source"/>, если та уже является <see cref="IReadOnlyNotifyCollection{T}"/>.</returns>
    public static IReadOnlyNotifyCollection<T> AsReadOnlyNotifyCollection<T>(this INotifyCollection<T> source)
    {
        if (source is IReadOnlyNotifyCollection<T> r_o_coll)
        {
            return r_o_coll;
        }
        return new ReadOnlyNotifyCollection<T>(source);
    }

    /// <summary>Возвращает коллекцию только для чтения с сохранением уведомлений.</summary>
    /// <remarks>
    /// Создание будет успешным в случае, если <paramref name="source"/> реализует:
    /// <list type="bullet">
    /// <item><see cref="IList{T}"/> или <see cref="IReadOnlyList{T}"/> (в кастомных производных коллекциях рекомендуется реализовать)</item>
    /// <item><see cref="ICollection{T}"/> или <see cref="IReadOnlyCollection{T}"/>/> 
    /// (может быть медленным при извлечении элементов по индексу, если не реализован ни один из выше указанных интерфейсов)</item>
    /// </list>
    /// </remarks>
    /// <returns>Объект <see cref="IReadOnlyNotifyCollection{T}"/>. Может вернуть ссылку на <paramref name="source"/>, если та уже является <see cref="IReadOnlyNotifyCollection{T}"/>.</returns>
    public static IReadOnlyNotifyCollection<T> TryCreateAsReadOnly<T>(this INotify<T> source)
    {
        if (source is IReadOnlyNotifyCollection<T> r_o_coll)
        {
            return r_o_coll;
        }
        if (source is INotifyCollection<T> coll)
        {
            return coll.AsReadOnlyNotifyCollection();
        }
        return new NotifyShell<T>(source);
    }
}
