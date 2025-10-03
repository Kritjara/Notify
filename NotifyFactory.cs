namespace Kritjara.Collections.Notify;

/// <summary>
/// Статический класс для коллекицй, пемеченных атрибутом <see cref="System.Runtime.CompilerServices.CollectionBuilderAttribute"/>
/// </summary>
public static class NotifyFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static NotifyCollection<T> CreateNotifyCollection<T>(ReadOnlySpan<T> items) 
    {
        return new NotifyCollection<T>(items);
    }
}