using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.AppConfig
{
    public static class AppConfig
    {
        public const string AppName = "Smart Task Organizer";
        public static readonly DateTime LaunchTime = DateTime.Now;
        public static string DataFile = "tasks.txt";
    }
}
