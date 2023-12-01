using System;
using System.IO;

class Program
{

    private static void problem1()
    {
        Console.WriteLine("function 1");
        string path = @"data.txt";
        
        //path = @"test.txt";

        int suma = 0;

        
        

        try
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)  
                {  
                    var digits = new String(s.Where(char.IsDigit).ToArray());  
                    if(digits.Length > 0)
                    {
                        if (digits.Length == 1)
                        {  
                            string newNumberStr = digits[0] + (digits.Length > 1 ? digits[digits.Length-1].ToString() : "");  
                            newNumberStr = newNumberStr + newNumberStr;
                            int newNumber = int.Parse(newNumberStr);  
                            //Console.WriteLine($"The new number formed from the first and last digits in '{s}' is {newNumber}.");
                            suma = suma + newNumber;
                        }  
                        else
                        {
                            string newNumberStr = digits[0] + (digits.Length > 1 ? digits[digits.Length-1].ToString() : "");                          
                            int newNumber = int.Parse(newNumberStr);  
                            //Console.WriteLine($"The new number formed from the first and last digits in '{s}' is {newNumber}.");
                            suma = suma + newNumber;
                        }
                    }
                    else  
                    {  
                        Console.WriteLine($"The string '{s}' does not contain a number.");  
                    }  
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine(suma);
    }

    public static void problem2()
    {
        string path = @"data.txt";
        
        //path = @"test.txt";

        Dictionary<string, int> letterNumbers = new Dictionary<string, int>();
        letterNumbers.Add("one",1);
        letterNumbers.Add("two",2);
        letterNumbers.Add("three",3);
        letterNumbers.Add("four",4);
        letterNumbers.Add("five",5);
        letterNumbers.Add("six",6);
        letterNumbers.Add("seven",7);
        letterNumbers.Add("eight",8);
        letterNumbers.Add("nine",9);

        try
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                int sumados = 0;
                foreach (string s in readText)    
                {
                    string newString = "";
                    for (int i=0; i< s.Length; i++)
                    {
                        for (int j=0; j < s.Length - i +1 ; j++)
                        {
                            string subString = s.Substring(i,j);
                            
                            // Now we will check if the substring is a number of single digit
                            if (subString.Length == 1)
                            {
                                if (Int32.TryParse(subString, out int numValue))
                                {
                                    
                                    newString = newString + subString;
                                }
                            }

                            foreach (KeyValuePair<string, int> kvp in letterNumbers)
                            {
                                if (subString == kvp.Key)
                                {
                                    //Console.WriteLine(kvp.Value);
                                    newString = newString + kvp.Value;
                                }
                            }
                        }
                    }
                    //Console.WriteLine(newString);
                    string firstNumber = "";
                    string secondNumber = "";
                    if (newString.Length > 1)
                    {
                        firstNumber = newString.Substring(0,1);
                        secondNumber = newString.Substring(newString.Length-1,1);
                    }
                    else
                    {
                        firstNumber = newString.Substring(0,1);
                        secondNumber = newString.Substring(newString.Length-1,1);
                    }
                    string finalNumber = firstNumber + secondNumber;
                    //Console.WriteLine(finalNumber);
                    if (Int32.TryParse(finalNumber, out int numValueLast))
                    {
                        
                        sumados = sumados + numValueLast;
                    }

                }
                Console.WriteLine(sumados);
                
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        
    }

    static void Main()
    {
        
        problem1();
        problem2();
    }
    
    
}