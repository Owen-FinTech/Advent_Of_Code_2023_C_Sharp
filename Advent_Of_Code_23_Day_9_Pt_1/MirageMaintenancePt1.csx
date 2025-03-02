using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

string filePath = "input.txt";
List<string> rows = new List<string>();

if (File.Exists(filePath)) {
    using (StreamReader reader = new StreamReader(filePath)) {
        string line;
        while ((line = reader.ReadLine()) != null) {
            rows.Add(line);
        }
    }
}

List<List<int>> hist = new List<List<int>>();

for (int i = 0; i < rows.Count; i++) {
    string[] splitRow = rows[i].Split(' ', 
        StringSplitOptions.RemoveEmptyEntries);
    List<int> ints = new List<int>();

    for (int j = 0; j < splitRow.Length; j++) {
        ints.Add(int.Parse(splitRow[j]));
    }

    hist.Add(ints);
}

for  (int i = 0; i < hist.Count; i++) {
    List<List<int>> diff = new List<List<int>>();
    diff.Add(hist[i]);
    bool allZeros = false;

    while (!allZeros) {
        List<int> currDiff = new List<int>();

        for (int j = 0; j < diff[diff.Count - 1].Count - 1; j++) {
            currDiff.Add(diff[diff.Count - 1][j + 1] -
                diff[diff.Count - 1][j]);
        }

        diff.Add(currDiff);
        allZeros = true;

        for (int j = 0; j < diff[diff.Count - 1].Count; j++) {
            if (diff[diff.Count - 1][j] != 0) {
                allZeros = false;
            }
        }
    }

    for (int j = diff.Count - 1; j >= 0; j--) {
        if (j == diff.Count - 1) {
            diff[j].Add(0);
        }
        else {
            diff[j].Add(diff[j][diff[j].Count - 1] + 
                diff[j + 1][diff[j + 1].Count - 1]);
        }
    }

    hist[i].Add(diff[0][diff[0].Count - 1]);
}

int sum = 0;

for (int i = 0; i < hist.Count; i++) {
    sum += hist[i][hist[i].Count - 1];
}

Console.WriteLine("sum: " + sum);