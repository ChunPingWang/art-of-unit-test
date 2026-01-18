using System;
using Chapter1;

namespace Chapter1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Running Chapter 1 Tests...");
            SimpleParserTests.TestReturnsZeroWhenEmptyString();
            System.Console.WriteLine("Tests completed.");
            System.Console.ReadKey();
        }
    }
}
