# C# Operators: Comprehensive Guide

Operators in C# are special symbols that perform operations on operands (variables and values). They're the building blocks for creating expressions and manipulating data. Let's explore all operator categories in C# with detailed explanations and examples.

## 1. Arithmetic Operators

Perform mathematical calculations on numeric operands.

| Operator | Name           | Description                         | Example        |
| -------- | -------------- | ----------------------------------- | -------------- |
| `+`      | Addition       | Adds two operands                   | `a + b`        |
| `-`      | Subtraction    | Subtracts second operand from first | `a - b`        |
| `*`      | Multiplication | Multiplies two operands             | `a * b`        |
| `/`      | Division       | Divides first operand by second     | `a / b`        |
| `%`      | Modulus        | Returns remainder of division       | `a % b`        |
| `++`     | Increment      | Increases operand by 1              | `a++` or `++a` |
| `--`     | Decrement      | Decreases operand by 1              | `a--` or `--a` |

**Important Notes:**

- Integer division truncates fractional parts: `5 / 2 = 2`
- Modulus works with floating-point: `5.0 % 2.0 = 1.0`
- Prefix vs Postfix increment/decrement:

  ```csharp
  int x = 5;
  int y = ++x; // x=6, y=6 (prefix: increment first)

  int a = 5;
  int b = a++; // a=6, b=5 (postfix: use value first)
  ```

## 2. Relational Operators

Compare two operands and return a boolean result.

| Operator | Name                  | Description                                 | Example  |
| -------- | --------------------- | ------------------------------------------- | -------- |
| `==`     | Equal to              | Checks if operands are equal                | `a == b` |
| `!=`     | Not equal to          | Checks if operands are not equal            | `a != b` |
| `>`      | Greater than          | Checks if first operand is greater          | `a > b`  |
| `<`      | Less than             | Checks if first operand is smaller          | `a < b`  |
| `>=`     | Greater than or equal | Checks if first operand is greater or equal | `a >= b` |
| `<=`     | Less than or equal    | Checks if first operand is smaller or equal | `a <= b` |

**Example:**

```csharp
int age = 25;
bool isAdult = age >= 18; // true
bool isSenior = age > 65; // false
```

## 3. Logical Operators

Combine boolean expressions or invert boolean values.

| Operator | Name        | Description                                  | Example    |
| -------- | ----------- | -------------------------------------------- | ---------- |
| `&&`     | Logical AND | Returns true if both operands are true       | `a && b`   |
| `\|\|`   | Logical OR  | Returns true if at least one operand is true | `a \|\| b` |
| `!`      | Logical NOT | Inverts boolean value                        | `!a`       |
| `&`      | Bitwise AND | Evaluates both operands always               | `a & b`    |
| `\|`     | Bitwise OR  | Evaluates both operands always               | `a \| b`   |
| `^`      | Bitwise XOR | Returns true if operands are different       | `a ^ b`    |

**Short-circuiting:**

- `&&` and `||` use short-circuit evaluation (second operand not evaluated if result is determined)
- `&` and `|` always evaluate both operands

**Example:**

```csharp
bool hasTicket = true;
bool hasId = false;
bool canEnter = hasTicket && hasId; // false

bool isWeekend = true;
bool isHoliday = false;
bool isDayOff = isWeekend || isHoliday; // true

bool isValid = !(isWeekend && isHoliday); // true
```

## 4. Bitwise Operators

Perform operations on individual bits of integer operands.

| Operator | Name        | Description                              | Example  |
| -------- | ----------- | ---------------------------------------- | -------- |
| `~`      | Bitwise NOT | Inverts all bits                         | `~a`     |
| `&`      | Bitwise AND | Sets bit to 1 if both bits are 1         | `a & b`  |
| `\|`     | Bitwise OR  | Sets bit to 1 if either bit is 1         | `a \| b` |
| `^`      | Bitwise XOR | Sets bit to 1 if bits are different      | `a ^ b`  |
| `<<`     | Left shift  | Shifts bits left by specified positions  | `a << 2` |
| `>>`     | Right shift | Shifts bits right by specified positions | `a >> 2` |

**Example:**

```csharp
int a = 5;  // Binary: 0101
int b = 3;  // Binary: 0011

int c = a & b; // 0001 (1)
int d = a | b; // 0111 (7)
int e = a ^ b; // 0110 (6)
int f = ~a;    // 1010 (in 2's complement: -6)

int g = a << 1; // 1010 (10)
int h = a >> 1; // 0010 (2)
```

## 5. Assignment Operators

Assign values to variables, often combined with other operations.

| Operator | Name                      | Description                               | Example   |
| -------- | ------------------------- | ----------------------------------------- | --------- |
| `=`      | Assignment                | Assigns right operand to left operand     | `a = b`   |
| `+=`     | Addition assignment       | Adds right operand to left operand        | `a += b`  |
| `-=`     | Subtraction assignment    | Subtracts right operand from left operand | `a -= b`  |
| `*=`     | Multiplication assignment | Multiplies left operand by right operand  | `a *= b`  |
| `/=`     | Division assignment       | Divides left operand by right operand     | `a /= b`  |
| `%=`     | Modulus assignment        | Takes modulus using both operands         | `a %= b`  |
| `&=`     | Bitwise AND assignment    | Performs bitwise AND and assigns          | `a &= b`  |
| `\|=`    | Bitwise OR assignment     | Performs bitwise OR and assigns           | `a \|= b` |
| `^=`     | Bitwise XOR assignment    | Performs bitwise XOR and assigns          | `a ^= b`  |
| `<<=`    | Left shift assignment     | Performs left shift and assigns           | `a <<= b` |
| `>>=`    | Right shift assignment    | Performs right shift and assigns          | `a >>= b` |

**Example:**

```csharp
int x = 10;
x += 5;  // x = 15
x *= 2;  // x = 30
x %= 7;  // x = 2 (30 % 7 = 2)
```

## 6. Ternary Conditional Operator

A concise way to write conditional expressions.

| Operator | Name    | Description                                         | Example                     |
| -------- | ------- | --------------------------------------------------- | --------------------------- |
| `?:`     | Ternary | Evaluates a condition and returns one of two values | `condition ? expr1 : expr2` |

**Example:**

```csharp
int age = 20;
string status = age >= 18 ? "Adult" : "Minor"; // "Adult"

// Can be nested (use sparingly for readability)
string message = score > 90 ? "Excellent" :
                 score > 70 ? "Good" :
                 score > 50 ? "Pass" : "Fail";
```

## 7. Null-Coalescing Operators

Handle null values in a concise way.

| Operator | Name                       | Description                                               | Example   |
| -------- | -------------------------- | --------------------------------------------------------- | --------- |
| `??`     | Null-coalescing            | Returns left operand if not null, otherwise right operand | `a ?? b`  |
| `??=`    | Null-coalescing assignment | Assigns right operand to left if left is null             | `a ??= b` |

**Example:**

```csharp
string name = null;
string displayName = name ?? "Guest"; // "Guest"

int? count = null;
int result = count ?? 0; // 0

// Null-coalescing assignment
List<string> items = null;
items ??= new List<string>(); // Creates new list if null
```

## 8. Member Access Operators

Access members of types and objects.

| Operator | Name                       | Description                                    | Example         |
| -------- | -------------------------- | ---------------------------------------------- | --------------- |
| `.`      | Member access              | Accesses member of namespace, class, or object | `obj.Property`  |
| `?.`     | Conditional member access  | Accesses member if object is not null          | `obj?.Property` |
| `?[]`    | Conditional element access | Accesses array element if array is not null    | `arr?[index]`   |
| `::`     | Namespace alias qualifier  | Accesses member of aliased namespace           | `alias::member` |

**Example:**

```csharp
// Member access
string text = "Hello";
int length = text.Length; // 5

// Conditional member access
string name = null;
int? nameLength = name?.Length; // null (no NullReferenceException)

// Conditional element access
List<string> items = null;
string first = items?[0]; // null

// Namespace alias
using myAlias = System.Collections;
myAlias::ArrayList list = new myAlias::ArrayList();
```

## 9. Type-Related Operators

Check and convert types.

| Operator | Name            | Description                                                      | Example         |
| -------- | --------------- | ---------------------------------------------------------------- | --------------- |
| `is`     | Type check      | Checks if an object is compatible with a type                    | `obj is string` |
| `as`     | Type conversion | Converts to specified type if compatible, returns null otherwise | `obj as string` |
| `typeof` | Get type        | Gets System.Type object for a type                               | `typeof(int)`   |
| `sizeof` | Get size        | Gets size of type in bytes                                       | `sizeof(int)`   |

**Example:**

```csharp
object obj = "Hello";

// Type check
if (obj is string)
{
    string s = (string)obj;
    Console.WriteLine(s.Length);
}

// Type conversion
string text = obj as string; // "Hello"
int? number = obj as int?;   // null

// Get type
Type intType = typeof(int); // System.Int32

// Get size
int intSize = sizeof(int); // 4
```

## 10. Overflow Handling Operators

Control overflow checking for arithmetic operations.

| Operator    | Name            | Description                | Example            |
| ----------- | --------------- | -------------------------- | ------------------ |
| `checked`   | Check overflow  | Enables overflow checking  | `checked(a + b)`   |
| `unchecked` | Ignore overflow | Disables overflow checking | `unchecked(a + b)` |

**Example:**

```csharp
int max = int.MaxValue;

// With overflow checking
try
{
    int result = checked(max + 1); // Throws OverflowException
}
catch (OverflowException ex)
{
    Console.WriteLine("Overflow occurred");
}

// Without overflow checking
int result = unchecked(max + 1); // Wraps around to -2147483648
```

## 11. Pointer-Related Operators (Unsafe Context)

Used in unsafe code for pointer manipulation.

| Operator | Name                | Description                     | Example      |
| -------- | ------------------- | ------------------------------- | ------------ |
| `*`      | Pointer indirection | Dereferences a pointer          | `*ptr`       |
| `&`      | Address of          | Gets address of a variable      | `&var`       |
| `->`     | Pointer to member   | Accesses member through pointer | `ptr->field` |

**Example (requires unsafe context):**

```csharp
unsafe
{
    int value = 10;
    int* ptr = &value; // Get address

    Console.WriteLine(*ptr); // 10 (dereference)

    *ptr = 20; // Change value through pointer
    Console.WriteLine(value); // 20
}
```

## 12. Lambda Operator

Creates lambda expressions.

| Operator | Name   | Description                                     | Example      |
| -------- | ------ | ----------------------------------------------- | ------------ |
| `=>`     | Lambda | Separates input parameters from expression body | `x => x * x` |

**Example:**

```csharp
// Expression lambda
Func<int, int> square = x => x * x;
Console.WriteLine(square(5)); // 25

// Statement lambda
Func<int, int, int> add = (x, y) =>
{
    int result = x + y;
    return result;
};
Console.WriteLine(add(3, 4)); // 7
```

## 13. Index From End Operator

Accesses elements from the end of a collection.

| Operator | Name           | Description                                | Example     |
| -------- | -------------- | ------------------------------------------ | ----------- |
| `^`      | Index from end | Specifies index from the end of a sequence | `array[^1]` |

**Example:**

```csharp
string[] words = { "first", "second", "last" };

string first = words[0];    // "first"
string last = words[^1];    // "last"
string second = words[^2];  // "second"

// With ranges
string[] allExceptFirst = words[1..];    // ["second", "last"]
string[] middle = words[1..^1];          // ["second"]
```

## 14. Range Operator

Creates ranges for slicing collections.

| Operator | Name  | Description                  | Example       |
| -------- | ----- | ---------------------------- | ------------- |
| `..`     | Range | Specifies a range of indices | `array[0..2]` |

**Example:**

```csharp
string[] words = { "first", "second", "third", "fourth" };

// Different range specifications
string[] firstTwo = words[0..2];      // ["first", "second"]
string[] lastTwo = words[^2..^0];      // ["third", "fourth"]
string[] middle = words[1..3];         // ["second", "third"]
string[] all = words[..];              // Entire array
string[] exceptLast = words[..^1];     // ["first", "second", "third"]
```

## 15. Pattern Matching Operators

Test expressions against patterns.

| Operator | Name              | Description                         | Example              |
| -------- | ----------------- | ----------------------------------- | -------------------- |
| `is`     | Pattern matching  | Tests expression against a pattern  | `obj is int i`       |
| `switch` | Switch expression | Matches expression against patterns | `obj switch { ... }` |

**Example:**

```csharp
// Type pattern with is
object obj = "Hello";
if (obj is string s)
{
    Console.WriteLine(s.ToUpper()); // "HELLO"
}

// Switch expression
string message = obj switch
{
    int i => $"Integer: {i}",
    string s when s.Length > 5 => $"Long string: {s}",
    string s => $"Short string: {s}",
    null => "Null value",
    _ => "Other type"
};
```

## Operator Precedence and Associativity

When multiple operators appear in an expression, they're evaluated based on precedence and associativity:

### Precedence Table (Highest to Lowest)

| Category                    | Operators                                                                                                                                             |
| --------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- | -------------- | --- |
| Primary                     | `x.y`, `x?.y`, `f(x)`, `a[i]`, `x++`, `x--`, `new`, `typeof`, `checked`, `unchecked`, `default`, `nameof`, `delegate`, `sizeof`, `stackalloc`, `x->y` |
| Unary                       | `+`, `-`, `!`, `~`, `++x`, `--x`, `(T)x`, `await`, `&x`, `*x`, `true`, `false`                                                                        |
| Multiplicative              | `*`, `/`, `%`                                                                                                                                         |
| Additive                    | `+`, `-`                                                                                                                                              |
| Shift                       | `<<`, `>>`                                                                                                                                            |
| Relational and Type Testing | `<`, `>`, `<=`, `>=`, `is`, `as`                                                                                                                      |
| Equality                    | `==`, `!=`                                                                                                                                            |
| Logical AND                 | `&`                                                                                                                                                   |
| Logical XOR                 | `^`                                                                                                                                                   |
| Logical OR                  | `                                                                                                                                                     | `              |
| Conditional AND             | `&&`                                                                                                                                                  |
| Conditional OR              | `                                                                                                                                                     |                | `   |
| Null Coalescing             | `??`, `??=`                                                                                                                                           |
| Conditional                 | `?:`                                                                                                                                                  |
| Assignment and Lambda       | `=`, `*=`, `/=`, `%=`, `+=`, `-=`, `<<=`, `>>=`, `&=`, `                                                                                              | =`, `^=`, `=>` |

### Associativity Rules

- **Left-associative**: Operators evaluate from left to right (most operators)
  ```csharp
  10 - 5 - 2 = (10 - 5) - 2 = 3
  ```
- **Right-associative**: Operators evaluate from right to left (assignment, conditional, lambda)
  ```csharp
  a = b = 5; // a = (b = 5)
  ```

## Operator Overloading

C# allows you to redefine how operators work with your custom types:

```csharp
public struct Vector
{
    public double X { get; }
    public double Y { get; }

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Overload + operator
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }

    // Overload - operator
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y);
    }

    // Overload == operator
    public static bool operator ==(Vector a, Vector b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    // Overload != operator
    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }

    // Override Equals and GetHashCode when overloading ==
    public override bool Equals(object obj)
    {
        if (obj is Vector v)
        {
            return this == v;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

// Usage
Vector v1 = new Vector(1, 2);
Vector v2 = new Vector(3, 4);
Vector sum = v1 + v2; // (4, 6)
bool equal = (v1 == v2); // false
```

## Best Practices for Using Operators

1. **Use parentheses for clarity**: Even when precedence is clear, parentheses improve readability

   ```csharp
   // Good
   int result = (a + b) * (c - d);

   // Potentially confusing
   int result = a + b * c - d;
   ```

2. **Be cautious with floating-point comparisons**: Use tolerance instead of exact equality

   ```csharp
   // Bad
   if (a == 0.3) { } // Might not work due to precision issues

   // Good
   if (Math.Abs(a - 0.3) < 0.0001) { }
   ```

3. **Prefer `is` pattern matching over `as`**: More concise and safe

   ```csharp
   // Old way
   string text = obj as string;
   if (text != null) { }

   // New way
   if (obj is string text) { }
   ```

4. **Use null-conditional operators to simplify null checks**:

   ```csharp
   // Without null-conditional
   string name = null;
   int length = 0;
   if (name != null)
   {
       length = name.Length;
   }

   // With null-conditional
   int? length = name?.Length;
   ```

5. **Be consistent with operator overloading**: Only overload when it makes intuitive sense

   ```csharp
   // Good: Vector addition makes sense
   public static Vector operator +(Vector a, Vector b) { }

   // Bad: Adding two employees doesn't make sense
   public static Employee operator +(Employee a, Employee b) { }
   ```

6. **Use compound assignment operators for conciseness**:

   ```csharp
   // Good
   count += 5;

   // Verbose
   count = count + 5;
   ```

7. **Prefer `switch` expressions over complex ternary chains**:

   ```csharp
   // Ternary chain (hard to read)
   string grade = score > 90 ? "A" :
                  score > 80 ? "B" :
                  score > 70 ? "C" : "D";

   // Switch expression (clearer)
   string grade = score switch
   {
       > 90 => "A",
       > 80 => "B",
       > 70 => "C",
       _ => "D"
   };
   ```
