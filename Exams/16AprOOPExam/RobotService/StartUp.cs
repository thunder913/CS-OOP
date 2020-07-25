namespace RobotService
{
    using RobotService.Core;
    using RobotService.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var value = 5.5555555555555555;
            System.Console.WriteLine($"{value:f2}");
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
