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



var agrupado = new List<int>();

if (DEBUG)
{

    var data_test = new List<int>(){
        199,200,208,210,200,207,240,269,260,263
    };

    for (int i=0; i<data_test.Count-2;  i++)
    {
        int suma = 0;
        int steps = 0;
        while ((steps < 3) && (i+steps < (data_test.Count)))    
        {        
            suma = suma + data_test[i+steps];
            steps++;
        }
        agrupado.Add(suma);

        System.Console.WriteLine(suma);
    }
}

agrupado = new List<int>();

for (int i=0; i<numbers.Count-2;  i++)
{
    int suma = 0;
    int steps = 0;
    while ((steps < 3) && (i+steps < (numbers.Count)))    
    {        
        suma = suma + numbers[i+steps];
        steps++;
    }
    agrupado.Add(suma);

    if (DEBUG)
    {
        System.Console.WriteLine(suma);
    }
}

increases = 0;
previous = 0;

foreach (int depth in agrupado)
{
    if (depth > previous)
    {
        increases++;
    }
    previous = depth;
}

System.Console.WriteLine("Part 2 solution:");

System.Console.WriteLine(increases-1);