using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new {stID = 15, courseID = 4},
            };

        }
    }

    class Course
    {
        //Fields
        private int _courseID;
        private string _courseName;

        // Properties
        public int CourseID
        {
            get
            {
                return _courseID;
            }
        }
        public string CourseName
        {
            get
            {
                return _courseName;
            }
        }

        //Constructor
        public Course(int newCourseId, string newCourseName)
        {
            _courseID = newCourseId;
            _courseName = newCourseName;
        }
    }
    class StudentCourse
    {
        //Fields
        private int _studentID;
        private int _courseID;

        //Properties
        public int StudentID
        {
            get
            {
                return _studentID;
            }
        }
        public int CourseID
        {
            get
            {
                return _courseID;
            }
        }

        //Constructor
        public StudentCourse(int newStudentID, int newCourseID)
        {
            _studentID = newStudentID;
            _courseID = newCourseID;
        }
    }


}
