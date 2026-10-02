class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(string name, string description) : base(name, description)
    {

    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)]; 
    
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)]; 
    }

    public void DisplayPrompt()
    {
        Console.Clear();
        Console.WriteLine(GetRandomPrompt());
        ShowSpinner(8);
        
    }

    public void DisplayQuestions()
    {
        Console.Clear();
        Console.WriteLine(GetRandomQuestion());
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

        DisplayPrompt();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(secondsInt);

        //int i = 0;
        while (DateTime.Now < endTime)
        { 
            DisplayQuestions();
            ShowSpinner(6);
        }
        
        DisplayEndingMessage();
    
    }
}