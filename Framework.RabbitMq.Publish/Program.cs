﻿using Framework.RabbitMq.Model;
using Framework.RabbitMq.RabbitMqProxyConfig;
using System;

namespace Framework.RabbitMq.Publish
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rabbitMqProxy = new RabbitMqService(new MqConfig
            {
                AutomaticRecoveryEnabled = true,
                HeartBeat = 60,
                NetworkRecoveryInterval = new TimeSpan(60),
                Host = "localhost",
                UserName = "guest",
                Password = "guest"
            });

            var input = Input();

            while (input != "exit")
            {
                var log = new MessageModel
                {
                    CreateDateTime = DateTime.Now,
                    Msg = input
                };
                rabbitMqProxy.Publish(log, ExchangeTypeCode.Direct);

                input = Input();
            }

            rabbitMqProxy.Dispose();
        }

        private static string Input()
        {
            Console.WriteLine("请输入信息：");
            var input = Console.ReadLine();
            return input;
        }
    }
}