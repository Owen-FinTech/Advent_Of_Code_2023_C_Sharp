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

long time = 0;
long distance = 0;
string[] timeSplit = rows[0].Split(' ', 
    StringSplitOptions.RemoveEmptyEntries);
string[] distanceSplit = rows[1].Split(' ',
    StringSplitOptions.RemoveEmptyEntries);
string timeString = "";
string distanceString = "";

for (int i = 1; i <  timeSplit.Length; i++)
{
    timeString += timeSplit[i];
    distanceString += distanceSplit[i];
}

time = long.Parse(timeString);
distance = long.Parse(distanceString);

int newRecordCount = 0;
for (int i = 0; i < time; i++)
{
    if ((i * (time - i)) > distance)
    {
        newRecordCount++;
    }
}

Console.WriteLine("newRecordCount: " + newRecordCount);

