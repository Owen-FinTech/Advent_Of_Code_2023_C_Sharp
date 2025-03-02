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
List<string> currNodes = new List<string>();

for (int i = 2; i < rows.Count; i++) {
    string[] splitRow = rows[i].Split(' ', 
        StringSplitOptions.RemoveEmptyEntries);
    List<string> nodesRow = new List<string> { 
        splitRow[2].Substring(1, 3), splitRow[3].Substring(0, 3) };
    nodes.Add(splitRow[0], nodesRow);

    if (splitRow[0][2] == 'A') {
        currNodes.Add(splitRow[0]);
    }
}

long[] stepsToZ = new long[currNodes.Count];

for (int i = 0; i < currNodes.Count; i++) {
    long steps = 0;
    bool endZ = false;
    while (!endZ) {
        if (rows[0][(int)(steps % rows[0].Length)] == 'L') {
            currNodes[i] = (nodes[currNodes[i]][0]);
        }
        else {
            currNodes[i] = (nodes[currNodes[i]][1]);
        }
        steps++;
        if (currNodes[i][2] == 'Z') {
            endZ = true;
            stepsToZ[i] = steps;
        }
    }
}

long GCD(long a, long b) {
    while (b != 0) {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

long LCM(long a, long b) {
    return Math.Abs(a * b) / GCD(a, b);
}

long LCM(params long[] numbers) {
    if (numbers.Length == 0) {
        return 0;
    }
    long result = numbers[0];
    for (int i = 1; i < numbers.Length; i++) {
        result = LCM(result, numbers[i]);
    }
    return result;
}

Console.WriteLine("steps: " + LCM(stepsToZ));