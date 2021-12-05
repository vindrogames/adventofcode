//Day 4

var datas = new List<string>();
var numbers_draw = new List<int>();

Boolean DEBUG = false;

// Load data and get the numbers to draw and the boards
int line = 0;
foreach (string data in System.IO.File.ReadLines(@"data.txt"))
{
    //the first line is the numbers to draw  
    if (line == 0)
    {
        string[] numbers_draw_temp = data.Split(',');
        foreach (string number in numbers_draw_temp)
        {
            numbers_draw.Add(Int32.Parse(number));
        }
    }

    


    line++;
}

foreach (int number in numbers_draw)
{
    System.Console.WriteLine(number);
}