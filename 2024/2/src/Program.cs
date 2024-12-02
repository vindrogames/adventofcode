const bool TEST = true;
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
    List<int> group1 = [];
    
    using StreamReader reader = new(dataFile);
    
    // changed from string -> string? to indicate that the variable could be nullable (it was a warning)
    string? line;
    int safeReports = 0;
    while ((line = reader.ReadLine()) != null)
    {      
        string[] subs = line.Split(" ");
        
        bool isSafe = false;  
        
        bool isRising = false;
        bool isDowning = false;
        //lets check if its ordered upwards
        for (int i=0; i<subs.Length - 1; i++)
        {
            _ = int.TryParse(subs[i], out int n1);
            _ = int.TryParse(subs[i+1], out int n2);
            if (n1 < n2)
            {
                isRising = true;
            }
            else
            {
                isRising = false;
                break;
            }
        }

        for (int i=0; i<subs.Length - 1; i++)
        {
            _ = int.TryParse(subs[i], out int n1);
            _ = int.TryParse(subs[i+1], out int n2);
            if (n1 > n2)
            {
                isDowning = true;
            }
            else
            {
                isDowning = false;
                break;
            }
        }

        if (isRising)
        {
            for (int i=0; i<subs.Length - 1; i++)
            {
                _ = int.TryParse(subs[i], out int n1);
                _ = int.TryParse(subs[i+1], out int n2);
                if (((n2 - n1) > 0) && ((n2 - n1) < 4))
                {
                    isSafe = true;
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }
        }

        if (isDowning)
        {
            for (int i=0; i<subs.Length - 1; i++)
            {
                _ = int.TryParse(subs[i], out int n1);
                _ = int.TryParse(subs[i+1], out int n2);
                if (((n1 - n2) > 0) && ((n1 - n2) < 4))
                {
                    isSafe = true;
                }
                else
                {
                    isSafe = false;
                    break;
                }
            }
        }

        if (isSafe)
        {
            safeReports++;
        }
        
    }
    Console.WriteLine(safeReports);

    // Part 2: we will add the fully safe, and now we will remove 1 elemnt each time

    using StreamReader reader2 = new(dataFile);
    
    // changed from string -> string? to indicate that the variable could be nullable (it was a warning)
    string? line2;

    while ((line2 = reader2.ReadLine()) != null)
    {      
        string[] subs = line2.Split(" ");
        
        for (int j=0; j<subs.Length; j++)
        {
            List<string> subsClone = (List<string>)subs.Clone();
            subsClone.RemoveAt(j);
            Console.WriteLine(subsClone);
        }
        
    }
    
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}