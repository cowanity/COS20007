using System;
using System.Collections.Generic;

namespace SemesterTest1
{
    public class DataAnalyser
    {
        private List<int> _numbers;
        private SummaryStrategy _strategy;

        public SummaryStrategy Strategy
        {
            get
            {
                return _strategy;
            }
            set
            {
                _strategy = value;
            }
        }

        public DataAnalyser(SummaryStrategy strategy, List<int> numbers)
        {
            _strategy = strategy;
            _numbers = numbers;
        }

        public DataAnalyser(SummaryStrategy strategy)
            : this(strategy, new List<int>())
        {
        }

        public DataAnalyser()
            : this(new AverageSummary(), new List<int>())
        {
        }

        public DataAnalyser(List<int> numbers)
            : this(new AverageSummary(), numbers)
        {
        }

        public void Summarise()
        {
            _strategy.PrintSummary(_numbers);
        }

        public void AddNumbers(int num)
        {
            _numbers.Add(num);
        }
    }
}