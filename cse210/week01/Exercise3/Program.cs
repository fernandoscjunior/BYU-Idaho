using System;

class Program
{
    static void Main(string[] args)
    {   
        Random randomGenerator = new Random();
        int intMagicNumber = randomGenerator.Next(1, 100);

        string guessNumber = "0";
        int intGuessNumber = int.Parse(guessNumber);

        while (intGuessNumber != intMagicNumber)
        {
            Console.Write("What's your guess?");
            guessNumber = Console.ReadLine();
            intGuessNumber = int.Parse(guessNumber);

            if (intGuessNumber == intMagicNumber)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (intGuessNumber > intMagicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
        }
    }
}