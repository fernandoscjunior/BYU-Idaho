using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        Console.WriteLine("Welcome to the Mindfulness app!");
        while (choice != 4)
        {
            Console.WriteLine("[1] - Breathing activity\n[2] - Reflecting activity\n[3] - Listing activity\n[4] - Exit\nSelect one:");

            string input = Console.ReadLine();
            int input_num = int.Parse(input);
            Console.Clear();
            if (input_num == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing");
                breathingActivity.Run();
            }
            else if (input_num == 2)
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflectingActivity.Run();
            }
            else if (input_num == 3)
            {
                ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                listingActivity.Run();
            }
            else if (input_num == 4)
            {
                choice = input_num;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again...");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}