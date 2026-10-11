namespace Task_Linq_1

{
    public class StaffMember
    {
        public int Code { get; set; }
        public string FullName { get; set; }
        public double MonthlySalary { get; set; }

        public StaffMember(int code, string name, double salary)
        {
            Code = code;
            FullName = name;
            MonthlySalary = salary;
        }
    }

    public static class CustomLinqExtensions
    {
        // 1- Custom Where
        public static void FilterWhere(this List<int> source, Func<int, bool> predicate)
        {
            foreach (var val in source)
            {
                if (predicate(val))
                    Console.WriteLine(val);
            }
        }

        // 2- Custom Where with Index
        public static void FilterWhereIndexed(this List<int> source, Func<int, int, bool> predicate)
        {
            for (int index = 0; index < source.Count; index++)
            {
                if (predicate(source[index], index))
                    Console.WriteLine(source[index]);
            }
        }

        // 3- Custom Select
        public static void MapSelect(this List<int> source, Func<int, int> mapper)
        {
            foreach (var element in source)
            {
                Console.WriteLine(mapper(element));
            }
        }

        // 4- Custom Select with Index
        public static void MapSelectIndexed(this List<int> source, Func<int, int, int> mapper)
        {
            for (int idx = 0; idx < source.Count; idx++)
            {
                Console.WriteLine(mapper(source[idx], idx));
            }
        }

        // 5- Custom Take
        public static void TakeFirst(this List<int> source, int limit)
        {
            for (int i = 0; i < limit && i < source.Count; i++)
            {
                Console.WriteLine(source[i]);
            }
        }

        // 6- Custom Skip
        public static void SkipFirst(this List<int> source, int offset)
        {
            for (int i = offset; i < source.Count; i++)
            {
                Console.WriteLine(source[i]);
            }
        }

        // 7- Custom TakeLast
        public static void TakeFromEnd(this List<int> source, int count)
        {
            int startIndex = source.Count - count;
            if (startIndex < 0) startIndex = 0;

            for (int i = startIndex; i < source.Count; i++)
            {
                Console.WriteLine(source[i]);
            }
        }

        // 8- Custom SkipLast
        public static void SkipFromEnd(this List<int> source, int count)
        {
            for (int i = 0; i < source.Count - count; i++)
            {
                Console.WriteLine(source[i]);
            }
        }

        // 9- Custom TakeWhile
        public static void TakeCondition(this List<int> source, Func<int, bool> condition)
        {
            foreach (var item in source)
            {
                if (condition(item))
                    Console.WriteLine(item);
                else
                    break;
            }
        }

        // 10- Custom SkipWhile
        public static void SkipCondition(this List<int> source, Func<int, bool> condition)
        {
            bool stopSkipping = false;
            foreach (var item in source)
            {
                if (!stopSkipping && condition(item))
                    continue;

                stopSkipping = true;
                Console.WriteLine(item);
            }
        }

        // 11- Custom OrderBy (Ascending)
        public static void SortAscending(this List<int> source)
        {
            List<int> sortedList = new List<int>(source);

            for (int i = 0; i < sortedList.Count; i++)
            {
                for (int j = 0; j < sortedList.Count - 1 - i; j++)
                {
                    if (sortedList[j] > sortedList[j + 1])
                    {
                        int tempValue = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = tempValue;
                    }
                }
            }

            foreach (var number in sortedList)
                Console.WriteLine(number);
        }

        // 12- Custom OrderByDescending
        public static void SortDescending(this List<int> source)
        {
            List<int> sortedList = new List<int>(source);

            for (int i = 0; i < sortedList.Count; i++)
            {
                for (int j = 0; j < sortedList.Count - 1 - i; j++)
                {
                    if (sortedList[j] < sortedList[j + 1])
                    {
                        int tempValue = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = tempValue;
                    }
                }
            }

            foreach (var number in sortedList)
                Console.WriteLine(number);
        }

        // 13- Custom Reverse
        public static void ReverseItems(this List<int> source)
        {
            for (int i = source.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(source[i]);
            }
        }

        // 14- Custom First
        public static void FetchFirstMatch(this List<int> source, Func<int, bool> match)
        {
            foreach (var val in source)
            {
                if (match(val))
                {
                    Console.WriteLine(val);
                    return;
                }
            }
        }

        // 15- Custom Last
        public static void FetchLastMatch(this List<int> source, Func<int, bool> match)
        {
            int lastMatchValue = -1;
            foreach (var val in source)
            {
                if (match(val))
                    lastMatchValue = val;
            }
            Console.WriteLine(lastMatchValue);
        }

        // 16- Custom Count
        public static void CountMatches(this List<int> source, Func<int, bool> match)
        {
            int total = 0;
            foreach (var val in source)
            {
                if (match(val))
                    total++;
            }
            Console.WriteLine($"Total Matches: {total}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<StaffMember> staffList = new List<StaffMember>
            {
                new StaffMember(101, "Aser Fathi", 15000),
                new StaffMember(202, "Fathi Bahaa", 12000),
                new StaffMember(303, "Ahmed Taha", 25000),
                new StaffMember(404, "Eslam Elbrbry", 30000),
                new StaffMember(505, "Youssef Elsherbiny", 18000)
            };

            List<int> numberList = new List<int> { 5, 42, 108, 24, 76, -120, -350, -45 };

            // === Testing Extension Methods ===
            numberList.FilterWhere(n => n > 0);
            numberList.FilterWhereIndexed((n, i) => i % 2 == 0);
            numberList.MapSelect(n => n * 3);
            numberList.MapSelectIndexed((n, i) => n + i);
            numberList.TakeFirst(4);
            numberList.SkipFirst(2);
            numberList.TakeFromEnd(3);
            numberList.SkipFromEnd(2);
            numberList.TakeCondition(n => n > 0);
            numberList.SkipCondition(n => n > 0);
            numberList.SortAscending();
            numberList.SortDescending();
            numberList.ReverseItems();
            numberList.FetchFirstMatch(n => n < 0);
            numberList.FetchLastMatch(n => n < 0);
            numberList.CountMatches(n => n > 0);
        }
    }
}