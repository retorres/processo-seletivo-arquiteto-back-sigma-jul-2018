using FluentAssertions;
using GP.CommandSide.Domain.Abstractions;
using GP.CommandSide.Domain.DomainServices.ModeloDomainService;
using GP.CommandSide.Domain.Entities;
using GP.CommandSide.Domain.Exceptions;
using GP.CommandSide.Domain.Repositories;
using GP.UnitTest.Builders.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GP.UnitTest.Domain.DomainEvents.ModeloDomainService
{
    public class CriacaoModeloDomainServiceTest
    {
        private Marca _marca;
        private MarcaTestBuilder _marcaTestBuilder;
        private Mock<ITimeProvider> timeProvider;
        private Mock<IIdGeneratorService<long>> idGen;
        private Mock<IMarcaRepository> marcaRepository;
        private Mock<IModeloRepository> modeloRepository;

        public CriacaoModeloDomainServiceTest()
        {
            _marcaTestBuilder = new MarcaTestBuilder();
            _marca = _marcaTestBuilder
                            .ComId(3333)
                            .AdicionaModelo(4441, "Corolla", DateTime.Today)
                            .AdicionaModelo(4442, "Yaris", DateTime.Today)
                            .AdicionaModelo(4443, "Etios", DateTime.Today)
                            .AdicionaModelo(4444, "Hillux", DateTime.Today)
                            .Build();



            timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(q => q.UtcNow).Returns(DateTime.Today);

            idGen = new Mock<IIdGeneratorService<long>>();
            idGen.Setup(q => q.GenerateId()).Returns(5165161);

            marcaRepository = new Mock<IMarcaRepository>();
            marcaRepository.Setup(q => q.ObterPorIdAsync(_marca.MarcaId)).Returns(Task.FromResult(_marca));
            marcaRepository.Setup(q => q.ObterPorIdAsync(44444)).Returns(Task.FromResult(default(Marca)));

            modeloRepository = new Mock<IModeloRepository>();
        }

        [Fact]
        public void Deve_ser_invalido_criacao_de_modelo_se_nao_tiver_marca()
        {
            //arrange
            ICriacaoModeloDomainService domainService =
                new CriacaoModeloDomainService(
                    timeProvider.Object,
                    idGen.Object,
                    marcaRepository.Object,
                    modeloRepository.Object);

            //act
            Func<Task> act = async () => await domainService.CriarModeloAsync(44444, "Corolla");

            //assert
            act.Should().Throw<EntityNotFoundException>();
        }


        [Fact]
        public async Task Deve_ser_invalido_criacao_de_modelo_se_houver_outro_modelo_de_mesmo_nome_nesta_marca()
        {
            //arrange
            ICriacaoModeloDomainService domainService =
                new CriacaoModeloDomainService(
                    timeProvider.Object,
                    idGen.Object,
                    marcaRepository.Object,
                    modeloRepository.Object);

            //act
            Func<Task> act = async () => await domainService.CriarModeloAsync(_marca.MarcaId, "Corolla");

            //assert
            act.Should().Throw<DuplicatedEntityException>();
        }

        [Theory]
        [InlineData("RAV4")]
        [InlineData("PRIUS")]
        public async Task Deve_ser_valido_criacao_de_modelo_com_nome_preenchido(string nome)
        {
            //arrange
            ICriacaoModeloDomainService domainService =
                new CriacaoModeloDomainService(
                    timeProvider.Object,
                    idGen.Object,
                    marcaRepository.Object,
                    modeloRepository.Object);

            //act
            await domainService.CriarModeloAsync(_marca.MarcaId, nome);

            //assert
            _marca.Modelos.Should().Contain(q => q.Nome == nome);
        }


        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public async Task Deve_ser_invalido_criacao_de_modelo_com_nome_vazio_ou_nulo(string nome)
        {
            //arrange
            ICriacaoModeloDomainService domainService =
                new CriacaoModeloDomainService(
                    timeProvider.Object,
                    idGen.Object,
                    marcaRepository.Object,
                    modeloRepository.Object);

            //act
            Func<Task> act = async () => await domainService.CriarModeloAsync(_marca.MarcaId, nome);

            //assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
