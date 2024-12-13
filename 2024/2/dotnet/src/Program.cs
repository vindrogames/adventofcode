const bool TEST = false;
string dataFile = "";

const bool PART2 = true;

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
        else //if it is not safe try to remove items until is safe
        {
            if (PART2)
            {
                List<int> shortList = [];
                foreach (string num in subs)
                {   
                    _ = int.TryParse(num, out int numTemp);
                    shortList.Add(numTemp);    
                    
                }
                for (int j=0; j<shortList.Count; j++)
                {
                    List<int> shortListClone =new List<int>(shortList);
                    shortListClone.RemoveAt(j);

                    bool isSafedos = false;  
            
                    bool isRisingdos = false;
                    bool isDowningdos = false;
                    //lets check if its ordered upwards
                    for (int i=0; i<shortListClone.Count - 1; i++)
                    {                    
                        if (shortListClone[i] < shortListClone[i+1])
                        {
                            isRisingdos = true;
                        }
                        else
                        {
                            isRisingdos = false;
                            break;
                        }
                    }

                    for (int i=0; i<shortListClone.Count - 1; i++)
                    {
                        
                        if (shortListClone[i] > shortListClone[i+1])
                        {
                            isDowningdos = true;
                        }
                        else
                        {
                            isDowningdos = false;
                            break;
                        }
                    }

                    if (isRisingdos)
                    {
                        for (int i=0; i<shortListClone.Count - 1; i++)
                        {
                            _ = int.TryParse(subs[i], out int n1);
                            _ = int.TryParse(subs[i+1], out int n2);
                            if (((shortListClone[i+1] - shortListClone[i]) > 0) && ((shortListClone[i+1] - shortListClone[i]) < 4))
                            {
                                isSafedos = true;
                            }
                            else
                            {
                                isSafedos = false;
                                break;
                            }
                        }
                    }

                    if (isDowningdos)
                    {
                        for (int i=0; i<shortListClone.Count - 1; i++)
                        {
                            _ = int.TryParse(subs[i], out int n1);
                            _ = int.TryParse(subs[i+1], out int n2);
                            if (((shortListClone[i] - shortListClone[i+1]) > 0) && ((shortListClone[i] - shortListClone[i+1]) < 4))
                            {
                                isSafedos = true;
                            }
                            else
                            {
                                isSafedos = false;
                                break;
                            }
                        }
                    }

                    if (isSafedos)
                    {
                        safeReports++;
                        break;
                    }
                    
                }
            }
        }
        
    }
    Console.WriteLine(safeReports);

    // Part 2: we will add the fully safe, and now we will remove 1 elemnt each time

   
    
}
catch (IOException e)
{
    Console.WriteLine("Cannot read file:");
    Console.WriteLine(e.Message);
}