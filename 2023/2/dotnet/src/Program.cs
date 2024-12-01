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
        //path = @"maik.txt";

        
        try
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                
                foreach (string s in readText)    
                {
                    

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

    static void Main()
    {
        
        problem1();
        problem2();
    }
    
    
}