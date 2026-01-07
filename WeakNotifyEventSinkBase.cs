namespace Kritjara.Collections;

/// <inheritdoc cref="IWeakNotifyEventSink{T}"/>
public abstract class WeakNotifyEventSinkBase<T> : IWeakNotifyEventSink<T>
{
    /// <inheritdoc/>
    protected abstract void ItemAdded(INotify<T> sender, IItemAddedEventArgs<T> e);

    /// <inheritdoc/>
    protected abstract void ItemRemoved(INotify<T> sender, IItemRemovedEventArgs<T> e);

    /// <inheritdoc/>
    protected abstract void RangeAdded(INotify<T> sender, IRangeAddedEventArgs<T> e);

    /// <inheritdoc/>
    protected abstract void RangeRemoved(INotify<T> sender, IRangeRemovedEventArgs<T> e);

    /// <inheritdoc/>
    protected abstract void ItemReplaced(INotify<T> sender, IItemReplacedEventArgs<T> e);

    /// <inheritdoc/>
    protected abstract void ItemMoved(INotify<T> sender, IItemMovedEventArgs<T> e);

    /// <inheritdoc/>
    protected abstract void CollectionCleared(INotify<T> sender, ICollectionClearedEventArgs<T> e);

    void IWeakNotifyEventSink<T>.ItemAdded(INotify<T> sender, IItemAddedEventArgs<T> e) => ItemAdded(sender, e);

    void IWeakNotifyEventSink<T>.ItemRemoved(INotify<T> sender, IItemRemovedEventArgs<T> e) => ItemRemoved(sender, e);

    void IWeakNotifyEventSink<T>.RangeAdded(INotify<T> sender, IRangeAddedEventArgs<T> e) => RangeAdded(sender, e);

    void IWeakNotifyEventSink<T>.RangeRemoved(INotify<T> sender, IRangeRemovedEventArgs<T> e) => RangeRemoved(sender, e);

    void IWeakNotifyEventSink<T>.ItemReplaced(INotify<T> sender, IItemReplacedEventArgs<T> e) => ItemReplaced(sender, e);

    void IWeakNotifyEventSink<T>.ItemMoved(INotify<T> sender, IItemMovedEventArgs<T> e) => ItemMoved(sender, e);

    void IWeakNotifyEventSink<T>.CollectionCleared(INotify<T> sender, ICollectionClearedEventArgs<T> e) => CollectionCleared(sender, e);
}
