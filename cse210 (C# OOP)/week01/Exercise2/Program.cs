using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Type your grade percentage:");
        string grade = Console.ReadLine();
        int intGrade = int.Parse(grade);
        string letter = "";

        if (intGrade >= 90)
        {
            letter = "A";
        }
        else if (intGrade >= 80)
        {
            letter = "B";

        }
        else if (intGrade >= 70)
        {
            letter = "C";
        }
        else if (intGrade >= 60)
        {
            letter = "D";
        }
        else if (intGrade < 60)
        {
            letter = "F";
        }
        else 
        {
            Console.WriteLine("An error has occured...");
        }

        Console.WriteLine($"Your grade is {letter}.");

        if (intGrade >= 70)
        {
            Console.WriteLine("Congratulations graduating on this course!");
        }
        else
        {
            Console.WriteLine("Sorry mate, try harder, better, faster, stronger next time.");
        }

    }
}