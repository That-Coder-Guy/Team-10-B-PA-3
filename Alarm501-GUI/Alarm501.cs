using Alarm501_MC;
using System.Diagnostics;



namespace Alarm501_GUI
{
    #region View Delegates
    public delegate void AddAlarm();

    public delegate void EditAlarm(int index);

    public delegate void AlarmSelected(int index);

    public delegate void SnoozeAlarm();

    public delegate void StopAlarm();

    public delegate void EditFormClosed(DialogResult result, int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled);

    public delegate void FormShown();

    public delegate void FormClosed();
    #endregion

    public partial class Alarm501 : Form
    {
        #region Fields
        private AddAlarm _addAlarmDelegate;

        private EditAlarm _editAlarmDelegate;

        private AlarmSelected _alarmSelectedDelegate;

        private SnoozeAlarm _snoozeAlarmDelegate;

        private StopAlarm _stopAlarmDelegate;

        private EditFormClosed _editFromClosedDelegate;
        
        private FormShown _fromShownDelegate;

        private FormClosed _formClosedDelegate;
        #endregion

        #region Methods
        public Alarm501(
            EditAlarm editDelegate,
            AddAlarm addDelegate,
            AlarmSelected selectedDelegate,
            SnoozeAlarm snoozeDelegate,
            StopAlarm stopDelegate,
            EditFormClosed editClosedDelegate,
            FormShown shownDelegate,
            FormClosed closedDelegate)
        {
            InitializeComponent();

            _editAlarmDelegate = editDelegate;
            _addAlarmDelegate = addDelegate;
            _alarmSelectedDelegate = selectedDelegate;
            _snoozeAlarmDelegate = snoozeDelegate;
            _stopAlarmDelegate = stopDelegate;
            _editFromClosedDelegate = editClosedDelegate;
            _fromShownDelegate = shownDelegate;
            _formClosedDelegate = closedDelegate;
        }

        public void UpdateAlarmListHandler(string[] alarmStrings)
        {
            uxAlarmList.Items.Clear();
            uxAlarmList.Items.AddRange(alarmStrings);
        }

        public void UpdateStateLabelHandler(string message)
        {
            Invoke(new Action(() => {
                uxStateLabel.Text = message;
            }));
        }

        public void OpenAlarmEditFormHandler(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            AddEditAlarm addEditAlarm = new AddEditAlarm(index, time, schedule, sound, snoozePeriod, enabled);
            DialogResult result = addEditAlarm.ShowDialog();
            _editFromClosedDelegate.Invoke(result, addEditAlarm.AlarmIndex, addEditAlarm.Time, addEditAlarm.Schedule, addEditAlarm.Sound, addEditAlarm.SnoozePeriod, addEditAlarm.AlarmEnabled);
        }

        public void EnableAlarmEditingHandler(bool enabled)
        {
            uxEditAlarm.Enabled = enabled;
        }

        public void EnableAlarmDismissalHandler(bool enabled)
        {
            Invoke(new Action(() =>
            {
                uxSnoozeAlarm.Enabled = enabled;
                uxStopAlarm.Enabled = enabled;
            }));
        }

        public void EnableAlarmCreationHandler(bool enable)
        {
            uxAddAlarm.Enabled = enable;
        }

        public void ShowNotificationHandler(string title, string message)
        {
            Debug.Print("Hello");
        }

        private void OnEditAlarmClicked(object sender, EventArgs e)
        {
            _editAlarmDelegate.Invoke(uxAlarmList.SelectedIndex);
        }

        private void OnAddAlarmClicked(object sender, EventArgs e)
        {
            _addAlarmDelegate.Invoke();
        }

        private void OnAlarmSelected(object sender, EventArgs e)
        {
            _alarmSelectedDelegate.Invoke(uxAlarmList.SelectedIndex);
        }

        private void OnSnoozeAlarmClicked(object sender, EventArgs e)
        {
            _snoozeAlarmDelegate.Invoke();
        }

        private void OnStopAlarmClicked(object sender, EventArgs e)
        {
            _stopAlarmDelegate.Invoke();
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            _fromShownDelegate.Invoke();
        }

        private void OnFromClosed(object sender, FormClosedEventArgs e)
        {
            _formClosedDelegate.Invoke();
        }
        #endregion
    }
}
