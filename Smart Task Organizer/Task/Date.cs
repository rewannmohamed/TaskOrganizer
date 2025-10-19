using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Task
{
  struct DueDate
    {
        public int Day;
        public int Month;
        public int Year;
        public DueDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString() => $"{Day}/{Month}/{Year}";
    }
}
