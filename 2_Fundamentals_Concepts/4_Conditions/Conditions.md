### **C# Conditional Statements: Detailed Explanation**

## **1. if Statement - The Fundamental Decision Maker**

### **What is the if Statement?**
**Definition:** The `if` statement is the most basic conditional statement that executes a block of code **only if** a specified condition evaluates to `true`.

**Core Concept:** It allows your program to make decisions and execute different code paths based on conditions.

### **Syntax Breakdown:**
```csharp
if (condition)
{
    // Code to execute if condition is TRUE
    statement1;
    statement2;
    // ... more statements
}
```

### **How it Works:**
1. **Condition Evaluation:** The expression inside parentheses is evaluated
2. **Boolean Result:** The condition must return `true` or `false`
3. **Execution Decision:** If `true`, the code block executes; if `false`, it's skipped
4. **Flow Continues:** Program continues with code after the if block

### **Detailed Examples:**

#### **Basic Condition Checking:**
```csharp
int age = 20;

// Simple condition
if (age >= 18)
{
    Console.WriteLine("You are eligible to vote.");
    Console.WriteLine("Please register if you haven't already.");
}

// The program continues here regardless of the condition
Console.WriteLine("Program execution continues...");
```

**Output:**
```
You are eligible to vote.
Please register if you haven't already.
Program execution continues...
```

#### **Multiple Conditions with Logical Operators:**
```csharp
bool hasDriverLicense = true;
int age = 17;
bool hasParentalConsent = true;

// Complex condition using logical operators
if (age >= 16 && hasDriverLicense)
{
    Console.WriteLine("You can drive legally.");
}

// Multiple conditions with OR
if (age >= 18 || (age >= 16 && hasParentalConsent))
{
    Console.WriteLine("You can participate in the program.");
}

// Nested conditions
if (age >= 13)
{
    if (hasParentalConsent)
    {
        Console.WriteLine("You can create a social media account.");
    }
}
```


### **Common Patterns and Best Practices:**

#### **Early Return Pattern:**
```csharp
public string GetUserStatus(User user)
{
    // Guard clauses - return early if conditions aren't met
    if (user == null)
        return "User not found";
    
    if (!user.IsVerified)
        return "User not verified";
    
    if (user.IsSuspended)
        return "Account suspended";
    
    // Main logic for valid users
    return "Active user";
}
```

#### **Conditional Method Execution:**
```csharp
public void ProcessOrder(Order order)
{
    if (order == null)
    {
        throw new ArgumentNullException(nameof(order));
    }
    
    if (order.Items.Count == 0)
    {
        Console.WriteLine("Order has no items. Skipping processing.");
        return;
    }
    
    if (order.TotalAmount > 1000)
    {
        ApplyDiscount(order); // Only apply discount for large orders
    }
    
    // Continue with normal order processing
    ProcessPayment(order);
    UpdateInventory(order);
}
```

---

## **2. if-else Statement - Two Path Decision Making**

### **What is the if-else Statement?**
**Definition:** The `if-else` statement provides **two alternative execution paths** - one executes if the condition is `true`, the other executes if it's `false`.

**Core Concept:** It ensures that **exactly one** of the two code blocks will always execute.

### **Syntax Breakdown:**
```csharp
if (condition)
{
    // Executes when condition is TRUE
    trueBlock;
}
else
{
    // Executes when condition is FALSE  
    falseBlock;
}
```

### **How it Works:**
1. **Condition Evaluation:** The if condition is evaluated
2. **Branch Selection:** 
   - If `true` → execute the `if` block, skip the `else` block
   - If `false` → skip the `if` block, execute the `else` block
3. **Mutually Exclusive:** Only one block executes, never both

### **Detailed Examples:**

#### **Basic if-else Pattern:**
```csharp
int number = 15;

if (number % 2 == 0)
{
    Console.WriteLine($"{number} is an EVEN number.");
    Console.WriteLine("It can be divided by 2 without remainder.");
}
else
{
    Console.WriteLine($"{number} is an ODD number.");
    Console.WriteLine("It leaves remainder when divided by 2.");
}

Console.WriteLine("This always executes after if-else.");
```

**Output:**
```
15 is an ODD number.
It leaves remainder when divided by 2.
This always executes after if-else.
```



#### **User Input Validation:**
```csharp
public void ProcessUserInput(string input)
{
    if (!string.IsNullOrWhiteSpace(input))
    {
        // Valid input path
        Console.WriteLine($"Processing input: '{input.Trim()}'");
        string processed = input.Trim().ToUpper();
        Console.WriteLine($"Processed result: {processed}");
        SaveToDatabase(processed);
    }
    else
    {
        // Invalid input path
        Console.WriteLine("ERROR: Input cannot be empty or whitespace.");
        Console.WriteLine("Please provide valid input.");
        ShowInputInstructions();
        RequestNewInput();
    }
}
```

### **Advanced if-else Patterns:**

#### **Ternary Operator Alternative:**
```csharp
// Traditional if-else
int score = 85;
string result;

if (score >= 60)
{
    result = "Pass";
}
else
{
    result = "Fail";
}

// Equivalent ternary operator
string ternaryResult = score >= 60 ? "Pass" : "Fail";
```

#### **Conditional Variable Assignment:**
```csharp
public decimal CalculateShippingCost(decimal orderAmount, bool isExpress)
{
    decimal baseShipping;
    
    if (orderAmount > 100)
    {
        baseShipping = 0.00m; // Free shipping for orders over $100
    }
    else
    {
        baseShipping = 5.99m; // Standard shipping
    }
    
    // Apply express shipping premium
    if (isExpress)
    {
        baseShipping += 10.00m;
    }
    
    return baseShipping;
}
```

---

## **3. if-else if-else Ladder - Multiple Condition Handling**

### **What is the if-else if Ladder?**
**Definition:** A sequence of `if-else if` statements that tests **multiple conditions in order** until one evaluates to `true`, with an optional final `else` for when all conditions are `false`.

**Core Concept:** It allows you to handle **multiple exclusive scenarios** in a clean, organized way.

### **Syntax Breakdown:**
```csharp
if (condition1)
{
    // Executes if condition1 is TRUE
}
else if (condition2)
{
    // Executes if condition1 is FALSE and condition2 is TRUE
}
else if (condition3)
{
    // Executes if previous are FALSE and condition3 is TRUE
}
else
{
    // Executes if ALL previous conditions are FALSE
}
```

### **How it Works:**
1. **Sequential Evaluation:** Conditions are checked from top to bottom
2. **First Match Wins:** The first `true` condition executes its block and **skips all others**
3. **Mutually Exclusive:** Only one block in the entire ladder executes
4. **Optional Else:** The final `else` acts as a default/catch-all




### **Important Considerations:**

#### **Order Matters:**
```csharp
// ❌ WRONG ORDER - This will never reach the second condition
int score = 75;

if (score >= 60)
{
    Console.WriteLine("Pass"); // This always executes for scores >= 60
}
else if (score >= 70) // This condition will NEVER be true
{
    Console.WriteLine("Good pass");
}

// ✅ CORRECT ORDER - Specific to general
if (score >= 90)
{
    Console.WriteLine("Excellent");
}
else if (score >= 80) // Only checked if score < 90
{
    Console.WriteLine("Very good");
}
else if (score >= 70) // Only checked if score < 80
{
    Console.WriteLine("Good");
}
else if (score >= 60) // Only checked if score < 70
{
    Console.WriteLine("Pass");
}
else
{
    Console.WriteLine("Fail");
}
```

#### **Using Braces for Clarity:**
```csharp
// ❌ Without braces (error-prone)
if (condition1)
    DoSomething();
else if (condition2)
    DoSomethingElse();
else
    DoDefault();

// ✅ With braces (recommended)
if (condition1)
{
    DoSomething();
}
else if (condition2)
{
    DoSomethingElse();
}
else
{
    DoDefault();
}
```

---

## **4. switch-case Statement - Multi-Way Branching**

### **What is the switch Statement?**
**Definition:** The `switch` statement selects one of many code blocks to execute based on the value of an expression. It's ideal when you have **one variable** that can have **multiple specific values**.

**Core Concept:** A cleaner, more readable alternative to long `if-else if` chains when comparing the same variable against constant values.

### **Syntax Breakdown:**
```csharp
switch (expression)
{
    case value1:
        // Code for value1
        break;
    case value2:
        // Code for value2  
        break;
    case value3:
        // Code for value3
        break;
    default:
        // Code if no cases match
        break;
}
```

### **How it Works:**
1. **Expression Evaluation:** The switch expression is evaluated once
2. **Case Matching:** The result is compared with each `case` value
3. **Execution:** When a match is found, that code block executes
4. **Break Requirement:** Each case must end with `break` (or other jump statement)
5. **Default Case:** Optional catch-all when no cases match




#### **When Clauses (C# 7.0+):**
```csharp
public string EvaluateNumber(object value)
{
    switch (value)
    {
        case int i when i > 0:
            return $"Positive integer: {i}";
        case int i when i < 0:
            return $"Negative integer: {i}";
        case int i:
            return "Zero";
        case double d when d > 100.0:
            return $"Large double: {d}";
        case double d:
            return $"Double: {d}";
        case string s when s.Length > 10:
            return $"Long string: {s.Substring(0, 10)}...";
        case string s:
            return $"String: {s}";
        case null:
            return "Null value";
        default:
            return $"Unknown type: {value.GetType().Name}";
    }
}
```

#### **Switch Expressions (C# 8.0+):**
```csharp
// Traditional switch statement
string dayType;
switch (dayNumber)
{
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        dayType = "Weekday";
        break;
    case 6:
    case 7:
        dayType = "Weekend";
        break;
    default:
        dayType = "Invalid";
        break;
}

// Modern switch expression (more concise)
string dayType = dayNumber switch
{
    1 or 2 or 3 or 4 or 5 => "Weekday",
    6 or 7 => "Weekend",
    _ => "Invalid"  // Default case
};

