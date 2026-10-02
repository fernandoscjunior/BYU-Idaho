using System;
using System.Security.Cryptography.X509Certificates;

public class Entry
{
    public string Date;
    public Entry()
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
    public void DisplayPrompt()
    {
        //getting random number     
        Console.WriteLine("Entry time:" + Date);

        //Getting prompt from Prompter class
        Prompter prompt = new Prompter();

        Console.WriteLine(prompt.GetRandomPrompt());
        
    }

}