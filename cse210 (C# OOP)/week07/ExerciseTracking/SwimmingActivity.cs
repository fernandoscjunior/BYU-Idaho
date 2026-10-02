class SwimmingActivity : Activity
{
    private int _swimmingLaps;
    public SwimmingActivity(int minutes, double distance, int laps) : base(minutes, distance)
    {
        _swimmingLaps = laps;
    }

    public override double GetDistance()
    {
        return _swimmingLaps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return _distance / _minutes * 60;
    }

    public override double GetPace()
    {
        return _minutes / _distance;
    }

    public override void GetSummary()
    {
        Console.WriteLine($"{date.ToString("d")} Swimming ({_minutes} min): Laps:{_swimmingLaps}, Distance:{GetDistance()}Km, Speed:{GetSpeed()}Kph, Pace:{GetPace()}min per Km");
    }
}