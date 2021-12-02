// Day 2

var commands = new List<string>();

Boolean DEBUG = false;

// Load data and put it in a list of integers
foreach (string line in System.IO.File.ReadLines(@"data.txt"))
{  
    commands.Add(line);     
}

if (DEBUG)
{
    foreach (string command in commands)
    {
        System.Console.WriteLine(command);
    }
}

int horizontal = 0;
int depth = 0;

foreach (string command in commands)
{
    string[] action = command.Split(' ');
    //System.Console.WriteLine(action[0]);
    //System.Console.WriteLine(action[1]);
    if (String.Equals(action[0], "forward"))
    {
        //System.Console.WriteLine("avanza");
        horizontal = horizontal + Int32.Parse(action[1]);
    }
    else if (String.Equals(action[0], "down"))
    {
        //System.Console.WriteLine("abajo");
        depth = depth + Int32.Parse(action[1]);
    }
    else if (String.Equals(action[0], "up"))
    {
        //System.Console.WriteLine("arriba");
        depth = depth - Int32.Parse(action[1]);
    }         
}

System.Console.WriteLine("Solucion 1:");
System.Console.WriteLine("Horizontal: " +horizontal+" Depth: "+depth);
System.Console.WriteLine("Solucion: "+horizontal*depth);

horizontal = 0;
depth = 0;
int aim = 0;

foreach (string command in commands)
{
    string[] action = command.Split(' ');
    //System.Console.WriteLine(action[0]);
    //System.Console.WriteLine(action[1]);
    if (String.Equals(action[0], "forward"))
    {
        //System.Console.WriteLine("avanza");
        horizontal = horizontal + Int32.Parse(action[1]);
        depth = depth + Int32.Parse(action[1])*aim;
    }
    else if (String.Equals(action[0], "down"))
    {
        
        aim = aim + Int32.Parse(action[1]);
        //System.Console.WriteLine("abajo "+aim);
    }
    else if (String.Equals(action[0], "up"))
    {
        
        aim = aim - Int32.Parse(action[1]);
        //System.Console.WriteLine("arriba "+aim);
    }  
    //System.Console.WriteLine(depth);       
}

System.Console.WriteLine("Solucion 2:");
System.Console.WriteLine("Horizontal: " +horizontal+" Depth: "+depth);
System.Console.WriteLine("Solucion: "+horizontal*depth);

