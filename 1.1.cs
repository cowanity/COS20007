using System;

class Program
{
    // Define a method that takes a parameter
    static void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    static void Main()
    {
        // Call the method with an argument (value for the parameter)
        Greet("Alice");  // Output: Hello, Alice!
        Greet("Bob");    // Output: Hello, Bob!
    }
}
