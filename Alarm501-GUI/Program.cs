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
                controller.AlarmSelectedHandler,
                controller.SnoozeAlarmHandler,
                controller.StopAlarmHandler,
                controller.EditFromClosedHandler,
                controller.FormShownHandler,
                controller.FormClosedHandler);

            controller.UpdateAlarmListDelegate = view.UpdateAlarmListHandler;
            controller.UpdateStateLabelDelegate = view.UpdateStateLabelHandler;
            controller.OpenAlarmEditFormDelegate = view.OpenAlarmEditFormHandler;
            controller.EnableAlarmEditingDelegate = view.EnableAlarmEditingHandler;
            controller.EnableAlarmDismissalDelegate = view.EnableAlarmDismissalHandler;
            controller.EnableAlarmCreationDelegate = view.EnableAlarmCreationHandler;
            controller.ShowNotificationDelegate = view.ShowNotificationHandler;

            Application.Run(view);
        }
    }
}
