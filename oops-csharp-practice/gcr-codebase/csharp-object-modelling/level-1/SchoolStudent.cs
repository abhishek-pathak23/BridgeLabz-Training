using System;
using System.Collections.Generic;

namespace SchoolManagement
{
    // Represents a course in the school
    class Course
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Course(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        // Add a student to this course
        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        // Display all students enrolled in this course
        public void ShowStudents()
        {
            Console.WriteLine($"Students enrolled in {Name}:");
            foreach (var s in Students)
                Console.WriteLine(s.Name);
        }
    }

    // Represents a student
    class Student
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Student(string name)
        {
            Name = name;
            Courses = new List<Course>();
        }

        // Enroll the student in a course
        public void EnrollCourse(Course c)
        {
            Courses.Add(c);
            c.AddStudent(this); // Link student to course
        }

        // Show all courses the student is enrolled in
        public void ShowCourses()
        {
            Console.WriteLine($"\n{Name} is enrolled in the following courses:");
            foreach (var c in Courses)
                Console.WriteLine(c.Name);
        }
    }

    // Represents the school
    class School
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        // Add a student to the school
        public void AddStudent(Student s) => Students.Add(s);

        // Display all students and their courses
        public void ShowAllStudents()
        {
            Console.WriteLine($"\nSchool: {Name}");
            foreach (var s in Students)
                s.ShowCourses();
        }
    }

    // Main program to manage school, students, and courses
    class SchoolStudent
    {
        static void Main()
        {
            // Input school name
            Console.WriteLine("Enter School Name:");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);

            // Input number of students
            Console.WriteLine("Enter number of students:");
            int numStudents = int.Parse(Console.ReadLine());

            // Input courses available in the school
            List<Course> courses = new List<Course>();
            Console.WriteLine("Enter number of courses:");
            int numCourses = int.Parse(Console.ReadLine());
            for (int i = 0; i < numCourses; i++)
            {
                Console.WriteLine($"Enter name of course {i + 1}:");
                string courseName = Console.ReadLine();
                courses.Add(new Course(courseName));
            }

            // Input students and enroll them in courses
            for (int i = 0; i < numStudents; i++)
            {
                Console.WriteLine($"\nEnter name of Student {i + 1}:");
                string studentName = Console.ReadLine();
                Student student = new Student(studentName);
                school.AddStudent(student);

                // Ask how many courses the student wants to join
                Console.WriteLine($"How many courses does {studentName} want to enroll in?");
                int enroll = int.Parse(Console.ReadLine());

                for (int j = 0; j < enroll; j++)
                {
                    Console.WriteLine("Select course index to enroll:");
                    for (int k = 0; k < courses.Count; k++)
                        Console.WriteLine($"{k + 1}. {courses[k].Name}");

                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < courses.Count)
                        student.EnrollCourse(courses[index]);
                }
            }

            // Display all students and their enrolled courses
            school.ShowAllStudents();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
