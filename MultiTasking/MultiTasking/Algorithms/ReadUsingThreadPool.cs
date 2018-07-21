using MultiTasking.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;

namespace MultiTasking.Algorithms
{
    class ReadUsingThreadPool : ReadLibrary, ReadingMethodology<int>
    {
        ManualResetEvent[] myEvents = new ManualResetEvent[4];

        public int Read(string filePath, object separatorObject)
        {
            List<string>[] myList = GetListFromFile(filePath);

            for (int i = 0; i < 4; i++)
            {
                myEvents[i] = new ManualResetEvent(false);
                var threadContext = new { MyList = myList[i], SeparatorObject = separatorObject, MyEvents = myEvents[i] };

                ThreadPool.QueueUserWorkItem(CountSeparator, threadContext);
            }

            WaitHandle.WaitAll(myEvents);
            return Result;
        }
    }
}
