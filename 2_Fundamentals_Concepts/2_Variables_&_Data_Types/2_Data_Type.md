# C# Data Types: Overview and Primitive Types in Detail

## Brief Overview of C# Data Types

In C#, data types are categorized into two main groups:

1. **Value Types**: Store data directly in memory

   - **Primitive types** (int, float, bool, etc.)
   - **Struct types** (DateTime, TimeSpan, etc.)
   - **Enum types** (user-defined named constants)

2. **Reference Types**: Store references to data in memory
   - **Class types** (String, Arrays, Custom classes)
   - **Interface types**
   - **Delegate types**
   - **Dynamic types**

C# is a statically-typed language, meaning you must declare the type of a variable before using it. The type determines:

- How much memory is allocated
- What values can be stored
- What operations can be performed

---

## Detailed Explanation of Primitive Types

Primitive types (also called simple types) are the most basic data types in C#. They're built into the language and directly mapped to .NET Framework types. Here's a detailed breakdown:

### 1. Integer Types

| Type     | Size (bits) | Range                                                   | .NET Type       | Example Usage                                 |
| -------- | ----------- | ------------------------------------------------------- | --------------- | --------------------------------------------- |
| `sbyte`  | 8           | -128 to 127                                             | `System.SByte`  | `sbyte temperature = -30;`                    |
| `byte`   | 8           | 0 to 255                                                | `System.Byte`   | `byte age = 25;`                              |
| `short`  | 16          | -32,768 to 32,767                                       | `System.Int16`  | `short count = 1000;`                         |
| `ushort` | 16          | 0 to 65,535                                             | `System.UInt16` | `ushort port = 8080;`                         |
| `int`    | 32          | -2,147,483,648 to 2,147,483,647                         | `System.Int32`  | `int population = 7_800_000_000;`             |
| `uint`   | 32          | 0 to 4,294,967,295                                      | `System.UInt32` | `uint positiveId = 100;`                      |
| `long`   | 64          | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 | `System.Int64`  | `long starsInGalaxy = 100_000_000_000;`       |
| `ulong`  | 64          | 0 to 18,446,744,073,709,551,615                         | `System.UInt64` | `ulong veryBigNumber = 18446744073709551615;` |

**Key Points:**

- `int` is the most commonly used integer type
- Underscores (`_`) can be used as digit separators for readability (C# 7.0+)
- Unsigned types (`u` prefix) only store non-negative values
- Choose the smallest type that can accommodate your expected range to save memory

### 2. Floating-Point Types

| Type      | Size (bits) | Precision            | Range                         | .NET Type        | Example Usage               |
| --------- | ----------- | -------------------- | ----------------------------- | ---------------- | --------------------------- |
| `float`   | 32          | 7 decimal digits     | ±1.5 × 10⁻⁴⁵ to ±3.4 × 10³⁸   | `System.Single`  | `float price = 19.99F;`     |
| `double`  | 64          | 15-16 decimal digits | ±5.0 × 10⁻³²⁴ to ±1.7 × 10³⁰⁸ | `System.Double`  | `double pi = 3.1415926535;` |
| `decimal` | 128         | 28-29 decimal digits | ±1.0 × 10⁻²⁸ to ±7.9 × 10²⁸   | `System.Decimal` | `decimal money = 999.99M;`  |

**Key Points:**

- `double` is the default floating-point type in C#
- `float` requires `F` suffix to avoid compilation error
- `decimal` requires `M` suffix and is ideal for financial calculations
- `decimal` has less range but more precision than `double`
- Floating-point types can represent special values: `PositiveInfinity`, `NegativeInfinity`, and `NaN`

### 3. Character Type

| Type   | Size (bits) | Range            | .NET Type     | Example Usage       |
| ------ | ----------- | ---------------- | ------------- | ------------------- |
| `char` | 16          | U+0000 to U+FFFF | `System.Char` | `char grade = 'A';` |

**Key Points:**

- Represents a single Unicode character
- Uses single quotes: `'a'`, `'?'`, `'$'`
- Can represent escape sequences: `'\n'` (newline), `'\t'` (tab), `'\\'` (backslash)
- Can represent Unicode characters: `'\u0041'` (A), `'\u03A9'` (Ω)

### 4. Boolean Type

| Type   | Size (bits) | Values          | .NET Type        | Example Usage          |
| ------ | ----------- | --------------- | ---------------- | ---------------------- |
| `bool` | 8           | `true`, `false` | `System.Boolean` | `bool isValid = true;` |

**Key Points:**

- Represents truth values
- Cannot be implicitly converted to/from integer types
- Essential for conditional statements and logical operations

### 5. Special Primitive Types

| Type      | Description                     | .NET Type       | Example Usage           |
| --------- | ------------------------------- | --------------- | ----------------------- |
| `object`  | Base type for all types in .NET | `System.Object` | `object obj = "Hello";` |
| `string`  | Sequence of Unicode characters  | `System.String` | `string name = "John";` |
| `dynamic` | Resolves type at runtime        | `System.Object` | `dynamic d = 10;`       |

**Key Points:**

- `object` is the ultimate base class for all types
- `string` is a reference type but has some value-type characteristics
- `dynamic` bypasses static type checking at compile time

---

## Important Characteristics of Primitive Types

### 1. Default Values

All primitive types have default values when not initialized:

- Numeric types: `0`
- `bool`: `false`
- `char`: `'\0'` (null character)
- `object`/`string`/`dynamic`: `null`

### 2. Literal Suffixes

- `F` or `f` for `float`
- `D` or `d` for `double` (optional)
- `M` or `m` for `decimal`
- `U` or `u` for `uint`, `ulong`
- `L` or `l` for `long`, `ulong`
- `UL` or `ul` for `ulong`

### 3. Type Conversion

- **Implicit conversion**: When no data loss occurs (e.g., `int` to `long`)
- **Explicit conversion**: When data loss might occur (e.g., `double` to `int`)
- **Parsing**: Converting strings to numeric types (e.g., `int.Parse("123")`)

### 4. Overflow Handling

- By default, arithmetic operations on integer types ignore overflow
- Use `checked` keyword to enable overflow checking:
  ```csharp
  checked
  {
      int x = int.MaxValue;
      int y = x + 1; // Throws OverflowException
  }
  ```

### 5. Nullable Types

All primitive types can be made nullable using `?`:

```csharp
int? nullableInt = null;
bool? hasValue = null;
```

---

## Practical Examples

### Working with Numeric Types

```csharp
// Integer types
int count = 42;
long population = 7_800_000_000;
byte age = 25;

// Floating-point types
float price = 19.99F;
double pi = 3.1415926535;
decimal money = 999.99M;

// Arithmetic operations
int sum = count + age;
double area = pi * 10 * 10;
decimal total = money * 1.08M; // Add 8% tax
```

### Working with Characters and Booleans

```csharp
// Characters
char firstInitial = 'J';
char newline = '\n';
char omega = '\u03A9';

// Booleans
bool isAdult = age >= 18;
bool hasDiscount = price > 50;

// Logical operations
bool canBuy = isAdult && hasDiscount;
bool isWeekend = day == "Saturday" || day == "Sunday";
```

### Type Conversion Examples

```csharp
// Implicit conversion
int i = 123;
long l = i; // No data loss

// Explicit conversion
double d = 3.14;
int truncated = (int)d; // truncated = 3

// Parsing
string numberStr = "42";
int parsed = int.Parse(numberStr);

// Safe parsing
string invalid = "abc";
if (int.TryParse(invalid, out int result))
{
    // Use result
}
else
{
    // Handle invalid input
}
```

### Nullable Types

```csharp
// Nullable declaration
int? nullableInt = null;
bool? hasValue = true;

// Check for value
if (nullableInt.HasValue)
{
    int value = nullableInt.Value;
}

// GetValueOrDefault
int safeValue = nullableInt.GetValueOrDefault(); // Returns 0 if null

// Null coalescing operator
int actualValue = nullableInt ?? 0; // Returns 0 if null
```

---

## Best Practices for Using Primitive Types

1. **Choose the right type for the job**:

   - Use `int` for general integer arithmetic
   - Use `double` for scientific calculations
   - Use `decimal` for financial calculations
   - Use `long` for large integers (like database IDs)

2. **Be explicit about numeric literals**:

   ```csharp
   // Good
   float f = 3.14F;
   decimal d = 100.50M;

   // Bad (may cause precision issues)
   float f = 3.14; // Treated as double, then converted
   ```

3. **Use meaningful variable names**:

   ```csharp
   // Good
   int customerAge = 25;
   double accountBalance = 1500.75;

   // Bad
   int a = 25;
   double b = 1500.75;
   ```

4. **Initialize variables**:

   ```csharp
   // Good
   int count = 0;
   bool isValid = false;

   // Bad (uninitialized)
   int count;
   bool isValid;
   ```

5. **Handle potential overflow**:

   ```csharp
   // For critical calculations
   checked
   {
       int result = x * y;
   }

   // Or use larger types
   long result = (long)x * y;
   ```

6. **Prefer `TryParse` over `Parse` for user input**:
   ```csharp
   // Safe parsing
   if (int.TryParse(userInput, out int number))
   {
       // Use number
   }
   else
   {
       // Handle invalid input
   }
   ```
