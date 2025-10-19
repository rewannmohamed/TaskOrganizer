using Microsoft.VisualBasic;
using Smart_Task_Organizer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Task
{
    internal class WorkTask : TaskBase
    {
        private string projectName;
        public WorkTask(string title, string description, string projectName, DueDate date ,TaskPriority taskPriority) : base(title, description, date, taskPriority)
        {
            this.projectName = projectName;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($@"Work task:
title:       {titleTask}
description: {descriptionTask}
location:    {projectName}
date:        {dueDate}
priority:    {priority}
");
        }
    }
}
