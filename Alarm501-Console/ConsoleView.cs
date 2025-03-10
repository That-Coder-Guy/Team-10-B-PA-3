using System;
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

        private AlarmSelected _alarmSelectedDelegate;

        private SnoozeAlarm _snoozeAlarmDelegate;

        private StopAlarm _stopAlarmDelegate;

        private FinishedModifyingAlarm _editFromClosedDelegate;

        private FormShown _fromShown;

        private FormClosed _formClosed;
        #endregion


        /// <summary>
        /// The default constructor 
        /// </summary>
        public ConsoleView(
            AddAlarm add,
            EditAlarm edit,
            AlarmSelected selectAlarm,
            SnoozeAlarm snoozeAlarm,
            StopAlarm stopAlarm,
            FinishedModifyingAlarm editFormClose,
            FormShown showForm,
            FormClosed closeForm)
        {
            Console.WriteLine("Welcome to CIS 501 - Alarms");
            Console.WriteLine("___________________________");
            Console.WriteLine("This is the current alarm list:\n");
            // Call delegate here to update the list of alarms

            // Subscribe delegates to the view methods
            _addAlarmDelegate = add;
            _editAlarmDelegate = edit;
            _alarmSelectedDelegate = selectAlarm;
            _snoozeAlarmDelegate = snoozeAlarm;
            _stopAlarmDelegate = stopAlarm;
            _editFromClosedDelegate = editFormClose;            
            _fromShown = showForm;
            _formClosed = closeForm;







        }

        private int _alarmAmount = 0;
        private string[] lastList = { "" };

        /// <summary>
        /// Updates the alarms in the console view
        /// </summary>
        /// <param name="alarms">the list of alarms</param>
        public void UpdateAlarmView(string[] alarms)
        {
            for (int i = 0; i < alarms.Length; i++)
            {
                Console.WriteLine(alarms[i]);
            }
            _alarmAmount = alarms.Length;
            Array.Copy(alarms, lastList, alarms.Length);
        }

        /// <summary>
        /// Updates the current state ie: alarm going off , quiet, snoozed etc
        /// </summary>
        public void UpdateStateLabelMethod(string message)
        {
            Console.WriteLine("\nThis is the current alarm list:\n");
            UpdateAlarmView(lastList);
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
            Console.Write("\nInvalid input, try again.\nInput here: ");
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
            }
        }


        /// <summary>
        /// The instructions on how to add an alarm from the console view
        /// </summary>
        public void AddAlarmInstructions()
        {
            if (_alarmAmount >= 5)
            {
                Console.WriteLine("You have too many alarms. Please choose a different instruction.\n");
                return;
            }

            string format = "yyyy-MM-dd hh:mm tt"; // this is the specific format for alarm datetime. only in 12 hour format.

            Console.Write($"Please enter in the alarm time, example being 2025-03-09 09:45 AM. '{format}'.\n This is only in 12-hour format!\nEnter here: ");
            string input = Console.ReadLine() ?? "";

            DateTime time;
            if (DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out time))
            {
                Console.WriteLine($"Success! Alarm set for {time}");
            }
            else
            {
                Console.Write($"Failed. Please try again with this format {format}\nEnter here: ");
            }

        }


        /// <summary>
        /// The method that calls the StopAlarmsDelegate
        /// </summary>
        public void StopAlarms()
        {

            // StopAlarm();


        }

        /// <summary>
        /// The method that calls the Snooze Alarm delegate
        /// </summary>
        public void SnoozeAlarms()
        {
            //SnoozeAlarm();
        }


        public void AddEditAlarmInstructions()
        {

        }

    }
}
