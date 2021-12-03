// See https://aka.ms/new-console-template for more information

var datas = new List<string>();

Boolean DEBUG = false;

// Load data and put it in a list of integers
foreach (string line in System.IO.File.ReadLines(@"data.txt"))
{  
    datas.Add(line);
}

if (DEBUG)
{
    foreach (string data in datas)
    {
        System.Console.WriteLine(data);
    }
}