namespace Kritjara.Collections.Notify;

/// <summary>Представляет коллекцию только для чтения, оповещающую о добавлении/удалении ее элементов.</summary>
/// <typeparam name="T">Тип объектов, содержащихся в коллекции.</typeparam>
public interface IReadOnlyNotifyCollection<out T> : INotify<T>, IReadOnlyList<T> 
{
        
}