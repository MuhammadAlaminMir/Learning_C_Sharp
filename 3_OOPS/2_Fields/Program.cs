public class Student
{
    //1. Standard instance Fields (every student should have name.)
    private string _name;
    // every fields is by default private, so I can remove the private keyword, if I want;
    int age;

    // 2. Readonly field - can only be set in the constructor
    public readonly int ClassRoll;

    //3. const field, an unique id for life time
    public const int Id = 101;

    //4. Static field - shared for every subjects.
    public static string ClassName = "temp";


    public Student(string name, int ClassRoll)
    {
        _name = name;
        this.ClassRoll = ClassRoll;

        Console.WriteLine("Hello " + name);
    }

}

class Program
{
    static void Main()
    {
        string name = "Alamin Mir";

        Student newStudent = new Student(name, 12);
        
    }
}