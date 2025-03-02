using System;
using System.Collections.Generic;
using System.IO;

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

List<List<int>> gears = new List<List<int>>();
int gearRow = 0;
int gearCol = 0;
string currIntAsString = "";
bool noSymbol = true;
long sum = 0;

for (int i = 0; i < rows.Count; i++)
{
    for (int j = 0; j < rows[i].Length; j++)
    {
        if (!Char.IsDigit(rows[i][j]))
        {
            if (!noSymbol && currIntAsString != "")
            {   
                List<int> gear1 = new List<int> { gearRow, gearCol, int.Parse(currIntAsString) };
                gears.Add(gear1);
            }
            currIntAsString = "";
            noSymbol = true;
        }
        else
        {
            if (j > 0)
            {
                if (rows[i][j - 1] == '*')
                {
                    noSymbol = false;
                    gearRow = i;
                    gearCol = j - 1;
                }
            }

            if (j < rows[i].Length - 1)
            {
                if (rows[i][j + 1] == '*')
                {
                    noSymbol = false;
                    gearRow = i;
                    gearCol = j + 1;
                }
            }

            if (i > 0)
            {
                if (rows[i - 1][j] ==  '*')
                {
                    noSymbol = false;
                    gearRow = i - 1;
                    gearCol = j;
                }
            }

            if (i < rows.Count - 1)
            {
                if (rows[i + 1][j] == '*')
                {
                    noSymbol = false;
                    gearRow = i + 1;
                    gearCol = j;
                }
            }

            if (j > 0 && i > 0)
            {
                if (rows[i - 1][j - 1] == '*')
                {
                    noSymbol = false;
                    gearRow = i - 1;
                    gearCol = j - 1;
                }
            }

            if ((j < rows[i].Length - 1) && (i < rows.Count - 1))
            {
                if (rows[i + 1][j + 1] == '*')
                {
                    noSymbol = false;
                    gearRow = i + 1;
                    gearCol = j + 1;
                }
            }

            if (j > 0 && (i < rows.Count - 1))
            {
                if (rows[i + 1][j - 1] == '*')
                {
                    noSymbol = false;
                    gearRow = i + 1;
                    gearCol = j - 1;
                }
            }

            if ((j < rows[i].Length - 1) && i > 0)
            {
                if (rows[i - 1][j + 1] == '*')
                {
                    noSymbol = false;
                    gearRow = i - 1;
                    gearCol = j + 1;
                }
            }
        }

        if ((j == rows[i].Length - 1) && Char.IsDigit(rows[i][j]) && !noSymbol)
        {
            currIntAsString += rows[i][j];
            List<int> gear2 = new List<int> { gearRow, gearCol, int.Parse(currIntAsString) };
            gears.Add(gear2);
            currIntAsString = "";
            noSymbol = true;
        }
        else if ((j == rows[i].Length - 1) && Char.IsDigit(rows[i][j]) && noSymbol)
        {
            currIntAsString = "";
            noSymbol = true;
        }
        else if (Char.IsDigit(rows[i][j]))
        {
            currIntAsString += rows[i][j];
        }
    }
}

for (int i = 0; i < gears.Count - 1; i++)
{
    for (int j = i + 1; j < gears.Count; j++)
    {
        if (gears[i][0] == gears[j][0] && gears[i][1] == gears[j][1])
        {
            sum += gears[i][2] * gears[j][2];
        }
    }
}

Console.WriteLine("Sum: " + sum);
