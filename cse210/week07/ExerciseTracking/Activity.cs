class Activity
{
    protected int _minutes;
    protected double _distance;
    private double _pace;
    private double _speed;

    protected DateTime date = DateTime.Today;

    public Activity(int minutes, double distance)
    {
        _minutes = minutes;
        _distance = distance;
    }

    public virtual void GetSummary()
    {
    }

    public virtual double GetDistance()
    {
        return _distance;
    }

    public virtual double GetPace()
    {
        return _pace;
    }

    public virtual double GetSpeed()
    {
        return _speed;
    }
}