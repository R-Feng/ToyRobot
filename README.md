# ToyRobot
## Environment
1. Visual Studio 2019 (2022 should also work, but I don't have it installed on my home computer)
2. .NET Core 3.1
## Notes
* This is a C# .NET Core 3.1 Console application. Please build and run it using Visual Studio 2019 or above.
* There are unit test cases in ToyRobot.Test MSTest project.
* The solution utilises dependency injection, where RobotRepository, RobotService, RobotCommendProcessor and RobotConsole are stateless which are singleton, while RobotState is stateful which is transient.

Please let me know if you need anything else. Many thanks!
