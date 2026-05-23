public class WritingAssignment : Assignment
{
    string _title;

    public WritingAssignment(string student, string topic, string title) : base(student, topic)
    {
        _title = title;
    }

    public string GetWritingInfo()
    {
        return $"{_title}";
    }
}