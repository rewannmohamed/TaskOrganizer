using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Utilities
{
    public enum TaskPriority { Low, Medium, High }

    [Flags]
    public enum TaskTag
    {
        None = 0,
        Work = 1,
        Home = 2,
        Urgent = 4,
        Study = 8,
        Health = 16
    }
    ///TODO: how to store multiple tag values using bitwise enums and apply them to objects.
}
