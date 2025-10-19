using Microsoft.VisualBasic;
using Smart_Task_Organizer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Task
{
    internal class PersonalTask : TaskBase
    {
        private string location;
        public PersonalTask(string title, string description, DueDate date,string location , TaskPriority taskPriority) : base(title, description,date, taskPriority)
        {
            this.location = location;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($@"Personal Task:
title:       {titleTask}
description: {descriptionTask}
location:    {location}
date:        {dueDate}
priority:    {priority}
");
        }
    }
}
