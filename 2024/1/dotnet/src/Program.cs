
Console.WriteLine("Hello, World!");

const bool TEST = false;
string dataFile = "";

if (TEST)
{
    dataFile = "test.txt";
}
else
{
    dataFile = "data.txt";
}



try
{
    List<int> group1 = new List<int>();

    // I changed from 'new List<int>()' to '[]' it was a recommendation to simplify by the compiler
    List<int> group2 = [];
    
    using StreamReader reader = new(dataFile);
    
    // changed from string -> string? to indicate that the variable could be nullable (it was a warning)
    string? line;
    while ((line = reader.ReadLine()) != null)
    {      
        string[] subs = line.Split("   ");
        
        if (subs.Length == 2)
        {
            // i changed from 'Int32.TryParse...' to '_ = int.TryParse...' first recommendation to simplif from Int32 to int
            // then I added '_ ='
            _ = int.TryParse(subs[0], out int n1);
            group1.Add(n1);
            Int32.TryParse(subs[1], out int n2);
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
            totalDistance += enum1.Current - enum2.Current;
        }
        else
        {
            totalDistance = totalDistance + (enum2.Current - enum1.Current);
        }

        numAvailable = enum1.MoveNext();
        enum2.MoveNext();        
    }

    Console.WriteLine(totalDistance);

    List<int>.Enumerator enumpart2_1 = group1.GetEnumerator();  
    numAvailable = enumpart2_1.MoveNext();
    
    int similarity = 0;

    while (numAvailable)
    {
        int count = 0;
        foreach (int num in group2)
        {
            if (num == enumpart2_1.Current)
            {
                count++;
            }
        }

        similarity += enumpart2_1.Current * count;
        
        numAvailable = enumpart2_1.MoveNext();
    }

    Console.WriteLine(similarity);
    
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}
