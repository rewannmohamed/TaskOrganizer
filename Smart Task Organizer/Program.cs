using Smart_Task_Organizer.Interfaces;
using Smart_Task_Organizer.quotes;
using Smart_Task_Organizer.Task;
using Smart_Task_Organizer.Utilities;
using Smart_Task_Organizer.AppConfig;
using Smart_Task_Organizer.Reminders;
namespace Smart_Task_Organizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"App name:{ AppConfig.AppConfig.AppName}");
            Console.WriteLine(AppConfig.AppConfig.LaunchTime);
            Console.WriteLine(RandomQuotes.GenerateRandomQuote());
            InputHelper inputHelper = new();
            Stack<(string ActionType, TaskBase Task)> actions = new();
            while (true)
            {
                Console.WriteLine("1. Add Task\n2. View Tasks\n3. Delete Task\n4. Generate Report\n5. reminder\n6. Undo Last Action\n7. Search task\n8. Exit\n");
                int choice = int.Parse(Console.ReadLine()!);
                switch (choice) 
                {
                    case 1:  
                        inputHelper.inputTask(actions);
                        break;
                    case 2:
                        inputHelper.HandleDisplayTasks();
                        break;
                    case 3:
                        inputHelper.HandleDelete(actions);
                        break;
                    case 4:
                        inputHelper.HandleGenerateReport();
                        break;
                    case 5:
                        Reminder reminder = new();
                        reminder.HandleReminder();
                        break;
                    case 6:
                        inputHelper.HandleUndo(actions);
                        break;
                    case 7:
                        inputHelper.HandleSearch();
                        break;
                    case 8:
                        return;
                
                }
            }

        }
    }
}


