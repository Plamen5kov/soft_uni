using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collect_the_coins
{
    class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position()
        {
            this.Row = 0;
            this.Col = 0;
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col; ;
        }
    }
    class Program
    {
        static int coinsCollected = 0;
        static int wallsHit = 0;
        static void Main(string[] args)
        {
            //test
            // Sj0u$hbc
            // $87yihc87
            // Ewg3444
            // $4$$
            // V>>^^>>>VVV<<

            var matrix = new List<IList<char>>();

            for (int i = 0; i < 4; i++)
            {
                var line = Console.ReadLine();
                var tempList = new List<char>();
                foreach (var symbol in line)
                {
                    tempList.Add(symbol);
                }
                matrix.Add(tempList);
            }

            var directions = Console.ReadLine();
            var currentPosition = new Position();
            foreach (var direction in directions)
            {
                ParseCommand(direction, matrix, currentPosition);
            }

            Console.WriteLine("Coins collected: {0}", coinsCollected);
            Console.WriteLine("Walls hit: {0}", wallsHit);
        }

        private static void ParseCommand(char direction, List<IList<char>> matrix, Position crPos)
        {
            if (direction == 'V')
            {
                crPos.Row++;
                DoActionForPosition(matrix, crPos, direction);
            }
            else if (direction == '^')
            {
                crPos.Row--;
                DoActionForPosition(matrix, crPos, direction);
            }
            else if (direction == '<')
            {
                crPos.Col--;
                DoActionForPosition(matrix, crPos, direction);
            }
            else if (direction == '>')
            {
                crPos.Col++;
                DoActionForPosition(matrix, crPos, direction);
            }
            else
            {
                throw new ArgumentException("There is no such command for direction.");
            }
        }

        private static void DoActionForPosition(List<IList<char>> matrix, Position crPos, char direction)
        {
            if ((crPos.Row < matrix.Count) &&  //down boundry
                (crPos.Row >= 0) && // up boundry
                (crPos.Col >= 0) && //left boundry
                (crPos.Col < matrix[crPos.Row].Count)) //right boundry
            {
                var currentSymbol = matrix[crPos.Row][crPos.Col];
                if (currentSymbol == '$')
                {
                    coinsCollected++;
                }   
            }
            else
            {
                wallsHit++;

                //reverse action if you hit a wall
                if (direction == 'V') crPos.Row--;
                else if (direction == '^') crPos.Row++;
                else if (direction == '<') crPos.Col++;
                else if (direction == '>') crPos.Col--;
            }
        }
    }
}
