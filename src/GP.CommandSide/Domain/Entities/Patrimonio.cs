using GP.CommandSide.Domain.Abstractions;
using GP.CommandSide.Domain.DomainEvents;
using GP.CommandSide.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.CommandSide.Domain.Entities
{
    public class Patrimonio : Entity, IAggregateRoot
    {
        private Patrimonio() { }

        internal Patrimonio(long tomboNumero, long modeloId, string nome, DateTime dataCriacao, string descricao)
        {
            TomboNumero = tomboNumero;
            ModeloId = modeloId;
            Nome = nome;
            DataCriacao = dataCriacao;
            Descricao = descricao;

            RegisterEvent(new PatrimonioTombado(TomboNumero, ModeloId, Nome, DataCriacao, Descricao));
        }

        public long TomboNumero { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public long ModeloId { get; private set; }

        public Modelo Modelo { get; private set; }

        public void AlterarInformacoesCadastrais(string nome, string descricao)
        {
            Guard.NotNullOrEmpty(nome, nameof(nome));
            Nome = nome;
            Descricao = descricao;

            RegisterEvent(new PatrimonioComInformacoesCadastraisAlterada(TomboNumero, Nome, Descricao));
        }

        public void Excluir()
        {
            RegisterEvent(new PatrimonioExcluido(TomboNumero));
        }
    }
}
