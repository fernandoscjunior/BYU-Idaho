public class Resume
{
    public Resume()
    {
    }
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");
        foreach (Job job in _jobs)
        {
            Console.WriteLine($"{job._jobTitle} ({job._companyName}) {job._startYear}-{job._endYear}");
        }
    }
}