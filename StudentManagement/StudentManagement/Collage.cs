using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement;
public abstract class Collage
{
    static List<Student> students = new();
    static List<Course> courses = new();
    static List<ChoiceCourse> choicecourses = new();

    public static void RegisterStudentInfo(string studentName, int studentId)
    {
        var student = students.Find(_ => _.Name == studentName);
        if (student == null)
        {
            Student newStudent = new(studentName, studentId);
            students.Add(newStudent);
            Success();
        }
        else
        {
            throw new Exception("this student has already been registred");
        }
    }

    public static void RegisterCourseInfo(string courseName, int courseUnit)
    {

        var course = courses.Find(_ => _.Name == courseName);
        if (course == null)
        {

            Course newCourse = new(courseName, courseUnit);
            courses.Add(newCourse);
            Success();
        }
        else
        {
            throw new Exception("This course has already been registered");
        }
    }

    public static void RegisterStudentCourseGrade(int id, string courseName, double courseGrade)
    {
        var student = students.Find(_ => _.StudentId == id);
        if (student != null)
        {
            var unit = courses.Find(_ => _.Name == courseName);
            if (unit != null)
            {
                ChoiceCourse choiceCourse = new(student.Name, id, courseGrade, courseName, unit.Unit);
                choicecourses.Add(choiceCourse);
                Success();
            }
            else
            {
                throw new Exception("course not found");
            }
        }
        else
        {
            throw new Exception("student not found");
        }
    }
    public static void DisplayStudentCourse(string studentName)
    {
        var studentCourse = choicecourses.Where(s => s.Name == studentName).ToList();
        if (studentCourse.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var student in studentCourse)
            {
                Console.WriteLine($" {student.CorseName}\tunit: {student.courseUnit}" +
                    $"\tgrade: {student.CorseGrade}");
            }
            Console.ResetColor();
        }
    }

    public static void EditStudentGrade(string studentName, string courseName, double newGrade)
    {
        var student = choicecourses.Find(_ => _.Name == studentName);
        if (student != null)
        {

            var course = choicecourses.Find(_ => _.CorseName == courseName);
            if (course != null)
            {
                course.EditStudentGrade(newGrade);
                Success();
            }
            else
            {
                throw new Exception("course not found");
            }
        }
        else
        {
            throw new Exception("student not found");
        }
    }
    public static int GetInteger(string message)
    {
        Console.WriteLine(message);
        int value = int.Parse(Console.ReadLine());
        return value;
    }
    public static string GetString(string message)
    {
        Console.WriteLine(message);
        string value = Console.ReadLine();
        return value;
    }


    public static double GetDouble(string message)
    {
        Console.WriteLine(message);

        double value = double.Parse(Console.ReadLine());
        return value;
    }
    public static int Run()
    {
        Console.WriteLine($"1: register stuedent\n" +
            $"2: Register Course\n" +
            $"3: register student grade\n" +
            $"4: Display student courses\n" +
            $"5: Edit student's course grade\n" +
            $"0: Exit");

        int value = int.Parse(Console.ReadLine());
        return value;
    }
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(message);
        Console.ResetColor();

    }

    public static void Success()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"-------------\nSuccess full\n-------------");
        Console.ResetColor();

    }

}
