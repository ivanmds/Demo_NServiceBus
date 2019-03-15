using NServiceBus;
using System;

namespace Messages.Events
{
    public class OrderPlacedEvent : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
