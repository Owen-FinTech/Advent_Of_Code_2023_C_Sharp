using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
else
{
    Console.WriteLine("File not found: " + filePath);
}

string seedsString1 = rows[0].Substring(7);
string seedsString2 = rows[1];
char[] delimiter = { ' ' };
string[] seedsStringSplit1 = seedsString1.Split(delimiter, 
    StringSplitOptions.RemoveEmptyEntries);
string[] seedsStringSplit2 = seedsString2.Split(delimiter,
    StringSplitOptions.RemoveEmptyEntries);
List<long> conversions = new List<long>();

for (int i = 0; i < seedsStringSplit1.Count(); i++)
{
    conversions.Add(long.Parse(seedsStringSplit1[i]));
}

for (int i = 0; i < seedsStringSplit2.Count(); i++)
{
    conversions.Add(long.Parse(seedsStringSplit2[i]));
}

List<List<long>> seedToSoil = new List<List<long>>();
List<List<long>> soilToFertilizer = new List<List<long>>();
List<List<long>> fertilizerToWater = new List<List<long>>();
List<List<long>> waterToLight = new List<List<long>>();
List<List<long>> lightToTemperature = new List<List<long>>();
List<List<long>> temperatureToHumidity = new List<List<long>>();
List<List<long>> humidityToLocation = new List<List<long>>();

int colonCount = 0;
for (int i = 0; i < rows.Count; i++)
{
    if (rows[i].Contains(':'))
    {
        colonCount++;
    }
    else if (rows[i] != "" && rows[i] != " ")
    {
        if (colonCount == 2) 
        {
            string[] seedToSoilStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> seedToSoilLongs = new List<long>();

            for (int j = 0; j < seedToSoilStrings.Count(); j++)
            {
                seedToSoilLongs.Add(long.Parse(seedToSoilStrings[j]));
            }
            seedToSoil.Add(seedToSoilLongs);
        }
        else if (colonCount == 3)
        {
            string[] soilToFertilizerStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> soilToFertilizerLongs = new List<long>();

            for (int j = 0; j < soilToFertilizerStrings.Count(); j++)
            {
                soilToFertilizerLongs.Add(
                    long.Parse(soilToFertilizerStrings[j]));
            }
            soilToFertilizer.Add(soilToFertilizerLongs);
        }
        else if (colonCount == 4)
        {
            string[] fertilizerToWaterStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> fertilizerToWaterLongs = new List<long>();

            for (int j = 0; j < fertilizerToWaterStrings.Count(); j++)
            {
                fertilizerToWaterLongs.Add(
                    long.Parse(fertilizerToWaterStrings[j]));
            }
            fertilizerToWater.Add(fertilizerToWaterLongs);
        }
        else if (colonCount == 5)
        {
            string[] waterToLightStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> waterToLightLongs = new List<long>();

            for (int j = 0; j < waterToLightStrings.Count(); j++)
            {
                waterToLightLongs.Add(
                    long.Parse(waterToLightStrings[j]));
            }
            waterToLight.Add(waterToLightLongs);
        }
        else if (colonCount == 6)
        {
            string[] lightToTemperatureStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> lightToTemperatureLongs = new List<long>();

            for (int j = 0; j < lightToTemperatureStrings.Count(); j++)
            {
                lightToTemperatureLongs.Add(
                    long.Parse(lightToTemperatureStrings[j]));
            }
            lightToTemperature.Add(lightToTemperatureLongs);
        }
        else if (colonCount == 7)
        {
            string[] temperatureToHumidityStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> temperatureToHumidityLongs = new List<long>();

            for (int j = 0; j < temperatureToHumidityStrings.Count(); j++)
            {
                temperatureToHumidityLongs.Add(
                    long.Parse(temperatureToHumidityStrings[j]));
            }
            temperatureToHumidity.Add(temperatureToHumidityLongs);
        }
        else if (colonCount == 8)
        {
            string[] humidityToLocationStrings = rows[i].Split(delimiter,
                StringSplitOptions.RemoveEmptyEntries);
            List<long> humidityToLocationLongs = new List<long>();

            for (int j = 0; j < humidityToLocationStrings.Count(); j++)
            {
                humidityToLocationLongs.Add(
                    long.Parse(humidityToLocationStrings[j]));
            }
            humidityToLocation.Add(humidityToLocationLongs);
        }
    }
}

long lowestLocation = Int64.MaxValue;

for (int k = 0; k < conversions.Count; k += 2)
{
    for (long i = conversions[k]; i < (conversions[k] + conversions[k + 1]); 
        i++)
    {
        long currConversion = i;
        for (int j = 0; j < seedToSoil.Count; j++)
        {
            if (currConversion >= seedToSoil[j][1] &&
                currConversion < (seedToSoil[j][1] + seedToSoil[j][2]))
            {
                currConversion = seedToSoil[j][0] +
                    (currConversion - seedToSoil[j][1]);
                break;
            }
        }

        for (int j = 0; j < soilToFertilizer.Count; j++)
        {
            if (currConversion >= soilToFertilizer[j][1] &&
                currConversion < (soilToFertilizer[j][1] +
                soilToFertilizer[j][2]))
            {
                currConversion = soilToFertilizer[j][0] +
                    (currConversion - soilToFertilizer[j][1]);
                break;
            }
        }

        for (int j = 0; j < fertilizerToWater.Count; j++)
        {
            if (currConversion >= fertilizerToWater[j][1] &&
                currConversion < (fertilizerToWater[j][1] +
                fertilizerToWater[j][2]))
            {
                currConversion = fertilizerToWater[j][0] +
                    (currConversion - fertilizerToWater[j][1]);
                break;
            }
        }

        for (int j = 0; j < waterToLight.Count; j++)
        {
            if (currConversion >= waterToLight[j][1] &&
                currConversion < (waterToLight[j][1] +
                waterToLight[j][2]))
            {
                currConversion = waterToLight[j][0] +
                    (currConversion - waterToLight[j][1]);
                break;
            }
        }

        for (int j = 0; j < lightToTemperature.Count; j++)
        {
            if (currConversion >= lightToTemperature[j][1] &&
                currConversion < (lightToTemperature[j][1] +
                lightToTemperature[j][2]))
            {
                currConversion = lightToTemperature[j][0] +
                    (currConversion - lightToTemperature[j][1]);
                break;
            }
        }

        for (int j = 0; j < temperatureToHumidity.Count; j++)
        {
            if (currConversion >= temperatureToHumidity[j][1] &&
                currConversion < (temperatureToHumidity[j][1] +
                temperatureToHumidity[j][2]))
            {
                currConversion = temperatureToHumidity[j][0] +
                    (currConversion - temperatureToHumidity[j][1]);
                break;
            }
        }

        for (int j = 0; j < humidityToLocation.Count; j++)
        {
            if (currConversion >= humidityToLocation[j][1] &&
                currConversion < (humidityToLocation[j][1] +
                humidityToLocation[j][2]))
            {
                currConversion = humidityToLocation[j][0] +
                    (currConversion - humidityToLocation[j][1]);
                break;
            }
        }

        if (currConversion < lowestLocation)
        {
            lowestLocation = currConversion;
        }
    }
}

Console.WriteLine("lowestLocation: " + lowestLocation);