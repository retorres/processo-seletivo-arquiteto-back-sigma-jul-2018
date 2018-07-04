using GP.CommandSide.Domain.Abstractions;
using System;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class ModeloCriado : IDomainEvent
    {
        public ModeloCriado(long modeloId, long marcaId, string nome, DateTime dataCriacao)
        {
            ModeloId = modeloId;
            MarcaId = marcaId;
            Nome = nome;
            DataCriacao = dataCriacao;
        }

        public long ModeloId { get; }
        public long MarcaId { get; }
        public string Nome { get; }
        public DateTime DataCriacao { get; }
    }
}
