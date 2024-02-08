using System;

public class EternalGoals : Goal
{
    public EternalGoals(string name, string description, string points) : base(name, description, points)
    {
        //constructor for EternalGoal, calling the base constructor//
    }

    public override void RecordEvent()
    {

    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}";
    }
}