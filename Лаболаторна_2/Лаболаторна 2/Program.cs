using System;

namespace Лаболаторна_2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose blok of tasks 1-3: ");
            int a = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Blok1();
                    break;
                case 2:
                    Blok2();
                    break;
                case 3:
                    Blok3();
                    break;
            }
        }

        static void Blok1()
        {
            Console.WriteLine("Task: вставити після кожного парного елемента елемент із значенням 0");
            Console.WriteLine("Оберіть способ вводу (1 - вручну, 2 - рандом)");
            int choose = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Size of array: ");
            int size = Int32.Parse(Console.ReadLine());
            int[] array = new int[size];
            if (choose == 2)
            {
                Avto(size, array);
            }
            else Manual(size, ref array);

            static void Avto(int size, int[] array)
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = rnd.Next(100);
                }
            }
            static void Manual(int size, ref int[] array)
            {
                Console.WriteLine("Enter a value: ");
                string str = Console.ReadLine();
                String[] strArr = str.Split();
                array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = Int32.Parse(strArr[i]);
                }
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    counter++;
                }
            }
            int[] NewArray = new int[array.Length + counter];
            int CounterForArray = 0;
            for (int i = 0; i < NewArray.Length; i++)
            {
                if (array[CounterForArray] % 2 != 0)
                {
                    NewArray[i] = array[CounterForArray];
                    CounterForArray++;
                }
                else
                {
                    NewArray[i] = array[CounterForArray];
                    NewArray[i + 1] = 0;
                    CounterForArray++;
                    i++;
                }
            }
            Console.WriteLine("Відповідь:");
            foreach (int i in NewArray)
            {
                Console.Write(i + " ");
            }
        }
        static void Blok2()
            {
                //Завдання
                Console.WriteLine("Додати рядок перед рядком, що містить найменший елемент (якщо у різних місцях є кілька елементів з " +
                                  "\n однаковим мінімальним значенням, то брати перший з них)");

                //Заповнення
                Console.WriteLine("Enter num of lines");
                int NumOfLines = Int32.Parse(Console.ReadLine());
                int[][] Array2d = new int[NumOfLines][];
                Console.WriteLine("Оберіть способ вводу (1 - вручну, 2 - рандом)");
                int choose =  Int32.Parse(Console.ReadLine());
                if(choose == 2)
                {
                    Avto(Array2d, NumOfLines);
                }
                else Manual(Array2d, NumOfLines);
                static void Avto(int[][] Array2d, int NumOfLines)
                {
                    Random rnd = new Random();
                    for (int i = 0; i < NumOfLines; i++)
                    {
                        
                        int SizeOfArray = rnd.Next(3, 8);
                        Console.WriteLine("Size of {0} line {1}", i + 1, SizeOfArray);
                        Array2d[i] = new int[SizeOfArray];

                        for (int j = 0; j < SizeOfArray; j++)
                        {
                            Array2d[i][j] = rnd.Next(0, 100);
                        }
                    }
                }
                static void Manual(int[][] Array2d, int NumOfLines)
                {
                    for (int i = 0; i < NumOfLines; i++)
                    {
                        Console.WriteLine("Size of {0} line: ", i + 1);
                        int SizeOfArray = Int32.Parse(Console.ReadLine());
                        Array2d[i] = new int[SizeOfArray];

                        Console.WriteLine("Enter numbers of this line");
                        string str = Console.ReadLine();
                        String[] strArr = str.Split();
                        for (int j = 0; j < SizeOfArray; j++)
                        {
                            Array2d[i][j] = Int32.Parse(strArr[j]);
                        }
                    }
                }
                

                //Пошук мінімуму
                int[] Min = new int[3];
                Min[0] = Array2d[0][0];
                Min[1] = 0;
                Min[2] = 0;
                for (int i = 0; i < NumOfLines; i++)
                {
                    for (int j = 0; j < Array2d[i].Length; j++)
                    {
                        if (Array2d[i][j] < Min[0])
                        {
                            Min[0] = Array2d[i][j];
                            Min[1] = i;
                            Min[2] = j;
                        }
                    }
                }

                //Виконання завдання
                int[][] ArrayV2 = new int[NumOfLines + 1][];

                int counter = 0;
                for (int i = 0; i < Min[1]; i++)
                {
                    ArrayV2[i] = new int[Array2d[i].Length];
                    for (int j = 0; j < Array2d[i].Length; j++)
                    {
                        ArrayV2[i][j] = Array2d[i][j];
                    }
                    counter++;
                }

                ArrayV2[counter] = new int[] { 0, 0, 0 };
                for (int i = counter + 1; i < NumOfLines + 1; i++)
                {
                    ArrayV2[i] = new int[Array2d[i - 1].Length];
                    for (int j = 0; j < Array2d[i - 1].Length; j++)
                    {
                        ArrayV2[i][j] = Array2d[i - 1][j];
                    }
                }

                //Вивід масиву
                for (int i = 0; i < NumOfLines + 1; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < ArrayV2[i].Length; j++)
                    {
                        Console.Write(ArrayV2[i][j] + " ");
                    }
                }
            }
        static void Blok3()
        {
            Console.WriteLine("Реалізувати додавання двох матриць: S1, кількість елементів якої у кожному рядку є однаковою та S2," +
                    "\n яка в кожному рядку має різну кількість елементів.Додаються лише елементи на тих позиціях, які" +
                    "\n існують в кожній матриці, всі інші переходять до сумарної матриці без змін.В отриманій прямокутній" +
                    "\n сумарній матриці інвертувати порядок елементів кожного рядка.");
            //Ввід матриць
            int[] size = new int[2];
            int[,] Matrix1, Matrix2;
            Console.WriteLine("Оберіть способ вводу (1 - вручну, 2 - рандом)");
            int choose = Int32.Parse(Console.ReadLine());
            if (choose == 2)
            {
                //Заповненя першої матриці
                Random rnd = new Random();
                for (int i = 0; i < size.Length; i++)
                {
                    size[i] = rnd.Next(1, 10);
                }
                Matrix1 = new int[size[0], size[1]];
                for (int i = 0; i < size[0]; i++)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        Matrix1[i, j] = rnd.Next(0, 100);
                    }
                }
                //Заповнення другої матриці
                Matrix2 = new int[size[0], size[1]];
                Random rdm = new Random();
                for (int i = 0; i < Matrix2.GetLength(0); i++)
                {
                    int length = rdm.Next(1, size[0]);
                    for (int j = 0; j < length; j++)
                    {
                        Matrix2[i, j] = rdm.Next(0, 100);
                    }
                }
            }
            else
            {
                //Заповненя першої матриці
                Console.WriteLine("Enter size of the first matrix(y x)");
                string STRsize = Console.ReadLine();
                String[] ArrStrsize = STRsize.Split();
                for (int i = 0; i < size.Length; i++)
                {
                    size[i] = Int32.Parse(ArrStrsize[i]);
                }


                Matrix1 = new int[size[0], size[1]];

                for (int i = 0; i < size[0]; i++)
                {
                    Console.WriteLine("Enter the {0} line", i + 1);
                    string nums = Console.ReadLine();
                    String[] StrArrOfNums = nums.Split();
                    for (int j = 0; j < size[1]; j++)
                    {
                        Matrix1[i, j] = Int32.Parse(StrArrOfNums[j]);
                    }
                }

                //Заповнення другої матриці
                Matrix2 = new int[size[0], size[1]];
                Random rdm = new Random();
                for (int i = 0; i < Matrix2.GetLength(0); i++)
                {
                    int length = rdm.Next(1, size[0]-1);
                    for (int j = 0; j < length; j++)
                    {
                        Matrix2[i, j] = rdm.Next(0, 100);
                    }
                }

            }

            //Вивід матриць
            Console.WriteLine("First matrix");
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(Matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Second matrix");
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(Matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }

            //Виконання завдання
            int[,] sum = new int[size[0], size[1]];
            for (int i = 0; i < sum.GetLength(0); i++)
            {
                for (int j = 0; j < sum.GetLength(1); j++)
                {
                    sum[i, j] = Matrix1[i, j] + Matrix2[i, j];
                }
            }

            //Вивід матриць
            for (int i = 0; i < sum.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < sum.GetLength(1); j++)
                {
                    Console.Write(sum[i, j] + " ");
                }
            }
        }
    }
    
}
