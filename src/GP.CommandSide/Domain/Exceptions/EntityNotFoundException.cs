using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Domain.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public string EntityName { get; }
        public object EntityId { get; }

        public EntityNotFoundException(string entityName, object entityId)
            : base($"'{entityName}' (Id = {entityId}) não foi encontrada")
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}
