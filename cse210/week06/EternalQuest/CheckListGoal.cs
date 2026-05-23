class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckListGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public void SetAmoutComplete(int amountComplete)
    {
        _amountCompleted = amountComplete;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted == _target - 1)
        {
            Console.WriteLine($"Congratulations you finished this goal and earned {_bonus}!");
            int pointInt = _bonus;
            _amountCompleted++;
            return pointInt;
        }
        else if (_amountCompleted >= _target)
        {
            Console.WriteLine("This goal was already completed.");
            Thread.Sleep(3000);
            return 0;
        }
        else
        {
            Console.WriteLine($"Congratulations you earned {_points}!");
            int pointInt = int.Parse(_points);
            _amountCompleted++;
            return pointInt;
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public override string GetDetailsString()
    {
        return $"{_shortName}, ({_description}) --- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"Checklistgoal:{_shortName}:{_description}:{_points}:{_bonus}:{_target}:{_amountCompleted}";
    }

}