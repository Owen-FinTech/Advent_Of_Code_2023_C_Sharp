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
        if (row == vis[i][0] && col == vis[i][1]) { found = true; }
    }
    return found;
}
bool looped = false;
int added = 1;
 
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

    if (added == 0) { looped = true; }
}
List<List<char>> loop = new List<List<char>>();

for (int i = 0; i < rows.Count; i++) {
    List<char> periods = new List<char>();
    for (int j = 0; j < rows[0].Length; j++) {
        periods.Add('.');
    }
    loop.Add(periods);
}

for (int i = 0; i < vis.Count; i++) {
    loop[vis[i][0]][vis[i][1]] = 'P';
}

if ((vis[0][0] - 1) >= 0 && (vis[0][0] + 1) < rows.Count) {
    if (((rows[vis[0][0] - 1][vis[0][1]] == '7') ||
        (rows[vis[0][0] - 1][vis[0][1]] == 'F') ||
        (rows[vis[0][0] - 1][vis[0][1]] == '|')) &&
        ((rows[vis[0][0] + 1][vis[0][1]] == 'J') ||
        (rows[vis[0][0] + 1][vis[0][1]] == 'L') ||
        (rows[vis[0][0] + 1][vis[0][1]] == '|')) &&
        loop[vis[0][0] - 1][vis[0][1]] == 'P' &&
        loop[vis[0][0] + 1][vis[0][1]] == 'P') {
        rows[vis[0][0]] = rows[vis[0][0]].Substring(0, vis[0][1]) + 
            '|' + rows[vis[0][0]].Substring(vis[0][1] + 1);
    }
}

if ((vis[0][1] - 1) >= 0 && (vis[0][1] + 1) < rows[0].Length) {
    if (((rows[vis[0][0]][vis[0][1] - 1] == 'L') ||
        (rows[vis[0][0]][vis[0][1] - 1] == 'F') ||
        (rows[vis[0][0]][vis[0][1] - 1] == '-')) &&
        ((rows[vis[0][0]][vis[0][1] + 1] == 'J') ||
        (rows[vis[0][0]][vis[0][1] + 1] == '7') ||
        (rows[vis[0][0]][vis[0][1] + 1] == '-')) &&
        loop[vis[0][0]][vis[0][1] - 1] == 'P' &&
        loop[vis[0][0]][vis[0][1] + 1] == 'P') {
        rows[vis[0][0]] = rows[vis[0][0]].Substring(0, vis[0][1]) +
            '-' + rows[vis[0][0]].Substring(vis[0][1] + 1);
    }
}

if ((vis[0][0] - 1) >= 0 && (vis[0][1] + 1) < rows[0].Length) {
    if (((rows[vis[0][0] - 1][vis[0][1]] == '7') ||
        (rows[vis[0][0] - 1][vis[0][1]] == 'F') ||
        (rows[vis[0][0] - 1][vis[0][1]] == '|')) &&
        ((rows[vis[0][0]][vis[0][1] + 1] == 'J') ||
        (rows[vis[0][0]][vis[0][1] + 1] == '7') ||
        (rows[vis[0][0]][vis[0][1] + 1] == '-')) &&
        loop[vis[0][0] - 1][vis[0][1]] == 'P' &&
        loop[vis[0][0]][vis[0][1] + 1] == 'P') {
        rows[vis[0][0]] = rows[vis[0][0]].Substring(0, vis[0][1]) +
            'L' + rows[vis[0][0]].Substring(vis[0][1] + 1);
    }
}

if ((vis[0][0] + 1) < rows.Count && (vis[0][1] + 1) < rows[0].Length) {
    if (((rows[vis[0][0] + 1][vis[0][1]] == 'L') ||
        (rows[vis[0][0] + 1][vis[0][1]] == 'J') ||
        (rows[vis[0][0] + 1][vis[0][1]] == '|')) &&
        ((rows[vis[0][0]][vis[0][1] + 1] == 'J') ||
        (rows[vis[0][0]][vis[0][1] + 1] == '7') ||
        (rows[vis[0][0]][vis[0][1] + 1] == '-')) &&
        loop[vis[0][0] + 1][vis[0][1]] == 'P' &&
        loop[vis[0][0]][vis[0][1] + 1] == 'P') {
        rows[vis[0][0]] = rows[vis[0][0]].Substring(0, vis[0][1]) +
            'F' + rows[vis[0][0]].Substring(vis[0][1] + 1);
    }
}

if ((vis[0][0] + 1) < rows.Count && (vis[0][1] - 1) >= 0) {
    if (((rows[vis[0][0] + 1][vis[0][1]] == 'L') ||
        (rows[vis[0][0] + 1][vis[0][1]] == 'J') ||
        (rows[vis[0][0] + 1][vis[0][1]] == '|')) &&
        ((rows[vis[0][0]][vis[0][1] - 1] == 'L') ||
        (rows[vis[0][0]][vis[0][1] - 1] == 'F') ||
        (rows[vis[0][0]][vis[0][1] - 1] == '-')) &&
        loop[vis[0][0] + 1][vis[0][1]] == 'P' &&
        loop[vis[0][0]][vis[0][1] - 1] == 'P') {
        rows[vis[0][0]] = rows[vis[0][0]].Substring(0, vis[0][1]) +
            '7' + rows[vis[0][0]].Substring(vis[0][1] + 1);
    }
}

if ((vis[0][0] - 1) >= 0 && (vis[0][1] - 1) >= 0) {
    if (((rows[vis[0][0] - 1][vis[0][1]] == '7') ||
        (rows[vis[0][0] - 1][vis[0][1]] == 'F') ||
        (rows[vis[0][0] - 1][vis[0][1]] == '|')) &&
        ((rows[vis[0][0]][vis[0][1] - 1] == 'L') ||
        (rows[vis[0][0]][vis[0][1] - 1] == 'F') ||
        (rows[vis[0][0]][vis[0][1] - 1] == '-')) &&
        loop[vis[0][0] - 1][vis[0][1]] == 'P' &&
        loop[vis[0][0]][vis[0][1] - 1] == 'P') {
        rows[vis[0][0]] = rows[vis[0][0]].Substring(0, vis[0][1]) +
            'J' + rows[vis[0][0]].Substring(vis[0][1] + 1);
    }
}
int enclosed = 0;

for (int i = 0; i < rows.Count; i++) {
    bool inside = false;
    bool onL = false;
    bool onF = false;
    for (int j = 0; j < rows[0].Length; j++) {
        if (loop[i][j] == '.' && inside) {
            enclosed++;
        } 
        else if (loop[i][j] == 'P' && rows[i][j] == '|') {  
            if (inside) { inside = false; } else { inside = true; }
        }
        else if (loop[i][j] == 'P' && rows[i][j] == 'L') {
            onL = true;
        }
        else if (loop[i][j] == 'P' && rows[i][j] == 'F') {
            onF = true;
        }
        else if (loop[i][j] == 'P' && rows[i][j] == 'J') {
            if (onL) {
                onL = false;
            }
            else {
                onF = false;
                if (inside) { inside = false; } else { inside = true; }
            }
        }
        else if (loop[i][j] == 'P' && rows[i][j] == '7') {
            if (onF) {
                onF = false;
            }
            else {
                onL = false;
                if (inside) { inside = false; } else { inside = true; }
            }
        }
    }
}

Console.WriteLine("enclosed: " + enclosed);
