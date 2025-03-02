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

int points = 0;
char[] delimiter = { ' ' };

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
    
    if (matches > 0)
    {
        points += (int)Math.Pow(2.0, (double)(matches - 1));  
    } 
}

Console.WriteLine("Points: " + points);
