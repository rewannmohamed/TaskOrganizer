using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Task_Organizer.quotes
{
    internal class RandomQuotes
    {
        static string[] quotes = { "Keep going!", "You got this!", "Stay focused!","small steps, big results" };
        static Random rnd = new Random();
        public static string GenerateRandomQuote(){
            string quote = quotes[rnd.Next(quotes.Length)];
            return quote;
        }  
    }
}
