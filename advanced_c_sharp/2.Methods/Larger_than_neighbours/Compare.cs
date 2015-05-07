using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Larger_than_neighbours
{
    public static class Compare
    {
        static void Main(string[] args)
        {
            var numbersArr = new int[] { 1, 3, 4, 5, 1, 0, 5 };

            for (int i = 0; i < numbersArr.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbersArr, i));
            }
        }

        public static bool IsLargerThanNeighbours(IList<int> numbersArr, int i)
        {
            var currentNumber = numbersArr[i];
            int? nextNumber = null;
            int? prevNumber = null;
            if((i + 1) < numbersArr.Count)
            {
                nextNumber = numbersArr[i + 1];
            }
            if(i > 0) 
            {
                prevNumber = numbersArr[i - 1];
            }

            if (prevNumber == null)
            {
                return currentNumber > nextNumber ? true : false;
            }
            else if (nextNumber == null)
            {
                return currentNumber > prevNumber ? true : false;
            }
            else if(currentNumber > prevNumber && currentNumber > nextNumber) 
            {
                return true;
            }

            return false;
        }
    }
}
