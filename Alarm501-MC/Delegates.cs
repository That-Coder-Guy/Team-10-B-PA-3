namespace Alarm501_MC
{
    #region View Delegates
    /// <summary>
    /// Called by view to add alarm.
    /// </summary>
    public delegate void AddAlarm();

    /// <summary>
    /// Called by view to edit the alarm at a specific index.
    /// </summary>
    /// <param name="index">The target index.</param>
    public delegate void EditAlarm(int index);

    /// <summary>
    /// Called by the view to snooze all sounding alarms.
    /// </summary>
    public delegate void SnoozeAlarm();

    /// <summary>
    /// Called by the view to stop all sounding alarms.
    /// </summary>
    public delegate void StopAlarm();

    /// <summary>
    /// Called by the view to change details of a specific alarm.
    /// </summary>
    /// <param name="isConfirmed">Whether the alarm modification should go through.</param>
    /// <param name="index">The index of the alarm.</param>
    /// <param name="time">The modified time.</param>
    /// <param name="schedule">The modified schedule.</param>
    /// <param name="sound">The modified sound.</param>
    /// <param name="snoozePeriod">The modified snooze period.</param>
    /// <param name="enabled">The modified enabled state.</param>
    public delegate void FinishedModifyingAlarm(bool isConfirmed, int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    /// <summary>
    /// Called by the view to indicate the start of the application.
    /// </summary>
    public delegate void ApplicationStart();

    /// <summary>
    /// Called by the view to indicate the end of the application.
    /// </summary>
    public delegate void ApplicationExit();
    #endregion

    #region Controller Delegate
    /// <summary>
    /// Called by the controller to update the alarms displayed by the view.
    /// </summary>
    /// <param name="alarmStrings"></param>
    public delegate void UpdateAlarmList(string[] alarmStrings);

    /// <summary>
    /// Called by the controller to display that an alarm sounded in the view.
    /// </summary>
    /// <param name="message"></param>
    public delegate void ShowAlarmSounded(string message);

    /// <summary>
    /// Called by the controller to allow the view to edit a target alarm.
    /// </summary>
    /// <param name="index">The index of the alarm.</param>
    /// <param name="time">The original time.</param>
    /// <param name="schedule">The original schedule.</param>
    /// <param name="sound">The original sound.</param>
    /// <param name="snoozePeriod">The original snooze period.</param>
    /// <param name="enabled">The original enabled state.</param>
    public delegate void ModifyAlarmDetails(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    /// <summary>
    /// Called by the controller to disable the ability of the view to add an alarm.
    /// </summary>
    public delegate void DisableAlarmCreation();
    #endregion
}
