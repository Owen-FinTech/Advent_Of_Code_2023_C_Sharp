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
            }
            sum += (firstInt * 10) + lastInt;
        }
    }
}
else {
    Console.WriteLine("File not found: " + filePath);
}

Console.WriteLine("Sum: " + sum);