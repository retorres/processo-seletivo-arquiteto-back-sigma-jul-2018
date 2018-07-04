using System.Collections.Generic;

namespace GP.CommandSide.Domain.Abstractions
{
    public abstract class Entity
    {

        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();



        public void RegisterEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

    }
}
