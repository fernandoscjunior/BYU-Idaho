using System.IO;
using System;

public class Journal
{
    public Journal()
    {

    }
    public void WriteFile(List<string> list, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (string line in list)
            {
                writer.WriteLine(line);
            }

        }

        Console.WriteLine("File created succesfully!\n");
    }

    public void LoadFile(string chosenFile)
    {   
        string[] lines = System.IO.File.ReadAllLines(chosenFile);
        foreach (string line in lines)
        {
            Console.WriteLine("\n" + line);
        }

    }

}
    