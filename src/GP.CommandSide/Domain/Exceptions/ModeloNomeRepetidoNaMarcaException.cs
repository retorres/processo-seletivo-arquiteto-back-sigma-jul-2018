using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Domain.Exceptions
{
    public class ModeloNomeRepetidoNaMarcaException : DomainException
    {
        public string ModeloNome { get; }
        public object EntityId { get; }

        public ModeloNomeRepetidoNaMarcaException(string modeloNome, object entityId)
            : base($"Modelo '{modeloNome}' repetido na marca (Id = {entityId})")
        {
            ModeloNome = modeloNome;
            EntityId = entityId;
        }
    }
}
