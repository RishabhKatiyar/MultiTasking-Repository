using MultiTasking.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MultiTasking.Algorithms
{
    class ReadUsingThreads : ReadingMethodology
    {
        private int Result = 0;

        readonly object padlock = new object();

        public int Read(string filePath, object separatorObject)
        {
            int count = 0, lineNumber = 1;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            List<string>[] myList = new List<string>[4];
            for(int i = 0; i<4; i++)
            {
                myList[i] = new List<string>();
            }
            
            while ((line = file.ReadLine()) != null)
            {
                switch(lineNumber)
                {
                    case 1: myList[0].Add(line);
                        lineNumber = 2;
                        break;
                    case 2: myList[1].Add(line);
                        lineNumber = 3;
                        break;
                    case 3: myList[2].Add(line);
                        lineNumber = 4;
                        break;
                    case 4: myList[3].Add(line);
                        lineNumber = 1;
                        ++count;
                        break;
                }
            }

            file.Close();
            
            Thread childThread1 = new Thread(() => CountSeparator(myList[0], separatorObject));
            Thread childThread2 = new Thread(() => CountSeparator(myList[1], separatorObject));
            Thread childThread3 = new Thread(() => CountSeparator(myList[2], separatorObject));
            Thread childThread4 = new Thread(() => CountSeparator(myList[3], separatorObject));


            //Console.WriteLine("Calling Method id = "+Thread.CurrentThread.ManagedThreadId);

            childThread1.Start();
            childThread2.Start();
            childThread3.Start();
            childThread4.Start();

            childThread1.Join();
            childThread3.Join();
            childThread2.Join();
            childThread4.Join();

            return Result;
           
        }

        public void CountSeparator(List<string> stringList, object separatorObject)
        {
            
            int count = 0;
            foreach(string str in stringList)
            {
                foreach(char ch in str)
                {
                    if(ch.ToString() == separatorObject.ToString())
                    {
                        count++;
                    }
                }
            }

            lock (padlock)
            {
                //Thread.Sleep(1000);
                Result += count;
                //Console.WriteLine("Thread id = "+Thread.CurrentThread.ManagedThreadId+" Result = "+Result);
            }
        }
    }
}
