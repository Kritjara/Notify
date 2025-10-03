namespace Kritjara.Collections.Notify;

/// <summary>Класс расширений для объектов сборки Notify</summary>
public static class Extensions
{
    /// <summary>Возвращает коллекцию только для чтения с сохранением уведомлений.</summary>
    /// <returns></returns>
    public static IReadOnlyNotifyCollection<T> AsReadOnly<T>(INotifyCollection<T> source) => new ReadOnlyNotifyCollection<T>(source);

    /// <summary>Возвращает коллекцию только для чтения с сохранением уведомлений.</summary>
    /// <returns></returns>
    public static IReadOnlyNotifyCollection<T> TryAsReadOnly<T>(INotify<T> source) => new ReadOnlyNotifyCollectionShell<T>(source);
}