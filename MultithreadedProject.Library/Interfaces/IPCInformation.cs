using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedProject.Library.Interfaces
{
    public interface IPCInformation
    {
        string GetOsVersion();
        string GetProcessorArchitecture();
        string GetProcessorName();
        string GetAmountOfRAM();
        string GetTotalThreads();
    }
}
