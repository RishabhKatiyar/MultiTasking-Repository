using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTasking
{
    class MyFileReader
    {
        public MyFileReader() { }
        public MyFileReader(object fileObject, object seperatorObject)
        {
            FileObect = fileObject;
            SeperatorObject = seperatorObject;
        }

        public object FileObect { get; set; }
        public object SeperatorObject { get; set; }

        public int ReadFileBy(ReadingMethodology methodology)
        {
            int count = methodology.Read(FileObect, SeperatorObject);
            return count;
        }
    }

    #region algorithm classes

    interface ReadingMethodology
    {
        int Read(object fileObject, object seperatorObject);
    }

    class ReadUsingThreads : ReadingMethodology
    {
        public int Read(object fileObject, object separatorObject)
        {
            int count = 0;
            string str = ((StreamReader)fileObject).ReadToEnd();
            
            foreach(char ch in str)
            {
                if (ch.ToString().Equals(separatorObject.ToString()))
                    count++;
            }
            return count;
        }
    }

    class ReadUsingTasks : ReadingMethodology
    {
        public int Read(object fileObject, object separatorObject)
        {
            return 0;
        }
    }


    class ReadUsingAsyncAwait : ReadingMethodology
    {
        public int Read(object fileObject, object separatorObject)
        {
            return 0;
        }
    }
    #endregion algorithm classes

    class TestMyFileReader
    {
        static void Main(string[] args)
        {
            string filePath = "c:\\temp\\text.txt";
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
                MyFileReader mfr = new MyFileReader(sr, " ");
                int count = mfr.ReadFileBy(threadMethodology);
                Console.WriteLine(count);
            }
            Console.Read();
        }
    }
}