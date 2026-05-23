using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string digit = "-1";
        int intDigit = int.Parse(digit);
        List<int> numberList = new List<int>();
        int sum = 0;
        

        while (intDigit != 0)
        {
            Console.Write("Enter a number:");
            string enter = Console.ReadLine();
            int intEnter = int.Parse(enter);
            intDigit = intEnter;

            if (intDigit == 0)
            {

            }
            else
            {
                numberList.Add(intDigit);
                sum += intDigit;
            }
            

        }
        int length = numberList.Count;
        double average = sum / length;
        int max = numberList.Max();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The biggest number is: {max}");


    }
}