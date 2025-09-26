### **C# Variables: Complete Guide**

## **1. What is a Variable?**

**Definition:** A variable is a named storage location in memory that holds a value which can be changed during program execution. Think of it as a labeled box where you can store data and retrieve it later.

**Key Concepts:**

- **Name:** Identifier for the variable
- **Type:** What kind of data it can hold
- **Value:** The actual data stored
- **Memory Location:** Where it's stored in RAM

```csharp
int age = 25;  // 'age' is the variable name, 'int' is the type, 25 is the value
```

---
### Note:

In C#, There is no Global variable, use Public specifier instead, to use a variable like global variable:

```csharp
public static string ApplicationName = "MyApp";
```

## **2. Variable Declaration and Initialization**

### **Declaration Only**

```csharp
int age;                    // Declare without assigning value
string name;               // Declaration
double salary;             // Declaration
```

### **Declaration with Initialization**

```csharp
int age = 25;              // Declare and initialize
string name = "John";      // Declare and initialize
double salary = 50000.50;  // Declare and initialize
bool isActive = true;      // Declare and initialize
```

### **Multiple Variables**

```csharp
// Separate declarations
int x = 10;
int y = 20;
int z = 30;

// Multiple in one line (same type)
int a = 1, b = 2, c = 3;

// Different types must be declared separately
string firstName = "John", lastName = "Doe";  // Same type - OK
// int age = 25, string name = "John";       // Error - different types
```

---

## **3. C# Data Types**

### **3.1 Value Types (Stored on Stack)**

#### **Integer Types**

```csharp
byte smallNumber = 255;                    // 0 to 255 (1 byte)
sbyte signedByte = -128;                   // -128 to 127 (1 byte)
short shortNumber = 32000;                 // -32,768 to 32,767 (2 bytes)
ushort unsignedShort = 65000;              // 0 to 65,535 (2 bytes)
int age = 25;                             // -2.1B to 2.1B (4 bytes) - MOST COMMON
uint unsignedInt = 4000000000;            // 0 to 4.3B (4 bytes)
long bigNumber = 9000000000000000000;     // Very large numbers (8 bytes)
ulong unsignedLong = 18000000000000000000; // Very large positive (8 bytes)
```

#### **Floating-Point Types**

```csharp
float price = 19.99f;     // 7-digit precision (4 bytes) - MUST USE 'f' SUFFIX
double salary = 55000.50; // 15-digit precision (8 bytes) - MOST COMMON
decimal money = 123.45m;  // 28-digit precision (16 bytes) - USE 'm' SUFFIX (financial)

// Usage examples:
float temperature = 98.6f;           // Good for measurements
double scientificValue = 1.23456e10; // Scientific notation
decimal accountBalance = 1234.56m;   // Financial calculations
```

#### **Other Value Types**

```csharp
bool isCompleted = true;           // true or false (1 byte)
char grade = 'A';                  // Single character (2 bytes)
char newLine = '\n';               // Escape sequence
DateTime today = DateTime.Now;     // Date and time
TimeSpan duration = TimeSpan.FromHours(2.5); // Time interval
```

### **3.2 Reference Types (Stored on Heap)**

#### **String Type**

```csharp
string name = "John Doe";                    // String literal
string message = "Hello\nWorld";             // With escape characters
string path = @"C:\Users\John\Documents";    // Verbatim string (@)
string emptyString = "";                     // Empty string
string nullString = null;                    // Null reference
```

#### **Object Type**

```csharp
object anything = "Hello";      // Can hold any type
anything = 42;                  // Now holds an integer
anything = DateTime.Now;        // Now holds a DateTime
```

---

## **4. Variable Naming Rules and Conventions**

### **Naming Rules (Compiler-Enforced)**

```csharp
// VALID names
int age;
string firstName;
double _salary;
int number1;
string @class;      // @ allows using keywords

// INVALID names
int 2ndNumber;      // Cannot start with digit
string first name;  // No spaces allowed
double class;       // Cannot use keywords
int #score;         // No special characters (except _ and @)
```

### **Naming Conventions (Best Practices)**

```csharp
// CamelCase for local variables
int studentCount;
string firstName;
double averageScore;
bool isActive;

// Descriptive names (GOOD)
int numberOfStudents;
DateTime accountCreationDate;
decimal totalOrderAmount;

// Avoid cryptic names (BAD)
int n;              // What does 'n' mean?
string str;         // Too vague
double d1, d2;      // Not descriptive
```

---

## **5. var Keyword (Type Inference)**

**Purpose:** Let the compiler determine the variable type based on the assigned value.

```csharp
// Explicit typing
string name = "John";
int age = 25;
List<string> names = new List<string>();

// Using var (compiler infers type)
var name = "John";           // Compiler knows it's string
var age = 25;                // Compiler knows it's int
var names = new List<string>(); // Compiler knows it's List<string>
var today = DateTime.Now;    // Compiler knows it's DateTime

// WHEN TO USE VAR:
var dictionary = new Dictionary<string, List<int>>(); // Complex types - GOOD
var i = 10;                 // Simple types - OK but explicit might be clearer
var result = Calculate();   // When return type is obvious from method name

// WHEN TO AVOID VAR:
var number = GetValue();    // What type does GetValue() return? Not clear!
```

---

## **6. Constants and Readonly Variables**

### **Constants (Compile-time)**

```csharp
const double PI = 3.14159;
const int MAX_USERS = 100;
const string COMPANY_NAME = "MyCorp";

// Must be initialized at declaration
// Value cannot be changed
// Available at compile-time

double area = PI * radius * radius;  // PI is replaced with 3.14159 at compile time
```

### **Readonly Variables (Run-time)**

```csharp
class Config
{
    public readonly string DatabasePath;
    public readonly int MaxConnections;

    public Config(string path, int connections)
    {
        // Can only be set in constructor
        DatabasePath = path;
        MaxConnections = connections;
    }

    public void UpdatePath(string newPath)
    {
        // DatabasePath = newPath;  // ERROR - readonly can't be modified here
    }
}
```

---

## **7. Scope and Lifetime**

### **Local Variables**

```csharp
public void MyMethod()
{
    int localVar = 10;      // Scope: Only within this method
    Console.WriteLine(localVar);

    if (true)
    {
        int blockVar = 20;  // Scope: Only within this if block
        Console.WriteLine(blockVar);
        Console.WriteLine(localVar); // Can access outer scope
    }

    // Console.WriteLine(blockVar); // ERROR - out of scope
}
```

### **Class-Level Variables**

```csharp
class Calculator
{
    // Field (class-level variable)
    private int _operationCount = 0;

    public int Add(int a, int b)
    {
        _operationCount++;  // Can access class-level variable
        int result = a + b; // Local variable
        return result;
    }
}
```

---

## **8. Default Values**

**Explanation:** Variables get default values if not initialized.

```csharp
// Value types get default values
int defaultInt;         // 0
double defaultDouble;   // 0.0
bool defaultBool;       // false
char defaultChar;       // '\0' (null character)

// Reference types default to null
string defaultString;   // null
object defaultObject;   // null
int[] defaultArray;     // null

// Example:
int uninitializedInt;
Console.WriteLine(uninitializedInt);  // Output: 0

string uninitializedString;
// Console.WriteLine(uninitializedString.Length);  // ERROR: NullReferenceException
```

---

## **9. Type Conversion**

### **Implicit Conversion (Safe)**

```csharp
int smallNumber = 100;
long bigNumber = smallNumber;  // int to long - no data loss

float floatValue = 3.14f;
double doubleValue = floatValue; // float to double - safe

// Allowed implicit conversions:
// byte → short → int → long → decimal
// float → double
```

### **Explicit Conversion (Casting)**

```csharp
double price = 19.99;
int intPrice = (int)price;     // 19 - fractional part lost

long bigValue = 3000000000;
int intValue = (int)bigValue;  // Overflow! Incorrect value

// Safe casting with checking
if (bigValue <= int.MaxValue && bigValue >= int.MinValue)
{
    intValue = (int)bigValue;
}
```

### **Conversion Methods**

```csharp
string numberString = "123";
int number = int.Parse(numberString);      // Throws exception if fails
int safeNumber = Convert.ToInt32(numberString); // Handles null

// Safe parsing
string userInput = "abc";
if (int.TryParse(userInput, out int result))
{
    Console.WriteLine($"Parsed: {result}");
}
else
{
    Console.WriteLine("Invalid number!");
}
```

---

## **10. Practical Examples**

### **Example 1: Student Information System**

```csharp
class StudentManager
{
    public void ProcessStudent()
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
```

### **Example 2: Shopping Cart Calculator**

```csharp
class ShoppingCart
{
    public void CalculateTotal()
    {
        // Product information
        string productName = "Laptop";
        decimal unitPrice = 999.99m;
        int quantity = 2;
        decimal taxRate = 0.08m;  // 8%
        bool hasDiscount = true;

        // Calculations
        decimal subtotal = unitPrice * quantity;
        decimal discount = hasDiscount ? subtotal * 0.1m : 0;  // 10% discount if applicable
        decimal taxableAmount = subtotal - discount;
        decimal taxAmount = taxableAmount * taxRate;
        decimal total = taxableAmount + taxAmount;

        // Display results
        Console.WriteLine($"Product: {productName}");
        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Subtotal: {subtotal:C}");
        Console.WriteLine($"Discount: {discount:C}");
        Console.WriteLine($"Tax: {taxAmount:C}");
        Console.WriteLine($"Total: {total:C}");
    }
}
```

### **Example 3: Type Conversion Practice**

```csharp
class TypeConverter
{
    public void DemonstrateConversions()
    {
        // String to number
        string userAge = "25";
        int age = int.Parse(userAge);

        // Number to string
        string ageString = age.ToString();

        // Floating point conversions
        double preciseValue = 123.456789;
        float lessPrecise = (float)preciseValue;  // Explicit cast

        // Character operations
        char firstLetter = 'A';
        int asciiValue = firstLetter;  // Implicit conversion to ASCII
        char nextLetter = (char)(asciiValue + 1);  // 'B'

        // Boolean conversions
        string truthString = "True";
        bool isTrue = bool.Parse(truthString);

        Console.WriteLine($"Age: {age}, Ascii: {asciiValue}, Next: {nextLetter}");
    }
}
```

---

## **11. Common Mistakes and Best Practices**

### **Common Mistakes**

```csharp
// 1. Using uninitialized variables
int count;
// Console.WriteLine(count);  // ERROR: Use of unassigned local variable

// 2. Wrong type assignments
// int number = "hello";     // ERROR: Cannot convert string to int

// 3. Scope issues
if (true)
{
    int temp = 10;
}
// Console.WriteLine(temp);  // ERROR: temp doesn't exist here

// 4. Overflow
// byte small = 300;        // ERROR: Value too large for byte
```

### **Best Practices**

```csharp
// 1. Initialize variables when declaring
int count = 0;              // GOOD
string name = string.Empty; // GOOD

// 2. Use descriptive names
int studentCount = 25;      // GOOD
int sc = 25;                // BAD (not descriptive)

// 3. Choose appropriate data types
decimal price = 19.99m;     // GOOD for money
double price = 19.99;       // OK but less precise for financial

// 4. Use constants for magic numbers
const int MAX_LOGIN_ATTEMPTS = 3;
if (attempts > MAX_LOGIN_ATTEMPTS)  // GOOD
// if (attempts > 3)                // BAD (magic number)

// 5. Group related variables
string firstName, lastName; // Related - GOOD
int age, price, count;      // Unrelated - BAD
```

This comprehensive guide covers everything you need to know about C# variables. Practice each concept with small programs to build your understanding!
