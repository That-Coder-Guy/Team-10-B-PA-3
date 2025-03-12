using Alarm501_MC;
namespace Alarm501_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            ConsoleView view = new ConsoleView(
                controller.EditAlarmHandler,
                controller.AddAlarmHandler,
                controller.SnoozeAlarmHandler,
                controller.StopAlarmHandler,
                controller.FinishedModifyAlarmHandler,
                controller.ApplicationStartHandler,
                controller.ApplicationExitHandler);

            controller.UpdateAlarmListDelegate = view.UpdateAlarmListHandler;
            controller.ShowAlarmSoundedDelegate = view.ShowAlarmSoundedHandler;
            controller.ModifyAlarmDetailsDelegate = view.ModifyAlarmDetailsHandler;
            controller.DisableAlarmCreationDelegate = view.DisableAlarmCreationHandler;

            view.ApplicationStartup();

            view.AlarmInstructions();
            while (true)
            {

                string input = view.AwaitUserInput();


                view.Manager(input);
            }

        }
    }
}