namespace Alarm501_MC
{
    #region View Delegates
    public delegate void AddAlarm();

    public delegate void EditAlarm(int index);

    public delegate void AlarmSelected(int index);

    public delegate void SnoozeAlarm();

    public delegate void StopAlarm();

    public delegate void ModifyAlarm(bool isConfirmed, int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    public delegate void ApplicationStart();

    public delegate void ApplicationExit();
    #endregion

    #region Controller Delegate
    public delegate void UpdateAlarmList(string[] alarmStrings);

    public delegate void ShowNotification(string message);

    public delegate void OpenAlarmEditForm(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    public delegate void EnableAlarmEditing(bool enabled);  // GUI specific

    public delegate void EnableAlarmDismissal(bool enabled);  // GUI specific

    public delegate void EnableAlarmCreation(bool enabled);  // GUI specific
    #endregion
}
