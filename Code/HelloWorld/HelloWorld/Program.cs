using System;

namespace HelloWorld
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello World - from Message Object");

            Message[] messages = new Message[5];
            messages[0] = new Message("Welcome back!");
            messages[1] = new Message("What a lovely name");
            messages[2] = new Message("Great name");
            messages[3] = new Message("Oh hi!");
            messages[4] = new Message("That is a silly name");

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            // Convert the user's input to lowercase for case-insensitive comparison
            string lowerCaseName = name.ToLowerInvariant();

            if (lowerCaseName == "mark")
            {
                messages[0].Print();
            }
            else if (lowerCaseName == "fred")
            {
                messages[1].Print();
            }
            else if (lowerCaseName == "wilma")
            {
                messages[2].Print();
            }
            else if (lowerCaseName == "alice")
            {
                messages[3].Print();
            }
            else
            {
                messages[4].Print();
            }

            Console.ReadLine();
        }
    }
}