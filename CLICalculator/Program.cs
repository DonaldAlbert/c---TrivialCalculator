using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            UI calculator = new UI();
            calculator.mainLoop();
        }
    }
}
