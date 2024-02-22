using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;


namespace _50_LINQ_Examples
{
    class Program1
    {
        static void main(string[] args)
        {
            var l1 = new List<int> { 1, 2, 3, 4 };
            List<string> l2 = l1.ConvertAll<string>(delegate (int x)
            {
                return x.ToString();
            });
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            var l1 = new List<int> { 1, 2, 3, 4 };
            // Using ConvertAll with a Lambda expression
            List<string> l2 = l1.ConvertAll(x => x.ToString());
        }
    }
    class Program3
    {
        static void Main(string[] args)
        {
            DirectoryInfo dInfo = new DirectoryInfo(@"C:/Articles");
            // set bool parameter to false if you
            // do not want to include subdirectories.
            long sizeOfDir = DirectorySize(dInfo, true);

            Console.WriteLine("Directory size in Bytes : " +
            "{0:N0} Bytes", sizeOfDir);
            Console.WriteLine("Directory size in KB : " +
            "{0:N2} KB", ((double)sizeOfDir) / 1024);
            Console.WriteLine("Directory size in MB : " +
            "{0:N2} MB", ((double)sizeOfDir) / (1024 * 1024));

            Console.ReadLine();
        }

        static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
        {
            // Enumerate all the files
            long totalSize = dInfo.EnumerateFiles()
                         .Sum(file => file.Length);

            // If Subdirectories are to be included
            if (includeSubDir)
            {
                // Enumerate all sub-directories
                totalSize += dInfo.EnumerateDirectories()
                         .Sum(dir => DirectorySize(dir, true));
            }
            return totalSize;
        }
    }

    class Program4
    {
        static void Main(string[] args)
        {
            IEnumerable<int> oddNums
               = ((ParallelQuery<int>)ParallelEnumerable.Range(20, 2000))
            .Where(x => x % 2 != 0)
            .Select(i => i);

            foreach (int n in oddNums) { Console.WriteLine(n); }
            Console.ReadLine();
        }
    }

    class Program5
    {
        static void Main(string[] args)
        {
            var l1 = new[] { 1, 2, 3, 4, 5, 6 };
            var l2 = new[] { 1, 2, 3, 4, 5 };
            var result = l1.SequenceEqual(l2);

            Console.WriteLine("Are they Equal?: {0}", result);

            if (!result)
            {
                Console.WriteLine("Difference between 2 sequences: ");
                var diff = l1.Except(l2);
                Array.ForEach(diff.ToArray(), x => Console.WriteLine(x));
            }
        }
    }

    class Program6
    {
        static void Main(string[] args)
        {
            string[] dirfiles = Directory.GetFiles("c:\\software\\");
            var avg = dirfiles.Select(file =>
                            new FileInfo(file).Length).Average();
            avg = Math.Round(avg / 1000000, 1);
            Console.WriteLine("The Average file size is {0} MB",
             avg);
            Console.ReadLine();
        }
    }

    class Program7
    {
        static void main(string[] args)
        {
            var listA = new string[] { "A", "B", "C" };
            var listB = new string[] { "1", "2", "3" };
            var cartesianList = listA.SelectMany(x => listB.Select(y => x + y + ' '));

            foreach (var list in cartesianList)
            {
                Console.WriteLine(list);
            }
            Console.ReadKey();
        }

        class Program8
        {
            public static void Main(string[] args)
            {
                var t = typeof(IEnumerable);

                var typesIEnum = AppDomain.CurrentDomain
               .GetAssemblies()
               .SelectMany(x => x.GetTypes())
               .Where(x => t.IsAssignableFrom(x));

                foreach (var types in typesIEnum)
                {
                    Console.WriteLine(types.FullName);
                }
                Console.ReadLine();
            }

        }

        class Program9
        {
            static void Main(string[] args)
            {
                // code from DevCurry.com
                var strwords = FilterWords("THIS is A very STRANGE string");
                foreach (string str in strwords)
                    Console.WriteLine(str);
                Console.ReadLine();
            }

            static IEnumerable<string> FilterWords(string str)
            {
                var upper = str.Split(' ')
                            .Where(s => String.Equals(s, s.ToUpper(),
                                        StringComparison.Ordinal));

                return upper;

            }
        }

        class Program10
        {
            static void Main(string[] args)
            {
                IEnumerable<string> strCSV =
                    File.ReadLines(@"../../Sample.csv");
                var results = from str in strCSV
                              let tmp = str.Split(',')
                              .Skip(1)
                              .Select(x => Convert.ToInt32(x))
                              select new
                              {
                                  Max = tmp.Max(),
                                  Min = tmp.Min(),
                                  Total = tmp.Sum(),
                                  Avg = tmp.Average()
                              };

                // caching for performance
                var query = results.ToList();

                foreach (var x in query)
                {
                    Console.WriteLine(
                        string.Format("Maximum: {0}, " +
                                      "Minimum: {1}, " +
                                      "Total: {2}, " +
                                      "Average: {3}",
                                      x.Max, x.Min, x.Total, x.Avg));
                }

                Console.ReadLine();
            }
        }

        class Program11
        {
            static void Main(string[] args)
            {
                IEnumerable<int> oddNums =
                    Enumerable.Range(20, 20).Where(x => x % 2 != 0);

                foreach (int n in oddNums)
                {
                    Console.WriteLine(n);
                }
                Console.ReadLine();

            }
        }

        class Program12
        {
            static void Main(string[] args)
            {
                var rng = Enumerable.Range(200, 200).Select(x => x / 10f);
                foreach (float n in rng)
                {
                    Console.WriteLine(n);
                }
                Console.ReadLine();
            }
        }

        class Program13
        {
            static void Main(string[] args)
            {
                var rng = Enumerable.Range(200, 200).Select(x => x / 10f);

                var frstNo = rng.First();
                Console.WriteLine("First Number: {0}", frstNo);

                var lastNo = rng.Last();
                Console.WriteLine("Last Number: {0}", lastNo);

                var frstFiltered = rng.Where(n => n > 20).FirstOrDefault();
                Console.WriteLine("First Number Greater than 20: {0}", frstFiltered);

                var lastFiltered = rng.Where(n => n < 22).LastOrDefault();
                Console.WriteLine("Last Number Lesser than 22: {0}", lastFiltered);

                var numIndex = rng.ElementAtOrDefault(15);
                Console.WriteLine("Element at index 15: {0}", numIndex);
            }
        }

        class Program14
        {
            static void Main(string[] args)
            {
                var sequence = Enumerable.Range(200, 200).Select(x => x / 10f);

                var grps = from x in sequence.Select((i, j) => new { i, Grp = j / 10 })
                           group x.i by x.Grp into y
                           select new { Min = y.Min(), Max = y.Max() };

                foreach (var grp in grps)
                    Console.WriteLine("Min: " + grp.Min + " Max:" + grp.Max);
                Console.ReadLine();
            }
        }

        class Program15
        {
            public class Book
            {
                public int BookID { get; set; }
                public string BookNm { get; set; }
            }

            public class Order
            {
                public int OrderID { get; set; }
                public int BookID { get; set; }
                public string PaymentMode { get; set; }
            }

            static void Main(string[] args)
            {
                List<Book> bookList = new List<Book>
                {
                    new Book{BookID=1, BookNm="DevCurry.com Developer Tips"},
                    new Book{BookID=2, BookNm=".NET and COM for Newbies"},
                    new Book{BookID=3, BookNm="51 jQuery ASP.NET Recipes"},
                    new Book{BookID=4, BookNm="Motivational Gurus"},
                    new Book{BookID=5, BookNm="Spiritual Gurus"}
                };

                List<Order> bookOrders = new List<Order>
                {
                    new Order{OrderID=1, BookID=1, PaymentMode="Cheque"},
                    new Order{OrderID=2, BookID=5, PaymentMode="Credit"},
                    new Order{OrderID=3, BookID=1, PaymentMode="Cash"},
                    new Order{OrderID=4, BookID=3, PaymentMode="Cheque"},
                    new Order{OrderID=5, BookID=5, PaymentMode="Cheque"},
                    new Order{OrderID=6, BookID=4, PaymentMode="Cash"}
                };

                var orderForBooks = from bk in bookList
                                    join ordr in bookOrders
                                    on bk.BookID equals ordr.BookID
                                    into a
                                    from b in a.DefaultIfEmpty(new Order())
                                    select new
                                    {
                                        bk.BookID,
                                        Name = bk.BookNm,
                                        b.PaymentMode
                                    };

                foreach (var item in orderForBooks)
                    Console.WriteLine(item);

                Console.ReadLine();
            }
        }

        class Program16
        {
            static void Main(string[] args)
            {
                // code from DevCurry.com
                var arr = new[] { 5, 3, 4, 2, 6, 7 };
                var sq = from int num in arr
                         let square = num * num
                         where square > 10
                         select new { num, square };

                foreach (var a in sq)
                    Console.WriteLine(a);

                Console.ReadLine();
            }
        }

        class Program17
        {
            static void Main(string[] args)
            {

                var attributes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from exptype in assembly.GetExportedTypes()
                                 where typeof(Attribute).IsAssignableFrom(exptype)
                                 select exptype;

                foreach (var nm in attributes)
                {
                    Console.WriteLine("Attribute Name: {0} \nFullName: {1}",
                        nm.Name, nm.FullName);
                    Console.WriteLine("-------------------------------------------");
                }

                Console.ReadLine();
            }
        }

        class Program18
        {
            static void main(string[] args)
            {
                //string[] uCase = { "A", "B", "C" };
                //string[] lCase = { "a", "b", "c" };

                //foreach (string s1 in uCase)
                //{
                //    foreach (string s2 in lCase)
                //    {
                //        Console.WriteLine(s1 + s2);
                //    }
                //}

                string[] uCase = { "A", "B", "C" };
                string[] lCase = { "a", "b", "c" };

                var ul = uCase.SelectMany(
                    uc => lCase, (uc, lc) => (uc + lc));

                foreach (string s in ul)
                {
                    Console.WriteLine(s);
                }
            }
        }

        class Program19
        {
            public static void Main()
            {
                // Assuming the array with file names is returned via a service
                string[] arr = {"abc1.txt", "abc2.TXT",
                "xyz.abc.pdf", "abc.PDF", "abc.xml", "zy.txt" };

                var extGrp = arr.Select(file => Path.GetExtension(file)
                                                    .TrimStart('.').ToLower())
                         .GroupBy(x => x,
                                  (ext, extCnt) =>
                                      new
                                      {
                                          Extension = ext,
                                          Count = extCnt.Count()
                                      });
                // Print values
                foreach (var a in extGrp)
                    Console.WriteLine("{0} file(s) with {1} extension ",
                        a.Count, a.Extension);
                Console.ReadLine();
            }
        }

        class Program20
        {
            public static void Main()
            {
                string name = "Suprotim, Agarwal";
                name = string.Join(", ", name.Split(',').Reverse()).Trim();
                Console.WriteLine(name);
                Console.ReadLine();
            }
        }
    }
}

