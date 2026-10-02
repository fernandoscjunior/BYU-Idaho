public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problem;

    public MathAssignment(string student, string topic, string textbook, string problem) : base(student, topic)
    {
        _textbookSection = textbook;
        _problem = problem;
    }

    public string GetHomeWork()
    {
        return $"{_textbookSection} - {_problem}";
    }
}