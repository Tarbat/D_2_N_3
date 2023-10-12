using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

class HelloWorld
{
    public static int[] Init(int[] Ar) // Инициализация
    {
        Random rnd = new Random();

        Console.Write("N - Array Size = ");
        int N1 = Convert.ToInt32(Console.ReadLine());
        Array.Resize(ref Ar, N1);

        int Len = Ar.Length;

        for (int i = 0; i != Len; i++)
        {
            Ar[i] = rnd.Next(0, 10);
        }

        return Ar;
    }

    public static void Print(int[] Ar) // Вывод
    {
        Console.Write("Array: ");
        for (int i = 0; i != Ar.Length; i++)
        {
            Console.Write(Ar[i].ToString() + " ");
        }
        Console.WriteLine();
    }

    public static int[] Total(int[] Ar1, int[] Ar2) // Сумма
    {
        int[] ArNew = new int[Ar1.Length];

        if (Ar1.Length == Ar2.Length)
        {
            for (int i = 0; i != Ar1.Length; i++)
            {
                ArNew[i] = Ar1[i] + Ar2[i];
            }
        }
        else return Ar1;

        return ArNew;
    }

    public static int[] Multi(int[] Ar, int M) // Умножение
    {
        int[] ArNew = new int[Ar.Length];

        for (int i = 0; i != Ar.Length; i++)
        {
            ArNew[i] = Ar[i] * M;
        }

        return ArNew;
    }
    
    public static void Sorting(int[] Ar) // Сортировка
    {
        int temp;

        for (int write = 0; write < Ar.Length; write++)
        {
            for (int sort = 0; sort < Ar.Length - 1; sort++)
            {
                if (Ar[sort] < Ar[sort + 1])
                {
                    temp = Ar[sort + 1];
                    Ar[sort + 1] = Ar[sort];
                    Ar[sort] = temp;
                }
            }
        }
    }

    public static void Single_values(int[] Ar1, int[] Ar2) // Одинаковые значения
    {
        int[] Ar_Sin1 = Ar1; int[] Ar_Sin_Un1 = new int[Ar1.Length];
        int[] Ar_Sin2 = Ar2; int[] Ar_Sin_Un2 = new int[Ar2.Length];
        int count1 = 0, Num_Un1 = 0, count2 = 0, Num_Un2 = 0;
        Sorting(Ar_Sin1);
        Sorting(Ar_Sin2);

        Ar_Sin_Un1[0] = Ar_Sin1[0];

        for (int i = 0; i != Ar_Sin1.Length; i++)
        {
            for (int j = 0; j != Ar_Sin_Un1.Length; j++)
            {
                if (Ar_Sin1[i] == Ar_Sin_Un1[j]) { Num_Un1++;}
            }
            if (Num_Un1 == 0) { count1++; Ar_Sin_Un1[count1] = Ar_Sin1[i];}
            Num_Un1 = 0;
        }

        Ar_Sin_Un2[0] = Ar_Sin2[0];

        for (int i = 0; i != Ar_Sin2.Length; i++)
        {
            for (int j = 0; j != Ar_Sin_Un2.Length; j++)
            {
                if (Ar_Sin2[i] == Ar_Sin_Un2[j]) { Num_Un2++; }
            }
            if (Num_Un2 == 0) { count2++; Ar_Sin_Un2[count2] = Ar_Sin2[i]; }
            Num_Un2 = 0;
        }

        for (int i = 0; i != count1; i++)
            for (int j = 0; j != count2; j++) {
                if (Ar_Sin_Un1[i] == Ar_Sin_Un2[j]) { Console.Write(Ar_Sin_Un1[i] + " "); break;}
            }
    }

    public static int MinArr(int[] Ar) // Минимум
    {
        int Min = 99999;

        for (int i = 0; i != Ar.Length; i++)
        {
            if (Min > Ar[i]) Min = Ar[i];
        }

        return Min;
    }

    public static int MaxArr(int[] Ar) // Максимум
    {
        int Max = -1;

        for (int i = 0; i != Ar.Length; i++)
        {
            if (Max < Ar[i]) Max = Ar[i];
        }

        return Max;
    }

    public static double AverArr(int[] Ar) // Среднее значение
    {
        double Sum = 0;

        for (int i = 0; i != Ar.Length; i++)
        {
            Sum += Ar[i];
        }

        Sum = Sum / Ar.Length;

        return Sum;
    }


    static void Main()
    {
        int[] num1 = new int[2] { 0, 1 };
        int[] num2 = new int[2] { 0, 1 };
        int code = 0;

        for (;;)
        {
            Console.WriteLine("1 - Инициализировать массив");
            Console.WriteLine("2 - Сложить массивы");
            Console.WriteLine("3 - Умножить массив на число");
            Console.WriteLine("4 - Найти общие значения в массивах");
            Console.WriteLine("5 - Отсортировать массив по убыванию");
            Console.WriteLine("6 - Минимум массива");
            Console.WriteLine("7 - Максимум массива");
            Console.WriteLine("8 - Среднее значение массива");
            Console.WriteLine("9 - Печать массива");
            Console.WriteLine("10 - Выход");

            while (code <= 0 || code > 10)
            {
                Console.Write("Code - ");
                code = Convert.ToInt32(Console.ReadLine());
            }

            switch (code)
            {

                case 1:
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    int NumAr = Convert.ToInt32(Console.ReadLine());
                    if (NumAr == 1) num1 = Init(num1);
                    if (NumAr == 2) num2 = Init(num2);
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Sum: ");

                    int[] numT = Total(num1, num2);
                    if (numT != num1) { Print(numT); }
                    else Console.WriteLine("The number of array elements is not equal");
                    break;

                case 3:
                    int[] numM = null;

                    Console.WriteLine();
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    NumAr = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.Write("Multiply the matrix by: ");
                    int Mul = Convert.ToInt32(Console.ReadLine());

                    if (NumAr == 1) { numM = Multi(num1, Mul); }
                    if (NumAr == 2) { numM = Multi(num2, Mul); }

                    Print(numM);
                    break;

                case 4:
                    Console.Write("Identical array values = "); Single_values(num1, num2);
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine();
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    NumAr = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine();
                    if (NumAr == 1) { Sorting(num1); Console.Write("Sort Array = "); Print(num1); }
                    if (NumAr == 2) { Sorting(num2); Console.Write("Sort Array = "); Print(num2); }
                    break;

                case 6:
                    Console.WriteLine();
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    NumAr = Convert.ToInt32(Console.ReadLine());

                    if (NumAr == 1) { Console.Write("Min = " + MinArr(num1)); }
                    if (NumAr == 2) { Console.Write("Min = " + MinArr(num2)); }
                    Console.WriteLine();
                    break;

                case 7:
                    Console.WriteLine();
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    NumAr = Convert.ToInt32(Console.ReadLine());

                    if (NumAr == 1) { Console.Write("Max = " + MaxArr(num1)); }
                    if (NumAr == 2) { Console.Write("Max = " + MaxArr(num2)); }
                    Console.WriteLine();
                    break;

                case 8:
                    Console.WriteLine();
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    NumAr = Convert.ToInt32(Console.ReadLine());

                    if (NumAr == 1) { Console.Write("Average = " + AverArr(num1)); }
                    if (NumAr == 2) { Console.Write("Average = " + AverArr(num2)); }
                    Console.WriteLine();
                    break;

                case 9:
                    Console.WriteLine();
                    Console.Write("Selecting an initiated array (1 or 2) - ");
                    NumAr = Convert.ToInt32(Console.ReadLine());

                    if (NumAr == 1) { Print(num1); }
                    if (NumAr == 2) { Print(num2); }
                    Console.WriteLine();
                    break;

                case 10:
                    return;
            }

            code = 0;
            Console.WriteLine();
        }
    }
}