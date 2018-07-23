using MultiTasking.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTasking.Algorithms
{
    class ReadUsingAsyncAwait : ReadLibrary, ReadingMethodology<Task<int>>
    {
        public async Task<int> Read(string filePath, object separatorObject)
        {
            List<string>[] myList = GetListFromFile(filePath); 

            Task<int> task1 = ReturnTaskCountSeparator(myList[0], separatorObject);
            Task<int> task2 = ReturnTaskCountSeparator(myList[1], separatorObject);
            Task<int> task3 = ReturnTaskCountSeparator(myList[2], separatorObject);
            Task<int> task4 = ReturnTaskCountSeparator(myList[3], separatorObject);
            return await(task1) + task2.Result + task3.Result + task4.Result;

        }
    }
}
