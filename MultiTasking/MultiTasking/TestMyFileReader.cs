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
            string filePath = "c:\\temp\\UIDesign.txt";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            if(sr != null)
            {
                ReadingMethodology threadMethodology = new ReadUsingThreads();
                ReadingMethodology tasksMethodology = new ReadUsingTasks();
                ReadingMethodology asyncAwaitMethodology = new ReadUsingAsyncAwait();

                MyFileReader mfr = new MyFileReader(sr, "\"");

                int count = mfr.ReadFileBy(threadMethodology);
                Console.WriteLine(count);

                count = mfr.ReadFileBy(tasksMethodology);
                Console.WriteLine(count);

                count = mfr.ReadFileBy(asyncAwaitMethodology);
                Console.WriteLine(count);
            }
            Console.Read();
        }
    }
}