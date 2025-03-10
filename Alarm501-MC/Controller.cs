using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Alarm501_MC
{
    public class Controller
    {
        #region Fields
        private Model _model;
        #endregion

        #region Properties
        public UpdateAlarmList? UpdateAlarmListDelegate { get; set; }

        public OpenAlarmEditForm? OpenAlarmEditFormDelegate { get; set; }

        public EnableAlarmEditing? EnableAlarmEditingDelegate { get; set; }

        public EnableAlarmDismissal? EnableAlarmDismissalDelegate { get; set; }

        public EnableAlarmCreation? EnableAlarmCreationDelegate { get; set; }

        public ShowNotification? ShowNotificationDelegate { get; set; }
        #endregion

        #region Static Methods
        private static bool IsConsoleApp()
        {
            return Environment.UserInteractive &&
                Console.OpenStandardInput(1) != Stream.Null;
        }

        private static bool IsWinFromsApp()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name is string name && name.Equals("System.Windows.Forms", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Methods
        public Controller(Model model)
        {
            _model = model;
            _model.AlarmSounded += OnAlarmSounded;
        }

        private void OnAlarmSounded(Alarm sender)
        {
            EnableAlarmDismissalDelegate?.Invoke(true);
            ShowNotificationDelegate?.Invoke($"{sender.Sound}");
        }

        public void EditAlarmHandler(int index)
        {
            Alarm alarm = _model.Alarms[index];
            OpenAlarmEditFormDelegate?.Invoke(index, alarm.Time, alarm.Schedule, alarm.Sound, alarm.SnoozePeriod, alarm.Enabled);
        }

        public void AddAlarmHandler()
        {
            OpenAlarmEditFormDelegate?.Invoke(
                -1,
                new TimeSpan(9, 30, 0),
                [false, true, true, true, true, true, false],
                AlarmSound.Radar,
                1u,
                false);
        }

        public void AlarmSelectedHandler(int index)
        {
            EnableAlarmEditingDelegate?.Invoke(true);
        }

        public void SnoozeAlarmHandler()
        {
            _model.SnoozeAll();
            ShowNotificationDelegate?.Invoke(string.Empty);
            EnableAlarmDismissalDelegate?.Invoke(false);
        }

        public void StopAlarmHandler()
        {
            _model.StopAll();

            ShowNotificationDelegate?.Invoke(string.Empty);
            EnableAlarmDismissalDelegate?.Invoke(false);
        }

        public void ModifyAlarmHandler(bool isConfirmed, int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            if (isConfirmed)
            {
                if (index >= 0)
                {
                    Alarm alarm = _model.Alarms[index];
                    alarm.Time = time;
                    alarm.Schedule = schedule;
                    alarm.Sound = sound;
                    alarm.SnoozePeriod = snoozePeriod;
                    alarm.Enabled = enabled;
                }
                else
                {
                    _model.CreateNewAlarm(time, schedule, sound, snoozePeriod, enabled);
                }

                EnableAlarmEditingDelegate?.Invoke(false);
                if (_model.HasMaximiumAlarms)
                {
                    EnableAlarmCreationDelegate?.Invoke(false);
                }
                UpdateAlarmListDelegate?.Invoke(_model.AlarmsToStrings());
            }
        }

        public void ApplicationStartHandler()
        {
            EnableAlarmEditingDelegate?.Invoke(false);
            EnableAlarmDismissalDelegate?.Invoke(false);
            if (_model.HasMaximiumAlarms)
            {
                EnableAlarmCreationDelegate?.Invoke(false);
            }
            UpdateAlarmListDelegate?.Invoke(_model.AlarmsToStrings());
        }

        public void ApplicationExitHandler()
        {
            _model.SaveAlarms();
        }
        #endregion
    }
}
