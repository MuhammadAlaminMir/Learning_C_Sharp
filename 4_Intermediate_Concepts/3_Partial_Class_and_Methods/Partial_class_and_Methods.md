

### 1. Partial Classes

**What it is:** A partial class allows you to split the definition of a single class across **multiple C# files**. When you compile your project, the compiler treats all the parts as a single, unified class.

**Why we need it:** The primary use case is for **code generation**. Tools like Visual Studio's UI designer or Entity Framework generate a lot of boilerplate code. By putting that auto-generated code in a separate file (e.g., `MyWindow.Designer.cs`), you can work on your own logic in another file (e.g., `MyWindow.cs`) without risking your changes being overwritten by the code generator.

**Short Example:**

Imagine you have a `Product` class.

**File 1: `Product.Generated.cs` (Auto-generated)**
```csharp
// This file is managed by a tool. Don't edit it manually.
public partial class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

**File 2: `Product.cs` (Your code)**
```csharp
// This is where you add your custom logic.
public partial class Product
{
    public string GetDisplayText()
    {
        return $"{Name} (${Price})";
    }
}
```

At compile time, these two files are merged into one `Product` class that has `Id`, `Name`, `Price`, and `GetDisplayText()`.

---

### 2. Partial Methods

**What it is:** A partial method is a special kind of method declared in one part of a partial class and optionally implemented in another part. It's essentially a "hook" that the code generator can create for you to use if you need to.

**How it works:**
*   One part of the partial class **declares** the method signature.
*   Another part **optionally provides the implementation**.
*   If no implementation is provided, the compiler completely removes the method declaration and all calls to it. This results in **zero performance overhead**.

**Answering your question:** Yes, you are absolutely correct.
*   Partial methods are **implicitly `private`**. They cannot be `public` because they are an internal implementation detail, not part of the class's public API.
*   They **must return `void`**. The compiler must be able to safely remove all calls to the method. If it returned a value, the calling code would be left without a return value, which is impossible.

**Short Example:**

Continuing our `Product` example, the generated code might provide a hook for when a property changes.

**File 1: `Product.Generated.cs` (Auto-generated)**
```csharp
public partial class Product
{
    private decimal _price;
    public decimal Price
    {
        get { return _price; }
        set
        {
            _price = value;
            // This is the hook. If you don't implement it, this line disappears.
            OnPriceChanged(); 
        }
    }

    // Declaration of the partial method
    partial void OnPriceChanged();
}
```

**File 2: `Product.cs` (Your code)**
```csharp
public partial class Product
{
    // Optional implementation of the partial method
    partial void OnPriceChanged()
    {
        Console.WriteLine($"The price for '{Name}' has changed to ${_price}.");
    }
}
```

---

### 3. Static Classes

**What it is:** A static class is a class that **cannot be instantiated**. You cannot create an object of it using the `new` keyword. It acts as a container for static members (like methods and properties).

**Why we need it:** It's perfect for creating utility or "toolbox" classes that hold a set of related helper functions that don't need to maintain any state. The `Math` and `Console` classes are classic examples.

**Key Rules:**
*   Cannot be instantiated (`new MyStaticClass()` is illegal).
*   Is implicitly `sealed` (cannot be inherited from).
*   Can only contain static members.
*   Cannot have an instance constructor (but can have a static constructor).

**Short Example:**

A simple helper class for string manipulation.

```csharp
public static class StringHelper
{
    // A static property
    public static string Separator { get; set; } = "---";

    // A static method
    public static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}

// --- How to use it ---
// You call members directly on the class, no 'new' keyword needed.
string text = "hello world";
string capitalized = StringHelper.CapitalizeFirstLetter(text);
Console.WriteLine(capitalized); // Output: Hello world
```

---

### 4. Static Methods

**What it is:** A static method is a method that belongs to the **class itself**, not to a specific instance of the class.

**How it works:**
*   You call it directly on the class name (`ClassName.MethodName()`).
*   It **cannot access instance members** (fields, properties, or methods that don't have the `static` keyword) because there is no instance (`this`) to work with.
*   It can only access other static members of the same class.

Static methods can exist in both regular classes and static classes.

**Short Example:**

```csharp
public class Calculator
{
    // This is a static method. It doesn't need any instance data.
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // This is an instance method. It belongs to a specific Calculator object.
    public double Memory { get; set; }

    public void AddToMemory(double value)
    {
        this.Memory += value; // It can access the instance 'Memory' property.
    }
}

// --- How to use it ---
// Call the static method directly on the class
int sum = Calculator.Add(5, 10); 

// To call the instance method, you must first create an object
Calculator myCalc = new Calculator();
myCalc.Memory = 50;
myCalc.AddToMemory(25);
```