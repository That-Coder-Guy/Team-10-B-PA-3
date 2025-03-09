using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm510_Console
{
    public class ConsoleView
    {
        /// <summary>
        /// The default constructor 
        /// </summary>
        public ConsoleView() 
        {
            Console.WriteLine("Welcome to CIS 501 - Alarms");
            Console.WriteLine("___________________________");
            Console.WriteLine("This is the current alarm list:\n");
            // Call delegate here to update the list of alarms

          

        }

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
            Console.Write("Input here: ");
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
                    // call add instructions
                    break;
                case "edit":
                    // call edit instructions
                    break;
                case "stop":
                    // call stop instructions
                    break;
                case "snooze":
                    // call snooze instructions
                    break;
                case "help":
                    AlarmInstructions();
                    break;
            }
        }


    }
}
