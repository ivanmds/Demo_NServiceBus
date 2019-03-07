using NServiceBus;
using System;

namespace ClientUI.Commands
{
    public class ChangeClientNameCommand : ICommand
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
