using Alarm501_MC;
using System;
using System.Windows.Forms;

namespace Alarm501_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model model = new Model();

            Controller controller = new Controller(model);

            Alarm501 view = new Alarm501(
                controller.EditAlarmHandler,
                controller.AddAlarmHandler,
                controller.SnoozeAlarmHandler,
                controller.StopAlarmHandler,
                controller.ModifyAlarmHandler,
                controller.ApplicationStartHandler,
                controller.ApplicationExitHandler);

            controller.UpdateAlarmListDelegate = view.UpdateAlarmListHandler;
            controller.ShowAlarmSoundedDelegate = view.ShowAlarmSoundedHandler;
            controller.ModifyAlarmDetailsDelegate = view.ModifyAlarmDetailsHandler;
            controller.DisableAlarmCreationDelegate = view.DisableAlarmCreationHandler;

            Application.Run(view);
        }
    }
}
