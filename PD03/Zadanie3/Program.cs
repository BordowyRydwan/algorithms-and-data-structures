using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Course : IComparable<Course>
    {
        readonly string name;
        public double start;
        public double end;

        public Course(string name, double start, double end)
        {
            this.name = name;
            this.start = start;
            this.end = end;
        }

        public override string ToString()
        {
            return name + " (" + start + " - " + end + ")";
        }

        public int CompareTo(Course courseToSort)
        {

            if(courseToSort == null)
            {
                return 1;
            }

            if(courseToSort.start < start)
            {
                return 1;
            }

            if(courseToSort.start > start)
            {
                return -1;
            }

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Przypadek testowy

            List<Course> testCourses = new List<Course>(){ //3 zgodne zajecia
                new Course("AISD", 12.0, 14.0),
                new Course("Elektronika", 10.0, 12.0),
                new Course("AK", 11.0, 14.0),
                new Course("SYS OP", 14.0, 16.0),
                new Course("Obalanie piwka na czas", 15.0, 17.0),
            };

            //ALGORTYM

            List<Course> validCourses = new List<Course>();

            testCourses.Sort();
            validCourses.Add(testCourses[0]);

            Course lastValid = testCourses[0];

            for(int i = 1; i < testCourses.Count; ++i)
            {
                if(testCourses[i].start >= lastValid.end)
                {
                    lastValid = testCourses[i];
                    validCourses.Add(lastValid);
                }
            }

            //////////////////////
            //Wypisanie rezultatów

            foreach(Course course in validCourses)
            {
                Console.WriteLine(course);
            }

            Console.ReadLine();
        }
    }
}
