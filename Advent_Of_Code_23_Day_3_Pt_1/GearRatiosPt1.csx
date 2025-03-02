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

List<char> symbolList = new List<char> { '-', '@', '*', '=', '%', '/', '$', '#', '&', '+' };
string currIntAsString = "";
bool noSymbol = true;
int sum = 0;

for (int i = 0; i < rows.Count; i++)
{
    for (int j = 0; j < rows[i].Length; j++)
    {
        if (!Char.IsDigit(rows[i][j]))
        {
            if (!noSymbol && currIntAsString != "")
            {
                sum += int.Parse(currIntAsString);
            }
            currIntAsString = "";
            noSymbol = true;
        }
        else
        {
            if (j > 0)
            {
                if (symbolList.Contains(rows[i][j - 1]))
                {
                    noSymbol = false;
                }
            }

            if (j < rows[i].Length - 1)
            {
                if (symbolList.Contains(rows[i][j + 1]))
                {
                    noSymbol = false;
                }
            }

            if (i > 0)
            {
                if (symbolList.Contains(rows[i - 1][j]))
                {
                    noSymbol = false;
                }
            }

            if (i < rows.Count - 1)
            {
                if (symbolList.Contains(rows[i + 1][j]))
                {
                    noSymbol = false;
                }
            }

            if (j > 0 && i > 0)
            {
                if (symbolList.Contains(rows[i - 1][j - 1]))
                {
                    noSymbol = false;
                }
            }

            if ((j < rows[i].Length - 1) && (i < rows.Count - 1))
            {
                if (symbolList.Contains(rows[i + 1][j + 1]))
                {
                    noSymbol = false;
                }
            }

            if (j > 0 && (i < rows.Count - 1))
            {
                if (symbolList.Contains(rows[i + 1][j - 1]))
                {
                    noSymbol = false;
                }
            }

            if ((j < rows[i].Length - 1) && i > 0)
            {
                if (symbolList.Contains(rows[i - 1][j + 1]))
                {
                    noSymbol = false;
                }
            }
        }

        if ((j == rows[i].Length - 1) && Char.IsDigit(rows[i][j]) && !noSymbol)
        {
            currIntAsString += rows[i][j];
            sum += int.Parse(currIntAsString);
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

Console.WriteLine("Sum: " + sum);
