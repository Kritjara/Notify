namespace Kritjara.Collections.Notify;

public static class NotifyFactory
{
    public static NotifyCollection<T> CreateNotifyCollection<T>(ReadOnlySpan<T> items) where T : notnull
    {
        return new NotifyCollection<T>(items);
    }
}