### **C# Loops: Comprehensive Guide**

## **1. Introduction to Loops**

### **What are Loops?**

**Definition:** Loops are control structures that allow you to **execute a block of code repeatedly** based on a condition. They automate repetitive tasks and process collections of data efficiently.

**Why Loops are Essential:**

- **Automate repetition:** Perform same task multiple times
- **Process collections:** Work with arrays, lists, and other data structures
- **Implement algorithms:** Sorting, searching, mathematical computations
- **Handle user input:** Validate and process multiple inputs
- **Create dynamic behavior:** Games, simulations, real-time systems

### **Loop Components:**

```csharp
// Every loop has these core components:
// 1. INITIALIZATION: Setup starting point
// 2. CONDITION: When to continue/stop
// 3. ITERATION: How to move to next step
// 4. BODY: Code to execute each time
```

---

## **2. for Loop - Counter-Controlled Iteration**

### **What is a for Loop?**

**Definition:** A `for` loop executes a code block a **specific number of times** using a counter variable. It's ideal when you know exactly how many iterations you need.

### **Syntax Breakdown:**

```csharp
for (initialization; condition; iteration)
{
    // Loop body - code to execute each iteration
    statement1;
    statement2;
    // ...
}
```

### **Execution Flow:**

1. **Initialization:** Executes once at start (setup counter)
2. **Condition Check:** Before each iteration - if `true`, continue; if `false`, exit
3. **Body Execution:** Run all statements in loop body
4. **Iteration:** Update counter, then go back to condition check

### **Detailed Examples:**

#### **Basic Counting:**

```csharp
// Count from 1 to 5
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Iteration: {i}");
    Console.WriteLine($"Square: {i * i}");
}
```

**Output:**

```
Iteration: 1
Square: 1
Iteration: 2
Square: 4
Iteration: 3
Square: 9
Iteration: 4
Square: 16
Iteration: 5
Square: 25
```

#### **Multiplication Table Generator:**

```csharp
public void GenerateMultiplicationTable(int number, int upTo = 10)
{
    Console.WriteLine($"Multiplication Table for {number}:");
    Console.WriteLine(new string('-', 25));

    for (int i = 1; i <= upTo; i++)
    {
        int result = number * i;
        Console.WriteLine($"{number} × {i} = {result}");

        // Add visual separator every 5 rows
        if (i % 5 == 0)
        {
            Console.WriteLine(new string('-', 25));
        }
    }
}

// Usage
GenerateMultiplicationTable(7);
```

#### **Array Processing:**

```csharp
public void ProcessStudentGrades()
{
    string[] students = { "Alice", "Bob", "Charlie", "Diana", "Eve" };
    int[] grades = { 85, 92, 78, 96, 88 };

    int total = 0;
    int highest = int.MinValue;
    int lowest = int.MaxValue;

    Console.WriteLine("=== STUDENT GRADE REPORT ===");

    // Process each student using index
    for (int i = 0; i < students.Length; i++)
    {
        string student = students[i];
        int grade = grades[i];

        // Update statistics
        total += grade;
        if (grade > highest) highest = grade;
        if (grade < lowest) lowest = grade;

        // Display student info
        string status = grade >= 80 ? "PASS" : "FAIL";
        Console.WriteLine($"{student,-10} : {grade,3}% - {status}");
    }

    // Display summary
    double average = (double)total / students.Length;
    Console.WriteLine(new string('=', 30));
    Console.WriteLine($"Average: {average:F1}%");
    Console.WriteLine($"Highest: {highest}%");
    Console.WriteLine($"Lowest:  {lowest}%");
}
```

## **3. while Loop - Condition-Controlled Iteration**

### **What is a while Loop?**

**Definition:** A `while` loop repeatedly executes a code block **as long as a condition remains true**. It's ideal when you don't know how many iterations you'll need in advance.

### **Syntax Breakdown:**

```csharp
while (condition)
{
    // Loop body
    statement1;
    statement2;
    // ...
    // Must include code that can change the condition
}
```

### **Execution Flow:**

1. **Condition Check:** Before each iteration
2. **If True:** Execute loop body
3. **If False:** Exit loop immediately
4. **Repeat:** Go back to condition check

### **Detailed Examples:**

#### **User Input Validation:**

```csharp
public string GetValidatedInput()
{
    string userInput = "";

    Console.WriteLine("Please enter a non-empty string:");

    while (string.IsNullOrWhiteSpace(userInput))
    {
        Console.Write("Input: ");
        userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("❌ Error: Input cannot be empty. Please try again.");
            Console.WriteLine();
        }
    }

    Console.WriteLine($"✅ Valid input received: '{userInput.Trim()}'");
    return userInput.Trim();
}

// Usage
string name = GetValidatedInput();
```

## **4. do-while Loop - Execute at Least Once**

### **What is a do-while Loop?**

**Definition:** A `do-while` loop executes the code block **first**, then checks the condition. It guarantees the loop body runs **at least once**.

### **Syntax Breakdown:**

```csharp
do
{
    // Loop body - executes AT LEAST ONCE
    statement1;
    statement2;
    // ...
} while (condition);
```

### **Execution Flow:**

1. **Execute Body:** Run all statements in loop body
2. **Condition Check:** After execution
3. **If True:** Go back to step 1
4. **If False:** Exit loop

## **5. foreach Loop - Collection Iteration**

### **What is a foreach Loop?**

**Definition:** A `foreach` loop iterates through **each element in a collection** (arrays, lists, dictionaries, etc.). It automatically handles the iteration logic.

### **Syntax Breakdown:**

```csharp
foreach (type variable in collection)
{
    // Work with each element
    // variable represents current item
}
```

### **Execution Flow:**

1. **Get Enumerator:** Collection provides way to iterate
2. **Move Next:** Advance to next element
3. **Current Element:** Make current element available
4. **Execute Body:** Run code with current element
5. **Repeat:** Until no more elements

## **2. break Statement - Detailed Explanation**

**What break does:** Immediately exits the loop, no matter what.

### **Break in for loop:**

```csharp
// Stop when we find number 5
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
    if (i == 5)
    {
        Console.WriteLine("Found 5! Stopping.");
        break;
    }
}
```

**Output:**

```
1
2
3
4
5
Found 5! Stopping.
```

### **Break in while loop:**

```csharp
int number = 1;
while (true) // Infinite loop
{
    Console.WriteLine(number);
    number++;

    if (number > 5)
    {
        Console.WriteLine("Reached 5, breaking loop");
        break;
    }
}
```

### **Break in nested loops:**

```csharp
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 3; j++)
    {
        Console.WriteLine($"i={i}, j={j}");

        if (i == 2 && j == 2)
        {
            Console.WriteLine("Breaking inner loop");
            break; // Only breaks the inner loop
        }
    }
}
```

---

## **3. continue Statement - Detailed Explanation**

**What continue does:** Skips the rest of the current iteration and moves to the next one.

### **Continue in for loop:**

```csharp
// Print only numbers not divisible by 3
for (int i = 1; i <= 10; i++)
{
    if (i % 3 == 0)
        continue; // Skip multiples of 3

    Console.WriteLine(i);
}
```

**Output:** `1 2 4 5 7 8 10`

### **Continue in while loop:**

```csharp
int number = 0;
while (number < 10)
{
    number++;

    if (number % 2 == 0)
        continue; // Skip even numbers

    Console.WriteLine($"Processing odd: {number}");
}
```

### **Continue with user input:**

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.Write($"Enter number {i}: ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int num))
    {
        Console.WriteLine("Invalid input! Skipping...");
        continue;
    }

    Console.WriteLine($"You entered: {num}");
}
```

---

## **5. General Tips and Best Practices**

### **Tip 1: Choose the Right Loop**

```csharp
// ✅ Use for when you know the count
for (int i = 0; i < 10; i++) { }

// ✅ Use while when condition-based
while (userWantsToContinue) { }

// ✅ Use do-while when must run at least once
do { } while (!isValidInput);

// ✅ Use foreach for collections
foreach (var item in collection) { }
```

### **Tip 2: Avoid Infinite Loops**

```csharp
// ❌ Dangerous - might run forever
// while (true) { }

// ✅ Safer - has an exit condition
int counter = 0;
while (counter < 100)
{
    counter++;
    // Your code here
}
```

### **Tip 3: Use Meaningful Variable Names**

```csharp
// ❌ Unclear
for (int i = 0; i < n; i++)

// ✅ Clear
for (int studentIndex = 0; studentIndex < studentCount; studentIndex++)
```

### **Tip 4: Keep Loop Bodies Small**

```csharp
// ❌ Hard to read
for (int i = 0; i < 10; i++)
{
    // 50 lines of code here...
}

// ✅ Better - extract method
for (int i = 0; i < 10; i++)
{
    ProcessItem(i);
}
```

### **Tip 5: Be Careful with Modifying Collections**

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// ❌ This will cause error!
// foreach (int num in numbers)
// {
//     if (num == 3)
//         numbers.Remove(num); // Cannot modify during iteration
// }

// ✅ Better - use for loop backwards
for (int i = numbers.Count - 1; i >= 0; i--)
{
    if (numbers[i] == 3)
        numbers.RemoveAt(i);
}
```

### **Tip 6: Use break and continue Wisely**

```csharp
// ✅ Good use - early exit when found
foreach (var item in items)
{
    if (item.IsWhatWeNeed)
    {
        result = item;
        break; // No need to check rest
    }
}

// ✅ Good use - skip invalid items
foreach (var item in items)
{
    if (!item.IsValid)
        continue; // Skip to next item

    ProcessItem(item);
}
```

### **Tip 7: Practice Common Patterns**

```csharp
// Sum pattern
int sum = 0;
foreach (int num in numbers)
{
    sum += num;
}

// Search pattern
bool found = false;
foreach (var item in items)
{
    if (item.MatchesCondition)
    {
        found = true;
        break;
    }
}

// Count pattern
int count = 0;
foreach (var item in items)
{
    if (item.IsValid)
        count++;
}
```
