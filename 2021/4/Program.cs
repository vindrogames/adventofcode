//Day 4

var datas = new List<string>();
var numbers_draw = new List<int>();

Boolean DEBUG = false;

// Load data and get the numbers to draw and the boards
int line = 0;
foreach (string line in System.IO.File.ReadLines(@"data.txt"))
{
    //the first line is the numbers to draw  
    string[] numbers_draw_temp = line.Split(',');
    foreach (char number in numbers_draw_temp)
    {
        
    }
    line++;
}
