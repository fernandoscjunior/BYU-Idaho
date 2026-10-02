class Program
{
    static void Main(string[] args)
    {
        RunningActivity runningActivity = new RunningActivity(10, 10);
        BikeActivity bikeActivity = new BikeActivity(5, 15);
        SwimmingActivity swimmingActivity = new SwimmingActivity(10, 10, 6);

        List<Activity> activities = new List<Activity>();
        activities.Add(runningActivity);
        activities.Add(bikeActivity);
        activities.Add(swimmingActivity);

        foreach (Activity activity in activities)
        {
            activity.GetSummary();
        }
        
    }
}