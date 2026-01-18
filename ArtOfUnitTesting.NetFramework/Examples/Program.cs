using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Art of Unit Testing - Examples");
            Console.WriteLine($"Current Time: {SystemTime.Now}");
            Console.WriteLine(TimeLogger.CreateMessage("Hello World"));
        }
    }
}
