using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoBinaryLiterals();
            Console.ReadKey();
        }

        private static void DemoBinaryLiterals()
        {
            int five_Old = Convert.ToInt32("0101", 2);
            int five_New = 0b0101;

            Console.WriteLine("Binary Literals:");
            Console.WriteLine($"{nameof(five_Old)} = {five_Old}");
            Console.WriteLine($"{nameof(five_New)} = {five_New}");
        }
    }
}
