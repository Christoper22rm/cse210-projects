using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;
    
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the activity: {Name}\n{Description}\n");
        Console.Write("Enter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nGet ready to start...");
        LoadingAnimation(3);
        Execute();
        
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"Activity: {Name}, Duration: {Duration} seconds.");
        LoadingAnimation(3);
    }
    
    protected abstract void Execute();

    protected void LoadingAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i} seconds...   ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class ReflectionActivity : Activity
{
    private List<string> questions = new List<string>
    {
        "Remember a moment when you achieved something important.",
        "Think of a time when you overcame an obstacle.",
        "Reflect on a moment when you helped someone and how it made you feel."
    };
    
    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "Think deeply about an experience where you succeeded or demonstrated strength.";
    }
    
    protected override void Execute()
    {
        Console.WriteLine("\nReflect on the following:");
        string question = questions[new Random().Next(questions.Count)];
        Console.WriteLine(question);
        LoadingAnimation(Duration);
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Reflection");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            
            string option = Console.ReadLine();
            if (option == "1")
            {
                Activity activity = new ReflectionActivity();
                activity.Start();
            }
            else if (option == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}

