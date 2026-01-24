namespace _1_List;

class Program
{
    static void Main(string[] args)
    {
        // --- Initial Setup: Create a list and add items ---
        List<string> todoList = new List<string>();
        todoList.Add("Buy groceries");
        todoList.Add("Walk the dog");
        todoList.Add("Finish project");

        Console.WriteLine("--- Initial To-Do List ---");
        foreach (var task in todoList)
        {
            Console.WriteLine($"- {task}");
        }

        // --- Insert a high-priority item at the beginning ---
        todoList.Insert(0, "Pay bills");
        Console.WriteLine("\\n--- After Inserting 'Pay bills' at the beginning ---");
        foreach (var task in todoList)
        {
            Console.WriteLine($"- {task}");
        }

        // --- Remove a completed task ---
        todoList.Remove("Walk the dog");
        Console.WriteLine("\n--- After Removing 'Walk the dog' ---");
        foreach (var task in todoList)
        {
            Console.WriteLine($"- {task}");
        }

        // --- Find a specific task ---
        string? projectTask = todoList.Find(task => task.Contains("project"));
        Console.WriteLine($"\n--- Found Task: '{projectTask}' ---");

        // --- Sort the list alphabetically ---
        todoList.Sort();
        Console.WriteLine("\n--- To-Do List Sorted Alphabetically ---");
        foreach (var task in todoList)
        {
            Console.WriteLine($"- {task}");
        }

        // --- Access an item by index after sorting ---
        string firstTask = todoList[0];
        Console.WriteLine($"\n--- First task in sorted list: '{firstTask}' ---");
    }
}
