class StudentManager
{
    public static void ProcessStudent()
    {
        // Variable declarations
        string studentName;
        int studentAge;
        double averageGrade;
        bool isEnrolled;
        char gradeLetter;
        DateTime enrollmentDate;

        // Variable initialization
        studentName = "Alice Johnson";
        studentAge = 20;
        averageGrade = 85.5;
        isEnrolled = true;
        gradeLetter = 'B';
        enrollmentDate = new DateTime(2024, 1, 15);

        // Using variables
        Console.WriteLine($"Student: {studentName}");
        Console.WriteLine($"Age: {studentAge}");
        Console.WriteLine($"Grade: {averageGrade} ({gradeLetter})");
        Console.WriteLine($"Enrolled: {isEnrolled}");
        Console.WriteLine($"Enrollment Date: {enrollmentDate:d}");
    }
}