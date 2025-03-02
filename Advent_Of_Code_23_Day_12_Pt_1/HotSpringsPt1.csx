using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

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

var configs  = new List<string>();
var nums = new List<List<int>>();

foreach(var row in rows)
{
    var splitArr = row.Split(' ');
    configs.Add(splitArr[0]);
    var splitNumsAsStrings = splitArr[1].Split(",").ToList();
    List<int> splitNums = new List<int>();
    foreach (var splitNum in splitNumsAsStrings)
    {
        splitNums.Add(int.Parse(splitNum));
    }
    nums.Add(splitNums);
}

int validCount = 0;
var permutations = new List<string>();

for (int i = 0; i < configs.Count; i++)
{
    permutations.Clear();

    for (int j = 0; j < configs[i].Length; j++)
    {
        if (configs[i][j] == '.')
        {
            if (permutations.Count == 0)
            {
                permutations.Add(".");
            }
            else
            {
                for (int k = 0; k < permutations.Count; k++)
                {
                    permutations[k] += ".";
                }
            }
        }
        else if (configs[i][j] == '#')
        {
            if (permutations.Count == 0)
            {
                permutations.Add("#");
            }
            else
            {
                for (int k = 0; k < permutations.Count; k++)
                {
                    permutations[k] += "#";
                }
            }
        }
        else
        {
            if (permutations.Count == 0)
            {
                permutations.Add(".");
            }
            else
            {
                for (int k = 0; k < permutations.Count; k++)
                {
                    permutations[k] += ".";
                }
            }

            var permCount = permutations.Count;

            for (int k = 0; k < permCount; k++)
            {
                var modifiedPerm = permutations[k].Substring(0, permutations[k].Length - 1);
                modifiedPerm += "#";
                permutations.Add(modifiedPerm);
            }
        }
    }

    foreach (var permutation in permutations)
    {
        var actualNums = new List<int>();
        int currNum = 0;

        for (int j = 0; j < permutation.Length; j++)
        {
            if (permutation[j] == '#')
            {
                currNum++;
            }
            else
            {
                if (currNum > 0)
                {
                    actualNums.Add(currNum);
                    currNum = 0;
                }
            }
        }

        if (currNum > 0)
        {
            actualNums.Add(currNum);
        }

        bool match = true;

        if (nums[i].Count != actualNums.Count)
        {
            match = false;
        }
        else
        {
            for (int j = 0; j < nums[i].Count; j++)
            {
                if (nums[i][j] != actualNums[j])
                {
                    match = false;
                    break;
                }
            } 
        }

        if (match)
        {
            validCount++;
        }
    }
}

Console.WriteLine(validCount);
