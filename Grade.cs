public class Grade
{
    public int SID;
    public int CID;
    public double gradePoint;

    public Grade(int studentID, int courseID, double point)
    {
        SID = studentID;
        CID = courseID;
        gradePoint = point;
    }

    public double GetGradePoint()
    {
        return gradePoint;
    }

    public void SetGradePoint(double point)
    {
        gradePoint = point;
    }

    public string LetterGrade
    {
        get
        {
            if (gradePoint >= 90)
            {
                return "A";
            }
            else if (gradePoint >= 80)
            {
                return "B";
            }
            else if (gradePoint >= 70)
            {
                return "C";
            }
            else if (gradePoint >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }
    }

    public static void EnterGradeInfo(Grade[] grades, Student[] students, Course[] courses)
    {
        Console.Write("\nEnter Student ID: ");
        int studentID = int.Parse(Console.ReadLine());

        Student student = Array.Find(students, s => s != null && s.SID == studentID);

        if (student == null)
        {
            Console.WriteLine("\nStudent not found");
        }
        else
        {
            Console.Write("\nEnter Course ID: ");
            int courseID = int.Parse(Console.ReadLine());
            Course course = Array.Find(courses, c => c != null && c.CID == courseID);

            if (course == null)
            {
                Console.WriteLine("\nCourse not found");
            }
            else
            {
                Console.Write("\nEnter Grade (a number between 0 and 100): ");
                double grade = double.Parse(Console.ReadLine());

                Grade newGrade = new Grade(studentID, courseID, grade);
                AddGrade(grades, newGrade);
            }
        }
    }

    public static void AddGrade(Grade[] grades, Grade newGrade)
    {
        for (int i = 0; i < grades.Length; i++)
        {
            if (grades[i] == null)
            {
                grades[i] = newGrade;
                break;
            }
        }
    }

    public static double GetStudentGPA(Grade[] grades, Course[] courses, int studentID)
    {
        double totalGPA = 0.0;
        int totalCredits = 0;

        foreach (var grade in grades)
        {
            if (grade != null && grade.SID == studentID)
            {
                Course course = Array.Find(courses, c => c != null && c.CID == grade.CID);

                if (course != null)
                {
                    totalGPA += LetterToGPA(grade.LetterGrade) * course.Credit;
                    totalCredits += course.Credit;
                }
            }
        }
        return totalCredits > 0 ? totalGPA / totalCredits : 0.0;
    }
    private static double LetterToGPA(string letterGrade)
    {
        switch (letterGrade)
        {
            case "A":
                return 4.0;
            case "B":
                return 3.0;
            case "C":
                return 2.0;
            case "D":
                return 1.0;
            default:
                return 0.0;
        }
    }
}