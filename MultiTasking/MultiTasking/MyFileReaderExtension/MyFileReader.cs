using MultiTasking.Interfaces;

namespace MultiTasking.MyFileReaderExtension
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
}
