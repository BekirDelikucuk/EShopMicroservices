﻿namespace Ordering.Domain.Absractions;
public interface IAggregate<T> : IAggregate, IEntity<T>
{
}
public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}
