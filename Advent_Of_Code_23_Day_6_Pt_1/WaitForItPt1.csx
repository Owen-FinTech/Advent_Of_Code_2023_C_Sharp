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

List<int> times = new List<int>();
List<int> distances = new List<int>();
string[] timesSplit = rows[0].Split(' ', 
    StringSplitOptions.RemoveEmptyEntries);
string[] distancesSplit = rows[1].Split(' ',
    StringSplitOptions.RemoveEmptyEntries);

for (int i = 1; i <  timesSplit.Length; i++)
{
    times.Add(int.Parse(timesSplit[i]));
    distances.Add(int.Parse(distancesSplit[i]));
}

int recordCountProduct = 0;

for (int i = 0; i < times.Count; i++)
{
    int newRecordCount = 0;
    for (int j = 0; j < times[i]; j++)
    {
        if ((j * (times[i] - j)) > distances[i])
        {
            newRecordCount++;
        }
    }

    if (recordCountProduct == 0)
    {
        recordCountProduct = newRecordCount;
    }
    else
    {
        recordCountProduct *= newRecordCount;
    }
}

Console.WriteLine("recordCountProduct: " + recordCountProduct);

