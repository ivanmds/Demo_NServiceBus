using NServiceBus;
using System;

namespace ClientUI.Commands
{
    public class CreateNewClientCommand : ICommand
    {
        public CreateNewClientCommand()
        {
            ClientId = Guid.NewGuid();
        }

        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
