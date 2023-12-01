using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"data.txt";
        
        //path = @"test.txt";

        int suma = 0;

        Dictionary<string, string> letterNumbers = new Dictionary<string, string>();
        letterNumbers.Add("one","o1e");
        letterNumbers.Add("two","t2o");
        letterNumbers.Add("three","t3e");
        letterNumbers.Add("four","f4r");
        letterNumbers.Add("five","f5e");
        letterNumbers.Add("six","s6x");
        letterNumbers.Add("seven","s7n");
        letterNumbers.Add("eight","e8t");
        letterNumbers.Add("nine","n9e");

        List<KeyValuePair<string, string>> sortedLetterNumbers = letterNumbers.ToList();  
        sortedLetterNumbers.Sort((pair1, pair2) => pair2.Key.Length.CompareTo(pair1.Key.Length));  

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

        // PART 2

        try
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                int sumados = 0;
                foreach (string s in readText)    
                {
                    string input = s;  
                    string output = string.Empty;   
                    while(input.Length > 0)      
                    {      
                        bool replaced = false;      
                        for (int i = input.Length; i > 0; i--)    
                        {    
                            foreach (KeyValuePair<string, string> pair in letterNumbers)    
                            {    
                                if (input.Substring(0, i).Equals(pair.Key))    
                                {    
                                    string tempInput = input.Remove(0, i);  
                                    
                                    // Check if the remaining part of the string begins with another word from the dictionary  
                                    if (!letterNumbers.Keys.Any(key => tempInput.StartsWith(key)))  
                                    {  
                                        output += pair.Value.ToString();    
                                        input = tempInput;    
                                        replaced = true;    
                                        break;    
                                    }    
                                }    
                            }    
                            if (replaced) break;    
                        }      
                        if(!replaced)      
                        {      
                            output += input[0];      
                            input = input.Substring(1);    
                        }      
                    }
                    //Console.WriteLine(output); 

                    
                    var digits = new String(output.Where(char.IsDigit).ToArray());  
                    if(digits.Length > 0)
                    {
                        if (digits.Length == 1)
                        {  
                            string newNumberStr = digits[0] + (digits.Length > 1 ? digits[digits.Length-1].ToString() : "");  
                            newNumberStr = newNumberStr + newNumberStr;
                            int newNumber = int.Parse(newNumberStr);  
                            Console.WriteLine($"The new number formed from the first and last digits in '{s}' is {newNumber}.");
                            sumados = sumados + newNumber;
                            Console.WriteLine(sumados);
                            
                        }  
                        else
                        {
                            string newNumberStr = digits[0] + (digits.Length > 1 ? digits[digits.Length-1].ToString() : "");                          
                            int newNumber = int.Parse(newNumberStr);  
                            Console.WriteLine($"The new number formed from the first and last digits in '{s}' is {newNumber}.");
                            sumados = sumados + newNumber;
                            Console.WriteLine(sumados);
                            
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

        
        
    }
    
    
}