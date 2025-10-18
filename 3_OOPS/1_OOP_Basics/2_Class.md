### **C# Classes: Comprehensive Theoretical Guide**

## **1. Introduction to Classes**

### **What is a Class?**

**Definition:** A class is a blueprint or template that defines the structure and behavior of objects. It's a fundamental building block in Object-Oriented Programming that encapsulates data and methods into a single unit.

### **The Blueprint Analogy:**

- **Class** = Architectural blueprint for a house
- **Object** = Actual house built from the blueprint
- **Multiple objects** can be created from one class, just like multiple houses can be built from one blueprint

### **Historical Context:**

Classes were introduced in Simula (1960s) as a way to simulate real-world entities. The concept was refined in Smalltalk and became mainstream with C++ and Java. In C#, classes are reference types that form the foundation of the .NET type system.

---

## **2. Class Components and Structure**

### **2.1 Class Declaration Syntax**

```csharp
[access_modifier] class ClassName
{
    // Fields (data)
    // Properties
    // Constructors
    // Methods
    // Events
    // Nested types
}

```

### **2.2 Access Modifiers**

## A class has only two access modifiers which is: public and internal, internal is the default access modifiers for class.

## Access modifiers for the class members: 

**Purpose:** Control the visibility and accessibility of class members

| Modifier | Accessibility | Usage |
| --- | --- | --- |
| `public` | Any code | Full access from anywhere |
| `private` | Same class only | Internal implementation |
| `protected` | Same class and derived classes | Inheritance hierarchy |
| `internal` | Same assembly | Library/internal code |
| `protected internal` | Same assembly OR derived classes | Combined access |

### C# Access Modifiers

**Purpose:** Control the visibility and accessibility of types and their members.

| Modifier | Accessibility | Usage Description |
| --- | --- | --- |
| `public` | Any code | The type or member is accessible by any other code in the same assembly or another assembly that references it. |
| `private` | Containing class only | The member is accessible only within the body of the class or struct in which it is declared. |
| `protected` | Containing class **or** derived classes | The member is accessible within its class and by derived class instances. |
| `internal` | Current assembly only, **this is a default modifier for the class** | The type or member is accessible only within its own assembly (e.g., a `.dll` or `.exe` project). |
| `protected internal` | Current assembly **OR** derived classes (even in other assemblies) | The member is accessible from the current assembly *or* from types derived from the containing class. It's a union of `protected` and `internal`. |
| `private protected` | Containing class **and** derived classes within the current assembly | The member is accessible only within its containing class *and* by derived classes that are declared in the same assembly. It's an intersection of `private` and `protected`. |

---

### Other Important Non-Access Modifiers (Optional)

they came after the access modifiers.

Here are other common modifiers that control behavior (not access), which are often grouped with access modifiers:

| Modifier | Applies To | Purpose |
| --- | --- | --- |
| `static` | Classes, members, methods, etc. | Declares a member that belongs to the type itself rather than to a specific object. A static class cannot be instantiated. |
| `readonly` | Fields | Declares a field that can only be assigned a value at declaration or in a constructor. |
| `const` | Fields, locals | Declares a constant value that is set at compile-time and cannot be changed. |
| `abstract` | Classes, methods, properties | Indicates that a class is intended only to be a base class, or that a member must be implemented by a derived class. |
| `sealed` | Classes, methods | Prevents other classes from inheriting from a class, or a method from being overridden further. |
| `virtual` | Methods, properties, etc. | Allows a member to be overridden in a derived class. |
| `override` | Methods, properties, etc. | Provides a new implementation of a member that is inherited from a base class. |
| `async` | Methods | Indicates that a method is asynchronous and can contain `await` expressions. |
| `volatile` | Fields | Indicates that a field might be modified by multiple threads. |

### **2.3 Class Members Overview**

### **Fields (Data Storage)**

- Store the state/data of objects
- Usually declared as private for encapsulation
- Represent "what an object has"

### **Properties (Controlled Access)**

- Provide controlled access to fields
- Can include validation logic
- Can be read-only, write-only, or read-write

### **Methods (Behavior)**

- Define what an object can do
- Represent the behavior/operations
- Can be instance methods or static methods

### **Constructors (Initialization)**

- Special methods that initialize new objects
- Called automatically when object is created
- Can be overloaded for different initialization scenarios

### **Events (Notification)**

- Enable classes to send notifications
- Follow publisher-subscriber pattern
- Used for loose coupling

---

---

## **3. Class Relationships**

### **3.1 Association - "Uses" Relationship**

- Objects know about each other
- Can be one-way or two-way
- Represents collaboration between objects

### **3.2 Composition - "Has-a" Relationship (Strong)**

- One object contains another
- Child cannot exist without parent
- Lifetime controlled by parent

### **3.3 Aggregation - "Has-a" Relationship (Weak)**

- One object contains another
- Child can exist independently
- Lifetime not controlled by parent

```csharp
// Composition example
public class Car
{
    private Engine _engine;  // Composition - car "has-an" engine

    public Car()
    {
        _engine = new Engine();  // Engine created with car
    }
}

// Aggregation example
public class University
{
    private List<Professor> _professors;  // Aggregation - university "has" professors

    public void AddProfessor(Professor prof)  // Professor exists independently
    {
        _professors.Add(prof);
    }
}

```

---

## **4. Class Lifecycle**

### **4.1 Object Creation**

1. **Memory Allocation:** CLR allocates memory for the object
2. **Field Initialization:** Fields are set to default values
3. **Constructor Execution:** Appropriate constructor runs
4. **Object Ready:** Object reference returned

### **4.2 Object Usage**

- Methods can be called
- Properties can be accessed
- Object state can change
- Can participate in relationships with other objects

### **4.3 Object Destruction**

1. **Eligibility:** Object no longer referenced
2. **Finalization:** Destructor runs (if defined)
3. **Memory Reclamation:** Garbage collector frees memory

---

## **5. Best Practices for Class Design**

### **5.1 Naming Conventions**

- Use PascalCase for class names (`CustomerAccount`)
- Use nouns or noun phrases (`FileProcessor`, `UserManager`)
- Be specific and descriptive
- Avoid abbreviations when possible

### **5.2 Member Organization**

```csharp
public class WellOrganizedClass
{
    // 1. Constants
    private const int DefaultSize = 100;

    // 2. Fields
    private string _name;
    private int _count;

    // 3. Constructors
    public WellOrganizedClass() { }
    public WellOrganizedClass(string name) { }

    // 4. Properties
    public string Name { get; set; }
    public int Count => _count;

    // 5. Methods
    public void Process() { }
    public void Calculate() { }

    // 6. Events
    public event EventHandler ProcessCompleted;
}

```

### **5.3 Size and Complexity**

- **Keep classes focused:** Single responsibility
- **Reasonable size:** Typically 100-300 lines
- **Clear purpose:** Easy to describe what the class does
- **Good abstraction:** Hide complexity, expose simplicity