### What is a Field?

A **field** is a variable that is declared directly in a class or struct. It's used to store data that belongs to an object (instance) of that class or to the class itself.

Think of it as the object's **internal state or memory**. For example, a `Person` object would have fields like `name`, `age`, and `height` to remember its specific data.

---

### How We Use Fields

1. **Declaration:** You declare a field inside the class body by specifying an access modifier, a type, and a name.
    
    ```csharp
    public class BankAccount
    {
        // These are field declarations
        private string _accountHolder;
        private decimal _balance;
    }
    
    ```
    
2. **Assignment:** You can assign values to fields:
    - At the point of declaration.
    - Inside a constructor.
    - Inside any method of the same class.
3. **Access:** Fields are accessed using the dot (`.`) operator on an object instance.
    
    ```csharp
    BankAccount myAccount = new BankAccount();
    myAccount._balance = 100.00m; // This would only work if _balance is public, which it usually isn't!
    
    ```
    

---

### Access Modifiers for Fields

---

**Purpose:** Control the visibility and accessibility of types and their members.

| Modifier | Accessibility | Usage Description |
| --- | --- | --- |
| `public` | Any code | The type or member is accessible by any other code in the same assembly or another assembly that references it. |
| `private` | Containing class only | The member is accessible only within the body of the class or struct in which it is declared. |
| `protected` | Containing class **or** derived classes | The member is accessible within its class and by derived class instances. |
| `internal` | Current assembly only, **this is a default modifier for the class** | The type or member is accessible only within its own assembly (e.g., a `.dll` or `.exe` project). |
| `protected internal` | Current assembly **OR** derived classes (even in other assemblies) | The member is accessible from the current assembly *or* from types derived from the containing class. It's a union of `protected` and `internal`. |
| `private protected` | Containing class **and** derived classes within the current assembly | The member is accessible only within its containing class *and* by derived classes that are declared in the same assembly. It's an intersection of `private` and `protected`. |

### Key Field Modifiers: `static`, `const`, `readonly`

These modifiers change the *behavior* of a field.

| Modifier | Purpose | When is the Value Set? | Belongs To... | Example |
| --- | --- | --- | --- | --- |
| `static` | The field is shared across **all instances** of the class. There is only one copy. | At declaration or in a static constructor. | The **class** itself. | `public static int TotalAccounts;` |
| `const` | The field is a **compile-time constant**. Its value can never change. | **At declaration only.** Must be initialized. | The **class** (accessed via `ClassName.ConstName`). | `public const double Pi = 3.14159;` |
| `readonly` | The field can be set **only at declaration or in a constructor**. After that, it's read-only. | At declaration or in any **instance/static constructor**. | An **instance** of the class (unless also `static`). | `public readonly string CreationDate;` |

**Key Distinction: `const` vs. `readonly`**

- Use `const` for values that are truly constant and will never, ever change (like mathematical constants).
- Use `readonly` for values that shouldn't change after the object is constructed, but might need to be calculated or passed in at runtime (like a database ID or creation timestamp).

---