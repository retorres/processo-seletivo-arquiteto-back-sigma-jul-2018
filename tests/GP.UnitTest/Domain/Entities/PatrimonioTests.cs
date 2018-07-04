using FluentAssertions;
using GP.CommandSide.Domain.DomainEvents;
using GP.UnitTest.Builders.Entities;
using System;
using Xunit;

namespace GP.UnitTest.Domain.Entities
{
    public class PatrimonioTests
    {

        private ModeloTestBuilder _modeloTestBuilder;
        private PatrimonioTestBuilder _patrimonioTestBuilder;
        public PatrimonioTests()
        {
            _modeloTestBuilder = new ModeloTestBuilder();
            _patrimonioTestBuilder = new PatrimonioTestBuilder();
        }



        [Theory]
        [InlineData("Corcel", "Prata")]
        [InlineData("Corcel", "")]
        [InlineData("Corcel", "   ")]
        [InlineData("Corcel", null)]
        [InlineData("Escort", "Hobby")]
        public void Deve_ser_valido_alterar_informacoes_cadastrais(string nome, string descricao)
        {
            //arrange
            var patrimonio = _patrimonioTestBuilder.Build();

            //act
            patrimonio.AlterarInformacoesCadastrais(nome, descricao);

            //assert
            patrimonio.Nome.Should().Be(nome);
            patrimonio.Descricao.Should().Be(descricao);
            patrimonio.DomainEvents.Should().Contain(q => q.GetType() == typeof(PatrimonioComInformacoesCadastraisAlterada));
        }


        [Theory]
        [InlineData("", "Prata")]
        [InlineData("   ", "")]
        [InlineData(null, "   ")]

        public void Deve_ser_invalido_alterar_informacoes_cadastrais_com_nome_nulo_ou_vazio(string nome, string descricao)
        {
            //arrange
            var patrimonio = _patrimonioTestBuilder.Build();

            //act
            Action act = () => patrimonio.AlterarInformacoesCadastrais(nome, descricao);

            //assert
            act.Should().Throw<ArgumentException>("Nome nao pode ser nulo");
        }



        [Fact]
        public void Deve_ser_valido_excluir_um_patrimonio()
        {
            //arrange
            var patrimonio = _patrimonioTestBuilder.Build();

            //act
            patrimonio.Excluir();

            //assert
            patrimonio.DomainEvents.Should().Contain(q => q.GetType() == typeof(PatrimonioExcluido));
        }
    }
}
