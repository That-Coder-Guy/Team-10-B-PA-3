using Microsoft.Toolkit.Uwp.Notifications;
using System.Security.Policy;

namespace Alarm501_MC1
{
    #region Delegate
    public delegate void UpdateAlarmList(string[] alarmStrings);

    public delegate void UpdateStateLabel(string message);

    public delegate void OpenAlarmEditForm(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    public delegate void EnableAlarmEditing(bool enabled);

    public delegate void EnableAlarmDismissal(bool enabled);

    public delegate void EnableAlarmCreation(bool enabled);

    public delegate void ShowNotification(string title, string message);
    #endregion

    public class Controller
    {
        #region Fields
        private Model _model;
        #endregion

        #region Properties
        public UpdateAlarmList? UpdateAlarmListDelegate { get; set; }

        public UpdateStateLabel? UpdateStateLabelDelegate { get; set; }

        public OpenAlarmEditForm? OpenAlarmEditFormDelegate { get; set; }

        public EnableAlarmEditing? EnableAlarmEditingDelegate { get; set; }

        public EnableAlarmDismissal? EnableAlarmDismissalDelegate { get; set; }

        public EnableAlarmCreation? EnableAlarmCreationDelegate { get; set; }

        public ShowNotification? ShowNotificationDelegate { get; set; }
        #endregion

        #region Methods
        public Controller(Model model)
        {
            _model = model;
            _model.AlarmSounded += OnAlarmSounded;
        }

        private void OnAlarmSounded(Alarm sender)
        {
            UpdateStateLabelDelegate?.Invoke($"{sender.Sound}");
            EnableAlarmDismissalDelegate?.Invoke(true);
            ShowNotificationDelegate?.Invoke("An alarm went off!", $"{sender.Sound}");
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
            if (index >= 0)
            {
                EnableAlarmEditingDelegate?.Invoke(true);
            }
            else
            {
                EnableAlarmEditingDelegate?.Invoke(true);
            }
        }

        public void SnoozeAlarmHandler()
        {
            _model.SnoozeAll();
            UpdateStateLabelDelegate?.Invoke("");
            EnableAlarmDismissalDelegate?.Invoke(false);
        }

        public void StopAlarmHandler()
        {
            _model.StopAll();
            UpdateStateLabelDelegate?.Invoke("");
            EnableAlarmDismissalDelegate?.Invoke(false);
        }

        public void EditFromClosedHandler(DialogResult result, int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            if (result == DialogResult.OK)
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

        public void FormShownHandler()
        {
            EnableAlarmEditingDelegate?.Invoke(false);
            EnableAlarmDismissalDelegate?.Invoke(false);
            if (_model.HasMaximiumAlarms)
            {
                EnableAlarmCreationDelegate?.Invoke(false);
            }
            UpdateAlarmListDelegate?.Invoke(_model.AlarmsToStrings());
        }

        public void FormClosedHandler()
        {
            _model.SaveAlarms();
        }
        #endregion
    }
}
