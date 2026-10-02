using System;
using System.Collections.Generic;
using System.Linq;
class Program
   {
       static void Main()
       {
           // Create a list of scriptures using the new classes.
           List<Scripture> scriptures = new List<Scripture>
           {
               new Scripture(
                   new ScriptureReference("John 3:15-16"),
                   new List<string>
                   {
                       "That everyone who believes may have eternal life in him.",
                       "For God so loved the world that he gave his one and only Son."
                   }
               ),
               new Scripture(
                   new ScriptureReference("Psalm 23:1-2"),
                   new List<string>
                   {
                       "The Lord is my shepherd, I lack nothing.",
                       "He makes me lie down in green pastures, he leads me beside quiet waters."
                   }
               )
           };
           Random random = new Random();
           Scripture scripture = scriptures[random.Next(scriptures.Count)];
           Console.WriteLine("Press Enter to hide words. Type 'exit' to quit.");
           while (true)
           {
               scripture.Display();
               if (scripture.AllHidden())
               {
                   Console.WriteLine("All words are hidden. Press Enter to exit.");
                   Console.ReadLine();
                   break;
               }
               string input = Console.ReadLine();
               if (input.ToLower() == "exit")
                   break;
               scripture.HideRandomWords(2);
           }
       }
   }