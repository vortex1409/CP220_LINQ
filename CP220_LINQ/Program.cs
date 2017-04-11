using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Project: Assignment 3 - Playing With Generics
    Class: CP220 - OOP II
    Destription: LINQ
    Name: Michael Dorfman
    Date: 04/03/2017
*/

namespace CP220_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new[]
            {
                new { stID = 1, LastName="McNaughton", FirstName="Donahue", Age = 22},
                new { stID = 2, LastName="Earl Jones", FirstName="James", Age = 55},
                new { stID = 4, LastName="Spacey", FirstName="Kevin", Age = 44},
                new { stID = 5, LastName="Shakespeare", FirstName="Bill", Age = 62},
                new { stID = 7, LastName="McKlane", FirstName="Stuart", Age = 21},
                new { stID = 8, LastName="Smith", FirstName="LeAnne", Age = 24},
                new { stID = 9, LastName="Davies", FirstName="Jocelyn", Age = 22},
                new { stID = 10, LastName="Jones", FirstName="Haley", Age = 25},
                new { stID = 11, LastName="Keegan", FirstName="Stacey", Age = 31},
                new { stID = 15, LastName="Remus", FirstName="James", Age = 21}
            };

            var courses = new[]
            {
                new {courseID = 1, course = "History"},
                new {courseID = 2, course = "Art"},
                new {courseID = 3, course = "English"},
                new {courseID = 4, course = "Math"},
                new {courseID = 5, course = "Programming"},
            };

            var studentcourses = new[]
            {
                new {stID = 1, courseID = 1},
                new {stID = 1, courseID = 3},
                new {stID = 2, courseID = 2},
                new {stID = 2, courseID = 3},
                new {stID = 4, courseID = 2},
                new {stID = 4, courseID = 1},
                new {stID = 5, courseID = 3},
                new {stID = 7, courseID = 3},
                new {stID = 9, courseID = 4},
                new {stID = 9, courseID = 5},
                new {stID = 9, courseID = 3},
                new {stID = 10, courseID = 4},
                new {stID = 11, courseID = 2},
                new {stID = 15, courseID = 5},
                new {stID = 15, courseID = 4}
            };

            // Query #1 - a
            var age25 = from a in students where a.Age >= 25 select a.LastName;

            // Query #2 - s
            var age20_30 = from b in students where b.Age > 20 && b.Age < 30 select b.LastName;

            // Query #3 - c
            var name_concat = from c in students let FullName = c.FirstName + " " + c.LastName select FullName + " " + c.Age;

            // Query #4 - s & c
            var join_st = (from d in students join c in studentcourses on d.stID equals c.stID where c.courseID == 3 select c.stID).Count();

            // Query #5 - s & c
            var join_sm = from e in students join c in studentcourses on e.stID equals c.stID  where c.courseID == 4 select e.FirstName;

            // Query #6
            var join_sg = from b in students
                          join c in studentcourses on b.stID equals c.stID
                          join bc in courses on c.courseID equals bc.courseID
                          group b by bc.course into grouping
                          select grouping;



            //Outputs

            // Query 1
            Console.WriteLine("25 And Older");
            foreach(var a in age25)
            {
                Console.WriteLine("Student: " + a);
            }

            Console.WriteLine("");

            // Query 2
            Console.WriteLine("Between 25 and 30");
            foreach(var b in age20_30)
            {
                Console.WriteLine("Student: " + b);
            }

            Console.WriteLine("");

            // Query 3
            Console.WriteLine("Full Name + Ages");
            foreach(var c in name_concat)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("");

            // Query 4
            Console.WriteLine("English Students");
            Console.WriteLine(join_st);

            Console.WriteLine("");

            // Query 5
            Console.WriteLine("Math Students");
            foreach(var e in join_sm)
            {
                Console.WriteLine("Student: " + e);
            }

            Console.WriteLine("");

            Console.WriteLine("Grouping");
            foreach(var item in join_sg)
            {
                foreach(var oat in item)
                {
                    Console.WriteLine(oat.FirstName);
                }
            }


            Console.ReadKey();

        }
    }
}
