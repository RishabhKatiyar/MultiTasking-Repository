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
            ReadingMethodology tasksMethodology = new ReadUsingTasks();
            ReadingMethodology asyncAwaitMethodology = new ReadUsingAsyncAwait();

            MyFileReader mfr = new MyFileReader(filePath, " ");

            int count = mfr.ReadFileBy(threadMethodology);
            Console.WriteLine("Final Result = "+count);

            //count = mfr.ReadFileBy(tasksMethodology);
            //Console.WriteLine(count);

            //count = mfr.ReadFileBy(asyncAwaitMethodology);
            //Console.WriteLine(count);
            Console.Read();
        }
    }
}