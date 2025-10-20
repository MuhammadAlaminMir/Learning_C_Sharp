

### What is OOP?

**Object-Oriented Programming (OOP)** is a programming paradigm based on the concept of "objects," which can contain data (in the form of fields or properties) and code (in the form of methods). The main goal is to model real-world entities to make software design more modular, reusable, and easier to manage.

---

### The 4 Pillars of OOP (In Short)

1.  **Encapsulation:** The protective shell.
    *   Bundling an object's data and the methods that operate on that data.
    *   Hides the internal state from the outside world. *(Think: `private` fields, `public` properties)*

2.  **Inheritance:** The "is-a" relationship.
    *   Allows a new class (child) to adopt the properties and methods of an existing class (parent).
    *   Promotes code reuse. *(Think: `Dog` inherits from `Animal`)*

3.  **Polymorphism:** Many forms.
    *   Allows objects of different classes to be treated as objects of a common parent class.
    *   The same action (e.g., `MakeSound()`) can have different behaviors for different objects. *(Think: `Dog` barks, `Cat` meows)*

4.  **Abstraction:** Hiding complexity.
    *   Hiding the complex implementation details and showing only the essential features of an object.
    *   Defines a contract for what an object can do. *(Think: An `IVehicle` interface defines `StartEngine()` but not how it works)*
  
  
### 1. Encapsulation (The Protective Shell)

**What it is:** The practice of bundling an object's data (fields) and the methods that operate on that data into a single unit (a class). It also involves **hiding** the internal state of the object from the outside world.

**Why we need it:** It's all about **control and safety**. It prevents other parts of your code from accidentally corrupting an object's state. You, as the class creator, get to decide exactly how your data can be accessed and modified.

**How it works in C#:** By using access modifiers.
*   `private`: The data (fields) is hidden inside the class.
*   `public`: The "remote controls" (properties and methods) are exposed to the outside.

**Simple Example: A `BankAccount`**

```csharp
public class BankAccount
{
    // The data is PRIVATE and hidden from the outside world.
    private decimal _balance;

    // The constructor provides a safe way to create an account.
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance >= 0)
        {
            _balance = initialBalance;
        }
        else
        {
            throw new ArgumentException("Initial balance cannot be negative.");
        }
    }

    // A public property provides controlled READ access.
    public decimal Balance
    {
        get { return _balance; }
    }

    // Public methods provide controlled WRITE access.
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }
}

// --- How to use it ---
BankAccount myAccount = new BankAccount(100);
// decimal balance = myAccount._balance; // ERROR! _balance is private.
Console.WriteLine(myAccount.Balance); // OK: Reading via the public property.

myAccount.Deposit(50); // OK: Modifying via a safe public method.
// myAccount._balance = -1000; // ERROR! Cannot directly mess with the internal state.
```

---

### 2. Inheritance (The "Is-A" Relationship)

**What it is:** A mechanism where a new class (derived/child class) acquires the properties and behaviors of an existing class (base/parent class). This creates a hierarchy.

**Why we need it:** For **code reuse and logical organization**. Instead of rewriting the same code for similar classes, you can put the common code in a base class and have the specialized classes inherit from it.

**How it works in C#:** Using the `:` syntax.

**Simple Example: `Animal` Hierarchy**

```csharp
// The BASE class (the parent)
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }
}

// The DERIVED class (the child)
// Dog "is-a" Animal and gets all its features automatically.
public class Dog : Animal
{
    // Dog can add its own unique behavior
    public void Bark()
    {
        Console.WriteLine("Woof!");
    }
}

// --- How to use it ---
Dog myDog = new Dog();
myDog.Name = "Buddy";
myDog.Age = 5;

myDog.Eat(); // This method was INHERITED from Animal
myDog.Bark(); // This method is unique to Dog
```

---

### 3. Polymorphism (Many Forms)

**What it is:** The ability of an object to take on many forms. In practice, it means you can treat an object of a derived class as if it were an object of its base class. When you call a method, the correct version for that specific object is executed.

**Why we need it:** For **flexibility and extensibility**. You can write code that works with a base class type, and it will automatically work with any new derived classes you create in the future, without you having to change the original code.

**How it works in C#:** Using `virtual` methods in the base class and `override` methods in the derived classes.

**Simple Example: A Collection of Animals**

```csharp
// Base class with a VIRTUAL method
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a generic sound.");
    }
}

public class Dog : Animal
{
    // Dog OVERRIDES the method with its own implementation
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Animal
{
    // Cat also OVERRIDES the method
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

// --- How to use it ---
List<Animal> animals = new List<Animal>();
animals.Add(new Dog());
animals.Add(new Cat());
animals.Add(new Dog());

// Polymorphism in action!
// We can treat all animals as just 'Animal', but the correct
// MakeSound() method is called for each one at runtime.
foreach (Animal animal in animals)
{
    animal.MakeSound();
}

// Output:
// Woof!
// Meow!
// Woof!
```

---

### 4. Abstraction (Hiding the Complexity)

**What it is:** The principle of hiding complex implementation details and showing only the essential features of the object. It's about defining *what* an object can do, without specifying *how* it does it.

**Why we need it:** To **reduce complexity and create a clear contract**. When you use an abstract class or interface, you don't need to worry about the internal workings. You just need to know what methods are available for you to call.

**How it works in C#:** Using `abstract` classes or `interfaces`.
*   An **abstract class** is a partially built blueprint. It can have both abstract (unimplemented) methods and regular methods.
*   An **interface** is a pure contract. It only defines method/property signatures with no implementation.

**Simple Example: An `IVehicle` Interface**

```csharp
// An INTERFACE defines a contract. It says "any class that implements me
// MUST have these methods." It doesn't say HOW.
public interface IVehicle
{
    void StartEngine();
    void StopEngine();
}

// A Car class FULFILLS the contract
public class Car : IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Car engine turns over and starts.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Car engine shuts off.");
    }
}

// A Motorcycle class also FULFILLS the same contract
public class Motorcycle : IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Motorcycle engine roars to life.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Motorcycle engine sputters and stops.");
    }
}

// --- How to use it ---
// We don't care if it's a car or motorcycle, just that it's an IVehicle.
IVehicle myVehicle = new Car();
myVehicle.StartEngine(); // We know it can start, we don't care how.
```

---

### Summary Table

| Pillar | Core Idea | Key C# Tool | Main Benefit |
| :--- | :--- | :--- | :--- |
| **Encapsulation** | The protective shell | `private` fields, `public` properties/methods | **Safety & Control** |
| **Inheritance** | The "is-a" relationship | `:` (colon) syntax | **Code Reuse & Hierarchy** |
| **Polymorphism** | Many forms | `virtual` & `override` keywords | **Flexibility & Extensibility** |
| **Abstraction** | Hiding complexity | `abstract` classes, `interface` | **Simplicity & Clear Contracts** |