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
    Date: 04/12/2017
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

            // Query #1 - LIST STUDENTS OVER 25
            var age25 = from q1 in students
                        where q1.Age >= 25
                        select q1.LastName;

            // Query #2 - COUNT STUDENTS OVER 25 LESS THAN 30
            var age20_30 = (from q2 in students
                           where q2.Age > 20 && q2.Age < 30
                           select q2.Age)
                           .Count();

            // Query #3 - STUDENT (FULL NAME) AND AGE
            var name_concat = from q3 in students
                              let FullName = q3.FirstName + " " + q3.LastName
                              select FullName + " " + q3.Age;

            // Query #4 - COUNT STUDENTS TAKING ENGLISH
            var join_st = (from q4 in students
                           join q4_1 in studentcourses on q4.stID
                           equals q4_1.stID
                           where q4_1.courseID == 3
                           select q4.stID)
                           .Count();

            // Query #5 - LIST STUDENTS TAKING MATH
            var join_sm = from q5 in students
                          join q5_1 in studentcourses on q5.stID
                          equals q5_1.stID
                          where q5_1.courseID == 4
                          select q5.FirstName;

            // Query #6 - LIST STUDENTS GROUPED BY COURSE
            var join_sg = from q6 in students
                          join q6_1 in studentcourses on q6.stID equals q6_1.stID
                          join q6_2 in courses on q6_1.courseID equals q6_2.courseID
                          group q6 by q6_2.course into grouping
                          select grouping;



            //Outputs

            // Query 1
            Console.WriteLine("Students Age 25+");
            Console.WriteLine("=======================");
            foreach (var q1_out in age25)
            {
                Console.WriteLine("Student: " + q1_out);
            }

            Console.WriteLine("");

            // Query 2
            Console.WriteLine("Students Age 25 to 30");
            Console.WriteLine("=======================");
            Console.WriteLine("There are " + age20_30 + " students");

            Console.WriteLine("");

            // Query 3
            Console.WriteLine("Students & Age");
            Console.WriteLine("=======================");
            foreach (var q3_out in name_concat)
            {
                Console.WriteLine(q3_out);
            }

            Console.WriteLine("");

            // Query 4
            Console.WriteLine("Number of English Students");
            Console.WriteLine("=======================");
            Console.WriteLine(join_st);

            Console.WriteLine("");

            // Query 5
            Console.WriteLine("Students Taking Math");
            Console.WriteLine("=======================");
            foreach (var q5_out in join_sm)
            {
                Console.WriteLine("Student: " + q5_out);
            }

            Console.WriteLine("");

            // Query 6
            Console.WriteLine("Student Groupings");
            Console.WriteLine("=======================");
            foreach (var oatmeal in join_sg)
            {
                Console.WriteLine("Course: " + oatmeal.Key);
                foreach (var oat in oatmeal)
                {
                    Console.WriteLine(oat.FirstName);
                }
                Console.WriteLine("");
            }


            Console.ReadKey();

        }
    }
}
