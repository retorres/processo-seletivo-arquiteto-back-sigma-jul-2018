using GP.CommandSide.Domain.Abstractions;
using GP.CommandSide.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GP.UnitTest.Builders.Entities
{
    public class MarcaTestBuilder
    {
        private readonly Mock<IIdGeneratorService<long>> _idGenerator;

        private string _parametroNome;
        private long _parametroMarcaId;
        private DateTime _parametroDataCriacao;
        private Marca _marca;

        public MarcaTestBuilder()
        {
            _idGenerator = new Mock<IIdGeneratorService<long>>();
            _idGenerator.Setup(e => e.GenerateId()).Returns(123123123);

            _parametroNome = "Marca Generica";
            _parametroMarcaId = 1;
            _parametroDataCriacao = new DateTime(2018, 1, 1);

            _marca = new Marca(_parametroMarcaId, _parametroNome, _parametroDataCriacao);
        }

        public MarcaTestBuilder ComNome(string nome)
        {
            var modelos = _marca.Modelos;
            _parametroNome = nome;

            _marca = new Marca(_parametroMarcaId, _parametroNome, _parametroDataCriacao, modelos);

            return this;
        }
        public MarcaTestBuilder ComId(long id)
        {
            var modelos = _marca.Modelos;
            _parametroMarcaId = id;

            _marca = new Marca(_parametroMarcaId, _parametroNome, _parametroDataCriacao, modelos);

            return this;
        }
        public MarcaTestBuilder ComDataCriacao(DateTime dataCriacao)
        {
            var modelos = _marca.Modelos;
            _parametroDataCriacao = dataCriacao;

            _marca = new Marca(_parametroMarcaId, _parametroNome, _parametroDataCriacao, modelos);

            return this;
        }
        public MarcaTestBuilder ComModelos(IEnumerable<Modelo> modelos)
        {
            _marca = new Marca(_parametroMarcaId, _parametroNome, _parametroDataCriacao, modelos);

            return this;
        }
        public MarcaTestBuilder AdicionaModelo(long modeloId, string modeloNome, DateTime dataCriacao)
        {
            _marca.NovoModelo(modeloId, modeloNome, dataCriacao);

            return this;
        }

        public Marca Build()
        {
            return _marca;
        }
    }
}
