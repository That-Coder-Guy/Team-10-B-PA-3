using Alarm501_MC;
using System.Diagnostics;

namespace Alarm501_GUI
{
    public partial class Alarm501 : Form
    {
        #region Fields
        private AddAlarm _addAlarmDelegate;

        private EditAlarm _editAlarmDelegate;

        private AlarmSelected _alarmSelectedDelegate;

        private SnoozeAlarm _snoozeAlarmDelegate;

        private StopAlarm _stopAlarmDelegate;

        private ModifyAlarm _editFromClosedDelegate;
        
        private ApplicationStart _fromShownDelegate;

        private ApplicationExit _formClosedDelegate;
        #endregion

        #region Methods
        public Alarm501(
            EditAlarm editDelegate,
            AddAlarm addDelegate,
            AlarmSelected selectedDelegate,
            SnoozeAlarm snoozeDelegate,
            StopAlarm stopDelegate,
            ModifyAlarm editClosedDelegate,
            ApplicationStart shownDelegate,
            ApplicationExit closedDelegate)
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

        public void OpenAlarmEditFormHandler(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            // TODO: Refactor this method signature to only take in a bool and an Alarm
            AddEditAlarm addEditAlarm = new AddEditAlarm(index, time, schedule, sound, snoozePeriod, enabled);
            bool isConfirmed = addEditAlarm.ShowDialog() == DialogResult.OK;
            _editFromClosedDelegate.Invoke(isConfirmed, addEditAlarm.AlarmIndex, addEditAlarm.Time, addEditAlarm.Schedule, addEditAlarm.Sound, addEditAlarm.SnoozePeriod, addEditAlarm.AlarmEnabled);
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

        public void ShowNotificationHandler(string message)
        {
            Invoke(new Action(() => {
                uxStateLabel.Text = message;
            }));

            if (message != string.Empty)
            {
                // TODO: Add something to notify the user if the window is not on top
                string title = "An alarm went off!";
                Debug.Print($"{title} : {message}");  // Remove this line
            }
            
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
            uxEditAlarm.Enabled = true;
            //_alarmSelectedDelegate.Invoke(uxAlarmList.SelectedIndex);
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
