using System;

namespace number_28131
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задача: На вход программы поступает последовательность из n целых положительных чисел.
            Рассматриваются все пары элементов последовательности a[i] и a[j], такие что i < j и a[i] > a[j]
            (первый элемент пары больше второго; i и j — порядковые номера чисел в последовательности входных данных). 
            Среди пар, удовлетворяющих этому условию, необходимо найти и напечатать пару с максимальной суммой элементов, 
            которая делится на m = 120. Если среди найденных пар максимальную сумму имеют несколько, 
            то можно напечатать любую из них. */

            Console.Write("Введите кол-во чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = 120;
            int left = 0;
            int right = 0;

            if (n % 2 == 0)
            {
                Random rand = new Random();
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = rand.Next(0, 10000);
                    Console.WriteLine(array[i] + " ");
                }

                for (int i = 0; i < n; i++)
                {
                    int p = array[i] % m;
                    if (p == 0) { p = m; }
                    
                    try
                    {
                        if (array[m - p] > array[i] & array[m - p] + array[i] > left + right)
                        {
                            left = array[m - p];
                            right = array[i];
                        }
                    }
                    catch
                    {
                       // Console.WriteLine("Слишком малое количество чисел. Скрипт ловит исключение. ");
                        break;
                    }

                    finally
                    {

                    }

                    try
                    {
                        if (p < m)
                        {
                            if (array[i] > array[p]) { array[p] = array[i]; }
                            else if (array[i] > array[0]) { array[0] = array[i]; }
                        }
                    }
                    catch
                    {
                       // Console.WriteLine("Слишком малое кол-во элементов. Скрипт ловит исключение. ");
                        break;
                    }
                    
                }

                Console.WriteLine("Пара чисел с максимальной суммой элементов, которая делится на 120: " + left + " " + right);
            }
            else { Console.WriteLine("Введено нечетное число"); }
            
           
        }
    }
}
