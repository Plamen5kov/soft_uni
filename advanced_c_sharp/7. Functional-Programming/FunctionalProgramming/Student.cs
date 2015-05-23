using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class Student
    {
        //Create a class Student with properties FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber. 

        public Student(string firstName, string lastName, int age, string facultyNumber, string phone, string eMail, IList<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = eMail;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

       public Student()
            : this(CustomRandomGenerator.GetRandomString(4, 7), //first name
           CustomRandomGenerator.GetRandomString(3, 7),  //lastName
           CustomRandomGenerator.GetRandomAge(15, 25), //age
           CustomRandomGenerator.GetRandomFacultyNumber(), //facultyNumber
           CustomRandomGenerator.GetRandomPhone(), //phone
           CustomRandomGenerator.GetRandomEmail(), //email
           CustomRandomGenerator.GetRandomMarks(), //marks
           CustomRandomGenerator.GetRandomInt()) //group number
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string FacultyNumber { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IList<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        public override string ToString()
        {
            return string.Format("\nFirstName: {0} \nLastName: {1} \nAge: {2} \nFacultyNumber: {3} \nPhone: {4} \nEmail: {5} \nMarks: [{6}] \nGroupNumber: {7}", 
                this.FirstName, 
                this.LastName, 
                this.Age, 
                this.FacultyNumber, 
                this.Phone, 
                this.Email, 
                string.Join(", ", this.Marks), 
                this.GroupNumber);
        }
    }
}
