using System.Runtime.CompilerServices;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description) : base(name, description)
    {

    }
    public void SetCount(int seconds)
    {
        _count = seconds;
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
    }

    public List<string> GetListFromUser()
    {
        List<string> listUser = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_count);

        while (DateTime.Now < endTime)
        {
            string appender = Console.ReadLine();
            listUser.Append(appender);
        }

        return listUser;
    }
    public void Run()
    {
        DisplayStartingMessage();
        string seconds = Console.ReadLine();
        int secondsInt = int.Parse(seconds);
        SetCount(secondsInt);
        Console.WriteLine("Prepare...");
        ShowSpinner(5);
        Console.Clear();

        GetRandomPrompt();
        ShowCountDown(10);
        GetListFromUser();
        DisplayEndingMessage();
    }
}