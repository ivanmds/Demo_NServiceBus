using NServiceBus;
using System;

namespace Messages.Events
{
    public class OrderBilledEvent : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
