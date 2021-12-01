// See https://aka.ms/new-console-template for more information

var numbers = new List<int>();
Boolean DEBUG = false;

// Load data and put it in a list of integers
foreach (string line in System.IO.File.ReadLines(@"data.txt"))
{  
    numbers.Add(Int32.Parse(line));     
}

if (DEBUG)
{
    foreach (int fuel in numbers)
    {
        System.Console.WriteLine(fuel);
    }
}

int increases = 0;
int previous = 0;

foreach (int depth in numbers)
{
    if (depth > previous)
    {
        increases++;
    }
    previous = depth;
}

System.Console.WriteLine("Part 1 solution:");
System.Console.WriteLine(increases-1);
