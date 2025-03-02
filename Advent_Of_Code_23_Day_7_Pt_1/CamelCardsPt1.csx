using System;
using System.IO;
using System.Collections.Generic;
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

List<int> types = new List<int>(); // Types 1 - 7

for (int i = 0; i < rows.Count; i++)
{
    types.Add(0);
    List<int> counts = new List<int> { 0, 0, 0, 0, 0 };
    
    for (int j = 0; j < 5; j++)
    {
        for (int k = 0; k < 5; k++)
        {
            if (rows[i][j] == rows[i][k])
            {
                counts[j]++;
            }
        }
    }

    for (int j = 0; j < counts.Count; j++)
    {
        if (counts[j] == 5)
        {
            types[i] = 1;
            break;
        }
        else if (counts[j] == 4)
        {
            types[i] = 2;
            break;
        }
        else if (counts[j] == 3)
        {
            bool twosFound = false;

            for (int k = 0; k < counts.Count; k++)
            {
                if (counts[k] == 2)
                {
                    types[i] = 3;
                    twosFound = true;
                }
            }

            if (!twosFound)
            {
                types[i] = 4;
            }
            break;
        }
        else if (counts[j] == 2)
        {
            int twoCount = 0;
            int threeCount = 0;

            for (int k = 0; k < counts.Count; k++)
            {
                if (counts[k] == 2)
                {
                    twoCount++;
                }
                else if (counts[k] == 3)
                {
                    threeCount++;
                }
            }

            if (threeCount > 0)
            {
                continue;
            }
            else
            {
                if (twoCount == 4)
                {
                    types[i] = 5;
                    break;
                }
                else
                {
                    types[i] = 6;
                    break;
                }
            }      
        }
    }

    if (types[i] == 0)
    {
        types[i] = 7;
    }
}

List<char> strengths = new List<char> { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', 
    '6', '5', '4', '3', '2' };

for (int i = 0; i < types.Count - 1; i++)
{
    for (int j = 0; j < types.Count - i - 1; j++)
    {
        if (types[j] > types[j + 1])
        {
            int temp1 = types[j];
            string temp2 = rows[j];
            types[j] = types[j + 1];
            rows[j] = rows[j + 1];
            types[j + 1] = temp1;
            rows[j + 1] = temp2;
        }
        else if (types[j] == types[j + 1])
        {
            for (int k = 0; k < 5; k++)
            {
                int firstStrength = 0;
                int secondStrength = 0;

                for (int l = 0; l < strengths.Count; l++) 
                {
                    if (rows[j][k] == strengths[l])
                    {
                        firstStrength = l;
                    }

                    if (rows[j + 1][k] == strengths[l])
                    {
                        secondStrength = l;
                    }
                }

                if (firstStrength != secondStrength)
                {
                    if (firstStrength > secondStrength)
                    {
                        int temp1 = types[j];
                        string temp2 = rows[j];
                        types[j] = types[j + 1];
                        rows[j] = rows[j + 1];
                        types[j + 1] = temp1;
                        rows[j + 1] = temp2;
                    }
                    break;
                }
            }
        }
    }
}

ulong totalWinnings = 0;
ulong rank = (ulong)types.Count;

for (int i = 0; i < types.Count; i++)
{
    string[] splitRow = rows[i].Split(' ', 
        StringSplitOptions.RemoveEmptyEntries);
    totalWinnings += ulong.Parse(splitRow[1]) * (ulong)rank;
    rank--;
}

Console.WriteLine("totalWinnings: " + totalWinnings);