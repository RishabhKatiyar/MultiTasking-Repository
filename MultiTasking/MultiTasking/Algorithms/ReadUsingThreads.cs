using MultiTasking.Interfaces;
using System.IO;

namespace MultiTasking.Algorithms
{
    class ReadUsingThreads : ReadingMethodology
    {
        public int Read(object fileObject, object separatorObject)
        {
            int count = 0;
            string str = ((StreamReader)fileObject).ReadToEnd();

            foreach (char ch in str)
            {
                if (ch.ToString().Equals(separatorObject.ToString()))
                    count++;
            }
            return count;
        }
    }
}
