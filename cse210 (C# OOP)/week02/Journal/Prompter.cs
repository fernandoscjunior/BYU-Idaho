using System.Collections.Generic;
class Prompter
{
    private List<string> questions;
    public Prompter()
    {
    questions = new List<string>
    {
        "What is one thing you're grateful for today, and why?",
        "Describe a challenge you faced recently and how you handled it.",
        "What is a goal you're currently working towards, and what steps are you taking?",
        "How did you take care of your mental or physical health today?",
        "Write about a moment that made you smile or feel joy this week.",
        "What is something you're avoiding, and what’s stopping you from addressing it?",
        "Describe a recent conversation that had a meaningful impact on you.",
        "How do you want to grow as a person over the next month?",
        "What’s one lesson you've learned from a recent mistake or failure?",
        "If today was a book chapter in your life, what would the title be and why?"
    };
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int indexPromp = random.Next(questions.Count);
        return questions[indexPromp];
    }
}