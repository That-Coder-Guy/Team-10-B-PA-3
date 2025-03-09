using Alarm501_MC;
namespace Alarm501_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Model model = new Model();
            Controller controller = new Controller(model);
            ConsoleView view = new ConsoleView(
                controller.AddAlarmHandler,
                controller.EditAlarmHandler,                
                controller.AlarmSelectedHandler,
                controller.SnoozeAlarmHandler,
                controller.StopAlarmHandler,
                controller.EditFromClosedHandler,
                controller.FormShownHandler,
                controller.FormClosedHandler);

            view.AlarmInstructions();
            while (true)
            {
                
                string input = view.AwaitUserInput();

                if (input.Equals("exit"))
                {
                    Environment.Exit(0);
                }
                view.Manager(input);

            }
            
        }
    }
}