using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedProject.Library.Interfaces
{
    public interface IArrayAdder
    {
        void FillArray();
        long SequentialSum();
        long ParallelSum(int countThreads);
        long PLINQSum();
    }
}
