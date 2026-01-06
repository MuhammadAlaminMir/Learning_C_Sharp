### **C# Objects: Comprehensive Theoretical Guide**

## **1. Introduction to Objects**

### **What is an Object?**

**Definition:** An object is an instance of a class that exists in memory during program execution. It represents a specific entity with its own state (data) and behavior (operations).

### **The Real-World Analogy:**

- **Class** = Blueprint for a car
- **Object** = Actual physical car built from the blueprint
- **Multiple Objects** = Multiple cars, each with its own color, mileage, and condition

### **Technical Definition:**

An object is a self-contained unit that:

- Occupies memory space
- Has a specific state at any given time
- Can perform operations (behavior)
- Has a unique identity
- Interacts with other objects

---

## **2. Object Characteristics**

### **2.1 State (Data)**

**Definition:** The current values of all the object's attributes/properties at a specific point in time.

**Characteristics:**

- Represented by fields and properties
- Can change over time (mutable objects)
- Defines what the object "is" at any moment
- Unique to each object instance

**Example:**

```csharp
// Two Car objects with different states
Car car1 = new Car();  // State: Color=null, Speed=0, Fuel=0
car1.Color = "Red";    // State changed
car1.Speed = 60;       // State changed

Car car2 = new Car();  // State: Color=null, Speed=0, Fuel=0
car2.Color = "Blue";   // Different state from car1

```

### **2.2 Behavior (Operations)**

**Definition:** The actions that an object can perform, defined by its methods.

**Characteristics:**

- Represented by methods
- Can change the object's state
- Can interact with other objects
- Defines what the object "can do"

**Example:**

```csharp
public class BankAccount
{
    private decimal _balance;  // State

    // Behaviors
    public void Deposit(decimal amount)  // Changes state
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount) // Changes state
    {
        _balance -= amount;
    }

    public decimal GetBalance()          // Doesn't change state
    {
        return _balance;
    }
}

```

### **2.3 Identity**

**Definition:** The unique existence that distinguishes one object from another, even if they have identical state.

**How Identity Works:**

- **Reference Identity:** Two references pointing to the same memory location
- **Value Identity:** Two objects with identical data but different memory locations
- **Hash Codes:** Unique identifiers for objects

**Example:**

```csharp
Person person1 = new Person { Name = "John", Age = 25 };
Person person2 = new Person { Name = "John", Age = 25 };
Person person3 = person1;  // Same object, different reference

Console.WriteLine(person1 == person2);  // False - different objects
Console.WriteLine(person1 == person3);  // True - same object
Console.WriteLine(object.ReferenceEquals(person1, person2)); // False
Console.WriteLine(object.ReferenceEquals(person1, person3)); // True

```

---

## **3. Object Creation and Memory Management**

### **3.1 Object Instantiation Process**

**Step 1: Declaration**

```csharp
Car myCar;  // Reference variable created (null initially)

```

**Step 2: Instantiation (new keyword)**

```csharp
myCar = new Car();  // Object created in memory

```

**What happens during `new Car()`:**

1. **Memory Allocation:** CLR allocates memory on the heap
2. **Field Initialization:** All fields set to default values (0, null, false)
3. **Constructor Execution:** Appropriate constructor runs
4. **Reference Assignment:** Memory address assigned to variable

### **3.2 Memory Allocation**

**Stack vs Heap:**

- **Stack:** Value types, method parameters, reference variables
- **Heap:** Objects (reference types), large data

**Memory Diagram:**

```
STACK (Fast, Automatic)      HEAP (Managed by GC)
┌─────────────────┐        ┌─────────────────┐
│ myCar (reference)│ ──────→│ Car Object      │
│                 │        │ ├─────────────┤ │
│                 │        │ │ Color=null  │ │
│                 │        │ │ Speed=0     │ │
│                 │        │ │ Fuel=0      │ │
└─────────────────┘        └─────────────────┘

```

### **4. Object Relationships**

### **Association ("Uses" relationship)**

- Objects know about each other
- Can be one-way or bidirectional
- Represents collaboration

```csharp
public class Teacher
{
    public void Teach(Student student)  // Association
    {
        student.Learn();  // Teacher uses Student
    }
}

public class Student
{
    public void Learn() { }
}

```

### **Composition ("Has-a" strong relationship)**

- One object contains another
- Child cannot exist without parent
- Lifetime controlled by parent

```csharp
public class House
{
    private Room _livingRoom;  // Composition

    public House()
    {
        _livingRoom = new Room();  // Room created with House
    }
    // When House is destroyed, Room is destroyed too
}

```

### **Aggregation ("Has-a" weak relationship)**

- One object contains another
- Child can exist independently
- Lifetime not controlled by parent

```csharp
public class University
{
    private List<Professor> _professors;  // Aggregation

    public void AddProfessor(Professor prof)  // Professor exists independently
    {
        _professors.Add(prof);
    }
    // When University closes, Professors still exist
}

```

---

## **5. Object Lifetime and Garbage Collection**

### **5.1 Object Lifecycle Stages**

**1. Creation:** Object instantiated with `new` keyword
**2. Usage:** Object methods called, state modified
**3. Inaccessibility:** No references point to the object
**4. Finalization:** Destructor runs (if defined)
**5. Collection:** Memory reclaimed by garbage collector

### **5.2 Garbage Collection (GC) Process**

**How GC Works:**

1. **Mark Phase:** Identify all reachable objects
2. **Sweep Phase:** Identify unreachable objects
3. **Compact Phase:** Defragment memory (optional)
4. **Collection:** Reclaim memory from unreachable objects

**GC Generations:**

- **Generation 0:** Newly created objects (short-lived)
- **Generation 1:** Objects that survived one GC cycle
- **Generation 2:** Long-lived objects

```csharp
// Object becomes eligible for GC when no references exist
public void CreateAndDestroy()
{
    Car myCar = new Car();  // Object created, reference exists

    // Use the object...
    myCar.Drive();

} // myCar goes out of scope, no references → eligible for GC

```

---

