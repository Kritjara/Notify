namespace Kritjara.Collections;

/// <summary>
/// Предоставляет механизм слабой подписки на события <see cref="INotify{T}"/>
/// </summary>
public static class NotifyWeakEventManager<T>
{
    // Таблица: источник -> список слабых ссылок на обработчики
    private static readonly System.Runtime.CompilerServices.ConditionalWeakTable<INotify<T>, List<WeakReference<IWeakNotifyEventSink<T>>>> _handlers = [];

    /// <summary>
    /// Добавляет слабого подписчика на события <see cref="INotify{T}"/> источника.
    /// </summary>
    /// <param name="target">Источник события.</param>
    /// <param name="subscriber">Подписчик на события.</param>

    public static void Subscribe(INotify<T> target, IWeakNotifyEventSink<T> subscriber)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(subscriber);

        // Получаем или создаем список handlers для источника
        List<WeakReference<IWeakNotifyEventSink<T>>> handlers = _handlers.GetOrCreateValue(target);
        lock (handlers)
        {
            // Проверяем, есть ли уже этот subscriber (чтобы избежать дубликатов)
            bool alreadyExists = false;
            foreach (var wr in handlers)
            {
                if (wr.TryGetTarget(out var existingHandler) && ReferenceEquals(existingHandler, subscriber))
                {
                    alreadyExists = true;
                    break;
                }
            }

            // Если дубликата нет, добавляем новую слабую ссылку
            if (!alreadyExists)
            {
                handlers.Add(new WeakReference<IWeakNotifyEventSink<T>>(subscriber));
                // Подписываемся на событие, если это первая подписка
                if (handlers.Count == 1) 
                {
                    AddHandlersToTarget(target);
                }
            }
        }
    }

    private static void AddHandlersToTarget(INotify<T> target)
    {
        target.ItemAdded += OnItemAdded;
        target.ItemRemoved += OnItemRemoved;
        target.RangeAdded += OnRangeAdded;
        target.RangeRemoved += OnRangeRemoved;
        target.ItemReplaced += OnItemReplaced;
        target.ItemMoved += OnItemMoved;
        target.CollectionCleared += OnCollectionCleared;
    }

    /// <summary>
    /// Удаляет слабого подписчика на события <see cref="INotify{T}"/> источника.
    /// </summary>
    /// <param name="target">Источник события.</param>
    /// <param name="subscriber">Подписчик на события.</param>
    public static void Unsubscribe(INotify<T> target, IWeakNotifyEventSink<T> subscriber)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(subscriber);

        // Получаем список handlers для источника (если он есть)
        if (_handlers.TryGetValue(target, out var handlers))
        {
            lock (handlers)
            {
                handlers.RemoveAll(wr =>
                {
                    if (wr.TryGetTarget(out var existingHandler))
                    {
                        return existingHandler == subscriber;
                    }
                    else
                    {
                        return true;
                    }
                });

                // Если список пуст, отписываемся от события
                if (handlers.Count == 0)
                {
                    RemoveHandlersFromTarget(target);
                }
            }
        }
    }

    private static void RemoveHandlersFromTarget(INotify<T> target)
    {
        target.ItemAdded -= OnItemAdded;
        target.ItemRemoved -= OnItemRemoved;
        target.RangeAdded -= OnRangeAdded;
        target.RangeRemoved -= OnRangeRemoved;
        target.ItemReplaced -= OnItemReplaced;
        target.ItemMoved -= OnItemMoved;
        target.CollectionCleared -= OnCollectionCleared;
    }

    private static void OnItemAdded(object sender, IItemAddedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.ItemAdded(source, e);
        }
    }

    private static void OnItemRemoved(object sender, IItemRemovedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.ItemRemoved(source, e);
        }
    }

    private static void OnRangeAdded(object sender, IRangeAddedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.RangeAdded(source, e);
        }
    }

    private static void OnRangeRemoved(object sender, IRangeRemovedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.RangeRemoved(source, e);
        }
    }

    private static void OnItemReplaced(object sender, IItemReplacedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.ItemReplaced(source, e);
        }
    }

    private static void OnItemMoved(object sender, IItemMovedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.ItemMoved(source, e);
        }
    }

    private static void OnCollectionCleared(object sender, ICollectionClearedEventArgs<T> e)
    {
        INotify<T> source = (INotify<T>)sender;

        foreach (var handler in GetLiveHandlers(source))
        {
            handler.CollectionCleared(source, e);
        }
    }


    private static IEnumerable<IWeakNotifyEventSink<T>> GetLiveHandlers(INotify<T> source)
    {
        List<IWeakNotifyEventSink<T>>? liveHandlers = null;

        if (_handlers.TryGetValue(source, out var handlers))
        {
            lock (handlers)
            {
                handlers.RemoveAll(wr => !wr.TryGetTarget(out _));

                if (handlers.Count == 0)
                {
                    RemoveHandlersFromTarget(source);
                }
                else
                {
                    liveHandlers = new List<IWeakNotifyEventSink<T>>(handlers.Count);
                    foreach (var wr in handlers)
                    {
                        if (wr.TryGetTarget(out var handler))
                        {                           
                            liveHandlers.Add(handler);
                        }
                    }
                }               
            }
        }
        return liveHandlers ?? Enumerable.Empty<IWeakNotifyEventSink<T>>();
    }
}