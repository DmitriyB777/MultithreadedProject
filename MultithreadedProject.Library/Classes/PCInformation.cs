using MultithreadedProject.Library.Interfaces;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;

namespace MultithreadedProject.Library.Classes
{
    public class PCInformation : IPCInformation
    {
        public string GetOsVersion()
        {
            return Environment.OSVersion.ToString();
        }

        public string GetProcessorArchitecture()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
            {
                return "64-бит";
            }
            else if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
            {
                return "32-бит";
            }
            else
            {
                return "Неизвестная архитектура";
            }
        }

        public string GetProcessorName()
        {
            string name = "Неизвестный процессор";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    name = obj["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка: " + ex.Message);
            }

            return name;
        }

        public string GetAmountOfRAM()
        {
            ulong totalRam = 0;
            ManagementObjectSearcher ramMonitor = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");

            foreach (ManagementObject objram in ramMonitor.Get())
            {
                totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);
            }

            return (totalRam / 1000000).ToString();
        }

        public string GetTotalThreads()
        {
            Process[] processes = Process.GetProcesses();

            int totalThreads = 0;

            foreach (Process process in processes)
            {
                try
                {
                    totalThreads += process.Threads.Count;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось получить информацию о процессе {process.ProcessName}: {ex.Message}");
                }
            }

            return totalThreads.ToString();
        }
    }
}
