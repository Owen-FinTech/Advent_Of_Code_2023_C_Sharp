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

Dictionary<string, List<string>> nodes = new Dictionary<string, List<string>>();

for (int i = 2; i < rows.Count; i++) {
    string[] splitRow = rows[i].Split(' ', 
        StringSplitOptions.RemoveEmptyEntries);
    List<string> nodesRow = new List<string> { 
        splitRow[2].Substring(1, 3), splitRow[3].Substring(0, 3) };
    nodes.Add(splitRow[0], nodesRow);
}

string currNode = "AAA";
int steps = 0;

while (currNode != "ZZZ") {
    if (rows[0][steps % rows[0].Length] == 'L') {
        currNode = nodes[currNode][0];
    }
    else {
        currNode = nodes[currNode][1];
    }
    steps++;
}

Console.WriteLine("steps: " + steps);




