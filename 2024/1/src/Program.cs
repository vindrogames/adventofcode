
Console.WriteLine("Hello, World!");

const bool TEST = false;
string dataFile = "";
int numDigits = 0;

if (TEST)
{
    dataFile = "test.txt";
    numDigits = 1;
}
else
{
    dataFile = "data.txt";
    numDigits = 5;
}



try
{
    List<int> group1 = new List<int>();
    List<int> group2 = new List<int>();
    
    using StreamReader reader = new(dataFile);
    string line;
    while ((line = reader.ReadLine()) != null)
    {      
        string[] subs = line.Split("   ");
        
        if (subs.Length == 2)
        {
            int n1;
            Int32.TryParse(subs[0],out n1);
            group1.Add(n1);
            int n2;
            Int32.TryParse(subs[1],out n2);
            group2.Add(n2);
        }
    }

    group1.Sort();
    group2.Sort();

    List<int>.Enumerator enum1 = group1.GetEnumerator();
    List<int>.Enumerator enum2 = group2.GetEnumerator();

    bool numAvailable = enum1.MoveNext();
    enum2.MoveNext();

    int totalDistance = 0;

    while (numAvailable)
    {
        //Console.WriteLine(enum1.Current);
        //Console.WriteLine(enum2.Current);

        if (enum1.Current > enum2.Current)
        {
            totalDistance = totalDistance + (enum1.Current - enum2.Current);
        }
        else
        {
            totalDistance = totalDistance + (enum2.Current - enum1.Current);
        }

        numAvailable = enum1.MoveNext();
        enum2.MoveNext();

        
    }

    Console.WriteLine(totalDistance);
    
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}
