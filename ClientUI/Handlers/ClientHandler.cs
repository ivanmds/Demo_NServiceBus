using System;
using System.Threading.Tasks;
using ClientUI.Commands;
using NServiceBus;

namespace ClientUI.Handlers
{
    public class ClientHandler : IHandleMessages<ChangeClientNameCommand>,
                                 IHandleMessages<CreateNewClientCommand>
    {
        public Task Handle(ChangeClientNameCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine("Received ChangeClientName");
            return Task.CompletedTask;
        }

        public Task Handle(CreateNewClientCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine("Received CreateNewClient");
            return Task.CompletedTask;
        }
    }
}
