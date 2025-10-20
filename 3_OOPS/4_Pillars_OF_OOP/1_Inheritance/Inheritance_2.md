### 1. Method Hiding (with the `new` keyword)

### What is it?

Method hiding is when a derived class declares a method with the **same name and signature** as a method in its base class. It effectively "covers up" or "hides" the parent's method.

The key takeaway is that **hiding is not polymorphic**. The method that gets called is determined by the **reference type**, not the actual object's type.

### How it Works: The `new` Keyword

To hide a method, you use the `new` keyword. If you don't, the compiler will give you a warning, because it's often done by accident and can lead to confusing behavior.

**Example:**

```csharp
// Base Class
public class Animal
{
    public void Eat()
    {
        Console.WriteLine("The animal is eating food.");
    }
}

// Derived Class
public class Dog : Animal
{
    // We are HIDING the parent's Eat() method with our own version.
    public new void Eat()
    {
        Console.WriteLine("The dog is enthusiastically eating kibble.");
    }
}

// --- How it behaves ---
Dog myDog = new Dog();
Animal myAnimal = myDog; // The 'Animal' reference points to the 'Dog' object

Console.WriteLine("Calling from a Dog reference:");
myDog.Eat();
// Output: The dog is enthusiastically eating kibble.
// The compiler sees 'Dog' and calls the Dog's version.

Console.WriteLine("\\nCalling from an Animal reference:");
myAnimal.Eat();
// Output: The animal is eating food.
// The compiler sees 'Animal' and calls the Animal's version,
// even though the object is actually a Dog!

```

### How Can It Be Helpful?

Method hiding is generally less common and often discouraged in favor of overriding, but it has one primary, critical use case: **Versioning**.

Imagine you create a `Dog` class that inherits from a third-party `Animal` library. Your `Dog` class has its own `Eat()` method. A year later, the library creators update the `Animal` class and *also* add an `Eat()` method. Without the `new` keyword, your code would now break! By explicitly marking your method as `new`, you are telling the compiler, "I know this method exists in the parent class, and I intend to provide my own version here."

---

### 2. Method Overriding (with `virtual` and `override`)

### What is it?

Method overriding is the cornerstone of polymorphism. It allows a derived class to provide a **specific implementation** for a method that is already defined in its base class.

The key takeaway is that **overriding is polymorphic**. The method that gets called is determined by the **actual object's type** at runtime, not the reference type.

### How it Works: `virtual` and `override`

To enable overriding, the base class must mark its method as `virtual`. The derived class then uses the `override` keyword to provide the new implementation.

**Example:**

```csharp
// Base Class
public class Animal
{
    // Mark the method as 'virtual' to allow children to override it.
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a generic sound.");
    }
}

// Derived Class
public class Dog : Animal
{
    // We are OVERRIDING the parent's MakeSound() method.
    public override void MakeSound()
    {
        Console.WriteLine("The dog barks: Woof!");
    }
}

// --- How it behaves ---
Dog myDog = new Dog();
Animal myAnimal = myDog; // The 'Animal' reference points to the 'Dog' object

Console.WriteLine("Calling from a Dog reference:");
myDog.MakeSound();
// Output: The dog barks: Woof!

Console.WriteLine("\\nCalling from an Animal reference:");
myAnimal.MakeSound();
// Output: The dog barks: Woof!
// The runtime checks the ACTUAL object's type (it's a Dog)
// and calls the Dog's overridden version. This is polymorphism!

```

---

### 3. The Key Differences (Hiding vs. Overriding)

This table is the most important part for understanding the distinction.

| Feature | Method Hiding (`new`) | Method Overriding (`override`) |
| --- | --- | --- |
| **Purpose** | To redefine a method. | To replace a method's implementation. |
| **Base Class Method** | Does not need any special keyword. | **Must** be marked as `virtual`, `abstract`, or `override`. |
| **Derived Class Method** | **Must** be marked as `new`. | **Must** be marked as `override`. |
| **Polymorphism** | **Does NOT support polymorphism.** | **Enables polymorphism.** |
| **Which method is called?** | Determined by the **reference type** at compile-time. | Determined by the **object's type** at runtime. |
| **Common Use Case** | Versioning, intentional non-polymorphic behavior. | Standard object-oriented design and polymorphism. |
| when to use, which? | Use method Hiding when you want to rewrite the hole method implementation  | Use method Overriding, when you need to add newer functionality's  |

---

### 4. Sealing: Stopping the Inheritance Chain

Sometimes, you want to prevent further inheritance or overriding.

### Sealed Class

A `sealed` class is a class that **cannot be inherited from**. It's the end of the inheritance line.

**Why use it?**

- **Security:** To prevent others from modifying your class's behavior (e.g., the `String` class is sealed).
- **Design:** To enforce a specific design where your class is a complete, final implementation.

**Syntax:**

```csharp
public sealed class FinalReport
{
    public void Generate() { /* ... */ }
}

// This would cause a compile error:
// public class MySpecialReport : FinalReport { }

```

### Sealed Method

A `sealed` method is a method that **cannot be overridden further** by derived classes. You can only seal a method that is itself an `override` method.

**Why use it?**
Imagine a class hierarchy where `Animal` has a virtual `MakeSound()`. `Mammal` overrides it. You might decide that for all mammals, the sound-making mechanism is now final and no specific mammal (like `Dog` or `Cat`) should be able to change it again. You would seal the `Mammal`'s implementation.

**Syntax:**

```csharp
public class Animal
{
    public virtual void MakeSound() { Console.WriteLine("..."); }
}

public class Mammal : Animal
{
    // We override it, but then SEAL it to stop further overrides.
    public sealed override void MakeSound()
    {
        Console.WriteLine("A generic mammal sound.");
    }
}

public class Dog : Mammal
{
    // This would cause a compile error because MakeSound is sealed in Mammal.
    // public override void MakeSound() { }
}

```