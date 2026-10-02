using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Jerry", "Scriptures");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment assignment1 = new MathAssignment("James", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment1.GetHomeWork());

        WritingAssignment assignment2 = new WritingAssignment("Mary", "European History", "The Union of the Iberian Peninsula");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInfo());
    }
}