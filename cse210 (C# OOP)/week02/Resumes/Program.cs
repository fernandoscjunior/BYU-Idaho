using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._companyName = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2021;
        job1._endYear = 2023;
        //job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._companyName = "Apple";
        job2._jobTitle = "CEO";
        job2._startYear = 1997;
        job2._endYear = 2011;
        //job2.DisplayJobDetails();

        Resume resume1 = new Resume();
        resume1._name = "Test Ryan";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
         

        resume1.DisplayResume();
    }
}