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
    
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}