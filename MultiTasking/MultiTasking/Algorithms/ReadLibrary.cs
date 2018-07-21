using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTasking.Algorithms
{
    class ReadLibrary
    {
        readonly object padlock = new object();

        public int Result { get; set; }
        
        public void CountSeparator(List<string> stringList, object separatorObject)
        {
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
                Result += count;
            }
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
                Result += count;
            }
            threadContext.MyEvents.Set();
        }

        public int ReturnCountSeparator(List<string> stringList, object separatorObject)
        {

            int count = 0;
            int localResult = 0;
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
                localResult += count;
                //Console.WriteLine("Thread id = "+Thread.CurrentThread.ManagedThreadId+" Result = "+Result);
            }
            return localResult;
        }

        public async Task<int> ReturnTaskCountSeparator(List<string> stringList, object separatorObject)
        {

            int count = 0;
            int localResult = 0;
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
                localResult += count;
            }

            return localResult;
        }

        public List<string>[] GetListFromFile(string filePath)
        {
            int count = 0;
            int lineNumber = 1;
            string line;
            List<string>[] myList = new List<string>[4];
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            
            for (int i = 0; i < 4; i++)
            {
                myList[i] = new List<string>();
            }

            while ((line = file.ReadLine()) != null)
            {
                switch (lineNumber)
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
                    case 4:myList[3].Add(line);
                        lineNumber = 1;
                        ++count;
                        break;
                }
            }
            file.Close();
            return myList;
        }
    }
}
