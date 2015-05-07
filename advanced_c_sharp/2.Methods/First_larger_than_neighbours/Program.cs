using Larger_than_neighbours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_larger_than_neighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCollections = new List<ICollection<int>>();
            testCollections.Add(new int[] { 1, 3, 4, 5, 1, 0, 5});
            testCollections.Add(new List<int>() { 1, 2, 3, 4, 5, 6, 6 });
            testCollections.Add(new List<int>() { 1, 1, 1 });

            foreach (IList<int> collection in testCollections)
            {
                Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(collection));
            }   
        }

        public static int GetIndexOfFirstElementLargerThanNeighbours(IList<int> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
			{
                var elementIsLargerThanNeighbours = Compare.IsLargerThanNeighbours(sequence, i);
                if (elementIsLargerThanNeighbours)
                {
                    return i;
                }
			}

            return -1;
        }
    }
}
