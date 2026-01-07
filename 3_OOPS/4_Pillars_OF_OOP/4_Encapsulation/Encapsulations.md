# **Encapsulation in C#: The Complete Guide**

## **What is Encapsulation?**

Encapsulation is the practice of **hiding internal implementation details** of a class and exposing only what's necessary through a public interface. Think of it like a capsule—you only see the outside, not the medicine inside. In programming, it means keeping fields private and providing controlled access through methods or properties.

## **Why Encapsulation Matters**

Without encapsulation, your code becomes fragile. If everyone can directly modify a class's internal data, one change can break everything. Encapsulation provides:

1. **Control** over how data is accessed and modified
2. **Safety** by preventing invalid states
3. **Flexibility** to change implementation without breaking existing code
4. **Maintainability** by reducing dependencies between components

## **The Basic Principle: Private Fields, Public Methods**

```csharp
// ❌ BAD - No encapsulation
public class BankAccount
{
    public decimal Balance;  // Direct access - dangerous!
}

// Anyone can do this:
BankAccount account = new BankAccount();
account.Balance = -1000;  // Negative balance? That's bad!

// ✅ GOOD - Proper encapsulation
public class BankAccount
{
    private decimal _balance;  // Private field - hidden internally

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            _balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
            return true;
        }
        return false;
    }

    public decimal GetBalance()  // Read-only access
    {
        return _balance;
    }
}

// Now usage is controlled:
BankAccount account = new BankAccount();
account.Deposit(500);      // Works
bool success = account.Withdraw(100);  // Validated withdrawal
// account._balance = -1000;  // ERROR! Can't access private field

```

## **Properties: C#'s Built-in Encapsulation**

In C#, we achieve Encapsulation through a three-step process.

### Step 1: Hide the Data (`private` fields)

As discussed in the access modifier guide, your variables should almost always be `private`. This stops other classes from messing with your data directly.

```csharp
public class BankAccount
{
    // BAD: public int balance; // Anyone can change this to anything!

    // GOOD: private field
    private double _balance;
}

```

### Step 2: Provide Access (Properties)

If the data is private, how do people read or change it? We use **Properties**.

A property looks like a variable to the outside world, but acts like a method internally. It has two accessors:

- **`get`**: Runs when someone reads the value.
- **`set`**: Runs when someone assigns a value.

```csharp
public class BankAccount
{
    private double _balance;

    // The Property
    public double Balance
    {
        get { return _balance; } // Read access
        set { _balance = value; } // Write access
    }
}

```

### Step 3: Add Logic (Validation)

This is the superpower of Encapsulation. Since `set` acts like a method, you can write code inside it to reject bad data.

```csharp
public class BankAccount
{
    private double _balance;

    public double Balance
    {
        get { return _balance; }
        set
        {
            if (value >= 0) // Validation Logic
            {
                _balance = value;
            }
            else
            {
                Console.WriteLine("Error: Balance cannot be negative!");
            }
        }
    }
}

```

---

### 3. Modern C# Encapsulation (Shortcuts)

Writing `get { return x; }` and `set { x = value; }` every time is tedious. C# provides shortcuts.

### A. Auto-Implemented Properties

If you don't need any validation logic right now, use this. The compiler creates a hidden private backing field for you automatically.

```csharp
public class Person
{
    // This creates a private string _name automatically behind the scenes
    public string Name { get; set; }
    public int Age { get; set; }
}

```

### B. Read-Only Properties

Sometimes you want people to see the value but never change it (like `readonly` fields, but for properties).

```csharp
public class Person
{
    public string Name { get; private set; } // Public read, Private write
    public int Age { get; }                 // Only settable in the constructor
}

```

### C. Expression-Bodied Members (C# 7+)

For very simple properties, we can make it one line using the `=>` (Lambda arrow).

```csharp
public class Person
{
    private string _name;
    public string Name => _name; // Same as { get { return _name; } }
}

```

---

## **Access Modifiers: The Gatekeepers**

C# provides several access levels to control visibility:

| Modifier | Access Level | Use When |
| --- | --- | --- |
| `private` | Same class only | Default for fields, internal implementation |
| `protected` | Same class and derived classes | For inheritance hierarchy |
| `internal` | Same assembly | Library-internal code |
| `protected internal` | Same assembly OR derived classes | Complex library scenarios |
| `public` | Anywhere | Public API, interfaces |

