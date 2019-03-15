using System.Threading.Tasks;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Billing.Handlers
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlacedEvent>
    {
        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");

            var orderBillied = new OrderBilledEvent { OrderId = message.OrderId };
            return context.Publish(orderBillied);
        }
    }
}
