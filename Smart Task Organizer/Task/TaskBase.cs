using Microsoft.VisualBasic;
using Smart_Task_Organizer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Task
{
    internal abstract class TaskBase
    {
        internal string titleTask;
        protected string descriptionTask;
        public bool isCompleted;
        protected DueDate dueDate;
        public TaskPriority priority;

        public TaskBase(string title, string description,DueDate date, TaskPriority taskPriority)
        {
            this.titleTask = title;
            this.descriptionTask = description;
            this.isCompleted = false;
            this.dueDate = date;
            this.priority = taskPriority;
        }
        public virtual void IsCompleted()
        {
             isCompleted = true;
        }
        public abstract void DisplayDetails();
    }
}
