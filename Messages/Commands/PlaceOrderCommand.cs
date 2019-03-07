using System;
using NServiceBus;

namespace Messages.Commands
{
    public class PlaceOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
