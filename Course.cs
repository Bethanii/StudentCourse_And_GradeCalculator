public class Course
{
    public int CID { get; set; }
    public int Credit { get; set; }
    public string Title { get; set; }
    public string Faculty { get; set; }

    public static void DisplayCourseInfo(Course[] courses)
    {
        Console.WriteLine("\nCourse Information:");
        foreach (var course in courses)
        {
            if (course != null)
            {
                Console.WriteLine("Course ID: " + course.CID);
                Console.WriteLine("Credit: " + course.Credit);
                Console.WriteLine("Title: " + course.Title);
                Console.WriteLine("Faculty: " + course.Faculty + "\n");
            }
        }
    }

    public static void DisplayCourseInfoById(Course[] courses, int courseID)
    {
        Course course = Array.Find(courses, c => c != null && c.CID == courseID);

        if (course != null)
        {
            Console.WriteLine("\nCourse Information for ID " + courseID + ":");
            Console.WriteLine("===========================");
            Console.WriteLine("Course ID: " + course.CID);
            Console.WriteLine("Credit: " + course.Credit);
            Console.WriteLine("Title: " + course.Title);
            Console.WriteLine("Faculty: " + course.Faculty + "\n");
        }
        else
        {
            Console.WriteLine("\nCourse not found");
        }
    }

    public static void EnterCourseinfo(Course[] courses)
    {
        Console.Write("\nEnter Course ID: \n");
        int courseID = int.Parse(Console.ReadLine());

        Console.Write("\nEnter course credit: \n");
        int courseCredit = int.Parse(Console.ReadLine());

        Console.Write("\nEnter course title: \n");
        string courseTitle = Console.ReadLine();

        Console.Write("\nEnter course faculty: \n");
        string courseFaculty = Console.ReadLine();

        AddCourse(courses, courseID, courseCredit, courseTitle, courseFaculty);
        DisplayCourseInfo(courses);
    }

    public static void AddCourse(Course[] courses, int courseID, int courseCredit, string courseTitle, string courseFaculty)
    {
        for (int i = 0; i < courses.Length; i++)
        {
            if (courses[i] == null)
            {
                courses[i] = new Course { CID = courseID, Credit = courseCredit, Title = courseTitle, Faculty = courseFaculty };
                break;
            }
        }
    }
}