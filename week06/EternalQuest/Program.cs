using System;

abstract class Goal
{
    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordProgress();
    public abstract string DisplayProgress();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }
    
    public override int RecordProgress()
    {
        IsCompleted = true;
        return Points;
    }

    public override string DisplayProgress()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}

class EternalGoal : Goal
{
    private int timesCompleted;
    
    public EternalGoal(string name, int points) : base(name, points)
    {
        timesCompleted = 0;
    }
    
    public override int RecordProgress()
    {
        timesCompleted++;
        return Points;
    }

    public override string DisplayProgress()
    {
        return "[∞] " + Name + " (Completed " + timesCompleted + " times)";
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;
    
    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        targetCount = target;
        this.bonus = bonus;
        currentCount = 0;
    }
    
    public override int RecordProgress()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
            {
                IsCompleted = true;
                return Points + bonus;
            }
            return Points;
        }
        return 0;
    }

    public override string DisplayProgress()
    {
        return (IsCompleted ? "[X] " : "[ ] ") + Name + " (Completed " + currentCount + "/" + targetCount + ")";
    }
}

class EternalQuest
{
    private List<Goal> goals;
    private int score;
    
    public EternalQuest()
    {
        goals = new List<Goal>();
        score = 0;
    }
    
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }
    
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            score += goals[index].RecordProgress();
            Console.WriteLine("Progress recorded: " + goals[index].Name);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
    
    public void DisplayGoals()
    {
        Console.WriteLine("Your goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine(i + ". " + goals[i].DisplayProgress());
        }
        Console.WriteLine("Current score: " + score);
    }
}

class Program
{
    static void Main()
    {
        EternalQuest quest = new EternalQuest();
        quest.AddGoal(new SimpleGoal("Run a marathon", 1000));
        quest.AddGoal(new EternalGoal("Read the Scriptures", 100));
        quest.AddGoal(new ChecklistGoal("Attend the temple", 50, 10, 500));

        while (true)
        {
            Console.WriteLine("1. Show goals");
            Console.WriteLine("2. Record progress");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                quest.DisplayGoals();
            }
            else if (option == 2)
            {
                Console.Write("Enter the goal number: ");
                int goalIndex = int.Parse(Console.ReadLine());
                quest.RecordEvent(goalIndex);
            }
            else if (option == 3)
            {
                break;
            }
        }
    }
}

