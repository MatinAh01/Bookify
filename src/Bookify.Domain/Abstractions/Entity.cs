using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; }
    private readonly List<IDomainEvent> _domainEvents = [];

    public Entity(Guid id)
    {
        Id = id;
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void RaiseDomainEvents(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}