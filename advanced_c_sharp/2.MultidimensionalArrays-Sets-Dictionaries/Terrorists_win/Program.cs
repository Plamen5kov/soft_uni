using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrorists_win
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            // prepare|yo|dong
            // de_dust2 |A| the best |BB|map!

            var input = Console.ReadLine().Trim();
            var bombs = GetBombs(input);

            var result = DetonateBombs(input, bombs);
            Console.WriteLine(result);
        }

        private static string DetonateBombs(string input, IDictionary<string, int> bombs)
        {
            var fieldAfterDetonation = new StringBuilder(input);
            foreach (KeyValuePair<string, int> bomb in bombs)
            {
                var blastArea = GetBombBlastArea(bomb.Key);
                Detonate(fieldAfterDetonation, blastArea, bomb);
            }
            return fieldAfterDetonation.ToString();
        }

        private static void Detonate(StringBuilder fieldAfterDetonation, int blastArea, KeyValuePair<string, int> bomb)
        {
            var startOfBlastArea = bomb.Value - blastArea;
            var endOfBlastArea = bomb.Value + bomb.Key.Length + blastArea + 1;

            if (startOfBlastArea < 0)
            {
                startOfBlastArea = 0;
            }
            if (endOfBlastArea >= fieldAfterDetonation.Length)
            {
                endOfBlastArea = fieldAfterDetonation.Length - 1;
            }

            var blastedPart = '.';
            for (int i = 0; i < fieldAfterDetonation.Length; i++)
            {
                if (i >= startOfBlastArea && i <= endOfBlastArea)
                {
                    fieldAfterDetonation[i] = blastedPart;
                }
            }
        }

        private static int GetBombBlastArea(string bomb)
        {
            var sum = 0;
            foreach (var symbol in bomb)
            {
                sum += (int)symbol;
            }

            return sum % 10;
        }

        private static IDictionary<string, int> GetBombs(string input)
        {
            var bombs = new Dictionary<string, int>();
            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];
                if (currentSymbol == '|')
                {
                    var bombStartsIndex = i;
                    var sb = new StringBuilder();
                    i++;
                    while (true)
                    {
                        currentSymbol = input[i++];
                        if (currentSymbol == '|')
                        {
                            break;
                        }
                        sb.Append(currentSymbol);
                    }
                    bombs.Add(sb.ToString(), bombStartsIndex);
                    sb.Clear();
                    continue;
                }
            }

            return bombs;
        }
    }
}
