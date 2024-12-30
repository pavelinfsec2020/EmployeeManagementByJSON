using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTaskProject.Interfaces;

namespace SecondTaskProject.Utilities
{
    internal class ConsolePrinter : IPrinter
    {
       public void PrintMessage(string message) 
       {
            Console.WriteLine(message); 
       }
    }
}
