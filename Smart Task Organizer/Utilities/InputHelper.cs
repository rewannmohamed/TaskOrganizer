using Smart_Task_Organizer.Task;
using Smart_Task_Organizer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Smart_Task_Organizer.Utilities
{
    internal class InputHelper
    {
        TaskManager insertedTask = new();
        public static bool TryGetPriority(string input, out TaskPriority priority)
        {
            return Enum.TryParse(input, true, out priority);
        }

        public static void SwapTitles(ref string title1, ref string title2)
        {
            string temp = title1;
            title1 = title2;
            title2 = temp;
        }

        public void inputTask()
        {
            List<TaskBase> tasks = new List<TaskBase>();
            tasks.Add(inputNewTask(out string category));
            insertedTask.AddTask(category, tasks);
            Console.WriteLine("\nTask added successfully!");
            insertedTask.DisplayAllTasks();
        }

        public TaskBase inputNewTask(out string category)
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine()! ?? "no title";
            Console.Write("Enter description: ");
            string description = Console.ReadLine()! ?? " ";
            DueDate date = HandleDate();           
            TaskPriority priority = HandleTaskPriority();
            TaskBase task = HandleTaskType(title,description, date, priority, out category);
            return task;
        }

        public DueDate HandleDate()
        {
            Console.Write(@"Enter date seperated by '/' without spaces ex.. DD/MM/YYYY: ");
            string date = Console.ReadLine() ?? DateTime.Now.ToString("dd/MM/yyyy");
            int day, month, year;

            while (true)
            {
                if (DateTime.TryParseExact(date, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime validDate))
                {
                    day = validDate.Day;
                    month = validDate.Month;
                    year = validDate.Year;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Expected DD/MM/YYYY");
                    date = Console.ReadLine() ?? DateTime.Now.ToString("dd/MM/yyyy");
                }
            }

            return new DueDate(day, month, year);
        }
        public TaskPriority HandleTaskPriority()
        {
            Console.WriteLine("Enter task priority ( Low, medium, high): ");
            string priority = Console.ReadLine()!;
            bool isValidPriority = Enum.TryParse<TaskPriority>(priority, true, out TaskPriority taskPriority);
            while (!isValidPriority)
            {
                Console.WriteLine("Invalid priority. Enter Valid priority: ");
                priority = Console.ReadLine()!;
                isValidPriority = Enum.TryParse<TaskPriority>(priority, true, out taskPriority);
            }
            return taskPriority;
        }

        public TaskBase HandleTaskType(string title, string description, DueDate date, TaskPriority priority, out string category)
        {
            //string category;
            while (true)
            {
                Console.WriteLine("Choose task type:\n1 - Personal task\n2 - Work task ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Please enter a number (1 or 2). ");
                    continue;//“Don’t execute the switch part below — jump back to the start of the while (true) loop and ask again.”
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter location: ");
                        string location = Console.ReadLine() ?? string.Empty;
                        category = "Personal Task";
                        return new PersonalTask(title, description, date, location, priority);

                    case 2:
                        Console.Write("Enter project Name: ");
                        string projectName = Console.ReadLine() ?? string.Empty;
                        category = "Work Task";
                        return new WorkTask(title, description, projectName, date, priority);

                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2. ");
                        break;
                }
            }
        }

        public void HandleDelete()
        {
            if (insertedTask.getCount() == 0)
                Console.WriteLine("No Tasks");
            else
            {
                Console.WriteLine("Which task you want to delete?");
                string title = Console.ReadLine()!;
                insertedTask.DeleteTask(title);
            }
        }
        public void HandleGenerateReport()
        {
            if (insertedTask.getCount() == 0)
                Console.WriteLine("No Tasks");
            else
            {
                Console.WriteLine("Which task you want to generate report?");
                string title = Console.ReadLine()!;
                Console.WriteLine(insertedTask.GenerateReport(title));
            }
        }

        public void HandleDisplayTasks()
        {
            if (insertedTask.getCount() == 0)
                Console.WriteLine("No Tasks");
            else
            {
                insertedTask.DisplayAllTasks();
            }
        }

    }
}
