using Framework.RabbitMq.RabbitMqProxyConfig;
using System;

namespace Framework.RabbitMq.Model
{
    [RabbitMq("RabbitMq.Direct.QueueName", ExchangeName = "RabbitMq.Direct.ExchangeName", RoutingKey = "RabbitMq.Direct.RoutingKey", IsProperties = false)]
    public class MessageModel
    {
        public string Msg { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}