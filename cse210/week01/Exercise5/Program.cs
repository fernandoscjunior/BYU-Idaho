using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        double squaredNumber = SquareNumber(number);
        DisplayResult(name, squaredNumber);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program.");

    }

    static string PromptUserName()
    {
        Console.WriteLine("What's your name?: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("What's your favorite number?: ");
        string favoriteNumber = Console.ReadLine();
        int intFavoriteNumber = int.Parse(favoriteNumber);
        return intFavoriteNumber;
    }
    static double SquareNumber(int number)
    {
        double squaredNum = Math.Pow(number, 2);
        return squaredNum;
    }
    static void DisplayResult(string name, double squaredNum)
    {
        Console.WriteLine($"Brother or Sister {name}, the square of your number is {squaredNum}.");
    }
}