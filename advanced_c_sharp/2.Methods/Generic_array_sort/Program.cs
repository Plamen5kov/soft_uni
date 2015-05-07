using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_array_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArrInt = new List<int>() { 1, 6, 2, 3, 7, 8, 4, -1, -2, -5, 1 };
            var testArrLinkedList = new LinkedList<int>();
            testArrLinkedList.AddLast(1);
            testArrLinkedList.AddLast(120);
            testArrLinkedList.AddLast(-23);
            testArrLinkedList.AddLast(0412);
            testArrLinkedList.AddLast(23);
            testArrLinkedList.AddLast(-44);
            testArrLinkedList.AddLast(-23);
            testArrLinkedList.AddLast(25);

            var result = SortList(testArrInt);
            var resultLinkedList = SortList(testArrLinkedList);

            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(string.Join(", ", resultLinkedList));
        }

        public static ICollection<T> SortList<T>(ICollection<T> values) where T : IComparable<T>
        {
            ICollection<T> _left = new List<T>();
            ICollection<T> _right = new List<T>();

            if (values.Count() > 1)
            {
                T pivot = values.Last();
                values.Remove(pivot); //won't work with fixed size arrays because they are of fixed size and can't use linq to remove
                
                foreach (T each in values)
                {
                    if (each.CompareTo(pivot) == 1)
                    {
                        _right.Add(each);
                    }
                    else
                    {
                        _left.Add(each);
                    }
                }
                return MergeList(SortList(_left), pivot, SortList(_right));
            }
            return values;
        }

        private static ICollection<T> MergeList<T>(ICollection<T> left, T pivot, ICollection<T> right)
        {
            left.Add(pivot);
            foreach (var item in right)
            {
                left.Add(item);
            }
            return left;
        }
    }
}
