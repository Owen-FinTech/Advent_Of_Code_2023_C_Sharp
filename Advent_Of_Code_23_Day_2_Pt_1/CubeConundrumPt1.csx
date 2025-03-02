using System;
using System.IO;
using System.Collections.Generic;


string filePath = "input.txt";
int sum = 0;

if (File.Exists(filePath))
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            List<string> gameWords = new List<string>();
            string word = "";

            for (int i = 0; i < line.Length; i++)
            {
                if (i == line.Length - 1)
                {
                    word += line[i];
                    gameWords.Add(word);
                    word = "";
                }
                else if (line[i] != ' ')
                {
                    word += line[i];
                }
                else
                {
                    gameWords.Add(word);
                    word = "";
                }
            }

            bool validGame = true;
            int blueCount = 0;
            int redCount = 0;
            int greenCount = 0;
            int currInt = 0;

            for (int i = 2; i < gameWords.Count; i++)
            {
                int prevInt = currInt;
                bool validNum = int.TryParse(gameWords[i], out currInt);
                if (validNum)
                {
                    currInt = int.Parse(gameWords[i]);
                }
                else
                {
                    currInt = prevInt;
                }

                if (gameWords[i] == "blue,")
                {
                    blueCount += currInt;
                }
                else if (gameWords[i] == "red,")
                {
                    redCount += currInt;
                }
                else if (gameWords[i] == "green,") 
                { 
                    greenCount += currInt;
                }
                else if (gameWords[i] == "blue;" || gameWords[i] == "blue")
                {
                    blueCount += currInt;
                    if (redCount > 12 || greenCount > 13 || blueCount > 14)
                    {
                        validGame = false;
                        break;
                    }
                    blueCount = redCount = greenCount = 0;
                }
                else if (gameWords[i] == "red;" || gameWords[i] == "red")
                {
                    redCount += currInt;
                    if (redCount > 12 || greenCount > 13 || blueCount > 14)
                    {
                        validGame = false;
                        break;
                    }
                    blueCount = redCount = greenCount = 0;
                }
                else if (gameWords[i] == "green;" || gameWords[i] == "green")
                {
                    greenCount += currInt;
                    if (redCount > 12 || greenCount > 13 || blueCount > 14)
                    {
                        validGame = false;
                        break;
                    }
                    blueCount = redCount = greenCount = 0;
                }   
            }

            if (validGame)
            {
                sum += int.Parse(gameWords[1].Substring(0,
                    gameWords[1].Length - 1));
            }
        }
    }
}
else
{
    Console.WriteLine("File not found: " + filePath);
}

Console.WriteLine("Sum: " + sum);
