using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string filePath = "input.txt";
List<string> rows = new List<string>();

if (File.Exists(filePath))
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            rows.Add(line);
        }
    }
}
else
{
    Console.WriteLine("File not found: " + filePath);
}

List<int> cards = new List<int>();
char[] delimiter = { ' ' };

for (int i = 0; i < rows.Count; i++)
{
    cards.Add(1);
}

    for (int i = 0; i < rows.Count; i++)
{
    int matches = 0;
    List<string> scratchcard = rows[i].Split(delimiter, 
        StringSplitOptions.RemoveEmptyEntries).ToList();

    for (int j = 2; j <= 11; j++)
    {
        for (int k = 13; k <= 37; k++)
        {
            if (scratchcard[j] == scratchcard[k])
            {
                matches++;
            }
        }
    }
    
    if (matches > 0 && (i < rows.Count - 1))
    {
        int j = i + 1;
        while (j < rows.Count && matches > 0) 
        { 
            cards[j] += cards[i];
            j++;
            matches--;
        }   
    } 
}

int totalCards = 0;

for (int i = 0; i < cards.Count; i++)
{
    totalCards += cards[i];
}

Console.WriteLine("totalCards: " + totalCards);
