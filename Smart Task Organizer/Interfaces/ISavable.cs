using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Interfaces
{
    internal interface ISavable
    {
        void SaveToFile(string title);
        void LoadFromFile(string title);
    }
}
