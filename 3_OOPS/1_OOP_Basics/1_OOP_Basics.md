# Introduction to Object-Oriented Programming (OOP)

Object-Oriented Programming (OOP) is a programming paradigm that organizes software design around "objects" rather than actions and data rather than logic. It's a way to structure programs so that properties and behaviors are bundled into individual objects.

## Core Concept

OOP models real-world entities as software objects that have:

- **State (Attributes/Properties)**: Data that describes the object
- **Behavior (Methods/Operations)**: Actions the object can perform

**Example**: A car object might have properties like color, model, and speed, and methods like start(), accelerate(), and brake().

## Four Fundamental Principles

1. **Encapsulation**

   - Bundling data and methods that operate on that data within a single unit (class)
   - Hiding internal state and requiring interaction through methods
   - Like a capsule: protects the contents inside

2. **Abstraction**

   - Hiding complex implementation details and showing only essential features
   - Focusing on what an object does rather than how it does it
   - Like a TV remote: you use buttons without knowing the internal electronics

3. **Inheritance**

   - Creating new classes based on existing ones
   - Child classes inherit properties and methods from parent classes
   - Promotes code reuse and establishes hierarchical relationships
   - Like a family tree: children inherit traits from parents

4. **Polymorphism**
   - "Many forms" - allowing objects of different types to be treated as objects of a common type
   - Same method can behave differently based on the object
   - Like a button that works differently for different applications

## Key Terminology

- **Class**: Blueprint or template for creating objects
- **Object**: Instance of a class with actual values
- **Method**: Function or behavior that belongs to a class
- **Property**: Attribute or data member of a class
- **Constructor**: Special method that initializes an object

## Why Use OOP?

- **Modularity**: Code is organized into self-contained objects
- **Reusability**: Objects can be reused in different programs
- **Scalability**: Easier to add new features without changing existing code
- **Maintainability**: Changes to one object don't affect others
- **Real-world modeling**: Maps closely to how we think about the world

## Simple Example

```csharp
// Class (blueprint)
public class Dog
{
    // Properties (state)
    public string Name { get; set; }
    public string Breed { get; set; }

    // Constructor
    public Dog(string name, string breed)
    {
        Name = name;
        Breed = breed;
    }

    // Method (behavior)
    public void Bark()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

// Object (instance)
Dog myDog = new Dog("Buddy", "Golden Retriever");
myDog.Bark(); // Output: Buddy says: Woof!
```

OOP provides a structured approach to programming that makes code more organized, intuitive, and maintainable, especially for complex applications.
