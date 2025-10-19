using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.Reminders
{
    internal class Reminder
    {
        Queue<string> reminders = new Queue<string>();
        public void CreateReminder(string newReminder)
        {
            reminders.Enqueue(newReminder);
        }
        public void DisplayReminders()
        {
            foreach (var reminder in reminders)
            {
                reminders.Peek();
            }
        }
        public void ReminderDone()
        {
            reminders.Dequeue();
        }

        public void HandleReminder()
        {
            while (true)
            {
                Console.WriteLine("1.create new reminder\n2.display reminders\n 3.finish reminder");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Please enter a number (1 or 2 or 3). ");
                    continue;//“Don’t execute the switch part below — jump back to the start of the while (true) loop and ask again.”
                }
                switch (choice) 
                {
                    case 1:
                        Console.WriteLine("Enter title of reminder");
                        string reminder = Console.ReadLine()!;
                        CreateReminder(reminder);
                        break;
                    case 2:
                        DisplayReminders();
                        break;
                    case 3:
                        ReminderDone();
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }
    }
}
