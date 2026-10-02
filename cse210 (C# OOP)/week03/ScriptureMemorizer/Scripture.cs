using System;
using System.Collections.Generic;
using System.Linq;
class Scripture
{
    private ScriptureReference reference;
    private VerseManager verses;

    public Scripture(ScriptureReference reference, List<string> verses)
    {
        this.reference = reference;
        this.verses = new VerseManager(verses);
    }

    // Hide a given number of random words in the scripture.
    public void HideRandomWords(int count)
    {
        verses.HideRandomWords(count);
    }

    // Display the reference and verses.
    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference.ReferenceText);
        verses.Display();
    }

    // Check if all words are hidden.
    public bool AllHidden()
    {
        return verses.AllHidden();
    }
}