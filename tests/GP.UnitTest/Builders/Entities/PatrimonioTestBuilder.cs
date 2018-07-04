using GP.CommandSide.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.UnitTest.Builders.Entities
{
    public class PatrimonioTestBuilder
    {

        private ModeloTestBuilder _modeloTestBuilder;
        private Modelo _modelo;
        private Patrimonio _patrimonio;
        private long _parametroTomboNumero;
        private string _parametroNome;
        private string _parametroDescricao;
        private DateTime _parametroDataCriacao;


        public PatrimonioTestBuilder()
        {
            _modeloTestBuilder = new ModeloTestBuilder();
            _modelo = _modeloTestBuilder.Build();

            _patrimonio = _modelo.NovoPatrimonio(1, "Patrimonio Generico", DateTime.Today, null);

            _parametroTomboNumero = _patrimonio.TomboNumero;
            _parametroNome = _patrimonio.Nome;
            _parametroDescricao = _patrimonio.Descricao;
            _parametroDataCriacao = _patrimonio.DataCriacao;
        }


        public PatrimonioTestBuilder ComNome(string nome)
        {
            _parametroNome = nome;

            _patrimonio = _modelo.NovoPatrimonio(_parametroTomboNumero, _parametroNome, _parametroDataCriacao, _parametroDescricao);

            return this;
        }

        public PatrimonioTestBuilder ComDescricao(string descricao)
        {
            _parametroDescricao = descricao;

            _patrimonio = _modelo.NovoPatrimonio(_parametroTomboNumero, _parametroNome, _parametroDataCriacao, _parametroDescricao);

            return this;
        }


        public PatrimonioTestBuilder ComTomboNumero(long tomboNumero)
        {
            _parametroTomboNumero = tomboNumero;

            _patrimonio = _modelo.NovoPatrimonio(_parametroTomboNumero, _parametroNome, _parametroDataCriacao, _parametroDescricao);

            return this;
        }

        public Patrimonio Build()
        {
            return _patrimonio;
        }
    }
}
