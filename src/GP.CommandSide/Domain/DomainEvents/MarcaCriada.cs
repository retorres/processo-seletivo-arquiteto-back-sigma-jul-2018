using GP.CommandSide.Domain.Abstractions;
using System;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class MarcaCriada : IDomainEvent
    {
        public MarcaCriada(long marcaId, string nome, DateTime dataCriacao)
        {
            MarcaId = marcaId;
            Nome = nome;
            DataCriacao = dataCriacao;
        }

        public long MarcaId { get; }
        public string Nome { get; }
        public DateTime DataCriacao { get; }
    }
}
