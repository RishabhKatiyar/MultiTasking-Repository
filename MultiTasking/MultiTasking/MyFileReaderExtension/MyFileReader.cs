using System;
using System.Threading.Tasks;
using MultiTasking.Interfaces;

namespace MultiTasking.MyFileReaderExtension
{
    class MyFileReader<T>
    {
        public MyFileReader() { }
        public MyFileReader(string filePath, object seperatorObject)
        {
            FilePath = filePath;
            SeperatorObject = seperatorObject;
        }

        public string FilePath { get; set; }
        public object SeperatorObject { get; set; }

        public T ReadFileBy(ReadingMethodology<T> methodology)
        {
            T count = methodology.Read(FilePath, SeperatorObject);
            return count;
        }
    }
}
