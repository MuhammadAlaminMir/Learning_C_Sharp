### **Introduction to the System Class**

**Explanation:** `System` is not actually a class itself, but rather a **fundamental namespace** in the .NET Framework that contains essential classes and types used in virtually every C# program. It's the core namespace that provides basic functionality for data types, console operations, math functions, garbage collection, and much more.

When you write `using System;` at the top of your file, you're importing this entire namespace so you can use its members without typing the full qualified names.

---

### **Console Class - Detailed Explanation**

### **1. What is the Console Class?**

**Explanation:** The `Console` class is a **static class** within the `System` namespace that provides methods and properties for interacting with the console window (command prompt/terminal). It's your primary interface for reading input from the keyboard and writing output to the screen in console applications.

**Key Characteristics:**

- **Static class:** You don't need to create an instance - use `Console.MethodName()` directly
- **Text-based:** Works with strings and characters
- **Synchronous:** Operations happen in sequence (though async versions exist)
- **Standard streams:** Uses standard input (keyboard), output (screen), and error streams

---

### **2. Console Class Structure**

```csharp
namespace System
{
    public static class Console
    {
        // Properties
        public static TextReader In { get; }        // Standard input stream
        public static TextWriter Out { get; }       // Standard output stream
        public static TextWriter Error { get; }     // Standard error stream

        // Methods for output
        public static void Write(...)               // Write without newline
        public static void WriteLine(...)           // Write with newline

        // Methods for input
        public static string ReadLine()             // Read entire line
        public static int Read()                    // Read single character
        public static ConsoleKeyInfo ReadKey()      // Read key press

        // Control methods
        public static void Clear()                  // Clear console
        public static void Beep()                   // Play beep sound

        // Configuration properties
        public static int WindowWidth { get; set; } // Console width
        public static string Title { get; set; }    // Window title
        // ... and many more
    }
}

```

---

### **3. Output Methods - Writing to Console**

### **Write() Method**

**Purpose:** Writes text to the console without moving to the next line.

```csharp
Console.Write("Hello");        // Writes "Hello"
Console.Write(" World");       // Writes " World" on same line
// Output: "Hello World" (on one line)

Console.Write(42);             // Writes integer: "42"
Console.Write(3.14);           // Writes double: "3.14"
Console.Write(true);           // Writes boolean: "True"

```

### **WriteLine() Method**

**Purpose:** Writes text to the console and moves to the next line.

```csharp
Console.WriteLine("Hello");
Console.WriteLine("World");
// Output:
// Hello
// World

Console.WriteLine(10 + 5);     // Writes calculation result: "15"

```

### **String Formatting with Write/WriteLine**

**Purpose:** Create formatted output using placeholders.

```csharp
string name = "John";
int age = 25;
double salary = 50000.50;

// Basic formatting
Console.WriteLine("Name: {0}, Age: {1}, Salary: {2}", name, age, salary);
// Output: Name: John, Age: 25, Salary: 50000.5

// Format specifiers
Console.WriteLine("Salary: {0:C}", salary);        // Currency: $50,000.50
Console.WriteLine("Salary: {0:N2}", salary);       // Number with 2 decimals: 50,000.50
Console.WriteLine("Percent: {0:P}", 0.25);         // Percentage: 25.00%

// String interpolation (C# 6+)
Console.WriteLine($"Name: {name}, Age: {age}, Salary: {salary:C}");

```

---

### **4. Input Methods - Reading from Console**

### **ReadLine() Method**

**Purpose:** Reads an entire line of text from the console until Enter is pressed.

```csharp
Console.Write("Enter your name: ");
string name = Console.ReadLine();  // Waits for user input
Console.WriteLine($"Hello, {name}!");

// Example usage with parsing
Console.Write("Enter your age: ");
string ageInput = Console.ReadLine();
if (int.TryParse(ageInput, out int age))
{
    Console.WriteLine($"You are {age} years old.");
}
else
{
    Console.WriteLine("Invalid age entered.");
}

```

### **Read() Method**

**Purpose:** Reads a single character and returns its ASCII value.

```csharp
Console.Write("Press any key: ");
int keyValue = Console.Read();     // Returns ASCII value
char character = (char)keyValue;   // Convert to character
Console.WriteLine($"You pressed: {character} (ASCII: {keyValue})");

```

### **ReadKey() Method**

**Purpose:** Reads a single key press and returns detailed information about the key.

```csharp
Console.Write("Press any key to continue...");
ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true); // Don't display key
Console.WriteLine($"\\nYou pressed: {keyInfo.Key} (Char: {keyInfo.KeyChar})");

// Useful for menu systems
Console.WriteLine("Press 'Y' for Yes, 'N' for No:");
ConsoleKeyInfo choice = Console.ReadKey();
if (choice.Key == ConsoleKey.Y)
{
    Console.WriteLine("\\nYou chose Yes!");
}
else if (choice.Key == ConsoleKey.N)
{
    Console.WriteLine("\\nYou chose No!");
}

```

---

### **5. Console Configuration Properties**

### **Colors and Appearance**

```csharp
// Change text and background colors
Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("This is green text on black background");

// Reset to default
Console.ResetColor();

// Change console title
Console.Title = "My Awesome Console Application";

```

### **Window and Buffer Settings**

```csharp
// Window size
Console.WindowWidth = 100;     // Characters wide
Console.WindowHeight = 30;     // Lines tall

// Buffer size (scrollable area)
Console.BufferWidth = 100;
Console.BufferHeight = 1000;   // Allows scrolling

// Cursor position
Console.SetCursorPosition(10, 5);  // Column 10, Row 5
Console.Write("Text at position 10,5");

// Get cursor position
int left = Console.CursorLeft;
int top = Console.CursorTop;

```

---

### **6. Practical Examples and Patterns**

### **Simple Menu System**

```csharp
static void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("=== MAIN MENU ===");
    Console.WriteLine("1. Add Customer");
    Console.WriteLine("2. View Customers");
    Console.WriteLine("3. Exit");
    Console.Write("Select an option (1-3): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddCustomer();
            break;
        case "2":
            ViewCustomers();
            break;
        case "3":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice! Press any key to continue...");
            Console.ReadKey();
            ShowMenu();
            break;
    }
}

```

### **Password Input (Masking Characters)**

```csharp
static string ReadPassword()
{
    string password = "";
    Console.Write("Enter password: ");

    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey(intercept: true);

        if (key.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();  // Move to next line
            return password;
        }
        else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
        {
            password = password.Remove(password.Length - 1);
            Console.Write("\\b \\b");  // Erase the asterisk
        }
        else if (key.KeyChar != '\\u0000')  // Not a control character
        {
            password += key.KeyChar;
            Console.Write("*");  // Show asterisk instead of actual character
        }
    }
}

```

### **Progress Indicator**

```csharp
static void ShowProgress()
{
    for (int i = 0; i <= 100; i++)
    {
        Console.Write($"\\rProgress: {i}% ");  // \\r returns to start of line
        Thread.Sleep(50);  // Simulate work
    }
    Console.WriteLine("\\nComplete!");
}

```

---

### **7. Error Output**

**Purpose:** Write error messages to the standard error stream (often displayed in red).

```csharp
// Regular output (stdout)
Console.Out.WriteLine("This is normal output");

// Error output (stderr)
Console.Error.WriteLine("This is an ERROR message!");

// Redirect error output (advanced)
// Console.SetError(new StreamWriter("error.log"));

```

---

### **8. Important Notes and Best Practices**

1. **Encoding Issues:** Console uses system default encoding. For special characters, you might need:
    
    ```csharp
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    
    ```
    
2. **Exception Handling:** Always handle potential exceptions:
    
    ```csharp
    try
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid number format!");
    }
    
    ```
    
3. **Resource Management:** The console streams are shared resources - be careful in multi-threaded applications.
4. **Platform Differences:** Console behavior may vary slightly between Windows, Linux, and macOS.
5. **For User-Friendly Apps:** Always provide clear prompts and validate input:
    
    ```csharp
    Console.Write("Enter your age: ");
    while (!int.TryParse(Console.ReadLine(), out int age) || age < 0 || age > 150)
    {
        Console.Write("Invalid age. Please enter a number between 0-150: ");
    }
    
    ```
    

The Console class is your gateway to simple text-based interaction in C#. While modern applications often use GUI frameworks, understanding console I/O is fundamental for learning, debugging, scripting, and server applications.