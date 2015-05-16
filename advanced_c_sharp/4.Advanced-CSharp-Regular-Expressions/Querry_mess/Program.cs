using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Querry_mess
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var keyValueDictionary = new Dictionary<string, List<string>>();
                var input = Console.ReadLine().Trim();
                if (input == "END")
                {
                    break;
                }

                GetKeyValuePairs(input, keyValueDictionary);

                PrintKeyValuesWithRequiredFormat(keyValueDictionary);

                keyValueDictionary.Clear();
            }
        }

        private static void PrintKeyValuesWithRequiredFormat(Dictionary<string, List<string>> keyValueDictionary)
        {
            var sb = new StringBuilder();

            foreach (var pair in keyValueDictionary)
            {
                sb.AppendFormat("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
            }
            Console.WriteLine(sb);
        }

        private static void GetKeyValuePairs(string input, Dictionary<string, List<string>> keyValueDictionary)
        {
            var allKeyValuePairs = GetWholeKeyValueString(input);

            var separateKeyValuesStrings = allKeyValuePairs.Split('&').ToList();

            TransformSpaces(separateKeyValuesStrings);

            FillKeyValueDictionary(separateKeyValuesStrings, keyValueDictionary);
        }

        private static void FillKeyValueDictionary(List<string> separateKeyValuesStrings, Dictionary<string, List<string>> keyValueDictionary)
        {
            foreach (var keyValueString in separateKeyValuesStrings)
            {
                var keyValuePair = keyValueString.Split('=').ToList();
                var key = keyValuePair[0].Trim();
                var value = keyValuePair[1].Trim();
                if (!keyValueDictionary.ContainsKey(key))
                {
                    keyValueDictionary.Add(key, new List<string>());
                }

                keyValueDictionary[key].Add(value);
            }
        }

        private static void TransformSpaces(List<string> separateKeyValuesStrings)
        {
            var pattern = @"\s+";
            var regex = new Regex(pattern);
            for (int i = 0; i < separateKeyValuesStrings.Count; i++)
            {
                separateKeyValuesStrings[i] = separateKeyValuesStrings[i].Replace("%20", " ").Replace('+', ' ');
                separateKeyValuesStrings[i] = regex.Replace(separateKeyValuesStrings[i], " ");
            }
        }


        private static string GetWholeKeyValueString(string input)
        {
            var stringToSplit = String.Empty;
            var indexOfQuestionMark = input.IndexOf('?');
            if (indexOfQuestionMark != -1)
            {
                stringToSplit = input.Substring(indexOfQuestionMark + 1);
            }
            else
            {
                stringToSplit = input;
            }
            return stringToSplit;
        }
    }
}
