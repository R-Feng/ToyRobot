using System;
using System.Linq;
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
            services.AddTransient<IRobot, Robot.Robot>();
            services.AddSingleton<IRobotRepository, RobotRepository>();
            services.AddSingleton<IRobotService, RobotService>();
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
            var robotService = ServiceProvider.GetRequiredService<IRobotService>();
            Console.WriteLine("Welcome to Toy Robot. Please start with your first commend.");
            var running = true;
            do
            {
                Console.Write(">");
                var commend = Console.ReadLine();
                if (commend == null)
                {
                    continue;
                }

                try
                {
                    if (commend.StartsWith("PLACE", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var commendParameters = commend.Split(' ').Where(c => !string.IsNullOrWhiteSpace(c))
                            .Select(c => c.Trim()).ToArray();
                        if (commendParameters.Length != 2)
                        {
                            Console.WriteLine("Wrong commend parameter. Only PLACE X, Y, DIRECTION is supported.");
                            continue;
                        }

                        var robotParameters = commendParameters[1].Split(',').Where(c => !string.IsNullOrWhiteSpace(c))
                            .Select(c => c.Trim()).ToArray();
                        if (robotParameters.Length == 2)
                        {
                            robotService.Place(Convert.ToInt32(robotParameters[0]), Convert.ToInt32(robotParameters[1]));
                        }
                        else if (robotParameters.Length == 3)
                        {
                            robotService.Place(Convert.ToInt32(robotParameters[0]), Convert.ToInt32(robotParameters[1]),
                                Enum.Parse<Direction>(robotParameters[2], true));
                        }
                        else
                        {
                            Console.WriteLine("Wrong robot parameter. Only PLACE X, Y, DIRECTION is supported.");
                        }

                        continue;
                    }

                    if (commend.StartsWith("MOVE", StringComparison.CurrentCultureIgnoreCase))
                    {
                        robotService.Move();
                        continue;
                    }

                    if (commend.StartsWith("LEFT", StringComparison.CurrentCultureIgnoreCase))
                    {
                        robotService.Left();
                        continue;
                    }

                    if (commend.StartsWith("RIGHT", StringComparison.CurrentCultureIgnoreCase))
                    {
                        robotService.Right();
                        continue;
                    }

                    if (commend.StartsWith("REPORT", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine(robotService.Report());
                        Console.WriteLine("Please press <Enter> to continue, please any other key to exit.");
                        running = Console.ReadKey().Key == ConsoleKey.Enter;
                    }
                    else
                    {
                        Console.WriteLine("Wrong commend. Only PLACE, MOVE, LEFT, RIGHT and REPORT are supported.");
                    }
                }
                catch (RobotNotPlacedException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (running);

            DisposeServices();
        }
    }
}
