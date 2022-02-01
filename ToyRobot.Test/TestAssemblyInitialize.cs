using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobot.Test
{
    [TestClass]
    public class TestAssemblyInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Program.RegisterServices();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Program.DisposeServices();
        }
    }
}
