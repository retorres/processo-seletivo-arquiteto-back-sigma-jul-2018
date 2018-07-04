using GP.CommandSide.Domain.Abstractions;
using System;

namespace GP.CommandSide.Domain.DomainEvents
{
    public class PatrimonioTombado : IDomainEvent
    {

        public PatrimonioTombado(long tomboNumero, long modeloId, string nome, DateTime dataCriacao, string descricao)
        {
            TomboNumero = tomboNumero;
            ModeloId = modeloId;
            Nome = nome;
            DataCriacao = dataCriacao;
            Descricao = descricao;
        }

        public long TomboNumero { get; }
        public long ModeloId { get; }
        public string Nome { get; }
        public DateTime DataCriacao { get; }
        public string Descricao { get; }
    }
}