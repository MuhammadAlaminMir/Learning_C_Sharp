# All about Methods in C#

### What is a Method?

A **method** is a code block that contains a series of statements. It's a behavior or action that a class or object can perform. Think of it as a named operation that can be executed whenever needed.

**Key Purposes:**

- Encapsulate logic for reusability
- Make code more readable and maintainable
- Allow code organization and separation of concerns

---

### Method Syntax

```csharp
access_modifier modifiers return_type MethodName(parameter_list)
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

### Parameter Types / Parameter Modifiers in C#

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

### Extra: Ref Return

**`ref return`** allows a method to return a **reference** (memory address) to a variable, rather than a **copy** of its value.

### The Concept

- **Normal Return:** Like giving someone a **photocopy** of a document. If they write on their copy, your original doesn't change.
- **Ref Return:** Like giving someone the **location** of the original document in the filing cabinet. If they write on it, **they are writing on your original.**

### Syntax & Example

You need to use the `ref` keyword in three places:

1. Method definition (return type).
2. The `return` statement.
3. The variable receiving the result (at the call site).

```csharp
public class Box
{
    private int[] _numbers = { 1, 2, 3, 4 };

    // 1. The method returns a reference to an int
    public ref int GetNumber(int index)
    {
        // 2. Use 'return ref' to return the actual array element
        return ref _numbers[index];
    }
}

// Usage
Box myBox = new Box();

// 3. Use 'ref' to receive the reference
ref int num = ref myBox.GetNumber(2);

// This is not changing 'num', it is changing _numbers[2] inside the object!
num = 100;

Console.WriteLine(myBox.GetNumber(2)); // Prints 100

```

### Why use it?

1. **Performance:** Avoids copying large data structures (like large `structs` or arrays) just to return a value.
2. **In-Place Editing:** Allows you to modify data inside a collection or object directly without complex setter methods.

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

The `params` keyword allows you to define a method that can accept a **variable number of arguments** without needing to manually create an array first. It makes your methods flexible to handle anywhere from zero to many inputs.

Think of it as an **"Expandable Backpack"** for your method arguments.

### 1. How It Works

When you use `params`, C# automatically takes all the extra arguments passed to the method and converts them into an array behind the scenes.

**Syntax:**

```csharp
public returnType MethodName(params type[] parameterName)
{
    // parameterName is treated as an array inside the method
}

```

### 2. The Golden Rules

There are strict rules when using `params`:

1. **Only One:** You can only have **one** `params` parameter per method.
2. **Last Position:** It must be the **last** parameter in the list (so the compiler knows where the variable list ends).
3. **Type Safety:** All arguments passed to it must be of the same type (e.g., `int[]` or `string[]`).

---

### 3. Usage Examples

**A. Mixed Parameters (Real-world scenario)**
You can have other required parameters *before* the `params`. This is very common in logging or formatting functions.

```csharp
// 'message' is required. 'tags' is optional.
public void LogMessage(string message, params string[] tags)
{
    Console.Write($"[LOG]: {message} | Tags: ");

    foreach (string tag in tags)
    {
        Console.Write($"#{tag} ");
    }
    Console.WriteLine();
}

// Usage
LogMessage("System Started");
// Output: [LOG]: System Started | Tags:

LogMessage("Database Error", "Critical", "DB");
// Output: [LOG]: Database Error | Tags: #Critical #DB

```

### 5. `in` Parameter Modifier

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

### Optional Parameters / Default values

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

### Named Arguments

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

### Advanced Local Function Features:

### Static Local Functions

Introduced in **C# 8.0**, a **Static Local Function** is a helper function defined inside another method that is explicitly marked as `static`.

The defining characteristic is: **It cannot access any variables from the enclosing method.** It can only access its own parameters and other static members (like static classes or constants).

Think of it as a "Pure Function" locked inside a bubble.

---

### 1. The Logic: Strict Isolation

To understand Static Local Functions, you first need to understand normal Local Functions.

- **Normal Local Function:** Can see and modify variables defined in the parent method. (It "captures" the context).
- **Static Local Function:** Is **blind** to the parent method's variables. It is completely self-contained.

**Analogy:**

- **Normal Local Function:** An assistant sitting at your desk who can reach over and steal your pen.
- **Static Local Function:** An assistant sitting in a soundproof glass booth. You have to slide documents under the glass (pass arguments) for them to work on it. They cannot grab your pen.

---

### 2. Code Example

Let's look at a method that calculates the length of the hypotenuse of a triangle.

### ❌ The Non-Static Way (Risky)

The local function `Square` can technically see `x` and `y`, but we pass them explicitly. However, if we made a typo and tried to use `x` inside `Square`, the compiler would allow it, potentially causing a bug if the logic gets complex.

```csharp
public double CalculateHypotenuse(int x, int y)
{
    // This function CAN access 'x' and 'y' directly, even if we don't want it to
    int Square(int n) => n * n;

    double result = Square(x) + Square(y);
    return Math.Sqrt(result);
}

```

### ✅ The Static Way (Safe)

By adding `static`, we guarantee `Square` relies **only** on what we pass to it (`n`).

```csharp
public double CalculateHypotenuse(int x, int y)
{
    // STATIC ensures 'Square' cannot touch 'x' or 'y' from this method.
    // It creates a clear boundary.
    static int Square(int n) => n * n;

    double result = Square(x) + Square(y);
    return Math.Sqrt(result);
}

```

**What happens if you try to cheat?**

```csharp
static int Square(int n) => n * x; // COMPILER ERROR: x cannot be accessed in a static local function.

```

---

### 3. Why use Static Local Functions?

1. **Prevents Accidental Bugs:** If you have a loop variable named `i` in your main method, and you also have a variable named `i` in your helper, a normal local function might accidentally use the wrong one. `static` prevents this confusion entirely.
2. **Makes Intent Clear:** By marking it `static`, you are telling other developers (and your future self): *"This function does not depend on the state of the method it is inside. It only depends on these arguments."*
3. **Performance (Minor):** In advanced scenarios, static local functions avoid creating extra memory allocations (closures) because they don't need to "capture" variables from the surrounding scope.

### Summary

Use `static` on a local function when you want to ensure it is **stateless** and **pure**—meaning it simply takes inputs and gives outputs without touching anything else in your method.

## Method Overloading

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