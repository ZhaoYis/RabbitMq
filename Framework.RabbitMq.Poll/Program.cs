using Topshelf;

namespace Framework.RabbitMq.Pull
{
    internal class Program
    {
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