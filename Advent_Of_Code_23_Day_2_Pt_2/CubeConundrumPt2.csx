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

            int minBlue = 0;
            int minRed = 0;
            int minGreen = 0;
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

                if (gameWords[i] == "blue," || gameWords[i] == "blue;" || 
                    gameWords[i] == "blue")
                {
                    if (currInt > minBlue)
                    {
                        minBlue = currInt;
                    }
                }
                else if (gameWords[i] == "red," || gameWords[i] == "red;" || 
                    gameWords[i] == "red")
                {
                    if (currInt > minRed)
                    {
                        minRed = currInt;
                    }
                }
                else if (gameWords[i] == "green," || gameWords[i] == "green;" || 
                    gameWords[i] == "green") 
                {
                    if (currInt > minGreen)
                    {
                        minGreen = currInt;
                    }
                }   
            }
            sum += minGreen * minBlue * minRed;
        }
    }
}
else
{
    Console.WriteLine("File not found: " + filePath);
}

Console.WriteLine("Sum: " + sum);
