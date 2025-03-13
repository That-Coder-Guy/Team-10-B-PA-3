using Alarm501_MC;
using System.Diagnostics;

namespace Alarm501_GUI
{
    public partial class Alarm501 : Form
    {
        #region Fields
        private AddAlarm _addAlarmDelegate;

        private EditAlarm _editAlarmDelegate;

        private SnoozeAlarm _snoozeAlarmDelegate;

        private StopAlarm _stopAlarmDelegate;

        private FinishedModifyingAlarm _finishedModifyingAlarmDelegate;
        
        private ApplicationStart _applicationStartDelegate;

        private ApplicationExit _applicationExitDelegate;
        #endregion

        #region Methods
        public Alarm501(
            EditAlarm editDelegate,
            AddAlarm addDelegate,
            SnoozeAlarm snoozeDelegate,
            StopAlarm stopDelegate,
            FinishedModifyingAlarm finishedModifyingDelegate,
            ApplicationStart startDelegate,
            ApplicationExit exitDelegate)
        {
            InitializeComponent();

            _editAlarmDelegate = editDelegate;
            _addAlarmDelegate = addDelegate;
            _snoozeAlarmDelegate = snoozeDelegate;
            _stopAlarmDelegate = stopDelegate;
            _finishedModifyingAlarmDelegate = finishedModifyingDelegate;
            _applicationStartDelegate = startDelegate;
            _applicationExitDelegate = exitDelegate;
        }

        public void UpdateAlarmListHandler(string[] alarmStrings)
        {

            uxEditAlarm.Enabled = false;
            uxAlarmList.Items.Clear();
            uxAlarmList.Items.AddRange(alarmStrings);
        }
        

        public void ModifyAlarmDetailsHandler(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            AddEditAlarm addEditAlarm = new AddEditAlarm(index, time, schedule, sound, snoozePeriod, enabled);
            bool isConfirmed = addEditAlarm.ShowDialog() == DialogResult.OK;
            _finishedModifyingAlarmDelegate.Invoke(isConfirmed, addEditAlarm.AlarmIndex, addEditAlarm.Time, addEditAlarm.Schedule, addEditAlarm.Sound, addEditAlarm.SnoozePeriod, addEditAlarm.AlarmEnabled);
        }

        public void DisableAlarmCreationHandler()
        {
            uxAddAlarm.Enabled = false;
        }

        public void ShowAlarmSoundedHandler(string message)
        {
            Invoke(new Action(() => {
                uxStateLabel.Text = message;
            }));

            if (message != string.Empty)
            {
                Invoke(new Action(() => {
                    uxStopAlarm.Enabled = true;
                    uxSnoozeAlarm.Enabled = true;
                }));
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
        }

        private void OnSnoozeAlarmClicked(object sender, EventArgs e)
        {
            uxStopAlarm.Enabled = false;
            uxSnoozeAlarm.Enabled = false;
            _snoozeAlarmDelegate.Invoke();
        }

        private void OnStopAlarmClicked(object sender, EventArgs e)
        {
            uxStopAlarm.Enabled = false;
            uxSnoozeAlarm.Enabled = false;
            _stopAlarmDelegate.Invoke();
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            uxEditAlarm.Enabled = false;
            uxStopAlarm.Enabled = false;
            uxSnoozeAlarm.Enabled = false;
            _applicationStartDelegate.Invoke();
        }

        private void OnFromClosed(object sender, FormClosedEventArgs e)
        {
            _applicationExitDelegate.Invoke();
        }
        #endregion
    }
}
