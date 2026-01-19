using System;
using System.Collections.Generic;

// Base course
abstract class CourseType
{
    public string CourseName;
}

class ExamCourse : CourseType { }

// Generic course manager
class Course<T> where T : CourseType
{
    List<T> courses = new List<T>();

    public void AddCourse(T course)
    {
        courses.Add(course);
    }

    public void Display()
    {
        foreach (var c in courses)
        {
            Console.WriteLine(c.CourseName);
        }
    }
}

class Program
{
    static void Main()
    {
        Course<ExamCourse> course = new Course<ExamCourse>();

        Console.Write("Enter Course Name: ");
        ExamCourse c1 = new ExamCourse();
        c1.CourseName = Console.ReadLine();

        course.AddCourse(c1);
        course.Display();
    }
}
