using System;
using Turfsport.Automation.LoadTest;

namespace EuroMonitorAssessment
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                DisplayStartupMessage();
                var number = Console.ReadLine();
                NumberUtil.ProcessInput(number, out var message,out var difference);
                Console.WriteLine(message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
               
            }
            
        }

        private static void DisplayStartupMessage() => Console.WriteLine("Please enter a number less than 5.");
        

    }
}
