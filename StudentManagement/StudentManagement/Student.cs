using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement;
public class Student
{
    public Student(string name, int studentId)
    {
        Name = name;
        StudentId = studentId;
    }
    public string Name { get; set; }
    public int StudentId { get; set; }
}


public class Course
{
    public Course(string name, int unit)
    {
        Name = name;
        Unit = unit;
    }
    public string Name { get; set; }
    public int Unit { get; set; }
}

public class ChoiceCourse : Student, IManagerChoiceCourse
{
    public ChoiceCourse(string name, int studentId, double corseGrade, string corseName, int courseUnit) : base(name, studentId)
    {
        CorseGrade = corseGrade;
        CorseName = corseName;
        this.courseUnit = courseUnit;
    }

    public double CorseGrade { get; set; }
    public string CorseName { get; set; }
    public int courseUnit { get; set; }



    public void EditStudentGrade(double courseGrade)
    {
        CorseGrade = courseGrade;
    }


}

public interface IManagerChoiceCourse
{

    void EditStudentGrade(double courseGrade);

}
