using System;

namespace CounterTask
{
    public class MainClass
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach (var c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

        public static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];

            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i = 0; i < 10; i++)
            {
                myCounters[0].Increment();
            }

            for (int i = 0; i < 15; i++)
            {
                myCounters[1].Increment();
            }

            Console.WriteLine("Counters after incrementing:");
            PrintCounters(myCounters);

            myCounters[2].Reset();

            Console.WriteLine("Counters after resetting:");
            PrintCounters(myCounters);
        }
    }
}
