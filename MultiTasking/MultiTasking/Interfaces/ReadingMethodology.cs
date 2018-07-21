using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTasking.Interfaces
{
    interface ReadingMethodology<T>
    {
        T Read(string filePath, object seperatorObject);
    }
}
