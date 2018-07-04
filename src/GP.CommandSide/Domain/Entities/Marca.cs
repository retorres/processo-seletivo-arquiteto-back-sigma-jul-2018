using GP.CommandSide.Domain.Abstractions;
using GP.CommandSide.Domain.DomainEvents;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GP.CommandSide.Domain.Entities
{
    public class Marca : Entity, IAggregateRoot
    {
        public Marca(long marcaId, string nome, DateTime dataCriacao, IEnumerable<Modelo> modelos)
        {
            Guard.MustBeGreaterThan(marcaId, 0, nameof(marcaId));
            Guard.NotNullOrEmpty(nome, nameof(nome));

            MarcaId = marcaId;
            Nome = nome;
            DataCriacao = dataCriacao;
            _modelos = modelos.ToList();

            RegisterEvent(new MarcaCriadaComModelos(MarcaId, Nome, DataCriacao, _modelos));
        }


        public Marca(long marcaId, string nome, DateTime dataCriacao)
        {
            Guard.MustBeGreaterThan(marcaId, 0, nameof(marcaId));
            Guard.NotNullOrEmpty(nome, nameof(nome));

            MarcaId = marcaId;
            Nome = nome;
            DataCriacao = dataCriacao;

            RegisterEvent(new MarcaCriada(MarcaId, Nome, DataCriacao));
        }
        private Marca()
        {
        }

        public long MarcaId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }

        private List<Modelo> _modelos = new List<Modelo>();
        public IReadOnlyCollection<Modelo> Modelos => _modelos.AsReadOnly();

        public Modelo NovoModelo(long modeloId, string nome, DateTime dataCriacao)
        {
            Guard.MustBeGreaterThan(modeloId, 0, nameof(modeloId));
            Guard.NotNullOrEmpty(nome, nameof(nome));

            var novoModelo = new Modelo(modeloId, nome, this, dataCriacao);
            _modelos.Add(novoModelo);

            return novoModelo;
        }

        public void AlterarNome(string nome)
        {
            Guard.NotNullOrEmpty(nome, nameof(nome));
            Nome = nome;

            RegisterEvent(new MarcaNomeAlterado(MarcaId, Nome));
        }

        public void Excluir()
        {
            if (Modelos.Any())
                throw new DomainException("Esta marca possui modelos, não pode ser excluido.");

            RegisterEvent(new MarcaExcluida(MarcaId));
        }
    }
}
