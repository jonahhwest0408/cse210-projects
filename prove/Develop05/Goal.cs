using System;
using System.Runtime.InteropServices;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public string Name => _shortName;
    public string Description => _description;

    public string Points
    {
        get { return _points; }
    }

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent()
    {
        Console.WriteLine($"Event recorded for goal: {_shortName}");
    }

    public abstract bool IsComplete();


    public virtual string GetDetailsString()
    {
        return $"Goal: {_shortName}\nDescription: {_description}\nPoints: {_points}";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}";
    }
}