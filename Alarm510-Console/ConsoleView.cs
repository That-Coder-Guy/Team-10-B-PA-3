using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm510_Console
{
    public class ConsoleView
    {

        public ConsoleView() 
        {
            
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

        

        





    }
}
