using FluentAssertions;
using GP.CommandSide.Domain.DomainEvents;
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
    public class ExclusaoModeloDomainServiceTest
    {

        private ModeloTestBuilder _modeloTestBuilder;
        private Modelo _modelo;
        public ExclusaoModeloDomainServiceTest()
        {
            _modeloTestBuilder = new ModeloTestBuilder();
            _modelo = _modeloTestBuilder.ComModeloId(4444).Build();
        }

        [Fact]
        public void Deve_ser_invalido_exclusao_modelo_quando_possuir_patrimonios()
        {
            //arrange
            var modeloRepository = new Mock<IModeloRepository>();
            modeloRepository.Setup(q => q.ObterPorIdAsync(_modelo.ModeloId))
                .Returns(Task.FromResult(_modelo));
            modeloRepository.Setup(q => q.ModeloPossuiPatrimonio(_modelo.ModeloId))
                .Returns(Task.FromResult(true));

            IExclusaoModeloDomainService domainService = new ExclusaoModeloDomainService(modeloRepository.Object);

            //act 
            Func<Task> act = async () => await domainService.ExcluirModeloAsync(_modelo.ModeloId);


            //assert
            act.Should().Throw<DomainException>();
        }


        [Fact]
        public async Task Deve_ser_valido_exclusao_modelo_quando_nao_possuir_patrimonios()
        {
            //arrange
            var modeloRepository = new Mock<IModeloRepository>();
            modeloRepository.Setup(q => q.ObterPorIdAsync(_modelo.ModeloId))
                .Returns(Task.FromResult(_modelo));
            modeloRepository.Setup(q => q.ModeloPossuiPatrimonio(_modelo.ModeloId))
                .Returns(Task.FromResult(false));

            IExclusaoModeloDomainService domainService = new ExclusaoModeloDomainService(modeloRepository.Object);

            //act 
            await domainService.ExcluirModeloAsync(_modelo.ModeloId);


            //assert
            _modelo.DomainEvents.Should().Contain(q => q.GetType() == typeof(ModeloExcluido));
        }



    }
}
