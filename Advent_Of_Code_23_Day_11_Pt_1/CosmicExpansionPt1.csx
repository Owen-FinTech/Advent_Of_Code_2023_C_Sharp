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
List<string> expandVert = new List<string>();
List<string> expandFull = new List<string>();
bool hasGalaxy = false;

for (int i = 0; i < rows.Count; i++) {
    hasGalaxy = false;
    for (int j = 0; j < rows[0].Length; j++) {
        if (rows[i][j] == '#') { hasGalaxy = true; break; }
    }
    expandVert.Add(rows[i]);
    expandFull.Add("");
    if (!hasGalaxy) { expandVert.Add(rows[i]); expandFull.Add(""); }
}

for (int i = 0; i < expandVert[0].Length; i++) {
    hasGalaxy = false;
    for (int j = 0; j < expandVert.Count; j++){
        if (expandVert[j][i] == '#') { hasGalaxy = true; }
        expandFull[j] += expandVert[j][i];
    }

    if (!hasGalaxy) {
        for (int j = 0; j < expandVert.Count; j++){
            expandFull[j] += expandVert[j][i];
        }
    } 
}
int lengths = 0;

for (int i = 0; i < expandFull.Count; i++) {
    for (int j = 0; j < expandFull[0].Length; j++) {
        for (int k = 0; k < expandFull.Count; k++) {
            for (int l = 0; l < expandFull[0].Length; l++) {
                if (expandFull[i][j] == '#' && expandFull[k][l] == '#') {
                    lengths += Math.Abs(i - k) + Math.Abs(j - l);
                }
            }
        }
    }
}
lengths /= 2;
Console.WriteLine("lengths: " + lengths);
