using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Task_Organizer.Interfaces;
///TODO : Implement file operations for saving and loading tasks
///TODO : link with completed function
///TODO : generate report function
namespace Smart_Task_Organizer.Task
{
    internal class TaskManager : ISavable
    {
       // List<TaskBase> tasks = new List<TaskBase>();
        Dictionary<string, List<TaskBase>> categories = new Dictionary<string, List<TaskBase>>();
        string infoOfTask="";
        string[] partsOfInfo= { };
        string printed="";
        void ISavable.LoadFromFile(string title)
        {
            Console.WriteLine("Loading tasks from file...");
            foreach (var category in categories)
            {
                foreach (var task in category.Value)
                {
                    if (task.titleTask.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        partsOfInfo = GenerateReport(title).Trim().Split(',');
                        partsOfInfo.Select(x => x.Trim()).ToArray();
                    }
                }
            }
            for(int i =0; i< partsOfInfo.Length; i++)
            {
                Console.WriteLine($"{i+1}- {partsOfInfo[i]}");
            }
        }

        void ISavable.SaveToFile(string title)
        {
            Console.WriteLine("saving tasks to file...");
            foreach (var category in categories)
            {
                foreach (var task in category.Value)
                {
                    if (task.titleTask.Equals(title, StringComparison.OrdinalIgnoreCase))
                        printed = string.Join(",", partsOfInfo);
                }
            }
            Console.WriteLine(printed);
        }
        public void AddTask(string category, List<TaskBase> newTasks)
        {
            if (categories.TryGetValue(category, out var existingTasks))
            {
                existingTasks.AddRange(newTasks);
            }
            else
            {
                categories[category] = newTasks;
            }
        }
        public void DisplayAllTasks()
        {
            foreach (var category in categories)
            {
                foreach (var task in category.Value)
                {
                    task.DisplayDetails();
                }
            }
        }

        public void FindByTitle(string title)
        {
            bool isFound = false;
            foreach (var category in categories)
            {
                foreach (var task in category.Value) 
                { 
                    if(task.titleTask.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        task.DisplayDetails();
                        isFound = true;
                        return;
                    }
                }
            }
            if(!isFound)
                Console.WriteLine($"Task with title '{title}' not found");
        }
        public bool DeleteTask(string title)
        {
            foreach(var category in categories)
            {
                foreach (var task in category.Value)
                {
                    if (task.titleTask.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        categories[category.Key].Remove(task);
                        if (categories[category.Key] == null)
                        {
                            Console.WriteLine("Task is deleted.");
                        }
                            return true;
                    }
                }
            }
            Console.WriteLine($"This title '{title}' Not found");
            return false;
        }
        
        public string GenerateReport(string title)
        {
            StringBuilder report = new StringBuilder();
            
            foreach (var category in categories)
            {
                foreach (var task in category.Value)
                {
                    if (task.titleTask.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        report.AppendLine(string.Format("tiltle:{0,-20} ,comleted?:{1,-10} ,priority:{2,-10}", task.titleTask, task.isCompleted, task.priority));
                        infoOfTask = report.ToString();
                    }
                }
            }
            return infoOfTask;
        }
    }
}
