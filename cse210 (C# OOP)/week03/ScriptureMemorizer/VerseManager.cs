using System;
using System.Collections.Generic;
using System.Linq;

class VerseManager
{
    private List<List<string>> words;
    private List<List<bool>> hidden;
    private Random random;
    public VerseManager(List<string> verses)
    {
        // Split each verse into words.
        words = verses.Select(v => v.Split(' ').ToList()).ToList();
        // Initialize the hidden status for each word as false  
        hidden = words.Select(w => Enumerable.Repeat(false, w.Count).ToList()).ToList();
        random = new Random();
    }
    // Hides a given number of random words.
    public void HideRandomWords(int count)
    {
        int hiddenCount = 0;
        // Build a list of all (verse, word) indices.
        var wordIndexes = new List<(int verseIndex, int wordIndex)>();
        for (int i = 0; i < words.Count; i++)
        {
            for (int j = 0; j < words[i].Count; j++)
            {
                wordIndexes.Add((i, j));
            }
        }
        // Randomly hide words until either count words are hidden or all words are already hidden.
        while (hiddenCount < count && wordIndexes.Any(idx => !hidden[idx.verseIndex][idx.wordIndex]))
        {
            var idx = wordIndexes[random.Next(wordIndexes.Count)];
            if (!hidden[idx.verseIndex][idx.wordIndex])
            {
                hidden[idx.verseIndex][idx.wordIndex] = true;
                hiddenCount++;
            }
        }
    }
    // Displays the verses with words hidden as underscores.
    public void Display()
    {
        for (int i = 0; i < words.Count; i++)
        {
            for (int j = 0; j < words[i].Count; j++)
            {
                // Replace hidden words with underscores.
                Console.Write(hidden[i][j] ?
                    new string('_', words[i][j].Length) + " " :
                    words[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
    // Checks if all words in all verses have been hidden.
    public bool AllHidden()
    {
        return hidden.All(row => row.All(status => status));
    }
}