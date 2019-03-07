using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "ClientUI";
            var endpointConfiguration = new EndpointConfiguration("ClientUI");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();

            await RunLoop(endpointInstance).ConfigureAwait(false);

            await endpointInstance.Stop().ConfigureAwait(false);
        }

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Pess 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var command = new PlaceOrderCommand()
                        {
                            OrderId = Guid.NewGuid()
                        };
                        log.Info($"Sending PlaceOrderCommand, orderId = {command.OrderId}.");
                        await endpointInstance.SendLocal(command);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }

            }
        }
    }
}
