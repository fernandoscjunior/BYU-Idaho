class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
    }
    public void SetCompletion(bool status)
    {
        _isComplete = status;
    }
    public override int RecordEvent()
    {
        if (_isComplete == true)
        {
            Console.WriteLine("This goal was already completed.");
            Thread.Sleep(3000);
            return 0;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Congratulations you earned {_points}!");
            int pointInt = int.Parse(_points);
            _isComplete = true;
            
            return pointInt;
        }
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        return $"Simplegoal:{_shortName}:({_description}):{_points}:{_isComplete}";
    }
    public override string GetDetailsString()
    {
        return $"{_shortName}, {_description}";
    }
}