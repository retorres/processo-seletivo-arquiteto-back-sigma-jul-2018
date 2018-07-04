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
    public class Modelo : Entity, IAggregateRoot
    {
        private Modelo()
        {

        }
        internal Modelo(long modeloId, string nome, Marca marca, DateTime dataCriacao)
        {
            Marca = marca;
            ModeloId = modeloId;
            Nome = nome;
            MarcaId = marca.MarcaId;
            DataCriacao = dataCriacao;

            RegisterEvent(new ModeloCriado(ModeloId, MarcaId, Nome, DataCriacao));
        }

        public long ModeloId { get; private set; }
        public string Nome { get; private set; }
        public long MarcaId { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Marca Marca { get; private set; }

        public void Excluir()
        {
            RegisterEvent(new ModeloExcluido(ModeloId));
        }

        public void AlterarNome(string nome)
        {
            Guard.NotNullOrEmpty(nome, nameof(nome));

            if (Marca.Modelos.Any(r => r.Nome == nome && r.ModeloId != ModeloId))
                throw new ModeloNomeRepetidoNaMarcaException(nome, Marca.MarcaId);

            Nome = nome;
            RegisterEvent(new ModeloNomeAlterado(ModeloId, Nome));
        }

        public void AlterarMarca(Marca marca)
        {
            Guard.NotNull(marca, nameof(marca));

            Marca = marca;
            MarcaId = marca.MarcaId;

            RegisterEvent(new ModeloComMarcaAlterado(ModeloId, MarcaId));
        }

        public Patrimonio NovoPatrimonio(long tomboNumero, string nome, DateTime dataCriacao, string descricao)
        {
            Guard.MustBeGreaterThan(tomboNumero, 0, nameof(tomboNumero));
            Guard.NotNullOrEmpty(nome, nameof(nome));

            var novoPatrimonio = new Patrimonio(tomboNumero, ModeloId, nome, dataCriacao, descricao);

            return novoPatrimonio;
        }
    }
}
