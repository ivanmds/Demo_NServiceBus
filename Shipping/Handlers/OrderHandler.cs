using System.Threading.Tasks;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping.Handlers
{
    public class OrderHandler : IHandleMessages<OrderPlacedEvent>,
                                IHandleMessages<OrderBilledEvent>
    {

        static ILog _log = LogManager.GetLogger<OrderHandler>();

        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            _log.Info($"Event OrderPlaced OrderId = { message.OrderId }.");

            return Task.CompletedTask;
        }

        public Task Handle(OrderBilledEvent message, IMessageHandlerContext context)
        {
            _log.Info($"Event OrderBilled OrderId = { message.OrderId }.");

            return Task.CompletedTask;
        }
    }
}
