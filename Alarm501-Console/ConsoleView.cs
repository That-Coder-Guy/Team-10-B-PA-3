using Alarm501_MC;

namespace Alarm501_Console
{
    public class ConsoleView
    {
        #region Fields
        private AddAlarm _addAlarmDelegate;

        private EditAlarm _editAlarmDelegate;

        private SnoozeAlarm _snoozeAlarmDelegate;

        private StopAlarm _stopAlarmDelegate;

        private FinishedModifyingAlarm _finishedModifyingAlarmDelegate;

        private ApplicationStart _applicationStartDelegate;

        private ApplicationExit _applicationExitDelegate;

        private string[] lastList = { "", "", "", "", "" };

        private int _amount = 0;

        private bool _maxAlarms = false;
        #endregion

        #region Methods
        /// <summary>
        /// The default constructor 
        /// </summary>
        public ConsoleView(
            EditAlarm editDelegate,
            AddAlarm addDelegate,
            SnoozeAlarm snoozeDelegate,
            StopAlarm stopDelegate,
            FinishedModifyingAlarm finishedModifyingDelegate,
            ApplicationStart startDelegate,
            ApplicationExit exitDelegate)
        {
            Console.WriteLine("Welcome to CIS 501 - Alarms\n");

            // Call delegate here to update the list of alarms

            // Subscribe delegates to the view methods
            _editAlarmDelegate = editDelegate;
            _addAlarmDelegate = addDelegate;
            _snoozeAlarmDelegate = snoozeDelegate;
            _stopAlarmDelegate = stopDelegate;
            _finishedModifyingAlarmDelegate = finishedModifyingDelegate;
            _applicationStartDelegate = startDelegate;
            _applicationExitDelegate = exitDelegate;

        }
        
        /// <summary>
        /// Updates the current state ie: alarm going off , quiet, snoozed etc
        /// </summary>
        public void UpdateStateLabelMethod(string message)
        {
            Console.WriteLine("\nThis is the current alarm list" +
                ":\n");
            UpdateAlarmListHandler(lastList);
            Console.WriteLine(message + "\n");
        }
        
        /// <summary>
        /// The instructions on how to perform certain operations in the alarm
        /// </summary>
        public void AlarmInstructions()
        {
            Console.WriteLine("\nType 'add' to add an alarm.");

            Console.WriteLine("Type 'edit', to edit an alarm.");

            Console.WriteLine("Type 'stop' to stop an alarm from going off.");

            Console.WriteLine("Type 'snooze' to snooze an alarm.");

            Console.WriteLine("Type 'help' to get instructions for the console.");

            Console.WriteLine("Type 'exit' to fully exit the program, \n");
        }
        
        /// <summary>
        /// Waits for the user to input a command
        /// </summary>
        public string AwaitUserInput()
        {
            Console.Write("Input alarm instruction: ");
            string input = "";
            do
            {
                input = (Console.ReadLine() ?? "").ToLower();
                Console.WriteLine();

            } while (!ValidInput(input));

            return input;


        }

        /// <summary>
        /// Checks if the user input is an acceptable input 
        /// </summary>
        /// <param name="input">the input the user entered</param>
        /// <returns></returns>
        public bool ValidInput(string input)
        {

            if (input != null && input.Length > 0)
            {
                if (input.Equals("add") || input.Equals("edit") || input.Equals("stop") || input.Equals("snooze") || input.Equals("exit") || input.Equals("help"))
                {
                    return true;
                }

            }
            Console.Write("Invalid input, try again.\nInput alarm instruction: ");
            return false;
        }

        /// <summary>
        /// Manages which function delegates the user should call
        /// </summary>
        /// <param name="input">User input.</param>
        public void Manager(string input)
        {
            switch (input)
            {
                case "add":
                    AddAlarmInstructions();
                    break;
                case "edit":
                    EditAlarmInstructions();
                    break;
                case "stop":
                    StopAlarms();
                    break;
                case "snooze":
                    SnoozeAlarms();
                    break;
                case "help":
                    AlarmInstructions();
                    break;
                case "exit":
                    _applicationExitDelegate();
                    Environment.Exit(0);
                    break;
            }
        }

        public void EditAlarmInstructions()
        {
            Console.Write("Enter the Index You Would Like to Edit: ");
            string s = Console.ReadLine() ?? "";
            int index = int.Parse(s) - 1;
            if (lastList[index].Equals(""))
            {
                Console.WriteLine("No alarm at index '" + (index + 1) + "'");
                return;
            }
            _editAlarmDelegate(index);
        }

        /// <summary>
        /// The instructions on how to add an alarm from the console view
        /// </summary>
        public void AddAlarmInstructions()
        {
            if (_maxAlarms)
            {
                Console.WriteLine("You have too many alarms. Please choose a different instruction.\n");
                return;
            }
            TimeSpan time = ReturnAlarmTime();
            bool[] schedule = ReturnAlarmSchedule(); ;
            AlarmSound sound = ReturnAlarmSound();
            uint snoozePeriod = ReturnAlarmSnoozePeriod();
            bool alarmEnabled = ReturnAlarmEnabled(); ;

            _finishedModifyingAlarmDelegate(true, -1, time, schedule, sound, snoozePeriod, alarmEnabled);


        }

        /// <summary>
        /// The method that calls the StopAlarmsDelegate
        /// </summary>
        public void StopAlarms()
        {
            _stopAlarmDelegate();
        }

        /// <summary>
        /// The method that calls the Snooze Alarm delegate
        /// </summary>
        public void SnoozeAlarms()
        {
            _snoozeAlarmDelegate();
        }

        public void ShowAlarmSoundedHandler(string message)
        {
            // throw new NotImplementedException();
            /*Console.WriteLine("\n-------------------------------");
            Console.WriteLine("This is the current alam list:\n");
            Console.WriteLine("-------------------------------");
            UpdateAlarmListHandler(lastList);
            Console.WriteLine(message);*/
            UpdateAlarmListHandler(lastList, message);
        }

        public void UpdateAlarmListHandler(string[] alarms)
        {
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| This is the current alarm list |");
            Console.WriteLine("+--------------------------------+");
            for (int i = 0; i < alarms.Length; i++)
            {
                //34 characters long  Make sure you accounted for the #s
                string alarm = $"| {i + 1}) {alarms[i]}";
                Console.Write($"| {i + 1}) {alarms[i]}");
                Console.Write(new string(' ', 33 - alarm.Length));
                Console.WriteLine("|");
            }
            Console.WriteLine("+--------------------------------+");

            Array.Copy(alarms, lastList, alarms.Length);
        }

        public void UpdateAlarmListHandler(string[] alarms , string msg)
        {
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| This is the current alarm list |");
            Console.WriteLine("+--------------------------------+");
            for (int i = 0; i < alarms.Length; i++)
            {
                //34 characters long  Make sure you accounted for the #s
                string alarm = $"| {i + 1}) {alarms[i]}";
                Console.Write($"| {i + 1}) {alarms[i]}");
                Console.Write(new string(' ', 33 - alarm.Length));
                Console.WriteLine("|");
            }
            Console.WriteLine("+--------------------------------+");

            Array.Copy(alarms, lastList, alarms.Length);
            Console.WriteLine(msg);
            Console.Write("\nInput alarm instruction: ");
        }

        public void DisableAlarmCreationHandler()
        {
            _maxAlarms = true;
        }

        public void ModifyAlarmDetailsHandler(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            if (index >= 0) {
                string input;
                do
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.WriteLine("Please choose from the following alarm settings to edit: ");
                    Console.WriteLine("Edit alarm time, type 'time'.");
                    Console.WriteLine("Edit alarm schedule, type 'schedule'.");
                    Console.WriteLine("Edit alarm sound, type 'sound'.");
                    Console.WriteLine("Edit alarm snooze period, type 'snooze'.");
                    Console.WriteLine("To enable/disable the alarm , type 'status'.");
                    Console.WriteLine("If you are done, type 'done'.");
                    Console.Write("Input here: ");

                    input = (Console.ReadLine() ?? "").ToLower();

                    switch (input)
                    {
                        case "time":
                            time = ReturnAlarmTime();
                            break;
                        case "schedule":
                            schedule = ReturnAlarmSchedule();
                            break;
                        case "sound":
                            sound = ReturnAlarmSound();
                            break;
                        case "snooze":
                            snoozePeriod = ReturnAlarmSnoozePeriod();
                            break;
                        case "status":
                            enabled = ReturnAlarmEnabled();
                            break;
                        case "done":
                            break;
                        default:
                            Console.WriteLine("Invalid Input Try Again :(");
                            break;
                    }
                } while (!input.Equals("done"));
                
                _finishedModifyingAlarmDelegate(true ,index, time, schedule, sound, snoozePeriod, enabled);
            }
        }

        private TimeSpan ReturnAlarmTime()
        {
            // TODO: User must be able to input time in a 12 hour format 

            Console.Write("Enter in the hour the alarm should be set off (in 24 hour format. 18 = 6PM. 6 = 6AM).\nEnter here: ");
            int hour;
            while (!int.TryParse(Console.ReadLine(), out hour) || hour > 24 || hour < 0)
            {
                Console.Write("Invalid input. Please enter a valid hour: ");
            }

            Console.Write("Enter in the minute the alarm should be set off.\nEnter here: ");
            int minute;
            while (!int.TryParse(Console.ReadLine(), out minute) || minute > 60 || minute < 0)
            {
                Console.Write("Invalid input. Please enter a valid minute: ");
            }

            Console.Write("Enter in the second the alarm should be set off.\nEnter here: ");
            int second;
            while (!int.TryParse(Console.ReadLine(), out second) || second > 60 || second < 0)
            {
                Console.Write("Invalid input. Please enter a valid second: ");
            }
            return new TimeSpan(hour, minute, second);
        }

        private bool[] ReturnAlarmSchedule()
        {
            // TODO: Add input validation so that only a string of 7 letters is accepted.
            int index;
            bool[] schedule = new bool[7];
            Console.Write("Enter in the days you want the alarm to be active for. Example (FTFFFFF) for only Monday active.\nEnter here: ");
            string scheduleInput = Console.ReadLine() ?? "";
            while (scheduleInput.Length != 7)
            {
                Console.Write("Invalid input, try again Example (FTFFFFF).\nEnter here: ");
                scheduleInput = Console.ReadLine() ?? "";
            }
            index = 0;
            foreach (char c in scheduleInput.ToUpper())
            {
                if (c == 'T')
                {
                    schedule[index] = true;
                }
                else
                {
                    schedule[index] = false;
                }
                index++;
            }
            return schedule;
        }

        private AlarmSound ReturnAlarmSound()
        {
            Console.WriteLine("Please input what sound you want from the following list.");
            List<string> soundNames = Enum.GetNames<AlarmSound>().ToList();
            soundNames.ForEach(Console.WriteLine);

            Console.Write("\nEnter here: ");
            string input = Console.ReadLine() ?? "";

            AlarmSound alarmSound;
            while (!Enum.TryParse(input, true, out alarmSound))
            {
                Console.Write("Invalid input, try again from the list\nEnter here: ");
                input = Console.ReadLine() ?? "";
            }

            return alarmSound;

            /*
            string[] sounds = new string[6];
            int index = 0;
            Console.Write("Please input what sound you want from the following list in exact type case..\n");
            foreach (AlarmSound s in Enum.GetValues(typeof(AlarmSound)))
            {
                Console.WriteLine(s.ToString());
                sounds[index] = s.ToString();
                index++;
            }
            Console.Write("\nEnter here: ");
            string sound = Console.ReadLine() ?? "";
            while (sound.Length == 0 || !sounds.Contains(sound))
            {
                Console.Write("Invalid input, try again from the list\nEnter here: ");
                sound = Console.ReadLine() ?? "";
            }
            AlarmSound alarmSound = AlarmSound.Radar;
            switch (sound)
            {
                case "Radar":
                    alarmSound = AlarmSound.Radar;
                    break;
                case "Beacon":
                    alarmSound = AlarmSound.Beacon;
                    break;
                case "Chimes":
                    alarmSound = AlarmSound.Chimes;
                    break;
                case "Circuit":
                    alarmSound = AlarmSound.Circuit;
                    break;
                case "Reflection":
                    alarmSound = AlarmSound.Reflection;
                    break;
                case "NoSound":
                    alarmSound = AlarmSound.NoSound;
                    break;
            }
            return alarmSound;
            */
        }

        private uint ReturnAlarmSnoozePeriod()
        {
            uint snoozePeriod = 0;
            Console.Write("\nEnter in the snooze period in minutes from 1 - 30.\nEnter here: ");

            string input = Console.ReadLine() ?? "";
            if (input == "") snoozePeriod = 0;
            else snoozePeriod = uint.Parse(input);

            while (snoozePeriod < 1 || snoozePeriod > 30)
            {
                Console.Write("\nInvalid input, please try again from 1 - 30 minutes.\nEnter here: ");

                input = Console.ReadLine() ?? "";
                if (input == "") snoozePeriod = 0;
                else snoozePeriod = uint.Parse(input);
            }
            return snoozePeriod;
        }

        private bool ReturnAlarmEnabled()
        {
            string enabled;
            Console.Write("Do you want this alarm to be enabled? (Y/N): ");
            enabled = Console.ReadLine() ?? "";
            while (enabled.ToUpper() != "Y" && enabled.ToUpper() != "N")
            {
                Console.Write("Invalid input, try again. (Y/N): ");
                enabled = Console.ReadLine() ?? "";
            }
            bool alarmEnabled;
            if (enabled.ToUpper() == "Y") { alarmEnabled = true; }
            else { alarmEnabled = false; }
            return alarmEnabled;
        }

        public void ApplicationStartup()
        {
            _applicationStartDelegate();
        }
        #endregion
    }
}
