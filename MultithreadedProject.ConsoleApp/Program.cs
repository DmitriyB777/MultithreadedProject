using MultithreadedProject.Library.Classes;
using MultithreadedProject.Library.Interfaces;
using System.Diagnostics;

namespace MultithreadedProject.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPCInformation information = new PCInformation();

            Console.WriteLine($"Операционная система: {information.GetOsVersion()}");
            Console.WriteLine($"Общее количество потоков в системе: {information.GetTotalThreads()}");
            Console.WriteLine($"Название процессора: {information.GetProcessorName()}");
            Console.WriteLine($"Архитектура процессора: {information.GetProcessorArchitecture()}");
            Console.WriteLine($"Объём оперативной памяти (ГБ): {information.GetAmountOfRAM()}");

            Console.WriteLine("---------------------------------------------------------------------");

            IArrayAdder array_100_000 = new ArrayAdder(100_000);
            array_100_000.FillArray();

            MeasureExecutionTime("Обычноена на 100.000", () => Console.WriteLine($"Сумма на 100.000 = {array_100_000.SequentialSum()}"));
            MeasureExecutionTime("Параллельное на 100.000 для 2-х потоков", () => Console.WriteLine($"Сумма на 100.000 = {array_100_000.ParallelSum(2)}"));
            MeasureExecutionTime("Параллельное на 100.000 для 4-х потоков", () => Console.WriteLine($"Сумма на 100.000 = {array_100_000.ParallelSum(4)}"));
            MeasureExecutionTime("Параллельное на 100.000 для 6-ти потоков", () => Console.WriteLine($"Сумма на 100.000 = {array_100_000.ParallelSum(6)}"));
            MeasureExecutionTime("Параллельное на 100.000 для 8-ми потоков", () => Console.WriteLine($"Сумма на 100.000 = {array_100_000.ParallelSum(8)}"));
            MeasureExecutionTime("Параллельное с помощью LINQ на 100.000", () => Console.WriteLine($"Сумма на 100.000 = {array_100_000.PLINQSum()}"));

            Console.WriteLine("---------------------------------------------------------------------");

            IArrayAdder array_1_000_000 = new ArrayAdder(1_000_000);
            array_1_000_000.FillArray();

            MeasureExecutionTime("Обычноена на 1.000.000", () => Console.WriteLine($"Сумма на 1.000.000 = {array_1_000_000.SequentialSum()}"));
            MeasureExecutionTime("Параллельное на 1.000.000 для 2-х потоков", () => Console.WriteLine($"Сумма на 1.000.000 = {array_1_000_000.ParallelSum(2)}"));
            MeasureExecutionTime("Параллельное на 1.000.000 для 4-х потоков", () => Console.WriteLine($"Сумма на 1.000.000 = {array_1_000_000.ParallelSum(4)}"));
            MeasureExecutionTime("Параллельное на 1.000.000 для 6-ти потоков", () => Console.WriteLine($"Сумма на 1.000.000 = {array_1_000_000.ParallelSum(6)}"));
            MeasureExecutionTime("Параллельное на 1.000.000 для 8-ми потоков", () => Console.WriteLine($"Сумма на 1.000.000 = {array_1_000_000.ParallelSum(8)}"));
            MeasureExecutionTime("Параллельное с помощью LINQ на 1.000.000", () => Console.WriteLine($"Сумма на 1.000.000 = {array_1_000_000.PLINQSum()}"));

            Console.WriteLine("---------------------------------------------------------------------");

            IArrayAdder array_10_000_000 = new ArrayAdder(10_000_000);
            array_10_000_000.FillArray();

            MeasureExecutionTime("Обычноена на 10.000.000", () => Console.WriteLine($"Сумма на 10.000.000 = {array_10_000_000.SequentialSum()}"));
            MeasureExecutionTime("Параллельное на 10.000.000 для 2-х потоков", () => Console.WriteLine($"Сумма на 10.000.000 = {array_10_000_000.ParallelSum(2)}"));
            MeasureExecutionTime("Параллельное на 10.000.000 для 4-х потоков", () => Console.WriteLine($"Сумма на 10.000.000 = {array_10_000_000.ParallelSum(4)}"));
            MeasureExecutionTime("Параллельное на 10.000.000 для 6-ти потоков", () => Console.WriteLine($"Сумма на 10.000.000 = {array_10_000_000.ParallelSum(6)}"));
            MeasureExecutionTime("Параллельное на 10.000.000 для 8-ми потоков", () => Console.WriteLine($"Сумма на 10.000.000 = {array_10_000_000.ParallelSum(8)}"));
            MeasureExecutionTime("Параллельное с помощью LINQ на 10.000.000", () => Console.WriteLine($"Сумма на 10.000.000 = {array_10_000_000.PLINQSum()}"));

            Console.WriteLine("---------------------------------------------------------------------");

            Console.ReadKey();
        }

        static void MeasureExecutionTime(string methodName, Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            Console.WriteLine($"{methodName}: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
