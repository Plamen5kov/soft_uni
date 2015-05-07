using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var testSequenceDouble = new double[] { -2.5, 1.2, 1.5, 6.2, 5.123, 125.5502, 512.325 };
            var testSequenceDecimal = new decimal[] { 1123123123123123123.2M, 1.5M, 6.2M, 5.123M, 125.5502M, 512.325M };
            var testSequenceInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var testSequenceShort = new short[] { 1, 2, 3, 4, 5, 6 };
            var testSequenceLong = new long[] { 123456789, 2123123123, 3234234234, 4234234234234, 5556546456456, 551125151516 };
            var testSequenceString = new string[] { "123", "454", "15552", "12241" }; 

            Console.WriteLine("\nAverage");
            Console.WriteLine(Average(testSequenceDouble));
            Console.WriteLine(Average(testSequenceDecimal));
            Console.WriteLine(Average(testSequenceInt));
            Console.WriteLine(Average(testSequenceShort));
            Console.WriteLine(Average(testSequenceLong));
            //Console.WriteLine(Average(testSequenceString)); //won't work because of struct restriction -> non nullable
                                                              //any class won't work either because it's nullable and struct restriction won't allow it
            
            Console.WriteLine("\nMinimum");
            Console.WriteLine(Minumum(testSequenceDouble));
            Console.WriteLine(Minumum(testSequenceDecimal));
            Console.WriteLine(Minumum(testSequenceInt));
            Console.WriteLine(Minumum(testSequenceShort));
            Console.WriteLine(Minumum(testSequenceLong));
            //Console.WriteLine(Minumum(testSequenceString)); //same as above

            Console.WriteLine("\nMaximum");
            Console.WriteLine(Maximum(testSequenceDouble));
            Console.WriteLine(Maximum(testSequenceDecimal));
            Console.WriteLine(Maximum(testSequenceInt));
            Console.WriteLine(Maximum(testSequenceShort));
            Console.WriteLine(Maximum(testSequenceLong));
            //Console.WriteLine(Maximum(testSequenceString)); //same as above

            Console.WriteLine("\nProduct");
            Console.WriteLine(Product(testSequenceDouble));
            Console.WriteLine(Product(testSequenceDecimal));
            Console.WriteLine(Product(testSequenceInt));
            Console.WriteLine(Product(testSequenceShort));
            Console.WriteLine(Product(testSequenceLong));
            //Console.WriteLine(Product(testSequenceString)); //same as above
        }

        private static T Average<T>(ICollection<T> array) where T : struct, IComparable<T>, IConvertible
        {
            dynamic sum = 0;
            foreach (T item in array)
            {
                sum += item;
            }
            var average = sum / array.Count;
            return (T)average;
        }

        private static T Minumum<T>(ICollection<T> array) where T : struct, IComparable<T>, IConvertible
        {
            T minimum = array.First();
            foreach (var item in array)
            {
                if (item.CompareTo(minimum) < 0)
                {
                    minimum = item;
                }
            }

            return minimum;
        }

        private static T Maximum<T>(ICollection<T> array) where T : struct, IComparable<T>, IConvertible
        {
            T maximum = array.First();
            foreach (var item in array)
            {
                if (item.CompareTo(maximum) > 0)
                {
                    maximum = item;
                }
            }

            return maximum;
        }

        private static T Product<T>(ICollection<T> array) where T : struct, IComparable<T>, IConvertible
        {
            dynamic sum = 1;
            foreach (T item in array)
            {
                sum *= item;
            }
            var average = sum / array.Count;
            return (T)average;
        }
    }
}
