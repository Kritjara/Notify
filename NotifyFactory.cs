namespace Kritjara.Collections.Notify;

public static class NotifyFactory
{
    public static NotifyCollection<T> CreateNotifyCollection<T>(ReadOnlySpan<T> items) 
    {
        return new NotifyCollection<T>(items);
    }
}