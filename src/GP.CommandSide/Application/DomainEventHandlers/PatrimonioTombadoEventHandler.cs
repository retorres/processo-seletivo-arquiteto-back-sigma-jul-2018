using GP.CommandSide.Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GP.CommandSide.Application.DomainEventHandlers
{
    public class PatrimonioTombadoEventHandler : INotificationHandler<PatrimonioTombado>
    {
        public PatrimonioTombadoEventHandler()
        {

        }
        public Task Handle(PatrimonioTombado notification, CancellationToken cancellationToken)
        {
            //TODO: Faz alguma coisa!
            //Exemplo: Coloca em uma fila para outro ponto do sistema fazer 
            //uma visao materializada dos patrimonios.
            //Pode ser adicionado também, envio de email, comunicação com serviços externos, etc.

            return Task.CompletedTask;
        }
    }
}
