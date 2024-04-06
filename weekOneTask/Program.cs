class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Course { get; set; }
};

class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }

};

class StudentManager
{
    List<Student> students = new List<Student>();

    public void viewstudents ()
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"The Name is {student.Name}, The Course is {student.Course}");
        }
    }

    public void addstudent (Student student)
    {
        students.Add(student);
    }

    public void updatestudent(int Id, Student updates)
    {
        var updated = students.FirstOrDefault(val => val.ID == Id);
        updated.ID = updates.ID;
        updated.Name = updates.Name;
        updated.Age = updates.Age;
        updated.Course = updates.Course;
    }

    public void deletestudent(int Id)
    {
        var todelete = students.FirstOrDefault(val => val.ID == Id);
        students.Remove(todelete);
    }

    public List<Student> agefilter(int Age)
    {
        return students.Where(val => val.Age > Age).ToList();
    }
}

class CourseManager
{
    List<Course> courses = new List<Course>();

    public void addcourse (Course course)
    {
        courses.Add(course);
    }

    public void viewcource ()
    {
        foreach(Course course in courses)
        {
            Console.WriteLine($"The course ID is {course.CourseId}, The Course is {course.CourseName}");
        }
    }

    public IEnumerable<Course> coursefilter (string cource)
    {
        return courses.Where(val => val.CourseName == cource);
    }

}

class Program
{
    static void Main ()
    {
        StudentManager student = new StudentManager();
        CourseManager course = new CourseManager();

        student.addstudent(new Student { ID = 1, Name = "anas", Age = 22, Course = "accounting" });
        student.addstudent(new Student { ID = 2, Name = "malik", Age = 26, Course = "Maths" });
        student.addstudent(new Student { ID = 3, Name = "test", Age = 27, Course = "Economics" });
        student.addstudent(new Student { ID = 4, Name = "namzad", Age = 29, Course = "Mech" });

        Console.WriteLine("The List of Students");
        student.viewstudents();

        student.updatestudent(3, new Student { ID = 3, Name = "ziyu", Age = 29, Course = "CA" });
        Console.WriteLine("\nStudents after Updating third one");
        student.viewstudents();

        student.deletestudent(4);
        Console.WriteLine("\nStudents after deleting Last one");
        student.viewstudents();

        course.addcourse(new Course { CourseId = 1, CourseName = "biology" });
        course.addcourse(new Course { CourseId = 2, CourseName = "physics" });
        course.addcourse(new Course { CourseId = 3, CourseName = "CMA" });
        Console.WriteLine("\nCourse List");
        course.viewcource();

        Console.WriteLine("age above 25");
        var sttf = student.agefilter(25);
        foreach(var stu in sttf)
        {
            Console.WriteLine($"Name is {stu.Name}, Age is {stu.Age}");
        }

        var eco = course.coursefilter("physics");
        foreach(var det  in eco)
        {
            Console.WriteLine($"the course {det.CourseId}, the name {det.CourseName}");
        }

        
    }
}








