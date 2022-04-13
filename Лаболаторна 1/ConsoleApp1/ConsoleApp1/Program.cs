Console.WriteLine("Введіть к-сть РЯДКІВ");    
int Y = Int32.Parse(Console.ReadLine());
Console.WriteLine("Введіть к-сть СТОПЧИКІВ");
int X = Int32.Parse(Console.ReadLine());
int[,] matrix = new int[Y, X];
Console.WriteLine("Введіть числа");

for (int i = 0; i < matrix.GetLength(0); i++)
{
    string[] str = Console.ReadLine().Trim().Split();
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = Int32.Parse(str[j]);
    }
    Console.WriteLine();
} 
TaskPlus(matrix);
static void TaskPlus(int[,] matrix)
{
    for (int i = 0; matrix.GetLength(0) < i; i++)
    {
        int[] coMax = new int [2] {i,1};
        int max = matrix[i,1];
        int[] coMin = new int[2] {i,1};
        int min = matrix[i, 1];
        for (int j = 0; j <= matrix.GetLength(1); j++)
        {
            if (matrix[i,j]>max)
            {
                max = matrix[i, j];
                coMax[0] = i;
                coMax[1] = j;
            }
            else
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    coMin[0] = i;
                    coMin[1] = j;
                }
            }
        }
        SwapMAX(max, coMax, matrix);
        SwapMIN(min, coMin, matrix);
        
    }
    Print(matrix);
}
static void SwapMAX(int max, int[] cooMAX, int[,] matrix)
{
    int mind = matrix[1,1];
    matrix[1, 1] = max;
    matrix[cooMAX[1], cooMAX[2]] = mind;
}
static void SwapMIN (int min, int[] cooMIN, int[,] matrix)
{
    int mind = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1)-1];
    matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] = min;
    matrix[cooMIN[1], cooMIN[2]] = mind;
}
static void Print (int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}