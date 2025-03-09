using System.Diagnostics;
using System.Text.Json;

namespace Alarm501_MC1
{
    public class Model
    {
        #region Events
        public event AlarmSoundedHandler? AlarmSounded;
        #endregion

        #region Fields
        private List<Alarm> _triggteredAlarms = new List<Alarm>();
        #endregion

        #region Properties
        public List<Alarm> Alarms { get; } = new List<Alarm>();

        public bool HasMaximiumAlarms => Alarms.Count > 4;
        #endregion

        #region Methods
        public Model()
        {
            if (File.Exists("alarms.txt"))
            {
                if (JsonSerializer.Deserialize<List<Alarm>>(File.ReadAllText("alarms.txt")) is List<Alarm> alarms)
                {
                    Alarms = alarms;
                    Alarms.ForEach(alarm => alarm.Sounded += OnAlarmSounded);
                }
                else
                {
                    throw new InvalidDataException("The contents of alarms.txt was formatted incorrectly.");
                }
            }
        }

        public Alarm CreateNewAlarm(TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            if (HasMaximiumAlarms) throw new InvalidOperationException();
            Alarm alarm = new Alarm(time, schedule, sound, snoozePeriod, enabled);
            alarm.Sounded += OnAlarmSounded;
            Alarms.Add(alarm);
            return alarm;
        }

        public void SnoozeAll()
        {
            _triggteredAlarms.ForEach(alarm => alarm.Snooze());
            _triggteredAlarms.Clear();
        }

        public void StopAll()
        {
            _triggteredAlarms.Clear();
        }

        public string[] AlarmsToStrings()
        {
            return Alarms.Select(alarm => alarm.ToString()).ToArray();
        }

        public void SaveAlarms()
        {
            string json = JsonSerializer.Serialize(Alarms);
            File.WriteAllText("alarms.txt", json);
        }

        private void OnAlarmSounded(Alarm sender)
        {
            Debug.Print("Triggered");
            _triggteredAlarms.Add(sender);
            AlarmSounded?.Invoke(sender);
        }
        #endregion
    }
}
