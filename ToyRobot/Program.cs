using System;
using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Robot;

namespace ToyRobot
{
    public class Program
    {
        public static IServiceProvider ServiceProvider;

        public static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IRobotState, RobotState>();
            services.AddSingleton<IRobotRepository, RobotRepository>();
            services.AddSingleton<IRobotService, RobotService>();
            services.AddSingleton<IRobotCommendProcessor, RobotCommendProcessor>();
            services.AddSingleton<IRobotConsole, RobotConsole>();
            ServiceProvider = services.BuildServiceProvider(true);
        }

        public static void DisposeServices()
        {
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        static void Main(string[] args)
        {
            RegisterServices();

            ServiceProvider.GetRequiredService<IRobotConsole>().Run();

            DisposeServices();
        }
    }
}
