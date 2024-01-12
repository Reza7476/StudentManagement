using StudentManagement;

while (true)
{
    try
    {
        int exe = Collage.Run();

        switch (exe)
        {

            case 0:
                {
                    Environment.Exit(0);
                    break;
                }
            case 1:
                {
                    var studentName = Collage.GetString("enter student name");
                    var studentId = Collage.GetInteger("enter student id");
                    Collage.RegisterStudentInfo(studentName, studentId);

                    break;


                }

            case 2:
                {

                    var courseName = Collage.GetString("enter course name");
                    var courseUnit = Collage.GetInteger("enter course unit");
                    Collage.RegisterCourseInfo(courseName, courseUnit);
                    break;

                }
            case 3:
                {

                    var studentId = Collage.GetInteger("enter student id");
                    var courseName = Collage.GetString("enter course name");
                    var courseGrade = Collage.GetDouble("enter course grade");
                    Collage.RegisterStudentCourseGrade(studentId, courseName, courseGrade);
                    break;
                }
            case 4:
                {

                    var studentName = Collage.GetString("enter student name");
                    Collage.DisplayStudentCourse(studentName);
                    break;
                }

            case 5:
                {

                    var studentName = Collage.GetString("enter student name");
                    var courseName = Collage.GetString("enter course name");
                    var newGrade = Collage.GetDouble($"enter new grade of {courseName} ");
                    Collage.EditStudentGrade(studentName, courseName, newGrade);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    catch (Exception ex)
    {

        Collage.Error(ex.Message);
    }
}






