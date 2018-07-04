using FluentAssertions;
using GP.CommandSide.Domain.DomainEvents;
using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.UnitTest.Builders.Entities;
using System;
using System.Linq;
using Xunit;

namespace GP.UnitTest.Domain.Entities
{
    public class ModeloTests
    {

        private readonly ModeloTestBuilder _modeloTestBuilder;
        private readonly MarcaTestBuilder _marcaTestBuilder;
        public ModeloTests()
        {
            _modeloTestBuilder = new ModeloTestBuilder();
            _marcaTestBuilder = new MarcaTestBuilder();
        }


        //excluir/
        //criar patrimonio

        [Theory]
        [InlineData("Hillux")]
        [InlineData("Etios")]
        public void Deve_ser_valido_alterar_nome_do_modelo(string nome)
        {
            //arrange
            var modelo = _modeloTestBuilder.ComNome("Yaris").Build();
            var nomeAntigo = modelo.Nome;
            //act
            modelo.AlterarNome(nome);

            //assert
            modelo.Nome.Should().Be(nome);
            modelo.Nome.Should().NotBe(nomeAntigo);
            modelo.DomainEvents.Should().HaveCountGreaterOrEqualTo(1, "Falta disparar evento de alteração de nome");
            modelo.DomainEvents.Should().Contain(r => r.GetType() == typeof(ModeloNomeAlterado));

        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_ser_invalido_alterar_nome_do_modelo_vazio_ou_espaco(string nome)
        {
            //arrange
            var modelo = _modeloTestBuilder.ComNome("Yaris").Build();
            var nomeAntigo = modelo.Nome;
            //act
            Action act = () => modelo.AlterarNome(nome);

            //assert
            act.Should().Throw<ArgumentException>("Nome da marca não deve ser nulo/vazio/espaço em branco");
        }


        [Fact]
        public void Deve_ser_invalido_alterar_nome_do_modelo_para_um_modelo_de_mesmo_nome_da_marca()
        {
            //arrange
            var marca = _marcaTestBuilder
                                .ComNome("Toyota")
                                .AdicionaModelo(1, "Yaris", DateTime.Today)
                                .AdicionaModelo(2, "Corolla", DateTime.Today)
                                .AdicionaModelo(3, "Etios", DateTime.Today).Build();

            var modelo = marca.Modelos.Where(q => q.Nome == "Yaris").FirstOrDefault();

            //act
            Action act = () => modelo.AlterarNome("Corolla");

            //assert
            act.Should().Throw<ModeloNomeRepetidoNaMarcaException>("Não deve permitir dois modelos com mesmo nome dentro de uma marca");
        }


        [Fact]
        public void Deve_ser_valido_alterar_marca()
        {
            //arrange
            var modelo = _modeloTestBuilder.Build();
            var novaMarca = _marcaTestBuilder.Build();

            //act
            modelo.AlterarMarca(novaMarca);

            //assert
            modelo.Marca.Should().Be(novaMarca);
            modelo.MarcaId.Should().Be(novaMarca.MarcaId);
            modelo.DomainEvents.Should().Contain(r => r.GetType() == typeof(ModeloComMarcaAlterado));
        }



        [Fact]
        public void Deve_ser_invalido_alterar_marca_nula()
        {
            //arrange
            var modelo = _modeloTestBuilder.Build();
            Marca marca = null;

            //act
            Action act = () => modelo.AlterarMarca(marca);

            //assert
            act.Should().Throw<ArgumentNullException>("A marca deve estar preenchida para ser alterada");
        }

        [Fact]
        public void Deve_ser_valido_excluir_um_modelo()
        {
            //arrange
            var modelo = _modeloTestBuilder.Build();

            //act
            modelo.Excluir();

            //assert
            modelo.DomainEvents.Should().Contain(r => r.GetType() == typeof(ModeloExcluido));
        }


        [Theory]
        [InlineData(12312312, "cadeira", "Quatro pernas")]
        [InlineData(235213, "Porta", "Metal")]
        [InlineData(2433, "Porta",null)]
        [InlineData(12312312, "cadeira", "")]
        [InlineData(2323513, "Porta", null)]
        public void Deve_ser_valido_criar_um_patrimonio(long tomboNumero, string nome, string descricao)
        {
            var dataCriacao = DateTime.Today;

            //arrange
            var modelo = _modeloTestBuilder.Build();

            //act
            var patrimonio = modelo.NovoPatrimonio(tomboNumero, nome, DateTime.Today, descricao);

            //assert
            patrimonio.DataCriacao.Should().Be(dataCriacao);
            patrimonio.TomboNumero.Should().Be(tomboNumero);
            patrimonio.Nome.Should().Be(nome);
            patrimonio.Descricao.Should().Be(descricao);
            patrimonio.DomainEvents.Should().Contain(q => q.GetType() == typeof(PatrimonioTombado));
        }


        [Theory]
        [InlineData(0, "cadeira", "Quatro pernas")]
        [InlineData(-461561, "Porta", "Metal")]
        public void Deve_ser_invalido_criar_um_patrimonio_com_tombo_zero_ou_negativo(long tomboNumero, string nome, string descricao)
        {
            var dataCriacao = DateTime.Today;

            //arrange
            var modelo = _modeloTestBuilder.Build();

            //act
            Action act = () => modelo.NovoPatrimonio(tomboNumero, nome, DateTime.Today, descricao);

            //assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(123123, "", "Quatro pernas")]
        [InlineData(834782173, null, "Metal")]
        [InlineData(1321, "    ", "madeira")]
        public void Deve_ser_invalido_criar_um_patrimonio_com_nome_vazio_ou_nulo(long tomboNumero, string nome, string descricao)
        {
            var dataCriacao = DateTime.Today;

            //arrange
            var modelo = _modeloTestBuilder.Build();

            //act
            Action act = () => modelo.NovoPatrimonio(tomboNumero, nome, DateTime.Today, descricao);

            //assert
            act.Should().Throw<ArgumentException>();
        }

    }
}
