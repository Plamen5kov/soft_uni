using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_the_stars
{
    class Position
    {
        public double Row { get; set; }
        public double Col { get; set; }

        public Position(double row, double col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
    class Program
    {
        static int[,] space;
        static Dictionary<string, Position> starSystems;
        static int stepsToTake;
        static Position startPosition;

        static void Main(string[] args)
        {
            //test
            // Sirius 3 7
            // Alpha-Centauri 7 5
            // Gamma-Cygni 10 10
            // 8 1
            // 6

            starSystems = new Dictionary<string, Position>();
            space = new int[30, 30];
            
            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Trim().Split();
                var col = double.Parse(input[1]);
                var row = double.Parse(input[2]);
                starSystems.Add(input[0].ToLower(), new Position(row, col));
            }

            var shipPositionStart = Console.ReadLine().Trim().Split().ToArray().Select(double.Parse).ToList();
            startPosition = new Position(shipPositionStart[1], shipPositionStart[0]);

            stepsToTake = int.Parse(Console.ReadLine());

            for (double row = startPosition.Row, col = startPosition.Col; row <= startPosition.Row + stepsToTake; row++)
            {
                var currentPosition = new Position(row, col);
                var result = PositionIisInSrarSystem(currentPosition);
                Console.WriteLine(result);
            }
        }

        private static string PositionIisInSrarSystem(Position currentPosition)
        {
            var currentPositionInSpace = string.Empty;
            foreach (var pair in starSystems)
            {
                var positionInSpace = CompareSystemToPosition(pair, currentPosition);
                if (positionInSpace != "space")
                {
                    return positionInSpace;
                }
            }

            return "space";
        }

        private static string CompareSystemToPosition(KeyValuePair<string, Position> pair, Position currentPosition)
        {
            //inside star system
            if ((currentPosition.Row <= pair.Value.Row + 1) && 
                (currentPosition.Row >= pair.Value.Row - 1) &&
                (currentPosition.Col <= pair.Value.Col + 1) &&
                (currentPosition.Col >= pair.Value.Col - 1))
            {
                return pair.Key;
            }

            return "space";
        }
    }
}
