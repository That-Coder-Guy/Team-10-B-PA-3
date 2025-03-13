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

            Console.WriteLine("Type 'exit' to fully exit and save the program.\n");
        }
        
        /// <summary>
        /// Waits for the user to input a command.
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

        /// <summary>
        /// selects the index to edit the alarm at
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ShowAlarmSoundedHandler(string message)
        {
            UpdateAlarmListHandler(lastList, message);
        }

        /// <summary>
        /// displays and updates alarms at the begining
        /// </summary>
        /// <param name="alarms">the list of alarms</param>
        public void UpdateAlarmListHandler(string[] alarms)
        {
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| This is the current alarm list |");
            Console.WriteLine("+--------------------------------+");
            for (int i = 0; i < alarms.Length; i++)
            {
                string alarm = $"| {i + 1}) {alarms[i]}";
                Console.Write($"| {i + 1}) {alarms[i]}");
                Console.Write(new string(' ', 33 - alarm.Length));
                Console.WriteLine("|");
            }
            Console.WriteLine("+--------------------------------+");

            Array.Copy(alarms, lastList, alarms.Length);
        }

        /// <summary>
        /// Updating the alarm list
        /// </summary>
        /// <param name="alarms">the list of alarms</param>
        /// <param name="msg">the msg for the alarm going off</param>
        public void UpdateAlarmListHandler(string[] alarms , string msg)
        {
            Console.WriteLine("\n+--------------------------------+");
            Console.WriteLine("| This is the current alarm list |");
            Console.WriteLine("+--------------------------------+");
            for (int i = 0; i < alarms.Length; i++)
            {
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

        /// <summary>
        /// 
        /// </summary>
        public void DisableAlarmCreationHandler()
        {
            _maxAlarms = true;
        }

        /// <summary>
        /// Calls the modifying alarm handler
        /// </summary>
        /// <param name="index">the alarm index to edit</param>
        /// <param name="time">the time to set the alarm for</param>
        /// <param name="schedule">the schedule for the alarm</param>
        /// <param name="sound">the sound for the alarm</param>
        /// <param name="snoozePeriod">the amount of time to snooze the alarm for</param>
        /// <param name="enabled">if the alarm is enabled or not</param>
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

        /// <summary>
        /// Returns the timespan for the alarm time
        /// </summary>
        /// <returns> Returns a timespan  </returns>
        private TimeSpan ReturnAlarmTime()
        {
            Console.Write("Enter in the hour the alarm should be set off (in 12 hour format -> 1-12).\nEnter here: ");
            int hour;
            while (!int.TryParse(Console.ReadLine(), out hour) || hour > 12 || hour < 1)
            {
                Console.Write("Invalid input. Please enter a valid hour: ");
            }

            Console.Write("Please enter if the alarm should be 'AM' or 'PM'\nEnter here: ");
            string meridiem = Console.ReadLine() ?? "";
            while ((!meridiem.ToLower().Equals("am")) && (!meridiem.ToLower().Equals("pm")))
            {

                Console.Write("Please enter 'AM' or 'PM'\nEnter here: ");
                meridiem = Console.ReadLine() ?? "";
            }

            
            if (meridiem.ToLower().Equals("pm"))
            {
                hour += 12;
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

        /// <summary>
        /// returns a bool array for what the user wants to enter 
        /// </summary>
        /// <returns>A bool array for what is happenigng<returns>
        private bool[] ReturnAlarmSchedule()
        {
            int index;
            bool[] schedule = new bool[7];
            Console.Write("Enter in the days you want the alarm to be active for. Example (FTFFFFF) for only Monday active.\nEnter here: ");
            string scheduleInput = (Console.ReadLine() ?? "").ToUpper();
            while (scheduleInput.Length != 7 || !scheduleInput.All(c => c == 'T' || c == 'F'))
            {
                Console.Write("Invalid input, try again. Example (FTFFFFF) for only Monday active.\nEnter here: ");
                scheduleInput = (Console.ReadLine() ?? "").ToUpper();
                
            }
            index = 0;
            foreach (char c in scheduleInput)
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

        /// <summary>
        /// Returns the sound that the User wants to use
        /// </summary>
        /// <returns>the alarm enumeration sound</returns>
        private AlarmSound ReturnAlarmSound()
        {
            Console.WriteLine("Please input what sound you want from the following list.");
            List<string> soundNames = Enum.GetNames<AlarmSound>().ToList();
            Console.WriteLine();
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
        }

        /// <summary>
        /// Returns the amount of time the alarm should snooze for
        /// </summary>
        /// <returns>returns a uint for snooze time in min</returns>
        private uint ReturnAlarmSnoozePeriod()
        {
            uint snoozePeriod = 0;
            Console.Write("\nEnter in the snooze period in minutes from 1 - 30.\nEnter here: ");

            string input = Console.ReadLine() ?? "";
            if (input == "")
            {
                snoozePeriod = 0;
            }
            else
            {
                snoozePeriod = uint.Parse(input);
            }

            while (snoozePeriod < 1 || snoozePeriod > 30)
            {
                Console.Write("\nInvalid input, please try again from 1 - 30.\nEnter here: ");

                input = Console.ReadLine() ?? "";
                if (input == "")
                {
                    snoozePeriod = 0;
                }
                else
                {
                    snoozePeriod = uint.Parse(input);
                }
            }
            return snoozePeriod;
        }
        
        /// <summary>
        /// Runs the code to get if the alarm should be enabled or not
        /// </summary>
        /// <returns>returns a bool if it is enable</returns>
        private bool ReturnAlarmEnabled()
        {
            
            Console.Write("Do you want this alarm to be enabled? (Y/N): ");
            string input = Console.ReadLine() ?? "";
            while (input.ToUpper() != "Y" && input.ToUpper() != "N")
            {
                Console.Write("Invalid input, try again. (Y/N): ");
                input = Console.ReadLine() ?? "";
            }
            bool alarmEnabled;
            if (input.ToUpper() == "Y") { alarmEnabled = true; }
            else { alarmEnabled = false; }
            return alarmEnabled;
        }

        /// <summary>
        /// calls the controllers startup delegate
        /// </summary>
        public void ApplicationStartup()
        {
            _applicationStartDelegate();
        }
        #endregion
    }
}
