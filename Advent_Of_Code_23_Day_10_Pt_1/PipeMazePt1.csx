using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

string filePath = "input.txt";
List<string> rows = new List<string>();
List<List<int>> vis = new List<List<int>>();

if (File.Exists(filePath)) {
    using (StreamReader reader = new StreamReader(filePath)) {
        string line;
        while ((line = reader.ReadLine()) != null) {
            rows.Add(line);
            for (int i = 0; i < line.Length; i++) {
                if (line[i] == 'S') {
                    List<int> coord = new List<int> { rows.Count - 1, i };
                    vis.Add(coord);
                }
            }
        }
    }
}

bool inVis(int row, int col) {
    bool found = false; 
    for (int i = 0; i < vis.Count; i++) {
        if (row == vis[i][0] && col == vis[i][1]) {
            found = true; 
        }
    }
    return found;
}
bool looped = false;
int added = 1;
int steps = 0;
 
while (!looped) {
    int initCount = vis.Count;
    int initAdd = added;
    added = 0;
    for (int i = (initCount - initAdd); i < initCount; i++) {
        if ((vis[i][0] - 1) >= 0) {
            if (rows[vis[i][0]][vis[i][1]] == 'S' ||
                rows[vis[i][0]][vis[i][1]] == '|' ||
                rows[vis[i][0]][vis[i][1]] == 'L' ||
                rows[vis[i][0]][vis[i][1]] == 'J') {
                if ((rows[vis[i][0] - 1][vis[i][1]] == '|' ||
                    rows[vis[i][0] - 1][vis[i][1]] == '7' ||
                    rows[vis[i][0] - 1][vis[i][1]] == 'F') &&
                    !inVis(vis[i][0] - 1, vis[i][1])) {
                    List<int> coord = new List<int> { vis[i][0] - 1,
                        vis[i][1] };
                    vis.Add(coord);
                    added++;
                }
            }
        }

        if ((vis[i][0] + 1) < rows.Count) {
            if (rows[vis[i][0]][vis[i][1]] == 'S' || 
                rows[vis[i][0]][vis[i][1]] == '|' ||
                rows[vis[i][0]][vis[i][1]] == '7' ||
                rows[vis[i][0]][vis[i][1]] == 'F') {
                if ((rows[vis[i][0] + 1][vis[i][1]] == '|' ||
                    rows[vis[i][0] + 1][vis[i][1]] == 'J' ||
                    rows[vis[i][0] + 1][vis[i][1]] == 'L') &&
                    !inVis(vis[i][0] + 1, vis[i][1])) {
                    List<int> coord = new List<int> { vis[i][0] + 1,
                        vis[i][1] };
                    vis.Add(coord);
                    added++;
                }
            }
        }

        if ((vis[i][1] - 1) >= 0) {
            if (rows[vis[i][0]][vis[i][1]] == 'S' || 
                rows[vis[i][0]][vis[i][1]] == '-' ||
                rows[vis[i][0]][vis[i][1]] == '7' ||
                rows[vis[i][0]][vis[i][1]] == 'J') {
                if ((rows[vis[i][0]][vis[i][1] - 1] == '-' ||
                    rows[vis[i][0]][vis[i][1] - 1] == 'L' ||
                    rows[vis[i][0]][vis[i][1] - 1] == 'F') &&
                    !inVis(vis[i][0], vis[i][1] - 1)) {
                    List<int> coord = new List<int> { vis[i][0],
                        vis[i][1] - 1 };
                    vis.Add(coord);
                    added++;
                }
            }
        }

        if ((vis[i][1] + 1) < rows[0].Length) {
            if (rows[vis[i][0]][vis[i][1]] == 'S' || 
                rows[vis[i][0]][vis[i][1]] == '-' ||
                rows[vis[i][0]][vis[i][1]] == 'F' ||
                rows[vis[i][0]][vis[i][1]] == 'L') {
                if ((rows[vis[i][0]][vis[i][1] + 1] == '-' ||
                    rows[vis[i][0]][vis[i][1] + 1] == '7' ||
                    rows[vis[i][0]][vis[i][1] + 1] == 'J') &&
                    !inVis(vis[i][0], vis[i][1] + 1)) {
                    List<int> coord = new List<int> { vis[i][0],
                        vis[i][1] + 1 };
                    vis.Add(coord);
                    added++;
                }
            }
        }
    }

    if (added > 0) {
        steps++;
    }
    else {
        looped = true;
    }
}

Console.WriteLine("steps: " + steps);
