using MultithreadedProject.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultithreadedProject.Library.Classes
{
    public class ArrayAdder : IArrayAdder
    {
        private List<long> _list;
        private int _size;

        public ArrayAdder(int size)
        {
            _list = new List<long>();
            _size = size;
        }

        public void FillArray()
        {
            for (int i = 0; i < _size; i++)
            {
                _list.Add(i + 1);
            }
        }

        public long SequentialSum()
        {
            long sum = 0;

            foreach (long item in _list)
            {
                sum += item;
            }

            return sum;
        }

        public long ParallelSum(int countThreads)
        {
            long sum = 0;

            int numberOfThreads = countThreads;
            int length = _list.Count;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numberOfThreads; i++)
            {
                int start = i * (length / numberOfThreads);
                int end = (i + 1) * (length / numberOfThreads);
                if (i == numberOfThreads - 1) end = length;

                Thread thread = new Thread(() => 
                {
                    long partialSum = 0;
                    for (int i = start; i < end; i++)
                    {
                        partialSum += _list[i];
                    }

                    sum += partialSum;
                });

                thread.Start();
                threads.Add(thread);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return sum;
        }

        public long PLINQSum()
        {
            return _list.AsParallel().Sum();
        }
    }
}
