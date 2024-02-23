public class Student
{
    public int SID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Address { get; set; }
    public double GPA { get; set; }

    public static void DisplayStudentInfo(Student[] students)
    {
        Console.WriteLine("\nStudent Information Entered:");
        Console.WriteLine("===========================");
        foreach (var student in students)
        {
            if (student != null)
            {
                Console.WriteLine("First Name: " + student.FirstName);
                Console.WriteLine("Last Name: " + student.LastName);
                Console.WriteLine("Student ID: " + student.SID);
                Console.WriteLine("Student Address: " + student.Address + "\n");
            }
        }
    }

    public static void DisplayStudentInfoById(Student[] students, int studentID)
    {
        Student student = Array.Find(students, s => s != null && s.SID == studentID);

        if (student != null)
        {
            Console.WriteLine("\nStudent Information for ID " + studentID + ":");
            Console.WriteLine("===========================");
            Console.WriteLine("First Name: " + student.FirstName);
            Console.WriteLine("Last Name: " + student.LastName);
            Console.WriteLine("Student ID: " + student.SID);
            Console.WriteLine("Student Address: " + student.Address + "\n");
        }
        else
        {
            Console.WriteLine("\nStudent not found");
        }
    }
    public static void DisplayStudentTranscript(Student[] students, Course[] courses, Grade[] grades, int studentID)
    {
        Student student = Array.Find(students, s => s != null && s.SID == studentID);

        if (student != null)
        {
            Console.WriteLine("\nTranscript:");
            Console.WriteLine("=====================================");

            Console.WriteLine("Student Name: " + student.FirstName + " " + student.LastName);
            Console.WriteLine("SID: " + student.SID);
            Console.WriteLine("Address: " + student.Address);

            var studentGrades = grades.Where(grade => grade != null && grade.SID == studentID);

            if (studentGrades.Any())
            {
                foreach (var grade in studentGrades)
                {
                    Course course = Array.Find(courses, c => c != null && c.CID == grade.CID);

                    if (course != null)
                    {
                        Console.WriteLine($"Course: {course.CID}");
                        Console.WriteLine($"Course Title: {course.Title}");
                        Console.WriteLine($"Course Credit: {course.Credit}");
                        Console.WriteLine($"Course Letter Grade: {grade.LetterGrade}");

                        double studentGPA = Grade.GetStudentGPA(grades, courses, studentID);
                        Console.WriteLine("GPA: " + studentGPA +"\n");
                    }
                    else
                    {
                        Console.WriteLine("Course not found\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Grades not found\n");
            }
        }
        else
        {
            Console.WriteLine("Student not found\n");
        }
    }

    public static void DisplayStudentsByGPA(Student[] students, Course[] courses, Grade[] grades)
    {
        Console.WriteLine("\nStudents Sorted by GPA:");
        Console.WriteLine("===========================");
        foreach (var student in students)
        {
            if (student != null)
            {
                Console.WriteLine("First Name: " + student.FirstName);
                Console.WriteLine("Last Name: " + student.LastName);
                Console.WriteLine("Student ID: " + student.SID);
                Console.WriteLine("Student Address: " + student.Address);

                double studentGPA = Grade.GetStudentGPA(grades, courses, student.SID);  
                Console.WriteLine("GPA: " + studentGPA + "\n");
            }
        }
    }


    public static void EnterStudentInfo(Student[] students)
    {
        Console.Write("\nEnter student first name: ");
        string firstName = Console.ReadLine();

        Console.Write("\nEnter student last name: ");
        string lastName = Console.ReadLine();

        Console.Write("\nEnter student ID: ");
        int SID = int.Parse(Console.ReadLine());

        Console.Write("\nEnter student address: ");
        string address = Console.ReadLine();

        AddStudent(students, firstName, lastName, SID, address);
        DisplayStudentInfo(students);
    }

    public static void AddStudent(Student[] students, string firstName, string lastName, int SID, string address)
    {
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i] == null)
            {
                students[i] = new Student { FirstName = firstName, LastName = lastName, SID = SID, Address = address };
                break;
            }
        }
    }
}