using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Domain.Exceptions
{
    public class DuplicatedEntityException : DomainException
    {
        public string EntityName { get; }
        public object EntityId { get; }

        public DuplicatedEntityException(string entityName, object entityId)
            : base($"'{entityName}' ({entityId}) ja existe.")
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}
