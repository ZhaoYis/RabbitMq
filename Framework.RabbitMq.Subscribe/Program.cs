using Topshelf;

namespace Framework.RabbitMq.Subscribe
{
    internal class Program
    {
        //https://www.cnblogs.com/jys509/p/4614975.html
        private static void Main(string[] args)
        {
            HostFactory.Run(config =>
            {
                config.SetServiceName("serviceName".ValueOfAppSetting());

                config.Service<MainService>(ser =>
                {
                    ser.ConstructUsing(name => new MainService());
                    ser.WhenStarted((service, control) => service.Start());
                    ser.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
}