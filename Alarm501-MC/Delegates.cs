namespace Alarm501_MC
{
    #region View Delegates
    public delegate void AddAlarm();

    public delegate void EditAlarm(int index);

    public delegate void SnoozeAlarm();

    public delegate void StopAlarm();

    public delegate void FinishedModifyingAlarm(bool isConfirmed, int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    public delegate void ApplicationStart();

    public delegate void ApplicationExit();
    #endregion

    #region Controller Delegate
    public delegate void UpdateAlarmList(string[] alarmStrings);

    public delegate void ShowNotification(string message);

    public delegate void ModifyAlarmDetails(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    public delegate void EnableAlarmDismissal();

    public delegate void DisableAlarmCreation();
    #endregion
}
