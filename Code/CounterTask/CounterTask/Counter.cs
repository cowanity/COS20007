using System;

namespace CounterTask
{
    public class Counter
    {
        private string _name;
        private int _count;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Ticks
        {
            get { return _count; }
        }
    }
}
