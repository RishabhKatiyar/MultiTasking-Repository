using MultiTasking.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;

namespace MultiTasking.Algorithms
{
    class ReadUsingThreadPool : ReadingMethodology
    {
        private int Result = 0;

        readonly object padlock = new object();

        ManualResetEvent[] myEvents = new ManualResetEvent[4];

        public int Read(string filePath, object separatorObject)
        {
            int count = 0, lineNumber = 1;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            List<string>[] myList = new List<string>[4];
            for (int i = 0; i < 4; i++)
            {
                myList[i] = new List<string>();
            }

            while ((line = file.ReadLine()) != null)
            {
                switch (lineNumber)
                {
                    case 1:
                        myList[0].Add(line);
                        lineNumber = 2;
                        break;
                    case 2:
                        myList[1].Add(line);
                        lineNumber = 3;
                        break;
                    case 3:
                        myList[2].Add(line);
                        lineNumber = 4;
                        break;
                    case 4:
                        myList[3].Add(line);
                        lineNumber = 1;
                        ++count;
                        break;
                }
            }

            file.Close();

            //dynamic myObject = new ExpandoObject();
            //myObject.MyList = myList[0];
            //myObject.SeparatorObject = separatorObject;

            for (int i = 0; i < 4; i++)
            {
                myEvents[i] = new ManualResetEvent(false);
                var myObject = new { MyList = myList[i], SeparatorObject = separatorObject, I = i };
                ThreadPool.QueueUserWorkItem(CountSeparator, myObject);
            }
            


            //Console.WriteLine("Calling Method id = " + Thread.CurrentThread.ManagedThreadId);
            WaitHandle.WaitAll(myEvents);
            return Result;

        }

        public void CountSeparator(dynamic threadContext)
        {
            List<string> stringList = (List<string>)threadContext.MyList;
            string separatorObject = threadContext.SeparatorObject.ToString();
            int count = 0;
            foreach (string str in stringList)
            {
                foreach (char ch in str)
                {
                    if (ch.ToString() == separatorObject.ToString())
                    {
                        count++;
                    }
                }
            }

            lock (padlock)
            {
                //Thread.Sleep(1000);
                Result += count;
                //Console.WriteLine("Thread id = " + Thread.CurrentThread.ManagedThreadId + " Result = " + Result);
            }
            myEvents[threadContext.I].Set();
        }
    }
}
