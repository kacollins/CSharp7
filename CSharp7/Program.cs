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
            DemoDigitSeparators();
            DemoLocalFunction("World");
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

        private static void DemoDigitSeparators()
        {
            int speedOfLight_Old = 299792458;
            int speedOfLight_New = 299_792_458;

            Console.WriteLine();
            Console.WriteLine("Digit Separators:");
            Console.WriteLine($"{nameof(speedOfLight_Old)} = {speedOfLight_Old.ToString("n0")}");
            Console.WriteLine($"{nameof(speedOfLight_New)} = {speedOfLight_New.ToString("n0")}");
        }

        private static void DemoLocalFunction(string recipient)
        {
            Console.WriteLine();
            Console.WriteLine("Local Function:");

            string greeting = "Hello";

            void GreetRecipient()
            {
                Console.WriteLine($"{greeting}, {recipient}!");
            }

            GreetRecipient();
        }
    }
}
