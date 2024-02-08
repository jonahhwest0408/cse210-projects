using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public int AmountCompleted => _amountCompleted;
    public int Target => _target;
 
    public ChecklistGoal(string name, string description, string points, int amountCompleted, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
         _amountCompleted++;

        if (_amountCompleted >= _target)
        {
            base._points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"Goal: {_shortName}\nDescription: {_description}\nPoints: {_points}\nCompleted: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}";
    }

    public void RecordCompletion()
    {
        _amountCompleted++;

        if (AmountCompleted >= Target)
        {
            //add bonus points//
        }
        
    }
}