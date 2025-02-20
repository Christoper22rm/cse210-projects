using System;
using System.Collections.Generic;

// Clase base Activity
abstract class Activity
{
    private DateTime date;
    private int duration;

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public DateTime Date => date;
    public int Duration => duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Duration} min): Distancia {GetDistance():0.0} km, Velocidad: {GetSpeed():0.0} km/h, Ritmo: {GetPace():0.0} min por km";
    }
}

// Subclase para Carrera
class Running : Activity
{
    private double distance;
    
    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / Duration) * 60;
    public override double GetPace() => Duration / distance;
}

// Subclase para Ciclismo
class Cycling : Activity
{
    private double speed;
    
    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * Duration) / 60;
    public override double GetSpeed() => speed;
    public override double GetPace() => 60 / speed;
}

// Subclase para Natación
class Swimming : Activity
{
    private int laps;
    
    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50) / 1000.0;
    public override double GetSpeed() => (GetDistance() / Duration) * 60;
    public override double GetPace() => Duration / GetDistance();
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 4), 40, 20.0),
            new Swimming(new DateTime(2022, 11, 5), 25, 20)
        };
        
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
