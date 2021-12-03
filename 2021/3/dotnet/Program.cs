// See https://aka.ms/new-console-template for more information

var datas = new List<string>();

Boolean DEBUG = false;

// Load data and put it in a list of strings
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

int gamma_rate_decimal = BinaryStringListToDecimal(gamma_rate);
int epsilon_rate_decimal = BinaryStringListToDecimal(epsilon_rate);

System.Console.WriteLine("-------------------------------------------------------");
System.Console.WriteLine("Solution to part 3.1: "+gamma_rate_decimal*epsilon_rate_decimal);
System.Console.WriteLine("-------------------------------------------------------");

int pos=0;

while (pos < 12 && datas.Count > 1)
{   
    
    int numberOfCeros = 0;
    int numberOfOnes = 0;
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
}

System.Console.WriteLine("oxygen generator rating");
int oxygen = 0;
foreach (string data in datas)
{
    System.Console.WriteLine("Binary: "+data);
    System.Console.WriteLine("Decimal: "+BinaryStringToDecimal(data));
    oxygen = BinaryStringToDecimal(data);
}

var datas_dos = new List<string>();
// Load data and put it in a list of strings
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
    
}

System.Console.WriteLine("CO2 scrubber rating");

int co2 = 0;
foreach (string data in datas_dos)
{
    System.Console.WriteLine("Binary: "+data);
    System.Console.WriteLine("Decimal: "+BinaryStringToDecimal(data));
    co2 = BinaryStringToDecimal(data);
}
System.Console.WriteLine("-------------------------------------------------------");
System.Console.WriteLine("Solucion to part 3.2: "+(co2*oxygen));
System.Console.WriteLine("-------------------------------------------------------");

/*
    This function takes a list of strings, but each string is only 1 character, and each
    character is 1 binary number:
    list-of-string = ["1","0","0","1","0","0","0","1"]
    and then return the conversion of binary to decimal
*/
int BinaryStringListToDecimal(List<string> listBinary)
{
    int decimal_number = 0;
    foreach (string bit in listBinary)
    {    
        int temp = Int32.Parse(bit);
        //System.Console.WriteLine(temp);
        decimal_number = 2*decimal_number + temp;
    }
    return decimal_number;
}

/*
    This function takes a string, but each character of the string is a 
    binary number:
    string = "01000100101"
    and then return the conversion of binary to decimal
*/
int BinaryStringToDecimal(string stringBinary)
{
    int decimal_number = 0;
    foreach (char bit in stringBinary)
    {    
        string s = bit.ToString();
        int temp = Int32.Parse(s);        
        decimal_number = 2*decimal_number + temp;
    }
    return decimal_number;
}
