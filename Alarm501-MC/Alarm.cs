using System.Diagnostics;
using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Alarm501_MC1
{
    public delegate void AlarmSoundedHandler(Alarm sender);

    public class Alarm
    {
        public event AlarmSoundedHandler? Sounded;

        #region Fields
        private TimeSpan _time = TimeSpan.MinValue;

        private Timer _timer = new Timer();

        private bool _enabled = false;
        #endregion

        #region Properties
        public TimeSpan Time
        {
            get => _time;
            set
            {
                if (value > new TimeSpan(23, 59, 59))
                {
                    _time = value - new TimeSpan(23, 0, 0);
                }
                else if (value < new TimeSpan(1, 0, 0))
                {
                    _time = value + new TimeSpan(24, 0, 0);
                }
                _time = value;

                if (Enabled) Start();
            }
        }

        public bool[] Schedule { get; set; } = new bool[7];

        public AlarmSound Sound { get; set; } = AlarmSound.Radar;

        public uint SnoozePeriod { get; set; } = 1;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (!_enabled && value) Start();
                else if (_enabled && !value) Stop();
                _enabled = value;
            }
        }
        #endregion

        #region Methods
        public Alarm(TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            Time = time;
            Schedule = schedule;
            Sound = sound;
            SnoozePeriod = snoozePeriod;
            Enabled = enabled;
        }

        public void Snooze()
        {
            _timer.Dispose();
            _timer = new Timer(SnoozePeriod * 60 * 1000);
            _timer.Elapsed += TriggerAlarm;
            _timer.Start();
        }

        private void Start()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            double timeUntilAlarmSounds;
            if (currentTime < Time)
            {
                // Trigger is later today
                timeUntilAlarmSounds = (Time - currentTime).TotalMilliseconds;
            }
            else
            {
                // Trigger is tomorrow
                timeUntilAlarmSounds = (TimeSpan.FromHours(24) - currentTime + Time).TotalMilliseconds;
            }
            Debug.Print($"{timeUntilAlarmSounds / 1000} seconds");
            _timer.Dispose();
            _timer = new Timer(timeUntilAlarmSounds);
            _timer.Elapsed += TriggerAlarm;
            _timer.Start();
        }

        private void Stop()
        {
            if (_timer.Enabled)
            {
                _timer.Enabled = false;
            }
        }

        private void TriggerAlarm(object? sender, ElapsedEventArgs e)
        {
            if (Schedule[(int)DateTime.Now.DayOfWeek])
            {
                Debug.Print("Alarm Triggered");
                Sounded?.Invoke(this);
            }
            if (Enabled) Start();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (Time.Hours > 12) builder.Append($"{Time.Hours - 12}:{Time.Minutes:00} ");
            else builder.Append($"{Time.Hours}:{Time.Minutes:00} ");
            if (Time.Hours >= 12) builder.Append("pm");
            else builder.Append("am");

            builder.Append("\t ");
            builder.Append(Enabled ? "On" : "Off");
            return builder.ToString();
        }
        #endregion
    }
}
