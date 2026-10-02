class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"{_name}\n{_description}\nHow long will it be (in seconds): ");

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Great job!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed another {_duration} of the {_name}.");
        ShowCountDown(3);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string>();
        animation.Add("/");
        animation.Add("|");
        animation.Add("\\");
        animation.Add("-");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animation[i];
            Console.Write(s);
            Thread.Sleep(300);
            Console.Write("\b \b");
            i++;

            if (i >= animation.Count)
            {
                i = 0;
            }
        }

    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
    }
}