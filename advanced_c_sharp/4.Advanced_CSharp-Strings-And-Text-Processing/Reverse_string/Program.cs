﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inputArr = input.ToArray();
            Array.Reverse(inputArr);
            Console.WriteLine(string.Join("", inputArr));
        }
    }
}
