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
            DemoPatternMatching();
            DemoRefReturns();
            DemoTuples_Old();

            Console.WriteLine();
            Console.WriteLine("Press any key:");
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

        #region Pattern Matching

        private static void DemoPatternMatching()
        {
            Console.WriteLine();
            Console.WriteLine("Pattern Matching:");

            Attendee[] meetupAttendees = {
                new Leader("Matt", Leader.Roles.Organizer),
                new Leader("Danny", Leader.Roles.Co_Organizer),
                new Leader("David", Leader.Roles.Co_Organizer),
                new Speaker("Dwayne", "Xamarin Android App"),
                new Speaker("Aaron", "Interview Recap with Amazon Web Services"),
                new Speaker("Kimberly", "New Features in C# 7"),
                new Speaker("Steven", null),
                new Attendee("Adam"),
                //lots of other awesome people too
            };

            foreach (Attendee a in meetupAttendees.OrderBy(a => a.Name))
            {
                Console.WriteLine(GetInfo(a));
            }
        }

        private static string GetInfo(Attendee a)
        {
            if (a is Leader l)
            {
                return $"{l.Name} ({l.Role})";
            }
            else if (a is Speaker s && string.IsNullOrWhiteSpace(s.Topic))
            {
                return $"{s.Name} speaking on unknown topic";
            }
            else if (a is Speaker s)
            {
                return $"{s.Name} speaking on \"{s.Topic}\"";
            }
            else
            {
                return $"{a.Name}";
            }
        }

        class Attendee
        {
            public string Name { get; }

            public Attendee(string name)
            {
                this.Name = name;
            }
        }

        class Leader : Attendee
        {
            public Roles Role { get; }

            public Leader(string name, Roles role) : base(name)
            {
                this.Role = role;
            }

            public enum Roles
            {
                Organizer,
                Co_Organizer
            }
        }

        class Speaker : Attendee
        {
            public string Topic { get; }

            public Speaker(string name, string topic) : base(name)
            {
                this.Topic = topic;
            }
        }

        #endregion

        #region Ref Returns

        private static void DemoRefReturns()
        {
            Console.WriteLine();
            Console.WriteLine("Ref Returns:");

            int input = 0;
            ref int output = ref ChangeValue(ref input);

            Console.WriteLine($"{nameof(input)} = {input}");
            Console.WriteLine($"{nameof(output)} = {output}");
        }

        private static ref int ChangeValue(ref int value)
        {
            value = 123;
            return ref value;
        }

        #endregion

        #region Tuples

        private static void DemoTuples_Old()
        {
            Console.WriteLine();
            Console.WriteLine("Tuples:");

            List<int> values = new List<int> { 1, 2, 3, 4, 5 };
            Tuple<int, int> result = GetCountAndSum(values);

            Console.WriteLine($"{nameof(result.Item1)} = {result.Item1}");
            Console.WriteLine($"{nameof(result.Item2)} = {result.Item2}");
        }

        private static Tuple<int, int> GetCountAndSum(List<int> values)
        {
            Tuple<int, int> result = new Tuple<int, int>(values.Count, values.Sum());
            return result;
        }

        #endregion
    }
}
