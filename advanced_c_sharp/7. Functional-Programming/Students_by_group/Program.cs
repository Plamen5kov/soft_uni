using FunctionalProgramming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_by_group
{
    class Program
    {
        static void Main(string[] args)
        {
            var listStudents = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                listStudents.Add(new Student());
            }

            Console.WriteLine("{0}--{1}", 2, new string('-', 40));
            //2. By group
            var byGroup = listStudents.OrderBy(x => x.GroupNumber).ToList();
            byGroup.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 3, new string('-', 40));
            //3. where first name is before last
            var firstNameBeforeLast = listStudents.Where(x => x.FirstName.CompareTo(x.LastName) == -1).ToList();
            firstNameBeforeLast.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 4, new string('-', 40));
            //4. By age
            var betweenAges = listStudents.Where(x => (x.Age > 17 && x.Age < 25))
                .Select(x => new { FirstName = x.FirstName, LastName = x.LastName, Age = x.Age }).ToList();
            betweenAges.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 5, new string('-', 40));
            //5. Order by first and last name
            var byName = listStudents.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            byName.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 6, new string('-', 40));
            //6. by email domain
            var byEmailDomain = listStudents.Where(x => x.Email.IndexOf("@abv.bg") != -1).ToList();
            byEmailDomain.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 7, new string('-', 40));
            //7. by phone
            var byPhone = listStudents.Where(x => x.Phone.StartsWith("02") || x.Phone.StartsWith("+3592") || x.Phone.StartsWith("+359 2")).ToList();
            byPhone.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 8, new string('-', 40));
            //8. by excelent grade
            var excelent = listStudents.Where(x => x.Marks.Any(m => m == 6)).Select(x => new { FullName = x.FirstName + " " + x.LastName, Marks = string.Join(", ", x.Marks)}).ToList();
            excelent.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 9, new string('-', 40));
            //9. by weak grade count
            var weak = listStudents.WeakStudents();
            weak.ForEach(Console.WriteLine);

            Console.WriteLine("{0}--{1}", 10, new string('-', 40));
            //10. students enroled in 2014
            var enroledByYear = listStudents.Where(x => x.FacultyNumber[4] == '1' && x.FacultyNumber[5] == '4').ToList();
            enroledByYear.ForEach(Console.WriteLine);
        }
    }
}
