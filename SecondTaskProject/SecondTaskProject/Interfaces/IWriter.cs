using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTaskProject.Interfaces
{
    internal interface IWriter
    {
        public bool AddObjectToJSON<T>(T data, string fileName);
    }
}
