

const bool TEST = true;
string dataFile = "";
string dataFilePart2 = "";

if (TEST)
{
    dataFile = "test_part1.txt";
    dataFilePart2 = "test_part2.txt";
}
else
{
    dataFile = "data_part1.txt";
    dataFilePart2 = "data_part2.txt";
}

try
{
    using StreamReader reader = new(dataFile);
    
    // changed from string -> string? to indicate that the variable could be nullable (it was a warning)
    string? line; 
    int sumaFinal = 0;   
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
   
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}