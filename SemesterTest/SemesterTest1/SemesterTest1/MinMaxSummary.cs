using System;

namespace SemesterTest1
{
    public class MinMaxSummary : SummaryStrategy
    {
        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine("The biggest number is: " + Max(numbers));
            Console.WriteLine("The smallest number is: " + Min(numbers));
        }

        public int Max(List<int> numbers)
        {
            int biggest = numbers[0];
            foreach (int i in numbers)
            {
                if (i >= biggest)
                    biggest = i;
            }
            return biggest;
        }

        public int Min(List<int> numbers)
        {
            int smallest = numbers[0];
            foreach (int i in numbers)
            {
                if (i <= smallest)
                    smallest = i;
            }
            return smallest;
        }
    }
}