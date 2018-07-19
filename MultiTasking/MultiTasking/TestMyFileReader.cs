using MultiTasking.Algorithms;
using MultiTasking.Interfaces;
using MultiTasking.MyFileReaderExtension;
using System;
using System.IO;

namespace MultiTasking
{
    class TestMyFileReader
    {
        static void Main(string[] args)
        {
            string filePath = @"c:\temp\text.txt";

            ReadingMethodology threadMethodology = new ReadUsingThreads();
            ReadingMethodology threadPoolMethodology = new ReadUsingThreadPool();
            ReadingMethodology tasksMethodology = new ReadUsingTasks();
            ReadingMethodology asyncAwaitMethodology = new ReadUsingAsyncAwait();

            MyFileReader mfr = new MyFileReader(filePath, " ");

            Console.WriteLine("Using threads...");
            int count = mfr.ReadFileBy(threadMethodology);
            Console.WriteLine("Final Result = "+count);

            Console.WriteLine("Using threadpool...");
            count = mfr.ReadFileBy(threadPoolMethodology);
            Console.WriteLine("Final Result = " + count);

            //int count = mfr.ReadFileBy(tasksMethodology);
            //Console.WriteLine("Final Result = " + count);

            //int count = mfr.ReadFileBy(asyncAwaitMethodology);
            //Console.WriteLine(count);
            Console.Read();
        }
    }
}