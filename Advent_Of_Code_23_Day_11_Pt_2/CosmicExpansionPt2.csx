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
List<int> expandRows= new List<int>();
List<int> expandCols = new List<int>();
bool hasGalaxy = false;

for (int i = 0; i < rows.Count; i++) {
    hasGalaxy = false;
    for (int j = 0; j < rows[0].Length; j++) {
        if (rows[i][j] == '#') { hasGalaxy = true; break; }
    }

    if (!hasGalaxy) { expandRows.Add(i); }
}

for (int i = 0; i < rows[0].Length; i++) {
    hasGalaxy = false;
    for (int j = 0; j < rows.Count; j++){
        if (rows[j][i] == '#') { hasGalaxy = true; }
    }

    if (!hasGalaxy) { expandCols.Add(i); }
}
long lengths = 0;

for (int i = 0; i < rows.Count; i++) {
    for (int j = 0; j < rows[0].Length; j++) {
        for (int k = 0; k < rows.Count; k++) {
            for (int l = 0; l < rows[0].Length; l++) {
                if (rows[i][j] == '#' && rows[k][l] == '#') {
                    lengths += Math.Abs(i - k) + Math.Abs(j - l);

                    if (k > i) {
                        for (int m = i; m <= k; m++) {
                            if (expandRows.Contains(m)) { lengths += 999999; }
                        }
                    }
                    else {
                        for (int m = k; m <= i; m++) {
                            if (expandRows.Contains(m)) { lengths += 999999; }
                        }
                    }

                    if (l > j) {
                        for (int m = j; m <= l; m++) {
                            if (expandCols.Contains(m)) { lengths += 999999; }
                        }
                    }
                    else {
                        for (int m = l; m <= j; m++) {
                            if (expandCols.Contains(m)) { lengths += 999999; }
                        }
                    }
                } 
            }
        }
    }
}
lengths /= 2;
Console.WriteLine("lengths: " + lengths);
