using Framework.RabbitMq.Model;
using Framework.RabbitMq.RabbitMqProxyConfig;
using System;

namespace Framework.RabbitMq.Subscribe
{
    /// <summary>
    /// 自动获取队列消息
    /// </summary>
    public class MainService
    {
        private readonly RabbitMqService _rabbitMqProxy;

        public MainService()
        {
            _rabbitMqProxy = new RabbitMqService(new MqConfig
            {
                AutomaticRecoveryEnabled = true,
                HeartBeat = 60,
                NetworkRecoveryInterval = new TimeSpan(60),
                Host = "localhost",
                UserName = "guest",
                Password = "guest"
            });
        }

        public bool Start()
        {
            _rabbitMqProxy.Subscribe<MessageModel>(msg =>
            {
                var json = msg.ToJson();
                Console.WriteLine(json);
            }, ExchangeTypeCode.Direct);

            return true;
        }

        public bool Stop()
        {
            _rabbitMqProxy.Dispose();
            return true;
        }
    }
}