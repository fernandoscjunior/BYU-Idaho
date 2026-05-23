class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Congratulations you earned {_points}!");
        int pointInt = int.Parse(_points);
        return pointInt;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"Eternalgoal:{_shortName}:({_description}):{_points}";
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}, ({_description})";
    }
}