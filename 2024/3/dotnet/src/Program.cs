﻿using System.Text.RegularExpressions;

const bool TEST = false;
string dataFile = "";
string dataFilePart2 = "";

if (TEST)
{
    dataFile = "test.txt";
    dataFilePart2 = "test_part2.txt";
}
else
{
    dataFile = "data.txt";
    dataFilePart2 = "data_part2.txt";
}

try
{
    List<int> group1 = [];
    
    using StreamReader reader = new(dataFile);
    
    // changed from string -> string? to indicate that the variable could be nullable (it was a warning)
    string? line; 
    int sumaFinal = 0;   
    while ((line = reader.ReadLine()) != null)
    {
        sumaFinal += Extractor(line);
    }
    Console.WriteLine(sumaFinal);
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}

int Extractor(string line)
{
    // mul(2,4)
    string pattern = @"mul\((\d+),(\d+)\)";
    MatchCollection collection = Regex.Matches(line,pattern);
    int sumaTotal = 0;
    foreach (Match match in collection)
    {
        //Console.WriteLine(match.Groups[1].Value +' '+ match.Groups[2].Value);
        
        _ = int.TryParse(match.Groups[1].Value, out int val1);
        _ = int.TryParse(match.Groups[2].Value, out int val2);
        
        sumaTotal = sumaTotal + (val1 * val2);
    }
    return sumaTotal;
}

// Part 2



try
{
        
    using StreamReader readerPart2 = new(dataFilePart2);
    
    // changed from string -> string? to indicate that the variable could be nullable (it was a warning)
    string? line; 
    int sumaFinal = 0;   
    while ((line = readerPart2.ReadLine()) != null)
    {
        string pattern = @"^.+don't\(\)|do\(\)";
        MatchCollection collection = Regex.Matches(line,pattern);
        
        foreach (Match match in collection)
        {
            Console.WriteLine(match.Groups[1].Value);          
            
        }
        //sumaFinal += Extractor(line);
    }
    //Console.WriteLine(sumaFinal);
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}