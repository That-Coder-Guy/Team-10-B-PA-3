using Alarm501_MC;
using System;
using System.Windows.Forms;

namespace Alarm501_GUI
{
    public partial class AddEditAlarm : Form
    {
        #region Properties
        public int AlarmIndex { get; }

        public TimeSpan Time { get; private set; }

        public bool[] Schedule { get; private set; }

        public AlarmSound Sound { get; private set; }

        public uint SnoozePeriod { get; private set; }

        public bool AlarmEnabled { get; private set; }
        #endregion

        #region Methods
        public AddEditAlarm(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            InitializeComponent();
            AlarmIndex = index;
            Time = time;
            Schedule = schedule;
            Sound = sound;
            SnoozePeriod = snoozePeriod;
            AlarmEnabled = enabled;

            uxTimePicker.Value = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                time.Hours,
                time.Minutes,
                time.Seconds);

            uxSundayCheckBox.Checked = schedule[0];
            uxMondayCheckBox.Checked = schedule[1];
            uxTuesdayCheckBox.Checked = schedule[2];
            uxWednesdayCheckBox.Checked = schedule[3];
            uxThursdayCheckBox.Checked = schedule[4];
            uxFridayCheckBox.Checked = schedule[5];
            uxSaturdayCheckBox.Checked = schedule[6];

            uxSoundComboBox.Items.AddRange(Enum.GetNames(typeof(AlarmSound)));
            uxSoundComboBox.SelectedIndex = (int)sound;

            uxSnoozePeriodNumericUpDown.Value = snoozePeriod;

            uxOnCheckBox.Checked = AlarmEnabled;

            
        }

        private void SetPressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Time = uxTimePicker.Value.TimeOfDay;

            Schedule = new bool[7] {
                uxSundayCheckBox.Checked,
                uxMondayCheckBox.Checked,
                uxTuesdayCheckBox.Checked,
                uxWednesdayCheckBox.Checked,
                uxThursdayCheckBox.Checked,
                uxFridayCheckBox.Checked,
                uxSaturdayCheckBox.Checked
            };

            Sound = (AlarmSound)uxSoundComboBox.SelectedIndex;

            SnoozePeriod = (uint)uxSnoozePeriodNumericUpDown.Value;

            AlarmEnabled = uxOnCheckBox.Checked;
        }

        private void CancelPressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
