using MultiTasking.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MultiTasking.Algorithms
{
    class ReadUsingThreads : ReadLibrary, ReadingMethodology<int> 
    {
        public int Read(string filePath, object separatorObject)
        {
            List<string>[] myList = GetListFromFile(filePath);
            
            Thread childThread1 = new Thread(() => CountSeparator(myList[0], separatorObject));
            Thread childThread2 = new Thread(() => CountSeparator(myList[1], separatorObject));
            Thread childThread3 = new Thread(() => CountSeparator(myList[2], separatorObject));
            Thread childThread4 = new Thread(() => CountSeparator(myList[3], separatorObject));

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
    }
}
