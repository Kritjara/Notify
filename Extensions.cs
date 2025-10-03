namespace Kritjara.Collections.Notify;

public static class Extensions
{
    /// <summary>Возвращает коллекцию только для чтения с сохранением уведомлений.</summary>
    /// <returns></returns>
    public static IReadOnlyNotifyCollection<T> AsReadOnly<T>(INotifyCollection<T> source) => new ReadOnlyNotifyCollection<T>(source);
}