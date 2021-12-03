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

var gamma_rate = new List<string>();
var epsilon_rate = new List<string>();

for (int i=0; i<12; i++)
{   
    int numberOfCeros = 0;
    int numberOfOnes = 0;
    foreach (string data in datas)
    {
        
        if (data[i] == '0')
        {
            numberOfCeros++;
        }
        else if (data[i] == '1')
        {
            numberOfOnes++;
        }
    }
    //System.Console.WriteLine(numberOfCeros);
    //System.Console.WriteLine(numberOfOnes);
    //System.Console.WriteLine("--------------");
    if (numberOfCeros > numberOfOnes)
    {
        gamma_rate.Add("0");
        epsilon_rate.Add("1");
    }
    else{
        gamma_rate.Add("1");
        epsilon_rate.Add("0");
    }
}


int gamma_rate_decimal = 0;

foreach (string bit in gamma_rate)
{    
    int temp = Int32.Parse(bit);
    //System.Console.WriteLine(temp);
    gamma_rate_decimal = 2*gamma_rate_decimal + temp;
}

//System.Console.WriteLine(gamma_rate_decimal);

int epsilon_rate_decimal = 0;

foreach (string bit in epsilon_rate)
{    
    int temp = Int32.Parse(bit);
    //System.Console.WriteLine(temp);
    epsilon_rate_decimal = 2*epsilon_rate_decimal + temp;
}

//System.Console.WriteLine(epsilon_rate_decimal);

System.Console.WriteLine("Solution to part one:");
System.Console.WriteLine(gamma_rate_decimal*epsilon_rate_decimal);

System.Console.WriteLine("-------------------------------------------------------");

int pos=0;

while (pos < 12 && datas.Count > 1)
{   
    
    int numberOfCeros = 0;
    int numberOfOnes = 0;
    //System.Console.WriteLine(pos);
    foreach (string data in datas)
    {
        
        if (data[pos] == '0')
        {
            numberOfCeros++;
        }
        else if (data[pos] == '1')
        {
            numberOfOnes++;
        }
    }
    
    
    List<string> temp = new List<string>();

    if (numberOfOnes >= numberOfCeros)
    {
        foreach (string data in datas)
        {
            if (data[pos] == '0')
            {
                temp.Add(data);
            }
        }
    }
    else
    {
        foreach (string data in datas)
        {
            if (data[pos] == '1')
            {
                temp.Add(data);
            }
        }
    }
    foreach (string item in temp)
    {
        datas.Remove(item);        
    }
    pos++;
    /*foreach (string data in datas)
    {
        System.Console.WriteLine(data); 
    }*/
    //System.Console.WriteLine(pos); 
    //System.Console.WriteLine(datas.Count); 
}



foreach (string data in datas)
{
    System.Console.WriteLine(data);
}

var datas_dos = new List<string>();

// Load data and put it in a list of integers
foreach (string line in System.IO.File.ReadLines(@"data.txt"))
{  
    datas_dos.Add(line);
}

pos = 0;

while (pos < 12 && datas_dos.Count > 1)
{   
    int numberOfCeros = 0;
    int numberOfOnes = 0;
    foreach (string data in datas_dos)
    {
        
        if (data[pos] == '0')
        {
            numberOfCeros++;
        }
        else if (data[pos] == '1')
        {
            numberOfOnes++;
        }
    }
    System.Console.WriteLine(numberOfCeros);
    System.Console.WriteLine(numberOfOnes);
    System.Console.WriteLine("--------------");
    List<string> temp = new List<string>();

    if (numberOfOnes >= numberOfCeros)
    {
        foreach (string data in datas_dos)
        {
            if (data[pos] == '1')
            {
                temp.Add(data);
            }
        }
    }
    else
    {
        foreach (string data in datas_dos)
        {
            if (data[pos] == '0')
            {
                temp.Add(data);
            }
        }
    }
    foreach (string item in temp)
    {
        datas_dos.Remove(item);
    }
    pos++;
    /*foreach (string data in datas_dos)
    {
        System.Console.WriteLine(data); 
    }
    */
    //System.Console.WriteLine(pos); 
    //System.Console.WriteLine(datas_dos.Count); 
    
}

System.Console.WriteLine("oxigen");

foreach (string data in datas_dos)
{
    System.Console.WriteLine(data);
}


