class BikeActivity : Activity
{

    public BikeActivity(int minutes, double distance) : base(minutes, distance)
    {

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
        Console.WriteLine($"{date.ToString("d")} Cycling ({_minutes} min): Distance:{GetDistance()}Km, Speed:{GetSpeed()}Kph, Pace:{GetPace()}min per Km");
    }

}