### What is a Method?

A **method** is a code block that contains a series of statements. It's a behavior or action that a class or object can perform. Think of it as a named operation that can be executed whenever needed.

**Key Purposes:**

- Encapsulate logic for reusability
- Make code more readable and maintainable
- Allow code organization and separation of concerns

---

### Method Syntax

```csharp
access_modifier return_type MethodName(parameter_list)
{
    // Method body - statements to execute
    return value; // if return_type is not void
}

```

**Example:**

```csharp
public int Add(int a, int b)
{
    int result = a + b;
    return result;
}

```

---

### Parameters vs Arguments

This is a crucial distinction:

- **Parameter:** The variable defined in the method declaration (the "placeholder")
- **Argument:** The actual value passed to the method when it's called (the "actual value")

```csharp
// 'a' and 'b' are PARAMETERS
public int Multiply(int a, int b)
{
    return a * b;
}

// In the method call, 5 and 10 are ARGUMENTS
int result = Multiply(5, 10);

```

---

### Parameter Types in C#

C# provides several ways to define parameters that affect how arguments are passed:

### 1. Value Parameters (Default)

- A copy of the argument is passed to the method
- Changes to the parameter inside the method **do not affect** the original argument

```csharp
public void ModifyValue(int x)
{
    x = 100; // This only changes the local copy
    Console.WriteLine($"Inside method: x = {x}");
}

// Usage
int number = 5;
ModifyValue(number);
Console.WriteLine($"Outside method: number = {number}"); // Still 5

```

### 2. Reference Parameters (`ref` keyword)

- The method receives a reference to the original variable
- Changes to the parameter **affect** the original argument
- The `ref` keyword must be used in both method declaration and call

```csharp
public void ModifyWithRef(ref int x)
{
    x = 100; // This changes the original variable
    Console.WriteLine($"Inside method: x = {x}");
}

// Usage
int number = 5;
ModifyWithRef(ref number);
Console.WriteLine($"Outside method: number = {number}"); // Now 100

```

### 3. Output Parameters (`out` keyword)

- Used when a method needs to return multiple values
- The parameter must be assigned a value within the method
- The `out` keyword must be used in both declaration and call

```csharp
public bool TryDivide(int dividend, int divisor, out int result)
{
    if (divisor != 0)
    {
        result = dividend / divisor;
        return true;
    }
    else
    {
        result = 0; // Must assign out parameter
        return false;
    }
}

// Usage
if (TryDivide(10, 2, out int quotient))
{
    Console.WriteLine($"Result: {quotient}"); // Result: 5
}

```

### 4. Parameter Arrays (`params` keyword)

- Allows a method to accept a variable number of arguments
- Must be the last parameter in the parameter list

```csharp
public int Sum(params int[] numbers)
{
    int total = 0;
    foreach (int num in numbers)
    {
        total += num;
    }
    return total;
}

// Usage - all are valid
int result1 = Sum(1, 2, 3);           // 6
int result2 = Sum(1, 2, 3, 4, 5);     // 15
int result3 = Sum();                   // 0

```

### 5. Optional Parameters

- Parameters can have default values
- Callers can omit arguments for these parameters

```csharp
public void Greet(string name, string greeting = "Hello", int times = 1)
{
    for (int i = 0; i < times; i++)
    {
        Console.WriteLine($"{greeting}, {name}!");
    }
}

// Usage - all are valid
Greet("Alice");                        // Hello, Alice!
Greet("Bob", "Hi");                    // Hi, Bob!
Greet("Charlie", "Welcome", 3);        // Welcome, Charlie! (3 times)

```

### 6. Named Arguments

- Allows you to specify arguments by parameter name rather than position
- Can be combined with optional parameters

```csharp
public void ConfigureServer(string hostname, int port = 80, bool ssl = false)
{
    Console.WriteLine($"Connecting to {hostname}:{port} (SSL: {ssl})");
}

// Usage
ConfigureServer("example.com");                    // Positional
ConfigureServer("example.com", ssl: true);        // Named argument
ConfigureServer(port: 8080, hostname: "localhost"); // Mixed, order doesn't matter

```

---

### 7. `in` Parameter Modifier

- The parameter is passed by reference but **cannot be modified** inside the method
- Provides performance benefits for large structs while ensuring immutability
- The `in` keyword can be used in both declaration and call

```csharp
public double CalculateDistance(in Vector3 point1, in Vector3 point2)
{
    // point1.X = 10; // COMPILER ERROR - cannot modify in parameter
    double dx = point2.X - point1.X;
    double dy = point2.Y - point1.Y;
    double dz = point2.Z - point1.Z;
    return Math.Sqrt(dx * dx + dy * dy + dz * dz);
}

// Usage (in is optional at call site for compatibility)
Vector3 start = new Vector3(1, 2, 3);
Vector3 end = new Vector3(4, 6, 8);
double distance = CalculateDistance(in start, in end);

```

---

### Static Methods

**Static methods** belong to the **class itself** rather than to any specific object instance. They're called using the class name.

**Key Characteristics:**

- Cannot access instance members (fields, properties, methods) directly
- Can only access other static members
- No `this` reference available
- Useful for utility functions that don't require object state

```csharp
public class MathUtilities
{
    // Instance field - each object has its own
    private int _calculationCount;

    // Static field - shared across all instances
    private static int _totalCalculations;

    // Instance method - operates on specific object
    public int IncrementCount()
    {
        _calculationCount++;
        _totalCalculations++; // Can access static members
        return _calculationCount;
    }

    // Static method - called on the class itself
    public static double CircleArea(double radius)
    {
        // _calculationCount++; // ERROR: Cannot access instance member
        _totalCalculations++;   // OK: Can access static members
        return Math.PI * radius * radius;
    }

    public static int GetTotalCalculations() => _totalCalculations;
}

// Usage
double area = MathUtilities.CircleArea(5.0); // No object needed
// MathUtilities.IncrementCount(); // ERROR: Cannot call instance method on class

MathUtilities util = new MathUtilities();
util.IncrementCount(); // OK: Call instance method on object

```

---

### `this` Keyword in Methods

The `this` keyword refers to the **current instance** of the class.  It acts as a direct reference to the current object instance on which the method was called. Think of it as an object's way of referring to itself.

### 1. Referring to Current Instance Members

```csharp
public class Person
{
    private string name;

    public void SetName(string name)
    {
        this.name = name; // 'this' distinguishes field from parameter
    }

    public void Display()
    {
        Console.WriteLine(this.name); // Explicit but optional
        Console.WriteLine(name);      // Same as above
    }
}

```

### 2. Constructor Chaining

```csharp
public class Rectangle
{
    private int width;
    private int height;
    private string color;

    // Constructor with all parameters
    public Rectangle(int width, int height, string color)
    {
        this.width = width;
        this.height = height;
        this.color = color;
    }

    // Constructor with default color - chains to main constructor
    public Rectangle(int width, int height) : this(width, height, "Black")
    {
    }

    // Default constructor - chains to other constructors
    public Rectangle() : this(10, 5)
    {
    }
}

```

### 3. Passing Current Object as Parameter

```csharp
public class Player
{
    public string Name { get; set; }

    public void JoinGame(Game game)
    {
        game.AddPlayer(this); // Pass the current player object
    }
}

```

### Local Functions

**Local functions** are methods defined inside other methods. They're nested methods that can only be called from within their containing method.

### Key Characteristics:

- Defined inside another method body
- Can access variables from the containing method
- Improve readability by breaking complex methods into smaller pieces
- Support all regular method features (parameters, return types, etc.)

### Syntax:

```csharp
return_type ContainingMethod()
{
    return_type LocalFunction(parameters)
    {
        // implementation
    }

    // Call the local function
    return LocalFunction();
}

```

### Example:

```csharp
public class Calculator
{
    public double CalculateTax(double income)
    {
        // Local function to calculate tax for a bracket
        double CalculateBracketTax(double amount, double rate)
        {
            return amount * rate;
        }

        // Local function with access to containing method's parameter
        bool IsInHighIncomeBracket()
        {
            return income > 100000;
        }

        double tax = 0;

       
        // Add base tax
        tax += CalculateBracketTax(Math.Min(income, 50000), 0.12);

       
        return tax;
    }
}

```

### Advanced Local Function Features:

```csharp
public void ProcessData(int[] numbers)
{
    int callCount = 0; // Captured variable

    // Local function that captures variables from containing method
    void ProcessItem(int item)
    {
        callCount++; // Modifies captured variable
        Console.WriteLine($"Processing {item}, call count: {callCount}");
    }

    // Static local function (C# 8.0+) - cannot capture variables
    static bool IsValid(int number)
    {
        return number >= 0;
    }

    foreach (int number in numbers)
    {
        if (IsValid(number))
        {
            ProcessItem(number);
        }
    }

    Console.WriteLine($"Total processed: {callCount}");
}

```

---

### Method Overloading

**Method overloading** allows you to create multiple methods with the **same name** but **different parameters** within the same class.

### Rules for Overloading:

1. Methods must have the same name
2. Methods must have different parameter lists (different types, number, or order)
3. Return type alone is **not sufficient** for overloading
4. Access modifiers can be different but don't affect overloading

### Example:

```csharp
public class MathOperations
{
    // Different number of parameters
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    // Different parameter types
    public double Add(double a, double b)
    {
        return a + b;
    }

    public string Add(string a, string b)
    {
        return a + b;
    }

    // Different parameter order
    public void Display(int number, string message)
    {
        Console.WriteLine($"{number}: {message}");
    }

    public void Display(string message, int number)
    {
        Console.WriteLine($"{message} - {number}");
    }

    // This would cause COMPILER ERROR - same parameters, different return type
    // public double Add(int a, int b)
    // {
    //     return (double)(a + b);
    // }

    // Overloading with params
    public int Sum(params int[] numbers)
    {
        return numbers.Sum();
    }

    public int Sum(int a, int b, params int[] rest)
    {
        return a + b + rest.Sum();
    }
}

```

---

### Recursion

**Recursion** occurs when a method calls itself directly or indirectly to solve a problem. It's particularly useful for problems that can be broken down into smaller, similar subproblems.

### Key Components of Recursion:

1. **Base Case** - The condition that stops the recursion
2. **Recursive Case** - The part where the method calls itself
3. **Progress Toward Base Case** - Each call should move closer to the base case

### Example: Factorial Calculation

```csharp
public class RecursiveFunctions
{
    // Recursive factorial calculation
    public long Factorial(int n)
    {
        // Base case
        if (n <= 1)
            return 1;

        // Recursive case
        return n * Factorial(n - 1);
    }
}

```