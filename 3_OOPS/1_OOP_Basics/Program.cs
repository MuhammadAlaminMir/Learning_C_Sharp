


// Object (instance)
Dog myDog = new Dog("Buddy", "Golden Retriever");
myDog.Bark(); // Output: Buddy says: Woof!


// Class (blueprint)
public class Dog
{
    // Properties (state)
    private string Name { get; set; }
    private string Breed { get; set; }

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