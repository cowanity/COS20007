using System;

namespace SemesterTest1
{
    public class AverageSummary : SummaryStrategy
    {
        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine("The average number is: " + Avg(numbers));
        }

        public float Avg(List<int> numbers)
        {
            int total = 0;
            foreach (int i in numbers)
            {
                total += i;
            }
            return (float)total / numbers.Count();
        }
    }
}