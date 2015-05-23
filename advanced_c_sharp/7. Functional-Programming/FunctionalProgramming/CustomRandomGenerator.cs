using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class CustomRandomGenerator
    {
        private static Random randomGen = new Random();

        public static string GetRandomString(int minLen, int maxLen)
        {
            var sb = new StringBuilder();
            var len = randomGen.Next(minLen, maxLen);
            for (int i = 0; i < len; i++)
            {
                sb.Append((char)randomGen.Next('a', 'z'));
            }

            return sb.ToString();
        }

        public static string GetRandomString()
        {
            return GetRandomString(4, 10);
        }

        public static int GetRandomInt()
        {
            return randomGen.Next(0, int.MaxValue);
        }

        public static int GetRandomAge(int min, int max)
        {
            return randomGen.Next(min, max);
        }

        public static string GetRandomPhone()
        {
            var code = new string[] {"02", "+359", "111","222"};
            var currentCode = code[GetRandomInt() % 4];
            return string.Format("{0}{1}", currentCode, GetRandomInt());
        }

        public static IList<int> GetRandomMarks()
        {
            var list = new List<int>();
            var len = randomGen.Next(5, 10);
            for (int i = 0; i < len; i++)
            {
                list.Add(GetRandomAge(2, 7));
            }

            return list;
        }

        public static string GetRandomEmail()
        {
            var site = new string[] {"abv", "gmail", "yahoo"};
            var domain = new string[] { "bg", "com" };

            var currentSite = site[GetRandomInt() % 3];
            var currentDomain = domain[GetRandomInt() % 1];
            return string.Format("{0}@{1}.{2}", GetRandomString(4, 6), currentSite, currentDomain);
        }

        public static string GetRandomFacultyNumber()
        {
            var facultyNumbers = new string[] { "9999149999", "9999999999", "123182381", "2222142222" };
            return facultyNumbers[GetRandomInt() % 4];
        }
    }
}
