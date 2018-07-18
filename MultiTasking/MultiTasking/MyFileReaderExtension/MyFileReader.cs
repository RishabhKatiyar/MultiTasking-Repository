using MultiTasking.Interfaces;

namespace MultiTasking.MyFileReaderExtension
{
    class MyFileReader
    {
        public MyFileReader() { }
        public MyFileReader(string filePath, object seperatorObject)
        {
            FilePath = filePath;
            SeperatorObject = seperatorObject;
        }

        public string FilePath { get; set; }
        public object SeperatorObject { get; set; }

        public int ReadFileBy(ReadingMethodology methodology)
        {
            int count = methodology.Read(FilePath, SeperatorObject);
            return count;
        }
    }
}
