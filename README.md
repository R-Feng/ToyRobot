# ToyRobot
## Environment
1. Visual Studio 2019 or 2022
2. .NET Core 3.1
## Build the solution:
On the menu bar, choose Build > Build Solution, or press Ctrl+Shift+B.
The Output window displays the results of the build. The build succeeded.
## Run the solution:
On the menu bar, choose Debug > Start Without Debugging, or press Ctrl+F5.
A console application window pops up where you can input the robot commends.
## Notes
* This is a C# .NET Core 3.1 Console application. Please build and run it using Visual Studio 2019 or above.
* There are 20 unit tests in ToyRobot.Test MSTest project covering RobotRepository, RobotService and RobotCommendProcessor.
* The solution utilises dependency injection, where RobotRepository, RobotService, RobotCommendProcessor and RobotConsole are stateless which are singleton, while RobotState is stateful which is transient.

Please let me know if you need anything else. Many thanks!
