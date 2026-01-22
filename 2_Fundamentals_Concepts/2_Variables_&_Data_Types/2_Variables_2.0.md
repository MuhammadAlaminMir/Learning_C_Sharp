## 1. Implicitly Typed Variables (var)

### Introduction

The `var` keyword, introduced in C# 3.0, lets you declare a local variable without explicitly specifying its data type. The compiler infers the type for you based on the value you use to initialize the variable.

### How var Works: Compile-Time Type Inference

This is the most critical concept to understand: `var` does not create a dynamically typed variable. C# remains a statically-typed language. The `var` keyword is purely a compile-time feature. The compiler looks at the expression on the right-hand side of the assignment and determines its type. It then replaces the `var` keyword with that explicit type in the Intermediate Language (IL).

When you write:

```csharp
var name = "John";

```

The compiler generates the same code as if you had written:

```csharp
string name = "John";

```

Once the type is inferred and compiled, it is locked in. You cannot later assign a value of a different type to that variable.

### Rules and Best Practices

### Rules:

1. A `var` variable must be initialized at the time of its declaration so the compiler can infer its type. `var x;` is a compiler error.
2. `var` can only be used for local variables inside a method. It cannot be used for fields or method parameters.
3. The initializer must be an expression. It cannot be an object or collection initializer by itself.
4. The compile-time type of the initializer expression cannot be the `null` type.

### Best Practices - When to Use var:

Use it when the type of the variable is obvious from the right-hand side of the assignment. This reduces code clutter and improves readability.

```csharp
// Good: type is clearly User
var user = new User();

// Good: type is clearly List<string>
var names = new List<string>();

// Good, if GetName() clearly returns a string
var name = GetName();

// Good with complex LINQ expressions
var filteredCustomers = customers.Where(c => c.IsActive && c.RegistrationDate > DateTime.Now.AddYears(-1))
                                .OrderBy(c => c.LastName)
                                .Select(c => new { c.Id, c.Name, c.Email });

```

### Best Practices - When to Avoid var:

Avoid it when the type is not immediately clear, as this can harm readability.

```csharp
// Potentially confusing: Is this an int, double, decimal?
var amount = 20;
// Better: Be explicit
decimal amount = 20M;

// Unclear: What does ProcessData return?
var result = ProcessData();
// Better: Be explicit
ProcessResult result = ProcessData();

// Unclear with numeric literals
var distance = CalculateDistance(origin, destination);
// Better: Be explicit about the unit
double distanceInKm = CalculateDistance(origin, destination);

```

### Using var with Anonymous Types

One of the most powerful use cases for `var` is with anonymous types, which have no name that you can explicitly specify:

```csharp
var person = new { FirstName = "John", LastName = "Doe", Age = 30 };
Console.WriteLine($"{person.FirstName} {person.LastName} is {person.Age} years old.");

// You cannot do this because there's no type name:
// SomeType person = new { FirstName = "John", LastName = "Doe", Age = 30 };

```

## 2. Dynamically Typed Variables (dynamic)

### Introduction

The `dynamic` keyword, introduced in C# 4.0, allows you to create variables that bypass static type checking at compile-time. It fundamentally changes how the compiler treats the variable.

### How dynamic Works: Run-Time Resolution

When you declare a variable as `dynamic`, you are telling the compiler: "Trust me. Don't check anything I do with this variable right now. We will figure it out at run-time."

All calls to methods, properties, or operators on a `dynamic` variable are packaged up and resolved only when the program is actually running. If the member you tried to call exists at run-time, the code works. If it does not exist, the program will crash with a `RuntimeBinderException`.

### Why and When to Use dynamic

You should use `dynamic` with great caution as it sacrifices the core benefit of C#'s static type safety. Its main valid use cases are for interoperability:

1. **Working with Dynamic Languages**: Interacting with libraries from languages like Python or IronRuby.
2. **Working with the DOM in HTML**: Manipulating HTML elements in certain web contexts.
3. **Parsing Dynamic Data Formats**: Working with data like JSON where the structure might not be known ahead of time.
4. **COM Interop**: Interacting with older COM components.

### var vs. dynamic: The Core Comparison

| Feature | var (Implicitly Typed) | dynamic (Dynamically Typed) |
| --- | --- | --- |
| Typing | Statically typed | Dynamically typed |
| When Checked | Type is determined and checked by the compiler at compile-time | Type is resolved by the runtime at run-time |
| IntelliSense | Full IntelliSense and compile-time error checking | No IntelliSense support for its members |
| Errors | Produces compile-time errors if you call a non-existent method | Bypasses the compiler and throws a run-time exception if you call a non-existent method |
| Example | `var x = 10; x = "hello";` // COMPILE-TIME ERROR | `dynamic x = 10; x = "hello";` // NO ERROR. The type of x changes at runtime |

### Example Implementation

```csharp
// The compiler knows x is an int.
var x = 10;
// Console.WriteLine(x.ToUpper()); // Compile-time error: 'int' does not contain a definition for 'ToUpper'

// The compiler knows nothing about what y can do. It trusts you.
dynamic y = 10;

// This next line compiles fine, but will CRASH at runtime because the integer 10
// does not have a ToUpper() method.
try
{
    Console.WriteLine(y.ToUpper());
}
catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
{
    Console.WriteLine("RUNTIME ERROR: " + ex.Message);
}

// This is valid, because the type of y can change at runtime.
y = "hello";
Console.WriteLine(y.ToUpper()); // This works now. Output: HELLO

// Dynamic with COM Interop example
dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
excelApp.Visible = true;
excelApp.Workbooks.Add(); // These methods exist at runtime but not known at compile time

```