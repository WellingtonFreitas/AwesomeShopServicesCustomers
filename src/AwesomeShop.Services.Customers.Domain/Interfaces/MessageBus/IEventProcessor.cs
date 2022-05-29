using AwesomeShop.Services.Customers.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Domain.Interfaces.MessageBus
{
    public interface IEventProcessor
    {
        void Process(IEnumerable<IDomainEvent> events);
    }
}
