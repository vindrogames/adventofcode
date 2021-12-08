//Day 4

var datas = new List<string>();
var numbers_draw = new List<int>();

var tableros = new List<Tablero>();

int[,] tablero_temp = new int[5,5];

// Load data and get the numbers to draw and the boards
int line = 0;
int contador = 0;
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
    else 
    {
        if (contador == 0)
        {
            contador++;
            //System.Console.WriteLine("---------------");
        } else if (contador > 0 && contador <6)
        {
            
            //System.Console.WriteLine(data);
            //Process each line here
            
                string temp1 = string.Concat(data[0],data[1]);
                string temp2 = string.Concat(data[3],data[4]);
                string temp3 = string.Concat(data[6],data[7]);
                string temp4 = string.Concat(data[9],data[10]);
                string temp5 = string.Concat(data[12],data[13]);
                int tempo = Int32.Parse(temp4);
                //System.Console.WriteLine(tempo);
                tablero_temp[contador-1,0] = Int32.Parse(temp1);
                tablero_temp[contador-1,1] = Int32.Parse(temp2);
                tablero_temp[contador-1,2] = Int32.Parse(temp3);
                tablero_temp[contador-1,3] = Int32.Parse(temp4);
                tablero_temp[contador-1,4] = Int32.Parse(temp5);
                //System.Console.Write(Int32.Parse(temp1)+" "+Int32.Parse(temp2)+" "+Int32.Parse(temp3)+" "+Int32.Parse(temp4)+" "+Int32.Parse(temp5)+ " ");
                
                
            //       
            contador++;
        }
        if (contador > 5)      
        {
            //System.Console.WriteLine(" ");
            for (int i=0; i<5; i++)
            {
                for (int j=0; j<5; j++)
                {
                    //System.Console.WriteLine(tablero_temp[i,j]);
                }
            }
            tableros.Add(new Tablero(tablero_temp));
            contador = 0;
        }
    }
    line++;
}

bool hayBingo = false;
int numero_extraido = -5;

var queue_second = new Queue<int>(numbers_draw);

while (queue_second.Count > 0)
{
    numero_extraido = queue_second.Dequeue();
    
    int tableros_comprobados = 0;
    foreach (Tablero tablero in tableros)
    {
        tablero.check_number(numero_extraido);
        if (!tablero.getTerminado())
        {
            //tablero.check_number(numero_extraido);
            hayBingo = tablero.bingo();
            if (hayBingo)
            {
                System.Console.WriteLine(numero_extraido);
                System.Console.WriteLine("Bingo!!!");
                tablero.print();
                List<int> unmarked = tablero.unmarked();
                int mult = 0;
                foreach (int x in unmarked)
                {
                    System.Console.Write(x+" ");
                    mult = mult + x;
                }
                //System.Console.WriteLine("Suma: "+mult);
                mult = mult * numero_extraido;
                System.Console.WriteLine("Resultado: "+mult);
            }
        }            
        
        tableros_comprobados++;        
    }
    //System.Console.WriteLine("Compruebo: "+tableros_comprobados+" tableros.");
    int count = 0;
    foreach (Tablero tablero in tableros)
    {
        if (tablero.getTerminado())
        {
            count++;
        }
    }
    //System.Console.WriteLine("quedan: "+count+" tableros");
}





public class Tablero
{
    int[,] numbers = new int[5,5];
    bool[,] checks = new bool[5,5];
    bool terminado;
    bool[,] real_marked = new bool[5,5];
    public Tablero(int[,] numeros )
    {
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                this.numbers[i,j] = numeros[i,j];
                this.checks[i,j] = false;
                this.real_marked[i,j] = false;
            }
        }
        this.terminado = false;
    }

    public void setCheck(int i,int j)
    {
        this.checks[i,j] = true;
    }

    public List<int> unmarked()
    {
        List<int> unmarked = new List<int>();
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {                
                if (!this.checks[i,j])
                {
                    unmarked.Add(numbers[i,j]);
                }
            }
        }
        return unmarked;
    }

    public List<int> real_unmarked()
    {
        List<int> unmarked = new List<int>();
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {                
                if (!this.real_marked[i,j])
                {
                    unmarked.Add(numbers[i,j]);
                }
            }
        }
        return unmarked;
    }

    public bool bingo()
    {        
        bool bingo_vertical=false;
        bool bingo_horizontal=false;
        //check for horizontal
        int i=0;
        int j=0;
        while (!bingo_horizontal && i<5)
        {
            bingo_horizontal = this.checks[i,0] && this.checks[i,1] && this.checks[i,2] && this.checks[i,3] && this.checks[i,4];
            if (bingo_horizontal)
            {
                real_marked[i,0] = true;
                real_marked[i,1] = true;
                real_marked[i,2] = true;
                real_marked[i,3] = true;
                real_marked[i,4] = true;
                this.terminado = true;
            }
            i++;
        }
        //check for vertical
        while (!bingo_vertical && j<5)
        {
            bingo_vertical = this.checks[0,j] && this.checks[1,j] && this.checks[2,j] && this.checks[3,j] && this.checks[4,j];
            if (bingo_vertical)
            {
                real_marked[0,j] = true;
                real_marked[1,j] = true;
                real_marked[2,j] = true;
                real_marked[3,j] = true;
                real_marked[4,j] = true;
                this.terminado = true;
                
            }
            j++;
        }
        //check both diagonales
        //bingo = this.checks[0,0] && this.checks[1,1] && this.checks[2,2] && this.checks[3,3] && this.checks[4,4];
        //bingo = this.checks[4,0] && this.checks[3,1] && this.checks[2,2] && this.checks[1,3] && this.checks[0,4];
        return bingo_vertical || bingo_horizontal;
    }

    public void print()
    {
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                System.Console.Write(numbers[i,j]+" ");
            }
            System.Console.WriteLine();
        }
    }

    public void check_number(int n)
    {
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                if (numbers[i,j] == n)
                {
                    setCheck(i,j);
                }
            }            
        }
    }

    public bool getTerminado()
    {
        return terminado;
    }
}