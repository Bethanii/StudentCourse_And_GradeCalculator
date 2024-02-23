class Driver
{
    static void DisplayMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("==================================");
        Console.WriteLine("A. Enter Student info");
        Console.WriteLine("B. Enter Course info");
        Console.WriteLine("C. Enter Grade info");
        Console.WriteLine("D. Display Student info by ID");
        Console.WriteLine("E. Display Course info by ID");
        Console.WriteLine("F. Display Student Transcript");
        Console.WriteLine("G. List of students sorted by their GPA");
        Console.WriteLine("H. Exit the app\n");
    }

    static void DisplayMenu(string selection, Student[] students, Course[] courses, Grade[] grades)
    {
        switch (selection.ToLower())
        {
            case "a":
                Student.EnterStudentInfo(students);
                break;

            case "b":
                Course.EnterCourseinfo(courses);
                break;

            case "c":
                Grade.EnterGradeInfo(grades, students, courses);
                break;

            case "d":
                Console.Write("\nEnter Student ID: \n");
                int studentID = int.Parse(Console.ReadLine());
                Student.DisplayStudentInfoById(students, studentID);
                break;

            case "e":
                Console.Write("\nEnter Course ID: \n");
                int courseID = int.Parse(Console.ReadLine());
                Course.DisplayCourseInfoById(courses, courseID);
                break;

            case "f":
                Console.Write("\nEnter Student ID: \n");
                int transcriptStudentID = int.Parse(Console.ReadLine());
                Student.DisplayStudentTranscript(students, courses, grades, transcriptStudentID);
                break;

            case "g":
                Student.DisplayStudentsByGPA(students, courses, grades);
                break;

            case "h":
                Console.WriteLine("Ending program");
                break;

            default:
                Console.WriteLine("Please choose an option from the menu");
                break;
        }
    }

    static void Main()
    {
        Student[] students = new Student[10];
        Course[] courses = new Course[10];
        Grade[] grades = new Grade[10];

        string selection;

        do
        {
            DisplayMenu();
            selection = Console.ReadLine();
            DisplayMenu(selection, students, courses, grades);

        } while (selection != "h");
    }
}
