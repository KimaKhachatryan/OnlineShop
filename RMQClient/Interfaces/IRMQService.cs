using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQClient.Interfaces
{
    public interface IRMQService : IDisposable
    {
        void Publish<T>(string exchange, string routingKey, T message);
        void Consume(string exchange, string queue, string routingKey, Action<string> onMessageReceived);
    }
}
