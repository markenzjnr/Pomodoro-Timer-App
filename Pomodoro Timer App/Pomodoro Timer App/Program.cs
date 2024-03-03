using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pomodoro_Timer_App
{
     internal class Program
    {
        static void Main(string[] args)
        {
            int pomodoroDurationMinutes = 1;
            int countdownSeconds = pomodoroDurationMinutes * 60;

            Console.WriteLine("Pomodoro Timer started!");
            Console.WriteLine($"Counting down from {pomodoroDurationMinutes} minutes...");
            
            //Loop until the countdown reaches zero
            while (countdownSeconds > 0)
            {
                Console.WriteLine($"Time remaining: {FormatTime(countdownSeconds)}");
                System.Threading.Thread.Sleep(1000); //sleep for 1 second
                countdownSeconds--;   
            }

            Console.WriteLine("Time's up! Starting beep....");
            Console.Beep();
            BeepForDuration(5000);//this is for the beep to last for 5 secods

            Console.WriteLine("Pomodoro Timer finished! Time to take a break!");
        }

        private static void BeepForDuration(int durationMilliseconds)
        {
            int startTime = Environment.TickCount; //Get the current tick count
            while (Environment.TickCount - startTime < durationMilliseconds)
            {
                Console.Beep();
                Thread.Sleep(200); // Sleep for 200 milliseconds between beeps
            }
        }

        static string FormatTime(int seconds)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            return $"{minutes:00}:{remainingSeconds:00}";
        }
    }
}
