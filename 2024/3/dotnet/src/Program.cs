using System.Text.RegularExpressions;

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
   
    int sumaFinal = 0;
    
    string? line2; 
    string line3 = string.Empty;
    while ((line2 = readerPart2.ReadLine()) != null)
    {
        line3 += line2;
    }
    
    string pattern = @"^.+?(don't\(\)|do\(\))";
    Regex regexFirstPart = new Regex(pattern);
    Match m = regexFirstPart.Match(line3,0);        
    if (m.Success)
    {
        //Console.WriteLine(m.Value);   
        sumaFinal += Extractor(m.Value);     
    }
    
    /*
    pattern = @"do\(\).+?(?!don't\(\))$";
    Regex regexSecondPart = new Regex(pattern);
    m = regexSecondPart.Match(line,0);        
    if (m.Success)
    {
        //Console.WriteLine(m.Value);   
        sumaFinal += Extractor(m.Value);     
    }
    */

    pattern = @"do\(\).+?(don't\(\)|\z)";
    Regex regexThirdPart = new Regex(pattern);
    //m = regexThirdPart.Match(line,0);        
    MatchCollection collection = Regex.Matches(line3,pattern);
    foreach (Match match in collection)
    {
        //Console.WriteLine(match.Groups[1].Value +' '+ match.Groups[2].Value);
    
        sumaFinal += Extractor(match.Value);
    }
    
    Console.WriteLine(sumaFinal);
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}