# The Comprehensive Guide to Structures in C#

## 1. Introduction: What is a Struct?

A **Struct (Structure)** is a composite data type that groups related variables under a single name.

**The Golden Rule:** The single most defining characteristic of a struct is that it is a **Value Type**. This distinguishes it fundamentally from Classes, which are **Reference Types**.

- **When to use:** Structs are best for small, lightweight objects that logically represent a single value (e.g., a coordinate point, a color, a complex number).

---

## 2. Core Mechanics: Value Type Semantics

Because structs are value types, a struct variable holds the **actual data**, not a reference (pointer) to the data.

### Memory Allocation

- **Location:** Structs are typically allocated on the **Stack** (a fast, temporary memory region).
- **Deallocation:** When a method finishes, the stack frame is "popped," and the struct is instantly removed. This avoids the overhead of Garbage Collection (GC) associated with Classes.
- A variable of a struct type holds the actual data itself, not a reference to the data
- Structs are typically allocated on the stack, which is fast and efficient
- When a method call finishes, structs created within it are deallocated as the stack frame is popped
- This avoids the overhead of garbage collection associated with class objects on the heap

### Assignment Behavior (Copy-on-Assignment)

When you assign one struct variable to another, **a complete copy of the data is created**.

- The variables are independent.
- Changing one does **not** affect the other.

### **Default Values (Never Null)**

**Simple Rule**: A struct variable always contains valid data, even if you don't initialize it. It's never `null`.

**Implication**: You don't need null checks for structs, but you also can't use `null` to represent "no value" or "uninitialized."

### Example: Demonstrating Independence

```csharp
public struct Point
{
    // Fields in a struct are typically public for easy access
    public int X;
    public int Y;
}
 
public class Program
{
    public static void Main(string[] args)
    {
        // point1 holds its own X and Y values directly
        Point point1 = new Point();
        point1.X = 10;
        point1.Y = 20;
 
        // When we assign point1 to point2, a complete COPY of the data is made
        Point point2 = point1;
 
        Console.WriteLine($"Before change: point1=({point1.X}, {point1.Y}), point2=({point2.X}, {point2.Y})");
 
        // Changing the X value of the FIRST point
        point1.X = 99;
        Console.WriteLine("\n--- Changed point1.X to 99 ---");
 
        // The change only affects point1. point2 is completely unaffected
        Console.WriteLine($"After change: point1=({point1.X}, {point1.Y}), point2=({point2.X}, {point2.Y})");
    }
}
```

---

## 3. Working with Constructors

Like classes, structs use constructors to ensure an object starts in a valid state. However, there are strict rules specific to structs.

### The Rules of Struct Constructors

1. **Parameterized Constructors:** You can define custom constructors.
    - *Rule:* You **must** initialize **all** instance fields inside the constructor. The compiler enforces this to guarantee the struct is fully initialized.
2. **The Implicit Parameterless Constructor:** Every struct automatically has a built-in parameterless constructor (e.g., `new Point()`). You cannot delete or hide it. It initializes all fields to default values (0, `false`, `null`).
3. **Explicit Parameterless Constructors (C# 10+):** You can now write your own parameterless constructor, but the implicit one still exists conceptually.

### Example

```csharp
public struct Point
{
    public int X;
    public int Y;
 
    // A parameterized constructor
    public Point(int x, int y)
    {
        // We MUST initialize all fields inside this constructor
        this.X = x;
        this.Y = y;
    }
 
    public void Display()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}
 
public class Program
{
    public static void Main(string[] args)
    {
        // 1. Create a point using the default parameterless constructor
        Point origin = new Point();
        Console.Write("Origin point: ");
        origin.Display(); // Output: (0, 0)
 
        // 2. Create a point using our custom parameterized constructor
        Point p1 = new Point(15, 25);
        Console.Write("Custom point: ");
        p1.Display(); // Output: (15, 25)
    }
}
```

---

## **4. Structs vs. Classes: A Detailed Comparison**

| **Aspect** | **Class** | **Struct** |
| --- | --- | --- |
| **Type** | Reference type | Value type |
| **Memory Allocation** | Object on the heap, variable holds reference | Typically on the stack, variable holds actual data |
| **Assignment Behavior** | Copies the reference (both point to same object) | Copies the entire data (creates new instance) |
| **Passing to Methods** | Passes reference copy (method can modify original) | Passes entire copy (method works on copy) |
| **Inheritance** | Supports single inheritance | No inheritance support (except from System.ValueType) |
| **Default Value** | null | Instance with all fields set to default values |

### Example: Class vs. Struct Behavior

```csharp
// The class (reference type)
public class ClassPoint { public int X; }

// The struct (value type)
public struct StructPoint { public int X; }

public class Program
{
    // This method attempts to change the X value of whatever it receives
    public static void TryToChangeValue(ClassPoint cp, StructPoint sp)
    {
        cp.X = 100;
        sp.X = 100;
    }

    public static void Main(string[] args)
    {
        ClassPoint myClassPoint = new ClassPoint();
        myClassPoint.X = 10;

        StructPoint myStructPoint = new StructPoint();
        myStructPoint.X = 10;

        Console.WriteLine($"Before method call: ClassPoint.X = {myClassPoint.X}, StructPoint.X = {myStructPoint.X}");

        // Pass both to the method
        TryToChangeValue(myClassPoint, myStructPoint);

        Console.WriteLine($"After method call:  ClassPoint.X = {myClassPoint.X}, StructPoint.X = {myStructPoint.X}");
    }
}

```

**Output:**

```
Before method call: ClassPoint.X = 10, StructPoint.X = 10
After method call:  ClassPoint.X = 100, StructPoint.X = 10

```

The change to the ClassPoint persisted because the method received a reference to the original object. The change to the StructPoint was lost because the method only operated on a temporary copy.

## 5. Readonly Structure

### **What Are Readonly Structs?**

A **readonly struct** is a special type of structure declared as immutable. Once created, its state can never be changed throughout its lifetime.

### How It Works

1. Add the `readonly` modifier to the struct declaration.
2. **Rule:** All instance fields must also be marked `readonly`.
3. Fields can only be assigned in the constructor or at declaration.

### Benefits

- **Thread Safety:** Immutable data is inherently safe in multi-threaded environments.
- **Intent:** Clearly signals that this struct is a fixed snapshot of data.
- **Performance:** Allows the compiler to make optimizations knowing the data won't change.

### Example

```csharp
public readonly struct RgbColor
{
    // All fields MUST be readonly
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;
 
    public RgbColor(byte r, byte g, byte b)
    {
        // Values can only be set here, in the constructor
        this.R = r;
        this.G = g;
        this.B = b;
    }
 
    public void ChangeRed(byte newRed)
    {
        // The following line would cause a compiler error because R is readonly
        // this.R = newRed; // ERROR! Cannot assign to 'R' because it is a readonly field.
    }
}
 
// Usage example
RgbColor myColor = new RgbColor(255, 165, 0); // Orange
// 'myColor' is now immutable. Its state cannot be changed.
```

---

## 6. Under the Hood: Primitive Types are Structs

In C#, basic "primitives" are actually aliases for System structs. This unifies the type system.

| Keyword | Struct Alias |
| --- | --- |
| `int` | `System.Int32` |
| `double` | `System.Double` |
| `bool` | `System.Boolean` |
| `decimal` | `System.Decimal` |
| `long` | `System.Int64` |
| decimal | System.Decimal |

**The Implication:**
Because `int` is a struct (System.Int32), it inherits all struct behaviors (stack storage, copy-on-assignment). However, because `int` inherits from `System.ValueType` (which inherits from `System.Object`), you can call methods on primitives:

```csharp
int myNumber = 123;
// Calling ToString() on a struct
string text = myNumber.ToString();
// Calling a method on a literal
Console.WriteLine(45.ToString());

```

---

## 7. Important Points & Best Practices

1. **Choose Class by Default:** Microsoft recommends using a class unless you have a specific performance reason to use a struct.
2. **When to Use a Struct:**
    - The type represents a **single value** (like a complex number).
    - It is **small** (typically < 16 bytes).
    - It is **immutable** (readonly).
    - It is short-lived (created and destroyed frequently).
3. **Performance Trade-off:** While structs avoid Garbage Collection, copying large structs is expensive. If a struct is large, copying it around is slower than passing a 4-byte reference to a class.
4. **Never make a struct mutable if you box it:** Changing the value of a boxed struct creates a copy, which is a common source of bugs. Stick to `readonly` for safety.

## 9. Advanced Topics

### Boxing and Unboxing

When a struct is treated as an object (e.g., when stored in a collection of objects), it undergoes **boxing** (converting from value type to reference type). This process creates a copy on the heap and can impact performance.

### Structs with Methods

Like classes, structs can have methods, properties, and other members. However, methods that modify the struct's state can be confusing due to the copy-on-assignment behavior.

### Structs and Interfaces

Structs can implement interfaces, but when a struct is cast to an interface type, it gets boxed, which can have performance implications.

## Conclusion

Structs in C# provide a powerful way to create lightweight value types that can improve performance in specific scenarios. Understanding their value-type nature, how they differ from classes, and when to use them is essential for writing efficient and correct C# code. By following the guidelines and best practices outlined in this guide, you can make informed decisions about when to use structs versus classes in your applications.