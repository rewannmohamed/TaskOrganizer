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
            // TaskManager Tmanager = new TaskManager();
            InputHelper inputHelper = new();
            while (true)
            {
                Console.WriteLine("1. Add Task\n2. View Tasks\n3. Delete Task\n4. Generate Report\n5. reminder\n6. Undo Last Action\n7. Search task\n8. Exit\n");
                int choice = int.Parse(Console.ReadLine()!);
                switch (choice) 
                {
                    case 1:  
                        inputHelper.inputTask();
                        break;
                    case 2:
                        inputHelper.HandleDisplayTasks();
                        break;
                    case 3:
                        inputHelper.HandleDelete();
                        break;
                    case 4:
                        inputHelper.HandleGenerateReport();
                        break;
                    case 5:
                        Reminder reminder = new();
                        reminder.HandleReminder();
                        break;
                    case 6:

                    //case 7:
                    //    Tmanager.FindByTitle(Console.ReadLine()!);
                    //    break;
                    case 8:
                        return;
                
                }
            }

            //List<TaskBase> personalTasks = new List<TaskBase>
            //{
            //    new PersonalTask("Grocery Shopping", "Buy groceries for the week", new DueDate(4,4,2025), "Supermarket",TaskPriority.Low),
            //    new PersonalTask("Doctor Appointment", "Annual check-up", new DueDate(20,10,2025), "Clinic",TaskPriority.High)
            //};
            //Tmanager.AddTask("Personal", personalTasks);
            //personalTasks.Add(new WorkTask("login page", "Authentication & validation", "my work",new DueDate(5,5,2025),TaskPriority.Medium));//reference type


           // Tmanager.DisplayAllTasks();
           // ISavable savable = Tmanager;
           // Console.WriteLine("----------------");
           // savable.LoadFromFile("login page");
           // Console.WriteLine("----------------");
           // savable.SaveToFile("Doctor Appointment");
           // Console.WriteLine("----------------");
           // Tmanager.FindByTitle("Gym Session");
           // Console.WriteLine("----------------");
           // Tmanager.FindByTitle("login page");
           // Console.WriteLine("----------------");
           // Tmanager.DeleteTask("Grocery Shopping");
           // Console.WriteLine("----------------");
           // Tmanager.DeleteTask("Grocery");
           // Console.WriteLine("----------------");
           // 
           // Console.WriteLine("----------------");
           //Console.WriteLine(Tmanager.GenerateReport("Doctor Appointment"));
           
        }
    }
}


