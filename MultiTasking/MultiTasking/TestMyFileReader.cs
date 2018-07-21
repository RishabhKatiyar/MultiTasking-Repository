using MultiTasking.Algorithms;
using MultiTasking.Interfaces;
using MultiTasking.MyFileReaderExtension;
using System;
using System.Threading.Tasks;

namespace MultiTasking
{
    class TestMyFileReader
    {
        static void Main(string[] args)
        {
            string filePath = @"c:\temp\text.txt";
            char separatorObject = ' ';

            ReadingMethodology<int> threadMethodology = new ReadUsingThreads();
            ReadingMethodology<int> threadPoolMethodology = new ReadUsingThreadPool();
            ReadingMethodology<int> tasksMethodology = new ReadUsingTasks();
            ReadingMethodology<Task<int>> asyncAwaitMethodology = new ReadUsingAsyncAwait();

            MyFileReader<int> mfr = new MyFileReader<int>(filePath, separatorObject);
            MyFileReader<Task<int>> mfr1 = new MyFileReader<Task<int>>(filePath, separatorObject);

            Console.WriteLine("Using threads...");
            int count = mfr.ReadFileBy(threadMethodology);
            Console.WriteLine("Final Result = " + count);

            Console.WriteLine("Using threadpool...");
            count = mfr.ReadFileBy(threadPoolMethodology);
            Console.WriteLine("Final Result = " + count);

            Console.WriteLine("Using tasks...");
            count = mfr.ReadFileBy(tasksMethodology);
            Console.WriteLine("Final Result = " + count);

            Console.WriteLine("Using async await...");
            Task<int> result = mfr1.ReadFileBy(asyncAwaitMethodology);
            Console.WriteLine("Final Result = " + result.Result);

            Console.Read();
        }
    }
}