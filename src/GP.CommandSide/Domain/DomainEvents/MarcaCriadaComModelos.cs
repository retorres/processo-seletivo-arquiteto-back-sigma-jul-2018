using System;
using System.Collections.Generic;
using GP.CommandSide.Domain.Abstractions;

namespace GP.CommandSide.Domain.Entities
{
    public class MarcaCriadaComModelos : IDomainEvent
    {
        
        public MarcaCriadaComModelos(long marcaId, string nome, DateTime dataCriacao, List<Modelo> modelos)
        {
            MarcaId = marcaId;
            Nome = nome;
            DataCriacao = dataCriacao;
            Modelos = modelos;
        }

        public long MarcaId { get; }
        public string Nome { get; }
        public DateTime DataCriacao { get; }
        public IReadOnlyCollection<Modelo> Modelos { get; }
    }
}