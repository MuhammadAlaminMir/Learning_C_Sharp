# Comprehensive Guide to C# Generics

## Lecture 1: Introduction to Generic Classes

### What Are Generics?

Generics are a powerful feature in C# that allow you to design classes, interfaces, and methods with placeholders for data types. These placeholders (typically represented by `T`) are specified later by developers using your code, enabling the creation of type-safe and high-performance data structures without sacrificing reusability.

### The Problem Generics Solve

Before generics, reusable collections used `System.Object` as the base type, which led to two significant issues:

1. **Lack of Type Safety**: Collections like `ArrayList` could hold any type of data. You could add an integer, then a string, then a custom object. When retrieving items, you had to perform explicit casts and hope for the correct type, often resulting in `InvalidCastException` errors at runtime.
2. **Poor Performance (Boxing)**: When adding value types (like `int` or `double`) to these collections, they had to be boxed (wrapped in an object on the heap). Retrieving them required unboxing. These operations are computationally expensive and create pressure on the garbage collector.

### How Generics Work

### Type Parameters and JIT Specialization

You create a generic class by adding a type parameter in angle brackets after the class name:

```csharp
public class MyList<T> { ... }

```

When developers use your generic class, they specify a concrete type, creating a closed generic type:

```csharp
MyList<int> integerList = new MyList<int>();
MyList<string> stringList = new MyList<string>();

```

The .NET Just-In-Time (JIT) compiler then performs specialization:

- For value types (like `int`, `double`, `struct`), the JIT creates a new, optimized version of the class specifically for that value type, completely avoiding boxing/unboxing.
- For reference types (`string`, custom classes, etc.), the JIT reuses a single underlying implementation since all references have the same size.

### Example: A Reusable Repository

```csharp
// 'T' is a placeholder for whatever type we want this repository to handle
public class Repository<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T GetById(int index)
    {
        return _items[index];
    }

    public int Count => _items.Count;
}

public class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
}

public class Product
{
    public string Sku { get; set; }
    public decimal Price { get; set; }
}

// --- Usage examples ---
// 1. Create a repository specifically for Employee objects
Repository<Employee> employeeRepo = new Repository<Employee>();
employeeRepo.Add(new Employee { Name = "John Doe", Id = 101 });
// employeeRepo.Add(new Product()); // ERROR! Compiler enforces type safety

// 2. Create another repository specifically for Product objects
Repository<Product> productRepo = new Repository<Product>();
productRepo.Add(new Product { Sku = "XYZ-123", Price = 19.99m });

Console.WriteLine($"Employees: {employeeRepo.Count}");
Console.WriteLine($"Products: {productRepo.Count}");

```

## Lecture 2: Multiple Generic Parameters

### Introduction

Generic classes and methods aren't limited to a single type parameter. You can define multiple placeholders for different types when your class needs to work with combinations of them.

### How It Works

You declare multiple type parameters by listing them inside angle brackets, separated by commas:

```csharp
public class MyClass<T, U> { ... }

```

By convention, letters like `T`, `U`, `V` are used, or more descriptive names like `TKey` and `TValue`.

### When to Use Multiple Parameters

Use multiple generic parameters when creating a class that naturally pairs or relates different types. The most common example in .NET is `Dictionary<TKey, TValue>`, which needs one type for keys and another for values.

### Example: A Simple Pair Class

```csharp
// This class uses two type parameters, TFirst and TSecond
public class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        this.First = first;
        this.Second = second;
    }

    public override string ToString()
    {
        return $"First: {First}, Second: {Second}";
    }
}

// --- Usage examples ---
// Create a pair of a string and an integer
Pair<string, int> nameAndAge = new Pair<string, int>("Alice", 30);
Console.WriteLine(nameAndAge);

// Create a pair of an Employee object and a double
Employee emp = new Employee { Name = "Bob", Id = 102 };
Pair<Employee, double> employeeAndSalary = new Pair<Employee, double>(emp, 75000.50);
Console.WriteLine(employeeAndSalary);

// Create a pair of two different types
Pair<int, string> numberAndWord = new Pair<int, string>(42, "Answer");
Console.WriteLine(numberAndWord);

```

## Lecture 3: Generic Constraints

### Introduction

Constraints are rules applied to generic type parameters to restrict the types that can be used with your generic class or method. Without constraints, the compiler only assumes that a type parameter `T` derives from `System.Object`, limiting you to methods defined in `Object` (like `ToString()`, `Equals()`, etc.).

Constraints give the compiler more information about `T`'s capabilities, allowing you to call specific methods or access properties on it.

### How to Apply Constraints

You apply constraints using the `where` keyword after the generic type parameter list:

```csharp
public class MyClass<T> where T : constraint
{
    // Class implementation
}

```

### Types of Constraints

1. **Reference Type Constraint**: `where T : class`
    - The type argument must be a reference type (class, interface, delegate, or array)
    - Useful when you need to work with null values
2. **Value Type Constraint**: `where T : struct`
    - The type argument must be a non-nullable value type (int, double, bool, or custom struct)
    - Ensures the type cannot be null
3. **Parameterless Constructor Constraint**: `where T : new()`
    - The type argument must have a public parameterless constructor
    - Allows you to create instances with `new T()`
    - Must be the last constraint in the list
4. **Base Class Constraint**: `where T : BaseClassName`
    - The type argument must be or derive from the specified base class
    - Allows you to use all public members of the base class
5. **Interface Constraint**: `where T : IInterfaceName`
    - The type argument must implement the specified interface
    - One of the most common and powerful constraints
6. **Multiple Constraints**: You can combine constraints:
    
    ```csharp
    public class MyClass<T> where T : BaseClass, IInterface, new()
    
    ```
    

### Example: Constraining to an Interface

```csharp
// 1. Define the contract (the interface)
public interface IEntityWithName
{
    string Name { get; }
    int Id { get; }
}

// 2. Create some classes that implement the interface
public class Product : IEntityWithName
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Id { get; set; }
}

public class Customer : IEntityWithName
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
}

// 3. Create the generic class with a constraint
public class ReportGenerator<T> where T : IEntityWithName
{
    public void GenerateReport(T item)
    {
        // Because of the constraint, the compiler KNOWS that 'item'
        // will have 'Name' and 'Id' properties
        Console.WriteLine($"--- Report for {item.Name} (ID: {item.Id}) ---");
        // ... more reporting logic ...
    }

    public T FindById(List<T> items, int id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }
}

// --- Usage examples ---
var generator = new ReportGenerator<Product>();
var products = new List<Product>
{
    new Product { Name = "Laptop", Price = 1200m, Id = 1 },
    new Product { Name = "Mouse", Price = 25m, Id = 2 }
};

generator.GenerateReport(products[0]);
Product foundProduct = generator.FindById(products, 2);
Console.WriteLine($"Found: {foundProduct.Name}");

// This would cause a compiler error because 'int' does not implement IEntityWithName
// var intGenerator = new ReportGenerator<int>(); // ERROR!

```

## Lecture 4: Generic Methods

### Introduction

A generic method is declared with its own type parameters, allowing a single method to perform the same action on various data types while maintaining type safety. A key feature is that generic methods can exist inside non-generic classes.

### How Generic Methods Work

You declare a generic method by placing the type parameter in angle brackets immediately after the method name:

```csharp
access_modifier return_type MethodName<T>(T parameter) { ... }

```

One powerful feature is **type inference** - the C# compiler can often deduce the type `T` from the arguments passed, so you don't need to specify the type in angle brackets when calling the method.

### When to Use Generic Methods

Use generic methods for standalone utility functions that perform actions not dependent on specific data types. They're perfect for general-purpose operations like swapping, sorting, or comparing items.

### Example: A Reusable Swap Method

Without generics, you'd need separate Swap methods for each data type. With a generic method, you write it once:

```csharp
public class Utilities
{
    // This is a generic method. 'T' can be any type.
    public static void Swap<T>(ref T a, ref T b)
    {
        Console.WriteLine($"Swapping items of type: {typeof(T).Name}");
        T temp = a;
        a = b;
        b = temp;
    }

    // Another example: A generic method to find the maximum of two items
    public static T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}

// --- Usage examples ---
// Swapping Integers
int x = 5;
int y = 10;
Console.WriteLine($"Before: x={x}, y={y}");
Utilities.Swap(ref x, ref y);  // Type inference: T is int
Console.WriteLine($"After: x={x}, y={y}");

// Swapping Strings
string s1 = "Hello";
string s2 = "World";
Console.WriteLine($"Before: s1={s1}, s2={s2}");
Utilities.Swap(ref s1, ref s2);  // Type inference: T is string
Console.WriteLine($"After: s1={s1}, s2={s2}");

// Finding maximum values
int maxInt = Utilities.Max(10, 20);  // Returns 20
string maxString = Utilities.Max("Apple", "Banana");  // Returns "Banana"

```

### Generic Methods with Multiple Type Parameters

Generic methods can also have multiple type parameters:

```csharp
public class Converter
{
    public static TResult Convert<TSource, TResult>(TSource source, Func<TSource, TResult> converter)
    {
        return converter(source);
    }
}

// Usage
string numberString = "123";
int number = Converter.Convert<string, int>(numberString, s => int.Parse(s));

// With type inference
double result = Converter.Convert("45.67", s => double.Parse(s));

```

## Lecture 5: Important Points to Remember

### 1. Generics Solve Two Main Problems

This is the most important takeaway about why C# has generics:

1. **Type Safety**: Generics move type checking from runtime to compile-time. When you use `List<string>`, the compiler guarantees only strings can be added, preventing `InvalidCastException` errors common with older collections.
2. **Performance**: Generics eliminate boxing/unboxing for value types. `List<int>` stores integers directly, while `ArrayList` had to box each integer into an object, causing performance degradation and garbage collector pressure.

### 2. List<T> vs. ArrayList: The Classic Comparison

| Feature | ArrayList (Old, Non-Generic) | List<T> (Modern, Generic) |
| --- | --- | --- |
| Storage | Stores everything as object | Stores a specific type T |
| Type Safety | Not type-safe | Type-safe (compiler enforced) |
| Casting | Requires explicit casting | No casting needed |
| Performance | Poor for value types (boxing) | High performance (no boxing) |

You should always use `List<T>` and other generic collections (`Dictionary<TKey, TValue>`, `Queue<T>`, etc.) in modern C# code.

### 3. Constraints Unlock Functionality

Use constraints (`where T : ...`) when your method needs to do more than store or pass data:

- `where T : IMyInterface`: Lets you call methods defined in `IMyInterface`
- `where T : MyBaseClass`: Lets you use members from `MyBaseClass`
- `where T : new()`: Lets you create new instances with `new T()`

### 4. Generic Methods vs. Generic Classes

Use this guideline to decide which to create:

- **Generic Class**: When the entire class works as a container or manager for a specific type. The class's state (fields/properties) depends on `T`. Examples: `List<T>`, `Repository<T>`.
- **Generic Method**: For standalone utility functions that perform actions on any type, where the containing class doesn't need to be generic. Examples: `Swap<T>()`, `Sort<T>()`.

### 5. Open vs. Closed Generic Types

- **Open Generic Type**: The type definition with placeholders still present. You cannot create an instance of an open type. Example: `typeof(List<>)`.
- **Closed Generic Type**: A type where specific type arguments have been provided. This is the type you can instantiate. Example: `typeof(List<int>)`.

### 6. Generic Interfaces

Just like classes, interfaces can also be generic:

```csharp
public interface IRepository<T>
{
    T GetById(int id);
    void Add(T item);
    void Update(T item);
    void Delete(int id);
}

public class SqlRepository<T> : IRepository<T> where T : class, new()
{
    // Implementation...
}

```

### 7. Generic Delegates

C# provides built-in generic delegates that are widely used:

- `Func<T, TResult>`: Represents a method that takes a parameter of type T and returns a result of type TResult
- `Action<T>`: Represents a method that takes a parameter of type T and returns void
- `Predicate<T>`: Represents a method that takes a parameter of type T and returns a boolean

```csharp
// Using Func<T, TResult>
Func<string, int> stringLength = s => s.Length;
int length = stringLength("Hello"); // Returns 5

// Using Action<T>
Action<string> printMessage = message => Console.WriteLine(message);
printMessage("Hello World");

// Using Predicate<T>
Predicate<int> isEven = number => number % 2 == 0;
bool result = isEven(4); // Returns true

```

### 8. Variance in Generics (Advanced)

C# supports variance in generic interfaces and delegates:

- **Covariance** (`out`): Allows you to use a more derived type than specified
- **Contravariance** (`in`): Allows you to use a more generic type than specified

```csharp
// Covariance example
IEnumerable<object> objects = new List<string>(); // Valid

// Contravariance example
Action<object> objectAction = o => Console.WriteLine(o.ToString());
Action<string> stringAction = objectAction; // Valid

```

Understanding generics is essential for modern C# development. They provide type safety, better performance, and code reusability, making them a fundamental tool in every C# developer's toolkit.