using Framework.RabbitMq.RabbitMqProxyConfig;
using System;

namespace Framework.RabbitMq.Model
{
    [RabbitMq("RabbitMq.Rpc.QueueName", ExchangeName = "RabbitMq.Rpc.ExchangeName", RoutingKey = "RabbitMq.Rpc.RoutingKey", IsProperties = false)]
    public class RpcMsgModel
    {
        public string Msg { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}