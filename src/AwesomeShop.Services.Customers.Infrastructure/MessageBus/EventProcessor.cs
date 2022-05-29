using AwesomeShop.Services.Customers.CrossCutting;
using AwesomeShop.Services.Customers.Domain.Events;
using AwesomeShop.Services.Customers.Domain.Interfaces.Events;
using AwesomeShop.Services.Customers.Domain.Interfaces.MessageBus;
using AwesomeShop.Services.Customers.Infrastructure.MessageBus.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Infrastructure.MessageBus
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMessageBusClient _bus;
        public EventProcessor(IMessageBusClient bus)
        {
            _bus = bus;
        }

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
        {
            return events.Select(Map);
        }

        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                CustomerCreated e => new CustomerCreatedIntegration(e.Id, e.FullName, e.Email),
                _ => null
            };

        public void Process(IEnumerable<IDomainEvent> events)
        {
            var integrationEvents = MapAll(events);

            foreach (var @event in integrationEvents)
            {
                _bus.Publish(@event, MapConvention(@event), "customer-service");
            }
        }

        private string MapConvention(IEvent @event)
        {
            return  @event.GetType().Name.ToDashCase();
        }
    }
}