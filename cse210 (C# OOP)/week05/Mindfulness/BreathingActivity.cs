class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        string seconds = Console.ReadLine();
        int secondsInt = int.Parse(seconds);
        Console.WriteLine("Prepare...");

        ShowSpinner(5);
        Console.Clear();
        SetDuration(secondsInt);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(secondsInt);

        //int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in");
            ShowCountDown(5);
            Console.WriteLine("Breathe out");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
        
    }
}