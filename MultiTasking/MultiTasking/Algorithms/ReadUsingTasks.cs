using MultiTasking.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTasking.Algorithms
{
    class ReadUsingTasks : ReadLibrary, ReadingMethodology<int>
    {
        public int Read(string filePath, object separatorObject)
        {
            List<string>[] myList = GetListFromFile(filePath);

            Task<int> task1 = Task.Run(() => ReturnCountSeparator(myList[0], separatorObject));
            Task<int> task2 = new Task<int>(() => ReturnCountSeparator(myList[1], separatorObject));
            Task<int> task3 = new Task<int>(() => ReturnCountSeparator(myList[2], separatorObject));
            Task<int> task4 = new Task<int>(() => ReturnCountSeparator(myList[3], separatorObject));

            //task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            return task1.Result+task2.Result+task3.Result+task4.Result;
        }
    }
}
