using System;
using System.Runtime.CompilerServices;
namespace Alarm510_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleView view = new ConsoleView();

            //  Will be in a for loop
            view.AlarmInstructions();
            while (true)
            {
                
                string input = view.AwaitUserInput();

                if (input.Equals("exit"))
                {
                    Environment.Exit(0);
                }
                view.Manager(input);

            }




        }

        

    }
}