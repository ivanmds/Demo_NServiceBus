using System.Threading.Tasks;
using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales.Handlers
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrderCommand>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrderCommand message, IMessageHandlerContext context)
        {
            log.Info($"Received PlaceOrderCommand, OrderId = {message.OrderId}");

            var orderPlaced = new OrderPlacedEvent { OrderId = message.OrderId };
            return context.Publish(orderPlaced);
        }
    }
}
