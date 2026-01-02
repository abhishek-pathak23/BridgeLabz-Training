using System;
using System.Collections.Generic;

namespace UniversitySystem
{
    // Represents a course in the university
    class Course
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>(); // Students enrolled in this course
        public Professor Professor { get; set; } // Professor assigned to teach this course

        public Course(string name)
        {
            Name = name;
        }
    }

    // Represents a student
    class Student
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>(); // Courses the student is enrolled in

        public Student(string name)
        {
            Name = name;
        }

        // Enroll the student in a course
        public void EnrollCourse(Course course)
        {
            Courses.Add(course);
            course.Students.Add(this); // Add student to the course's list
        }
    }

    // Represents a professor
    class Professor
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>(); // Courses the professor teaches

        public Professor(string name)
        {
            Name = name;
        }

        // Assign a course to the professor
        public void AssignCourse(Course course)
        {
            Courses.Add(course);
            course.Professor = this; // Set professor for the course
        }
    }

    class UniversityManageSys
    {
        static void Main()
        {
            // Input courses
            Console.WriteLine("Enter total number of courses:");
            int numCourses = int.Parse(Console.ReadLine());
            List<Course> courses = new List<Course>();
            for (int i = 0; i < numCourses; i++)
            {
                Console.WriteLine($"Enter name for Course {i + 1}:");
                courses.Add(new Course(Console.ReadLine()));
            }

            // Input professors
            Console.WriteLine("\nEnter total number of professors:");
            int numProfessors = int.Parse(Console.ReadLine());
            List<Professor> professors = new List<Professor>();
            for (int i = 0; i < numProfessors; i++)
            {
                Console.WriteLine($"Enter name for Professor {i + 1}:");
                professors.Add(new Professor(Console.ReadLine()));
            }

            // Input students
            Console.WriteLine("\nEnter total number of students:");
            int numStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < numStudents; i++)
            {
                Console.WriteLine($"Enter name for Student {i + 1}:");
                students.Add(new Student(Console.ReadLine()));
            }

            // Enroll students in courses
            foreach (var student in students)
            {
                Console.WriteLine($"\nHow many courses will {student.Name} enroll in?");
                int coursesToEnroll = int.Parse(Console.ReadLine());

                for (int j = 0; j < coursesToEnroll; j++)
                {
                    Console.WriteLine("Select a course by index:");
                    for (int k = 0; k < courses.Count; k++)
                        Console.WriteLine($"{k + 1}. {courses[k].Name}");

                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < courses.Count)
                        student.EnrollCourse(courses[index]);
                }
            }

            // Assign professors to courses
            foreach (var professor in professors)
            {
                Console.WriteLine($"\nHow many courses will Professor {professor.Name} teach?");
                int coursesToTeach = int.Parse(Console.ReadLine());

                for (int j = 0; j < coursesToTeach; j++)
                {
                    Console.WriteLine("Select a course by index:");
                    for (int k = 0; k < courses.Count; k++)
                        Console.WriteLine($"{k + 1}. {courses[k].Name}");

                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < courses.Count)
                        professor.AssignCourse(courses[index]);
                }
            }

            // Display course details
            Console.WriteLine("\nCourse Details:");
            foreach (var course in courses)
            {
                Console.WriteLine($"\nCourse: {course.Name}");
                Console.WriteLine($"Professor: {(course.Professor != null ? course.Professor.Name : "None")}");
                Console.WriteLine("Enrolled Students:");
                if (course.Students.Count == 0)
                    Console.WriteLine("No students enrolled.");
                else
                    foreach (var student in course.Students)
                        Console.WriteLine($"- {student.Name}");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
