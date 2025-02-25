using System;
using System.Collections.Generic;

namespace SemesterTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Phan Vu - 104222099");

            // a) Create a list and set strategy to minmax strategy
            List<int> numbers = new List<int> { 1, 4, 0, 2, 2, 2, 0, 9, 9 };
            DataAnalyser analyser = new DataAnalyser(new MinMaxSummary(), numbers);

            // b) Call Summary
            analyser.Summarise();

            // c) Add 3 numbers
            analyser.AddNumbers(14);
            analyser.AddNumbers(02);
            analyser.AddNumbers(04);

            // d) Set the summary strategy to the average strategy
            analyser.Strategy = new AverageSummary();

            // e) Call Summary
            analyser.Summarise();
            Console.ReadLine();
        }
    }
}