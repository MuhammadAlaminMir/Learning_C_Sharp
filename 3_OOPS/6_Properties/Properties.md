### 1. What is a Property and Why We Need It

A property is a member of a class that provides a flexible mechanism to **read, write, or compute the value of a private field**.

**Why not just make fields `public`?**

This is the key question. If you have `public string Name;`, any code anywhere can do `myObject.Name = null;` or `myObject.Name = "An incredibly long string that might break something";`. You have no control.

**We need properties to enforce Encapsulation.** Encapsulation is the principle of bundling data and the methods that work on that data, while _hiding_ the internal state from the outside world.

Properties let you:

1. **Validate Data:** Prevent invalid data from being set (e.g., an `Age` property that doesn't allow negative numbers).
2. **Control Access:** Make a field read-only from the outside, but writable from inside the class.
3. **Trigger Actions:** Run code whenever a value is read or changed (e.g., log a change, update a UI element, recalculate another value).
4. **Expose "Virtual" Data:** A property can calculate a value on the fly without storing it anywhere. For example, a `FullName` property that combines `FirstName` and `LastName`.

---

### 2. How It Works: The Mechanics

A property is made of two special accessors: `get` and `set`.

- **`get` accessor:** This code is executed when the property is **read**. It must return a value.
- **`set` accessor:** This code is executed when the property is **written to**. It uses a special keyword called `value` to represent the data being assigned to the property.

Here is the "classic" or "full" property syntax with a **backing field**.

```csharp
public class Person
{
    // 1. The private backing field. This is the actual data storage.
    private string _name;

    // 2. The public property. This is the "remote control".
    public string Name
    {
        // The 'get' accessor controls reading the value
        get
        {
            // You could add logic here, like logging
            Console.WriteLine("Getting the name...");
            return _name;
        }

        // The 'set' accessor controls writing the value
        set
        {
            // 'value' is the implicit variable holding what's being assigned
            // e.g., if we do myPerson.Name = "John"; then 'value' is "John"
            if (!string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Setting the name to: {value}");
                _name = value;
            }
            else
            {
                Console.WriteLine("Cannot set an empty name!");
            }
        }
    }
}

```

---

### 3. Read-Only and Write-Only Properties

You can create properties that can only be read or only be written by simply omitting the `get` or `set` accessor.

### Read-Only Property

Only has a `get` accessor. It's useful for values that are set once (like in a constructor) or are calculated.

```csharp
public class Order
{
    public int OrderId { get; } // Read-only auto-property (more on this soon)

    public Order(int id)
    {
        this.OrderId = id; // Can only be set in the constructor
    }

    // Calculated read-only property
    public string OrderInfo => $"Order #{this.OrderId}"; // Expression-bodied property
}

```

### Write-Only Property

Only has a `set` accessor. This is **rare** but can be useful for things like a `Password` property, where you should never be able to read it back for security reasons.

```csharp
private string _passwordHash;
public string Password
{
    set
    {
        // Hash the incoming value and store it. Never store the plain text password.
        _passwordHash = Hasher.Hash(value);
    }
    // No 'get' accessor, so you cannot read the password.
}

```

---

### 4. Accessibility of `get` and `set` Accessors

You can apply different access levels to the `get` and `set` accessors individually. This is extremely powerful for controlling who can modify data.

The most common pattern is `public get, private set`. This means anyone can read the property, but only code _within the same class_ can change it.

```csharp
public class Employee
{
    public int Id { get; private set; }

    public Employee(int id)
    {
        this.Id = id; // OK to set here because we're inside the class
    }

    public void Promote()
    {
        // You can't change the ID, but you could change other things.
        // The point is, the Id is now immutable from the outside.
    }
}

// --- Outside the class ---
Employee emp = new Employee(101);
int id = emp.Id; // OK to read

// emp.Id = 102; // COMPILE ERROR! The 'set' accessor is private.

```

---

### 5. Auto-Implemented Properties (The Modern Shortcut)

Writing a private field and a full property is verbose. In most cases, the property doesn't need any special logic in the `get` or `set`. For these cases, C# provides **auto-implemented properties**.

The compiler automatically creates the hidden, anonymous backing field for you.

```csharp
// Instead of this:
// private string _firstName;
// public string FirstName { get { return _firstName; } set { _firstName = value; } }

// You can just write this:
public string FirstName { get; set; }
public string LastName { get; set; }

```

This is the standard, modern way to write simple properties.

### Auto-Properties with Accessibility

You can combine the accessibility modifiers with auto-properties.

```csharp
public class Product
{
    public int Sku { get; private set; } // Read-only to the public
    public string Name { get; protected set; } // Can be set by this class and derived classes
    public decimal Price { get; set; } // Fully public
}

```

---

### 6. Auto-Property Initializers (C# 6.0 and later)

Before C# 6, if you wanted a default value for an auto-property, you had to set it in the constructor. Now, you can set it directly on the property itself. This makes your code cleaner and more declarative.

```csharp
public class Settings
{
    // Set a default value right here!
    public bool IsEnabled { get; set; } = true;

    public string LogLevel { get; set; } = "Info";

    public int MaxRetries { get; } = 3; // Works for read-only properties too!
}

```

---
