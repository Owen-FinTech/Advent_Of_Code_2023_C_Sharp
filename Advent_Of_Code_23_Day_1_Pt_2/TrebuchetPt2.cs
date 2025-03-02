using System;
using System.IO;

string filePath = "input.txt";
int sum = 0;

if (File.Exists(filePath)) {
    using (StreamReader reader = new StreamReader(filePath)) {
        string line;
        while ((line = reader.ReadLine()) != null) {
            bool firstFound = false;
            int firstInt = 0;
            int lastInt = 0;
            for (int i = 0; i < line.Length; i++) {
                if (Char.IsDigit(line[i]) && !firstFound) {
                    firstInt = line[i] - '0'; 
                    lastInt = line[i] - '0';
                    firstFound = true;
                }
                else if (Char.IsDigit(line[i])) {
                    lastInt = line[i] - '0';
                }
                else {
                    for (int j = i; j < line.Length; j++) {
                        if (line.Substring(i, j - i + 1) == "one") {
                            if (!firstFound) {
                                firstInt = 1;
                                lastInt = 1;
                                firstFound = true;
                            }
                            else {
                                lastInt = 1;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "two") {
                            if (!firstFound) {
                                firstInt = 2;
                                lastInt = 2;
                                firstFound = true;
                            }
                            else {
                                lastInt = 2;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "three") {
                            if (!firstFound) {
                                firstInt = 3;
                                lastInt = 3;
                                firstFound = true;
                            }
                            else {
                                lastInt = 3;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "four") {
                            if (!firstFound) {
                                firstInt = 4;
                                lastInt = 4;
                                firstFound = true;
                            }
                            else {
                                lastInt = 4;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "five") {
                            if (!firstFound) {
                                firstInt = 5;
                                lastInt = 5;
                                firstFound = true;
                            }
                            else {
                                lastInt = 5;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "six") {
                            if (!firstFound) {
                                firstInt = 6;
                                lastInt = 6;
                                firstFound = true;
                            }
                            else {
                                lastInt = 6;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "seven") {
                            if (!firstFound) {
                                firstInt = 7;
                                lastInt = 7;
                                firstFound = true;
                            }
                            else {
                                lastInt = 7;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "eight") {
                            if (!firstFound) {
                                firstInt = 8;
                                lastInt = 8;
                                firstFound = true;
                            }
                            else {
                                lastInt = 8;
                            }
                        }
                        else if (line.Substring(i, j - i + 1) == "nine") {
                            if (!firstFound) {
                                firstInt = 9;
                                lastInt = 9;
                                firstFound = true;
                            }
                            else {
                                lastInt = 9;
                            }
                        }
                    }
                }
            }
            sum += (firstInt * 10) + lastInt;
        }
    }
}
else {
    Console.WriteLine("File not found: " + filePath);
}

Console.WriteLine("Sum: " + sum);