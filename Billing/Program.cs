using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Billing
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "Billing";

            var endpointConfiguration = new EndpointConfiguration("Billing");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();


            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
