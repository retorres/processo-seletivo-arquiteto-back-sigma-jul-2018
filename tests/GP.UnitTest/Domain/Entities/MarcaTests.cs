using FluentAssertions;
using GP.CommandSide.Domain.DomainEvents;
using GP.CommandSide.Domain.Exceptions;
using GP.UnitTest.Builders.Entities;
using System;
using Xunit;
using DomainMarca = GP.CommandSide.Domain.Entities.Marca;

namespace GP.UnitTest.Domain.Entities
{
    public class MarcaTests
    {
        private readonly MarcaTestBuilder _marcaBuilder;
        public MarcaTests()
        {
            _marcaBuilder = new MarcaTestBuilder();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_ser_invalido_a_criacao_de_marca_com_id_maior_que_um(long id)
        {
            //arrange
            //act
            Action criaMarca = () => new DomainMarca(id, "uma marca qualquer", DateTime.Today);

            //assert
            criaMarca.Should().Throw<ArgumentOutOfRangeException>("Deve-se informar um id de marca maior que 0.");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Deve_ser_invalido_a_criacao_de_marca_sem_nome(string nome)
        {
            //arrange
            //act
            Action criaMarca = () => new DomainMarca(1, nome, DateTime.Today);

            //assert
            criaMarca.Should().Throw<ArgumentException>("Deve-se informar um nome para marca.");
        }


        [Theory]
        [InlineData(65156456, "marca 1")]
        [InlineData(1, "marca 2 com texto grande")]
        public void Deve_ser_valido_criar_uma_marca_valida(long marcaId, string nome)
        {
            //arrange
            //act
            var marca = new DomainMarca(marcaId, nome, DateTime.Today);

            //assert
            marca.Should().BeOfType<DomainMarca>();
            marca.DomainEvents.Should().HaveCount(1);
            marca.DomainEvents.Should().ContainItemsAssignableTo<MarcaCriada>();
        }



        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Deve_ser_invalido_alterar_nome_da_marca_com_nome_vazio_ou_nulo_ou_espaco_Vazio(string nome)
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("Toyota")
                            .Build();


            //act
            Action alterarMarca = () => { marca.AlterarNome(nome); };


            //assert
            alterarMarca.Should().Throw<ArgumentException>("Nome da marca não deve ser nulo/vazio/espaço em branco");
        }


        [Theory]
        [InlineData("Toyota")]
        [InlineData("Honda")]
        public void Deve_ser_valido_alterar_nome_da_marca_com_nome_Preenchido(string nome)
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("marca qualquer")
                            .Build();


            //act
            marca.AlterarNome(nome);


            //assert
            marca.Nome.Should().Be(nome);
            marca.DomainEvents.Should().HaveCountGreaterOrEqualTo(1, "Falta disparar evento de alteração de nome");
            marca.DomainEvents.Should().Contain(r => r.GetType() == typeof(MarcaNomeAlterado));
        }



        [Theory]
        [InlineData(80000564, "Prius")]
        [InlineData(21344, "Fit")]
        public void Deve_ser_valido_criar_um_modelo_valido(long modeloId, string modelo)
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("Toyota")
                            .Build();


            //act
            var novoModelo = marca.NovoModelo(modeloId, modelo, DateTime.Today);


            //assert
            novoModelo.Nome.Should().Be(modelo);
            novoModelo.ModeloId.Should().Be(modeloId);
            novoModelo.DomainEvents.Should().Contain(r => r.GetType() == typeof(ModeloCriado));
            marca.Modelos.Should().Contain(novoModelo, "O modelo criado pela marca não foi adicionado a lista de modelos dessa marca");
        }


        [Theory]
        [InlineData(21344, "")]
        [InlineData(21344, null)]
        [InlineData(21344, " ")]
        public void Deve_ser_invalido_criar_modelo_com_nome_nulo_ou_vazio_ou_espaco_vazio(long modeloId, string modelo)
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("Toyota")
                            .Build();

            //act
            Action novoModelo = () => marca.NovoModelo(modeloId, modelo, DateTime.Today);

            //assert
            novoModelo.Should().Throw<ArgumentException>("Nome do modelo não deve ser nulo/vazio/espaço em branco");
        }

        [Theory]
        [InlineData(0, "Prius")]
        [InlineData(-1, "Prius")]
        public void Deve_ser_invalido_criar_modelo_com_id_zero_ou_menor(long modeloId, string modelo)
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("Toyota")
                            .Build();

            //act
            Action novoModelo = () => marca.NovoModelo(modeloId, modelo, DateTime.Today);

            //assert
            novoModelo.Should()
                .Throw<ArgumentOutOfRangeException>("Deve-se informar um id de modelo maior que 0.");
        }


        [Fact]
        public void Deve_ser_valido_excluir_uma_marca()
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("Toyota")
                            .Build();


            //act
            marca.Excluir();

            //assert
            marca.DomainEvents.Should().Contain(r => r.GetType() == typeof(MarcaExcluida));
        }


        [Fact]
        public void Deve_ser_invalido_excluir_uma_marca_que_possua_modelos()
        {
            //arrange
            var marca = _marcaBuilder
                            .ComNome("Toyota")
                            .AdicionaModelo(7123123, "Corolla", DateTime.Today)
                            .AdicionaModelo(7123133, "Yaris", DateTime.Today)
                            .AdicionaModelo(7123145, "Etios", DateTime.Today)
                            .Build();

            //act
            Action excluir = () => marca.Excluir();

            //assert
            excluir.Should()
                .Throw<DomainException>("Não deve excluir uma marca que tenha modelos.");
        }


    }
}
