﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("Welcome to CIS 501 - Alarms");

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
            Console.WriteLine("\nTo add an alarm, type 'add'.");

            Console.WriteLine("To edit an alarm, type 'edit'.");

            Console.WriteLine("To stop an alarm from going off, type 'stop'.");

            Console.WriteLine("To snooze an alarm, type 'snooze'.");

            Console.WriteLine("To get instructions for the console, type 'help'.");

            Console.WriteLine("To fully exit the program, type 'exit'.\n");
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
                input = Console.ReadLine() ?? "";

            } while (!ValidInput(input.ToLower()));

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
            Console.Write("\nInvalid input, try again.\nInput alarm instruction: ");
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
                    // call edit instructions
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
        /// The instructions on how to add an alarm from the console view
        /// </summary>
        public void AddAlarmInstructions()
        {
            if (_maxAlarms)
            {
                Console.WriteLine("You have too many alarms. Please choose a different instruction.\n");
                return;
            }

            Console.Write("Enter in the hour the alarm should be set off (in 24 hour format. 18 = 6PM. 6 = 6AM).\nEnter here: ");
            int hour;
            while (!int.TryParse(Console.ReadLine(), out hour) || hour > 24 || hour < 0) {
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
            TimeSpan time = new TimeSpan(hour, minute, second);


            bool[] schedule = new bool[7];
            Console.Write("Enter in the days you want the alarm to be active for. Example(TFFFFF) for only monday active.\nEnter here: ");
            string scheduleInput = Console.ReadLine() ?? "";
            while (scheduleInput.Length == 0 || scheduleInput.Length > 7)
            {
                Console.Write("Invalid input, try again Example(TFFFFF).\nEnter here: ");
                scheduleInput = Console.ReadLine() ?? "";
            }
            int index = 0;
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

            string[] sounds = new string[5];
            index = 0;
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
            }

            Console.Write("Enter in the snooze period in minutes from 0 - 30.\nEnter here: ");
            int snoozePeriod = Int32.Parse(Console.ReadLine() ?? "");
            while (snoozePeriod < 0 || snoozePeriod > 30)
            {
                Console.Write("Invalid input, please try again from 0 - 30 minutes.\nEnter here: ");
                snoozePeriod = Int32.Parse(Console.ReadLine() ?? "");
            }

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
            _finishedModifyingAlarmDelegate(true, -1, time, schedule, alarmSound, (uint)snoozePeriod, alarmEnabled);


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


        public void AddEditAlarmInstructions()
        {

        }
        
        public void ShowAlarmSoundedHandler(string message)
        {
            // throw new NotImplementedException();
            /*Console.WriteLine("\n-------------------------------");
            Console.WriteLine("This is the current alarm list:\n");
            Console.WriteLine("-------------------------------");
            UpdateAlarmListHandler(lastList);
            Console.WriteLine(message);*/
            UpdateAlarmListHandler(lastList, message);
            
        }

        public void UpdateAlarmListHandler(string[] alarms)
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("This is the current alarm list:\n");
            Console.WriteLine("-------------------------------");
            for (int i = 0; i < alarms.Length; i++)
            {
                Console.WriteLine(alarms[i]);
            }
            Array.Copy(alarms, lastList, alarms.Length);
        }

        public void UpdateAlarmListHandler(string[] alarms , string msg)
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("This is the current alarm list:\n");
            Console.WriteLine("-------------------------------");
            for (int i = 0; i < alarms.Length; i++)
            {
                Console.WriteLine(alarms[i]);
            }
            Array.Copy(alarms, lastList, alarms.Length);
            Console.WriteLine(msg);
            Console.Write("\nInput alarm instruction: ");
        }


        public void DisableAlarmCreationHandler()
        {
            _maxAlarms = true;

           // throw new NotImplementedException();
        }

        public void ModifyAlarmDetailsHandler(int index, TimeSpan time, bool[] schedule, AlarmSound sound, uint snoozePeriod, bool enabled)
        {
            throw new NotImplementedException();
        }

        public void ApplicationStartup()
        {
            _applicationStartDelegate();
        }
        #endregion
    }
}
