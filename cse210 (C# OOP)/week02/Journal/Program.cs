using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> entries = new List<string>();

        //splash message
        Console.WriteLine("\nWelcome to MyJournal C# edition.");

        //Initializing app menu loop
        while (true)
        {
            Console.WriteLine("\n[1] - Write a new entry.\n[2] - Display current entries\n[3] - Save current entries into a file\n[4] - Load entries from file\n[5] - Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Write new entry

                    //calling Entry class to get the user to write his/her answer.
                    Entry entry = new Entry();
                    entry.DisplayPrompt();

                    //getting user's answer
                    string answer = Console.ReadLine();

                    //adding answer to an entries list to be displayed later
                    entries.Add(answer);
                    entries.Add(entry.Date);

                    //Getting back to menu
                    break;

                case "2": //display local entries yet not saved in any file
                    foreach (string line in entries)
                    {
                        Console.WriteLine("Here are your entries:");
                        Console.WriteLine("\n" + line);
                    }
                    break;

                case "3": //Save entries into a file
                    //getting file name from user
                    Console.WriteLine("Enter file's name:");
                    string fileName = Console.ReadLine();

                    //calling Journal class to write file
                    Journal journal = new Journal();
                    journal.WriteFile(entries, fileName);

                    break;
                
                case "4": // loading entries from file
                    //getting file name from user
                    Console.WriteLine("What file you want to load?");
                    string chosenFile = Console.ReadLine();

                    //calling journal class method for loading a file
                    Journal journal1 = new Journal();
                    journal1.LoadFile(chosenFile);
                    break;
                
                case "5":
                    Console.WriteLine("Exiting application...");
                    return; // End program

                default: //in case user digits invalid option
                    Console.WriteLine("Option not avaible, try again.");
                    break;
            }
        }
    }
}