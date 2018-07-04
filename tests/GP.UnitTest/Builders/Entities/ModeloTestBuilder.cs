using GP.CommandSide.Domain.Abstractions;
using GP.CommandSide.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.UnitTest.Builders.Entities
{
    public class ModeloTestBuilder
    {
        private string _parametroNome;
        private long _parametroMarcaId;
        private long _parametroModeloId;
        private DateTime _parametroDataCriacao;

        private IEnumerable<Patrimonio> _parametroPatrimonios = new List<Patrimonio>();
        private MarcaTestBuilder _marcaTestBuilder;



        public ModeloTestBuilder()
        {
            _marcaTestBuilder = new MarcaTestBuilder();

            _parametroNome = "Modelo Generico";
            _parametroMarcaId = 1;
            _parametroModeloId = 2;
            _parametroDataCriacao = new DateTime(2018, 1, 1);
        }

        public ModeloTestBuilder ComModeloId(long modeloId)
        {
            _parametroModeloId = modeloId;
            return this;
        }
        public ModeloTestBuilder ComNome(string nome)
        {
            _parametroNome = nome;
            return this;
        }

        public ModeloTestBuilder ComMarca(long marcaId)
        {
            _parametroMarcaId = marcaId;
            return this;
        }

        public ModeloTestBuilder ComDataCriacao(long id)
        {
            _parametroMarcaId = id;
            return this;
        }

        public Modelo Build()
        {
            var marca = _marcaTestBuilder.Build();

            return marca.NovoModelo(_parametroModeloId, _parametroNome, _parametroDataCriacao);
        }

    }
}
