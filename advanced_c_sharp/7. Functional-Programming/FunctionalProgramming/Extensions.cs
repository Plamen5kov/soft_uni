using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class Extensions
    {
        public static List<Student> WeakStudents(this List<Student> collection)
        {
            return collection.Where(x => x.Marks.Where(m => m == 2).Count() == 2).ToList();
        }
    }
}
