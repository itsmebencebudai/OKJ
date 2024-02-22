using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _101_LINQ_Samples
{
    internal class Program
    {
        //Aggregate(simple)
        private static void Sample_Aggregate_Lambda_Simple()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };

            var result = numbers.Aggregate((a, b) => a * b);

            Console.WriteLine("Aggregated numbers by multiplication:");
            Console.WriteLine(result);
        }

        //Aggregate (seed)
        private static void Sample_Aggregate_Lambda_Seed()
        {
            var numbers = new int[] { 1, 2, 3 };

            var result = numbers.Aggregate(10, (a, b) => a + b);

            Console.WriteLine("Aggregated numbers by addition with a seed of 10:");
            Console.WriteLine(result);
        }

        //Average
        static void Sample_Average_Lambda()
        {
            int[] numbers = { 10, 10, 11, 11 };

            var result = numbers.Average();

            Console.WriteLine("Average is:");
            Console.WriteLine(result);
        }

        //Count
        static void Sample_Count_Lambda()
        {
            string[] names = { "Peter", "John", "Kathlyn", "Allen", "Tim" };

            var result = names.Count();

            Console.WriteLine("Counting names gives:");
            Console.WriteLine(result);
        }

        //LongCount
        // Use LongCount() when you expect the result to be greater than Int32.MaxValue()
        static void Sample_LongCount_Lambda()
        {
            // Create array which is 5 elements larger than Int32.MaxValue
            var largeArr = Enumerable.Range(0, Int32.MaxValue).Concat(Enumerable.Range(0, 5));

            Int64 result = largeArr.LongCount();

            Console.WriteLine("Counting largeArr elements:");
            Console.WriteLine(result);
        }

        //Max
        static void Sample_Max_Lambda()
        {
            int[] numbers = { 2, 8, 5, 6, 1 };

            var result = numbers.Max();

            Console.WriteLine("Highest number is:");
            Console.WriteLine(result);
        }

        //Min
        static void Sample_Min_Lambda()
        {
            int[] numbers = { 6, 9, 3, 7, 5 };

            var result = numbers.Min();

            Console.WriteLine("Lowest number is:");
            Console.WriteLine(result);
        }

        //Sum
        static void Sample_Sum_Lambda()
        {
            int[] numbers = { 2, 5, 10 };

            var result = numbers.Sum();

            Console.WriteLine("Summing the numbers yields:");
            Console.WriteLine(result);
        }

        //AsEnumerable
        static void Sample_AsEnumerable_Lambda()
        {
            string[] names = { "John", "Suzy", "Dave" };

            var result = names.AsEnumerable();

            Console.WriteLine("Iterating over IEnumerable collection:");
            foreach (var name in result)
                Console.WriteLine(name);
        }

        //Cast
        // Note: The source we're casting from must contain only elements of the same type.
        static void Sample_Cast_Lambda()
        {
            List<string> vegetables = new List<string> { "Cucumber", "Tomato", "Broccoli" };

            var result = vegetables.Cast<string>();

            Console.WriteLine("List of vegetables casted to a simple string array:");
            foreach (string vegetable in result)
                Console.WriteLine(vegetable);
        }

        //OfType
        static void Sample_OfType_Lambda()
        {
            object[] objects = { "Thomas", 31, 5.02, null, "Joey" };

            var result = objects.OfType<string>();

            Console.WriteLine("Objects being of type string have the values:");
            foreach (string str in result)
                Console.WriteLine(str);
        }

        //ToArray
        static void Sample_ToArray_Lambda()
        {
            int[] numbers = { 1, 2, 3, 4 };

            var result = numbers.ToArray();

            Console.WriteLine("New array contains identical values:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //ToDictionary (simple)
        class English2German
        {
            public string EnglishSalute { get; set; }
            public string GermanSalute { get; set; }
        }

        static void Sample_ToDictionary_Lambda_Simple()
        {
            English2German[] english2German =
            {
        new English2German { EnglishSalute = "Good morning", GermanSalute = "Guten Morgen" },
        new English2German { EnglishSalute = "Good day", GermanSalute = "Guten Tag" },
        new English2German { EnglishSalute = "Good evening", GermanSalute = "Guten Abend" },
    };

            var result = english2German.ToDictionary(k => k.EnglishSalute, v => v.GermanSalute);

            Console.WriteLine("Values inserted into dictionary:");
            foreach (KeyValuePair<string, string> dic in result)
                Console.WriteLine(String.Format("English salute {0} is {1} in German", dic.Key, dic.Value));
        }

        //ToDictionary (conditional)
        static void Sample_ToDictionary_Lambda_Conditional()
        {
            int[] numbers = { 1, 2, 3, 4 };

            var result = numbers.ToDictionary(k => k, v => (v % 2) == 1 ? "Odd" : "Even");

            Console.WriteLine("Numbers labeled Odd and Even in dictionary:");
            foreach (var dic in result)
                Console.WriteLine("Value {0} is {1}", dic.Key, dic.Value);
        }

        //ToList
        static void Sample_ToList_Lambda()
        {
            string[] names = { "Brenda", "Carl", "Finn" };

            List<string> result = names.ToList();

            Console.WriteLine(String.Format("names is of type: {0}", names.GetType().Name));
            Console.WriteLine(String.Format("result is of type: {0}", result.GetType().Name));
        }

        //ToLookup
        static void Sample_ToLookup_Lambda()
        {
            string[] words = { "one", "two", "three", "four", "five", "six", "seven" };

            var result = words.ToLookup(w => w.Length);

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(String.Format("Elements with a length of {0}:", i));
                foreach (string word in result[i])
                    Console.WriteLine(word);
            }
        }

        //ElementAt
        static void Sample_ElementAt_Lambda()
        {
            string[] words = { "One", "Two", "Three" };

            var result = words.ElementAt(1);

            Console.WriteLine("Element at index 1 in the array is:");
            Console.WriteLine(result);
        }

        //ElementAtOrDefault
        static void Sample_ElementAtOrDefault_Lambda()
        {
            string[] colors = { "Red", "Green", "Blue" };

            var resultIndex1 = colors.ElementAtOrDefault(1);

            var resultIndex10 = colors.ElementAtOrDefault(10);

            Console.WriteLine("Element at index 1 in the array contains:");
            Console.WriteLine(resultIndex1);

            Console.WriteLine("Element at index 10 in the array does not exist:");
            Console.WriteLine(resultIndex10 == null);
        }

        //First (simple)
        // Note: Operator First will throw an exception, if there is not at least one element in the sequence.
        static void Sample_First_Lambda_Simple()
        {
            string[] fruits = { "Banana", "Apple", "Orange" };

            var result = fruits.First();

            Console.WriteLine("First element in the array is:");
            Console.WriteLine(result);
        }

        //First (conditional)
        static void Sample_First_Lambda_Conditional()
        {
            string[] countries = { "Denmark", "Sweden", "Norway" };

            var result = countries.First(c => c.Length == 6);

            Console.WriteLine("First element with a length of 6 characters:");
            Console.WriteLine(result);
        }

        //FirstOrDefault
        // Note: While First() will throw an exception if array...
        //       ...is empty, FirstOrDefault gracefully returns null.
        static void Sample_FirstOrDefault_Lambda()
        {
            string[] countries = { "Denmark", "Sweden", "Norway" };
            string[] empty = { };

            var result = countries.FirstOrDefault();

            var resultEmpty = empty.FirstOrDefault();

            Console.WriteLine("First element in the countries array contains:");
            Console.WriteLine(result);

            Console.WriteLine("First element in the empty array does not exist:");
            Console.WriteLine(resultEmpty == null);
        }

        //Last
        static void Sample_Last_Lambda()
        {
            int[] numbers = { 7, 3, 5 };

            var result = numbers.Last();

            Console.WriteLine("Last number in array is:");
            Console.WriteLine(result);
        }

        //LastOrDefault (simple)
        // Note: While Last will throw an exception if array...
        //       ...is empty, LastOrDefault gracefully returns null.
        static void Sample_LastOrDefault_Simple()
        {
            string[] words = { "one", "two", "three" };
            string[] empty = { };

            var result = words.LastOrDefault();

            var resultEmpty = empty.LastOrDefault();

            Console.WriteLine("Last element in the words array contains:");
            Console.WriteLine(result);

            Console.WriteLine("Last element in the empty array does not exist:");
            Console.WriteLine(resultEmpty == null);
        }

        //LastOrDefault (conditional)
        // Note: While Last will throw an exception if array...
        //       ...is empty, LastOrDefault gracefully returns null.
        static void Sample_LastOrDefault_Conditional()
        {
            string[] words = { "one", "two", "three" };

            var result = words.LastOrDefault(w => w.Length == 3);

            var resultNoMatch = words.LastOrDefault(w => w.Length == 2);

            Console.WriteLine("Last element in the words array having a length of 3:");
            Console.WriteLine(result);

            Console.WriteLine("Last element in the empty array having a length of 2 does not exist:");
            Console.WriteLine(resultNoMatch == null);
        }

        //Single
        // Note: Single will throw an Exception, if there is not exactly one element in the array.
        static void Sample_Single_Lambda()
        {
            string[] names1 = { "Peter" };
            string[] names3 = { "Peter", "Joe", "Wilma" };
            string[] empty = { };

            var result1 = names1.Single();

            Console.WriteLine("The only name in the array is:");
            Console.WriteLine(result1);

            try
            {
                // This will throw an exception because array contains no elements
                var resultEmpty = empty.Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                // This will throw an exception as well because array contains more than one element
                var result3 = names3.Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //SingleOrDefault
        // Note: SingleOrDefault retrieves null value if array is empty, and...
        //       ...throws an exception if array contains more than one element.
        static void Sample_SingleOrDefault_Lambda()
        {
            string[] names1 = { "Peter" };
            string[] names3 = { "Peter", "Joe", "Wilma" };
            string[] empty = { };

            var result1 = names1.SingleOrDefault();

            var resultEmpty = empty.SingleOrDefault();

            Console.WriteLine("The only name in the array is:");
            Console.WriteLine(result1);

            Console.WriteLine("As array is empty, SingleOrDefault yields null:");
            Console.WriteLine(resultEmpty == null);

            try
            {
                // This will throw an exception as well because array contains more than one element
                var result3 = names3.SingleOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //DefaultIfEmpty (simple)
        static void Sample_DefaultIfEmpty_Lambda_Simple()
        {
            string[] emptyStr = { };
            int[] emptyInt = { };
            string[] words = { "one", "two", "three" };

            var resultStr = emptyStr.DefaultIfEmpty(); // Default is null for string

            var resultInt = emptyInt.DefaultIfEmpty(); // Default is 0 for int

            var resultWords = words.DefaultIfEmpty(); // Not empty, so words array is just copied

            Console.WriteLine("resultStr has one element with a value of null:");
            Console.WriteLine(resultStr.Count() == 1 && resultStr.First() == null);

            Console.WriteLine("resultInt has one element with a value of 0:");
            Console.WriteLine(resultInt.Count() == 1 && resultInt.First() == 0);

            Console.WriteLine("resultWords has same content as words array:");
            Console.WriteLine(resultWords.SequenceEqual(words));
        }

        //DefaultIfEmpty (default value)
        static void Sample_DefaultIfEmpty_Lambda_DefaultValue()
        {
            int[] empty = { };

            var result = empty.DefaultIfEmpty(5);

            Console.WriteLine("result contains one element with a value of 5:");
            Console.WriteLine(result.Count() == 1 && result.First() == 5);
        }


        //Empty
        static void Sample_Empty_Lambda()
        {
            var empty = Enumerable.Empty<string>();
            // To make sequence into an array use empty.ToArray()

            Console.WriteLine("Sequence is empty:");
            Console.WriteLine(empty.Count() == 0);
        }

        //Range
        static void Sample_Range_Lambda()
        {
            var result = Enumerable.Range(0, 10);

            Console.WriteLine("Counting from 0 to 9:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Repeat
        static void Sample_Repeat_Lambda()
        {
            string word = "Banana";

            var result = Enumerable.Repeat(word, 5);

            Console.WriteLine("String is repeated 5 times:");
            foreach (string str in result)
                Console.WriteLine(str);
        }

        //GroupBy
        static void Sample_GroupBy_Lambda()
        {
            int[] numbers = { 10, 15, 20, 25, 30, 35 };

            var result = numbers.GroupBy(n => (n % 10 == 0));

            Console.WriteLine("GroupBy has created two groups:");
            foreach (IGrouping<bool, int> group in result)
            {
                if (group.Key == true)
                    Console.WriteLine("Divisible by 10");
                else
                    Console.WriteLine("Not Divisible by 10");

                foreach (int number in group)
                    Console.WriteLine(number);
            }
        }

        //GroupJoin (left outer join)
        class Language
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Person
        {
            public int LanguageId { get; set; }
            public string FirstName { get; set; }
        }

        static void Sample_GroupJoin_Lambda()
        {
            Language[] languages = new Language[]
            {
        new Language {Id = 1, Name = "English"},
        new Language {Id = 2, Name = "Russian"}
            };

            Person[] persons = new Person[]
            {
        new Person { LanguageId = 1, FirstName = "Tom" },
        new Person { LanguageId = 1, FirstName = "Sandy" },
        new Person { LanguageId = 2, FirstName = "Vladimir" },
        new Person { LanguageId = 2, FirstName = "Mikhail" },
            };

            var result = languages.GroupJoin(persons, lang => lang.Id, pers => pers.LanguageId,
                (lang, ps) => new { Key = lang.Name, Persons = ps });

            Console.WriteLine("Group-joined list of people speaking either English or Russian:");
            foreach (var language in result)
            {
                Console.WriteLine(String.Format("Persons speaking {0}:", language.Key));

                foreach (var person in language.Persons)
                {
                    Console.WriteLine(person.FirstName);
                }
            }
        }

        //Join (inner join)
        static void Sample_Join_Lambda()
        {
            string[] warmCountries = { "Turkey", "Italy", "Spain", "Saudi Arabia", "Etiobia" };
            string[] europeanCountries = { "Denmark", "Germany", "Italy", "Portugal", "Spain" };

            var result = warmCountries.Join(europeanCountries, warm => warm, european => european, (warm, european) => warm);

            Console.WriteLine("Joined countries which are both warm and Europan:");
            foreach (var country in result) // Note: result is an anomymous type, thus must use a var to iterate.
                Console.WriteLine(country);
        }

        //OrderBy (simple - numbers)
        static void Sample_OrderBy_Lambda_Numbers()
        {
            int[] numbers = { 7, 9, 5 };

            var result = numbers.OrderBy(n => n);

            Console.WriteLine("Ordered list of numbers:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //OrderBy (simple - dates)
        static void Sample_OrderBy_Lambda_Dates()
        {
            var dates = new DateTime[] {
                new DateTime(2015, 2, 15),
                new DateTime(2015, 3, 25),
                new DateTime(2015, 1, 5)
            };

            var result = dates.OrderBy(d => d);

            Console.WriteLine("Ordered list of dates:");
            foreach (DateTime dt in result)
                Console.WriteLine(dt.ToString("yyyy/MM/dd"));
        }

        //OrderBy (simple - objects)
        class Car
        {
            public string Name { get; set; }
            public int HorsePower { get; set; }
        }

        static void Sample_OrderBy_Lambda_Objects()
        {
            Car[] cars =
                {
            new Car { Name = "Super Car", HorsePower = 215 },
            new Car { Name = "Economy Car", HorsePower = 75 },
            new Car { Name = "Family Car", HorsePower = 145 },
        };

            var result = cars.OrderBy(c => c.HorsePower);

            Console.WriteLine("Ordered list of cars by horsepower:");
            foreach (Car car in result)
                Console.WriteLine(String.Format("{0}: {1} horses", car.Name, car.HorsePower));
        }

        //OrderByDescending
        static void Sample_OrderByDescending_Lambda()
        {
            string[] names = { "Ned", "Ben", "Susan" };

            var result = names.OrderByDescending(n => n);

            Console.WriteLine("Descending ordered list of names:");
            foreach (string name in result)
                Console.WriteLine(name);
        }

        //Reverse
        static void Sample_Reverse_Lambda()
        {
            char[] characters = { 's', 'a', 'm', 'p', 'l', 'e' };

            var result = characters.Reverse();

            Console.WriteLine("Characters in reverse order:");
            foreach (char character in result)
                Console.WriteLine(character);
        }

        //ThenBy
        static void Sample_ThenBy_Lambda()
        {
            string[] capitals = { "Berlin", "Paris", "Madrid", "Tokyo", "London",
                          "Athens", "Beijing", "Seoul" };

            var result = capitals.OrderBy(c => c.Length).ThenBy(c => c);

            Console.WriteLine("Ordered list of capitals, first by length and then alphabetical:");
            foreach (string capital in result)
                Console.WriteLine(capital);
        }

        //ThenByDescending
        static void Sample_ThenByDescending_Lambda()
        {
            var dates = new DateTime[] {
        new DateTime(2015, 3, 1),
        new DateTime(2014, 7, 1),
        new DateTime(2013, 5, 1),
        new DateTime(2015, 1, 1),
        new DateTime(2015, 7, 1)
    };

            var result = dates.OrderByDescending(d => d.Year).ThenByDescending(d => d.Month);

            Console.WriteLine("List of dates first ordered by year descending, and then by month descending:");
            foreach (DateTime dt in result)
                Console.WriteLine(dt.ToString("yyyy/MM/dd"));
        }

        //Concat (simple - numbers)
        static void Sample_Concat_Lambda_Numbers()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 4, 5, 6 };

            var result = numbers1.Concat(numbers2);

            Console.WriteLine("Concatenating numbers1 and numbers2 gives:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Concat (simple - strings)
        static void Sample_Concat_Lambda_Strings()
        {
            string[] vegetables = { "Tomato", "Cucumber", "Carrot" };
            string[] fruits = { "Apples", "Grapes", "Banana" };

            var result = vegetables.Concat(fruits);

            Console.WriteLine("Concatinating vegetables and fruits gives:");
            foreach (string piece in result)
                Console.WriteLine(piece);
        }

        //SequenceEqual
        static void Sample_SequenceEqual_Lambda()
        {
            string[] words = { "one", "two", "three" };
            string[] wordsSame = { "one", "two", "three" };
            string[] wordsOrder = { "two", "three", "one" };
            string[] wordsCase = { "one", "TWO", "three" };

            var resultSame = words.SequenceEqual(wordsSame);
            var resultOrder = words.SequenceEqual(wordsOrder);
            var resultCase = words.SequenceEqual(wordsCase);
            var resultCaseIgnored = words.SequenceEqual(wordsCase, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("SequenceEqual on two identical arrays:");
            Console.WriteLine(resultSame);

            Console.WriteLine("SequenceEqual on two differently ordered but otherwise identical arrays:");
            Console.WriteLine(resultOrder);

            Console.WriteLine("SequenceEqual on two differently cased but otherwise identical arrays:");
            Console.WriteLine(resultCase);

            Console.WriteLine("SequenceEqual on two differently cased but otherwise identical arrays, where case is ignored:");
            Console.WriteLine(resultCaseIgnored);
        }

        //Zip
        static void Sample_Zip_Lambda()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 10, 11, 12 };

            var result = numbers1.Zip(numbers2, (a, b) => (a * b));

            Console.WriteLine("Using Zip to combine two arrays into one (1*10, 2*11, 3*12):");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Skip
        static void Sample_Skip_Lambda()
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };

            var result = words.Skip(4);

            Console.WriteLine("Skips the first 4 words:");
            foreach (string word in result)
                Console.WriteLine(word);
        }

        //SkipWhile
        static void Sample_SkipWhile_Lambda()
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };

            var result = words.SkipWhile(w => w.Length == 3);

            Console.WriteLine("Skips words while the condition is met:");
            foreach (string word in result)
                Console.WriteLine(word);
        }

        //Take
        static void Sample_Take_Lambda()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.Take(5);

            Console.WriteLine("Takes the first 5 numbers only:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //TakeWhile
        static void Sample_TakeWhile_Lambda()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.TakeWhile(n => n < 5);

            Console.WriteLine("Takes numbers one by one, and stops when condition is no longer met:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Select (simple)
        static void Sample_Select_Lambda_Simple()
        {
            decimal[] numbers = { 3.4M, 8.33M, 5.225M };

            var result = numbers.Select(n => Math.Floor(n));

            Console.WriteLine("Numbers rounded down:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Select (anonymous type)
        static void Sample_Select_Lambda_Anonymous()
        {
            double[] angles = { 30D, 60D, 90D }; // Angles in radians

            var result = angles.Select(a => new { Angle = a, Cos = Math.Cos(a), Sin = Math.Sin(a) });

            Console.WriteLine("Calculated values:");
            foreach (var res in result)
                Console.WriteLine(String.Format("Angle {0}: Cos = {1}, Sin = {2}", res.Angle, res.Cos, res.Sin));
        }

        //Select (indexed)
        static void Sample_Select_Lambda_Indexed()
        {
            string[] words = { "one", "two", "three" };

            var result = words.Select((w, i) => new
            {
                Index = i,
                Value = w
            });

            Console.WriteLine("Words with index and value:");
            foreach (var word in result)
                Console.WriteLine(String.Format("Index {0} is {1}", word.Index, word.Value));
        }

        //SelectMany (cross join)
        static void Sample_SelectMany_Lambda()
        {
            string[] fruits = { "Grape", "Orange", "Apple" };
            int[] amounts = { 1, 2, 3 };

            var result = fruits.SelectMany(f => amounts, (f, a) => new
            {
                Fruit = f,
                Amount = a
            });

            Console.WriteLine("Selecting all values from each array, and mixing them:");
            foreach (var o in result)
                Console.WriteLine(o.Fruit + ", " + o.Amount);
        }

        //All
        static void Sample_All_Lambda()
        {
            string[] names = { "Bob", "Ned", "Amy", "Bill" };

            var result = names.All(n => n.StartsWith("B"));

            Console.WriteLine("Does all of the names start with the letter 'B':");
            Console.WriteLine(result);
        }

        //Any
        static void Sample_Any_Lambda()
        {
            string[] names = { "Bob", "Ned", "Amy", "Bill" };

            var result = names.Any(n => n.StartsWith("B"));

            Console.WriteLine("Does any of the names start with the letter 'B':");
            Console.WriteLine(result);
        }

        //Contains
        static void Sample_Contains_Lambda()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };

            var result = numbers.Contains(5);

            Console.WriteLine("sequence contains the value 5:");
            Console.WriteLine(result);
        }

        //Where (simple - numbers)
        static void Sample_Where_Lambda_Numbers()
        {
            int[] numbers = { 5, 10, 15, 20, 25, 30 };

            var result = numbers.Where(n => n >= 15 && n <= 25);

            Console.WriteLine("Numbers being >= 15 and <= 25:");
            foreach (var number in result)
                Console.WriteLine(number);
        }

        //Where (simple - objects)
        class Person2
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Sample_Where_Lambda_Objects()
        {
            Person2[] persons = {
                new Person2 { Name = "Mike", Age = 25 },
                new Person2 { Name = "Joe", Age = 43 },
                new Person2 { Name = "Nadia", Age = 31 }
            };

            var result = persons.Where(p => p.Age >= 30);

            Console.WriteLine("Finding persons who are 30 years old or older:");
            foreach (Person2 person in result)
            {
                Console.WriteLine(String.Format("{0}: {1} years old", person.Name, person.Age));
            }
        }

        //Where (indexed)
        static void Sample_Where_Lambda_Indexed()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.Where((n, i) => n % 3 == 0 && i >= 5);

            Console.WriteLine("Numbers divisible by 3 and indexed >= 5:");
            foreach (var number in result)
                Console.WriteLine(number);
        }

        //Distinct
        static void Sample_Distinct_Lambda()
        {
            int[] numbers = { 1, 2, 2, 3, 5, 6, 6, 6, 8, 9 };

            var result = numbers.Distinct();

            Console.WriteLine("Distinct removes duplicate elements:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Except
        static void Sample_Except_Lambda()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 3, 4, 5 };

            var result = numbers1.Except(numbers2);

            Console.WriteLine("Except creates a single sequence from numbers1 and removes the duplicates found in numbers2:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Intersect
        static void Sample_Intersect_Lambda()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 3, 4, 5 };

            var result = numbers1.Intersect(numbers2);

            Console.WriteLine("Intersect creates a single sequence with only the duplicates:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        //Union
        static void Sample_Union_Lambda()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 3, 4, 5 };

            var result = numbers1.Union(numbers2);

            Console.WriteLine("Union creates a single sequence and eliminates the duplicates:");
            foreach (int number in result)
                Console.WriteLine(number);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Aggregate_Lambda_Simple");
            Sample_Aggregate_Lambda_Simple();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Aggregate_Lambda_Seed");
            Sample_Aggregate_Lambda_Seed();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Average_Lambda");
            Sample_Average_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Count_Lambda");
            Sample_Count_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_LongCount_Lambda");
            Sample_LongCount_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Max_Lambda");
            Sample_Max_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Min_Lambda");
            Sample_Min_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Sum_Lambda");
            Sample_Sum_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_AsEnumerable_Lambda");
            Sample_AsEnumerable_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Cast_Lambda");
            Sample_Cast_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_OfType_Lambda");
            Sample_OfType_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ToArray_Lambda");
            Sample_ToArray_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ToDictionary_Lambda_Simple");
            Sample_ToDictionary_Lambda_Simple();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ToDictionary_Lambda_Conditional");
            Sample_ToDictionary_Lambda_Conditional();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ToList_Lambda");
            Sample_ToList_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ToLookup_Lambda");
            Sample_ToLookup_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ElementAt_Lambda");
            Sample_ElementAt_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ElementAtOrDefault_Lambda");
            Sample_ElementAtOrDefault_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_First_Lambda_Simple");
            Sample_First_Lambda_Simple();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_First_Lambda_Conditional");
            Sample_First_Lambda_Conditional();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_FirstOrDefault_Lambda");
            Sample_FirstOrDefault_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Last_Lambda");
            Sample_Last_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_LastOrDefault_Simple");
            Sample_LastOrDefault_Simple();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_LastOrDefault_Conditional");
            Sample_LastOrDefault_Conditional();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Single_Lambda");
            Sample_Single_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_SingleOrDefault_Lambda");
            Sample_SingleOrDefault_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_DefaultIfEmpty_Lambda_Simple");
            Sample_DefaultIfEmpty_Lambda_Simple();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_DefaultIfEmpty_Lambda_DefaultValue");
            Sample_DefaultIfEmpty_Lambda_DefaultValue();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Empty_Lambda");
            Sample_Empty_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Range_Lambda");
            Sample_Range_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Repeat_Lambda");
            Sample_Repeat_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_GroupBy_Lambda");
            Sample_GroupBy_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_GroupJoin_Lambda");
            Sample_GroupJoin_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Join_Lambda");
            Sample_Join_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_OrderBy_Lambda_Numbers");
            Sample_OrderBy_Lambda_Numbers();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_OrderBy_Lambda_Dates");
            Sample_OrderBy_Lambda_Dates();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_OrderBy_Lambda_Objects");
            Sample_OrderBy_Lambda_Objects();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_OrderByDescending_Lambda");
            Sample_OrderByDescending_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Reverse_Lambda");
            Sample_Reverse_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ThenBy_Lambda");
            Sample_ThenBy_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_ThenByDescending_Lambda");
            Sample_ThenByDescending_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Concat_Lambda_Numbers");
            Sample_Concat_Lambda_Numbers();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Concat_Lambda_Strings");
            Sample_Concat_Lambda_Strings();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_SequenceEqual_Lambda");
            Sample_SequenceEqual_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Zip_Lambda");
            Sample_Zip_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Skip_Lambda");
            Sample_Skip_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_SkipWhile_Lambda");
            Sample_SkipWhile_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Take_Lambda");
            Sample_Take_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_TakeWhile_Lambda");
            Sample_TakeWhile_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Select_Lambda_Simple");
            Sample_Select_Lambda_Simple();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Select_Lambda_Anonymous");
            Sample_Select_Lambda_Anonymous();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Select_Lambda_Indexed");
            Sample_Select_Lambda_Indexed();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_SelectMany_Lambda");
            Sample_SelectMany_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_All_Lambda");
            Sample_All_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Any_Lambda");
            Sample_Any_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Contains_Lambda");
            Sample_Contains_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Where_Lambda_Numbers");
            Sample_Where_Lambda_Numbers();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Where_Lambda_Objects");
            Sample_Where_Lambda_Objects();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Where_Lambda_Indexed");
            Sample_Where_Lambda_Indexed();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Distinct_Lambda");
            Sample_Distinct_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Except_Lambda");
            Sample_Except_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Intersect_Lambda");
            Sample_Intersect_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sample_Union_Lambda");
            Sample_Union_Lambda();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
