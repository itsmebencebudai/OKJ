using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tuple_bacics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: create three-item tuple.
            Tuple<int, string, bool> tuple = new Tuple<int, string, bool>(1, "cat", true);

            // Part 2: access tuple properties.
            if (tuple.Item1 == 1)
            {
                Console.WriteLine(tuple.Item1);
            }
            if (tuple.Item2 == "dog")
            {
                Console.WriteLine(tuple.Item2);
            }
            if (tuple.Item3)
            {
                Console.WriteLine(tuple.Item3);
            }
        }
    }
    class Program2
    {
        static void Main()
        {
            // Create four-item tuple.
            // ... Use var implicit type.
            var tuple = new Tuple<string, string[], int, int[]>("perl",
                new string[] { "java", "c#" },
                1,
                new int[] { 2, 3 });
            // Pass tuple as argument.
            M(tuple);
        }

        static void M(Tuple<string, string[], int, int[]> tuple)
        {
            // Evaluate the tuple's items.
            Console.WriteLine(tuple.Item1);
            foreach (string value in tuple.Item2)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine(tuple.Item3);
            foreach (int value in tuple.Item4)
            {
                Console.WriteLine(value);
            }
        }
    }
    class Program3
    {
        static void Main()
        {
            var sextuple =
                new Tuple<int, int, int, string, string, string>(1,
                1, 2, "dot", "net", "perls");
            Console.WriteLine(sextuple);
        }
    }
    class Program4
    {
        static void Main()
        {
            // Use Tuple.Create static method.
            var tuple = Tuple.Create("cat", 2, true);

            // Test value of string.
            string value = tuple.Item1;
            if (value == "cat")
            {
                Console.WriteLine(true);
            }

            // Test Item2 and Item3.
            Console.WriteLine(tuple.Item2 == 10);
            Console.WriteLine(!tuple.Item3);

            // Write string representation.
            Console.WriteLine(tuple);
        }
    }
    class Program5
    {
        static void Main()
        {
            var tuple = new Tuple<int, string>(200, "Greece");

            // This will not work.
            //tuple.Item1 = 300;
        }
    }
    class Program6
    {
        static void Main()
        {
            List<Tuple<int, string>> list = new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1, "cat"),
                new Tuple<int, string>(100, "apple"),
                new Tuple<int, string>(2, "zebra")
            };

            // Use Sort method with Comparison delegate.
            // ... Has two parameters; return comparison of Item2 on each.
            list.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
    class Program7
    {
        static Tuple<string, int> NameAndId()
        {
            // This method returns multiple values.
            return new Tuple<string, int>("Satya Nadella", 100);
        }

        static void Main()
        {
            var result = NameAndId();
            string name = result.Item1;
            int id = result.Item2;
            // Display the multiple values returned.
            Console.WriteLine(name);
            Console.WriteLine(id);
        }
    }
    class Program8
    {
        static void Main()
        {
            // Go to NuGet, then search for and install System.ValueTuple.
            // ... This program will then compile correctly.
            var values = (10, "bird", "plane");
            Console.WriteLine(values);
            Console.WriteLine(values.Item1);
            Console.WriteLine(values.Item2);
            Console.WriteLine(values.Item3);
        }
    }
    class Program9
    {
        static void Main()
        {
            var tuple = new Tuple<int, string>(-20, "Bolivia");
            // Convert tuple to a value tuple, and pass it to a method.
            Print(tuple.ToValueTuple());
        }

        static void Print((int, string) items)
        {
            // Print value tuple.
            Console.WriteLine(items);
        }
    }
    class Program10
    {
        static void Main()
        {
            Allocation();
            Argument();
            Return();
            Load();
        }

        static void Allocation()
        {
            // Time allocating the object.
            const int max = 1000000;
            var a = new Tuple<string, string>("", "");
            var b = new KeyValuePair<string, string>("", "");
            var c = ("", "");

            var s1 = Stopwatch.StartNew();
            // Version 1: allocate Tuple.
            for (var i = 0; i < max; i++)
            {
                var tuple = new Tuple<string, string>("cat", "dog");
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            // Version 2: allocate KeyValuePair.
            for (var i = 0; i < max; i++)
            {
                var pair = new KeyValuePair<string, string>("cat", "dog");
            }
            s2.Stop();
            var s3 = Stopwatch.StartNew();
            // Version 3: allocate tuple literal.
            for (var i = 0; i < max; i++)
            {
                var pair = ("cat", "dog");
            }
            s3.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max) + "  allocation, Tuple");
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max) + "  allocation, KeyValuePair");
            Console.WriteLine(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max) + "  allocation, Tuple literal");
            Console.WriteLine();
        }

        static void Argument()
        {
            // Time passing the object as an argument to a function.
            const int max = 10000000;
            var a = new Tuple<string, string>("", "");
            var b = new KeyValuePair<string, string>("", "");
            var c = ("", "");
            X(a);
            X(b);
            X(c);

            var s1 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                X(a);
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                X(b);
            }
            s2.Stop();
            var s3 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                X(c);
            }
            s3.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max) + "  argument, Tuple");
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max) + "  argument, KeyValuePair");
            Console.WriteLine(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max) + "  argument, Tuple literal");
            Console.WriteLine();
        }

        static void Return()
        {
            // Time returning the object itself.
            const int max = 10000000;
            var a = new Tuple<string, string>("", "");
            var b = new KeyValuePair<string, string>("", "");
            var c = ("", "");
            Y(a);
            Y(b);
            Y(c);

            var s1 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                Y(a);
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                Y(b);
            }
            s2.Stop();
            var s3 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                Y(c);
            }
            s3.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max) + "  return, Tuple");
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max) + "  return, KeyValuePair");
            Console.WriteLine(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max) + "  return, Tuple literal");
            Console.WriteLine();
        }

        static void Load()
        {
            // Time accessing an element.
            const int max = 10000000;
            var a = new Tuple<string, string>("cat", "dog");
            var b = new KeyValuePair<string, string>("cat", "dog");
            var c = ("cat", "dog");

            var list1 = new List<Tuple<string, string>>
            {
                a
            };
            Z(list1);

            var list2 = new List<KeyValuePair<string, string>>
            {
                b
            };
            Z(list2);

            var list3 = new List<(string, string)>
            {
                c
            };
            Z(list3);

            var s1 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                Z(list1);
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                Z(list2);
            }
            s2.Stop();
            var s3 = Stopwatch.StartNew();
            for (var i = 0; i < max; i++)
            {
                Z(list3);
            }
            s3.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max) + "  load, Tuple");
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max) + "  load, KeyValuePair");
            Console.WriteLine(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max) + "  load, Tuple literal");
            Console.WriteLine();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void X(Tuple<string, string> a)
        {
            // This and following methods are used in the benchmarks.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void X(KeyValuePair<string, string> a)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void X((string, string) a)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static Tuple<string, string> Y(Tuple<string, string> a)
        {
            return a;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static KeyValuePair<string, string> Y(KeyValuePair<string, string> a)
        {
            return a;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static (string, string) Y((string, string) a)
        {
            return a;
        }

        static char Z(List<Tuple<string, string>> list)
        {
            return list[0].Item1[0];
        }

        static char Z(List<KeyValuePair<string, string>> list)
        {
            return list[0].Key[0];
        }

        static char Z(List<(string, string)> list)
        {
            return list[0].Item1[0];
        }
    }
}
