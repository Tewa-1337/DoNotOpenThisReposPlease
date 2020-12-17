﻿using System;
using System.IO;

namespace number_28131
{
    class Program
    {

        /* Задача: На вход программы поступает последовательность из n целых положительных чисел.
      Рассматриваются все пары элементов последовательности a[i] и a[j], такие что i < j и a[i] > a[j]
      (первый элемент пары больше второго; i и j — порядковые номера чисел в последовательности входных данных). 
      Среди пар, удовлетворяющих этому условию, необходимо найти и напечатать пару с максимальной суммой элементов, 
      которая делится на m = 120. Если среди найденных пар максимальную сумму имеют несколько, 
      то можно напечатать любую из них. */

        public static void log(string message)//метод для логгирования
        {
            try
            {
                File.AppendAllText("E:\\log.txt", message);//класс и метод для записи в файл
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }

        static void Main(string[] args)
        {
            log(DateTime.Now + "\n");
            Console.Write("Введите кол-во чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());//переменная для кол-ва чисел
            log("Ввод кол-ва чисел в массиве: " + n + '\n');
            int m = 120;//переменная - делитель элементов массива
            int left = 0;//левое число пары
            int right = 0;//правое число пары
            log("Объявление переменных и задание им значений: " + m + " " + left + " " + right + '\n');

            if (n % 2 == 0)//проверка на четность введенного кол-ва символов
            {
                log("Обьявление переменной rand" + '\n');
                Random rand = new Random();
                int[] array = new int[n];//обЪявление массива
                log("Объявление массива" + '\n');
                for (int i = 0; i < n; i++)
                {
                    array[i] = rand.Next(0, 10000);//заполнение массива случайными числами
                    Console.WriteLine(array[i]);
                    log("Элемент " + i + ": " + array[i] + '\n');
                }
                log("Массив заполнен случайными числами" + '\n');


                for (int i = 0; i < n; i++)
                {
                    int p = array[i] % m;//переменая остаток от деления элемента массива на 120
                    if (p == 0) { p = m; log("Переменной p присваивается значение " + p + '\n'); }

                    try
                    {
                        if (array[m - p] > array[i] & array[m - p] + array[i] > left + right)//поиск элемента с самой большой суммой цифр 
                        {
                            left = array[m - p];
                            log("Переменной left присваивается значение " + left + '\n');
                            right = array[i];
                            log("Переменной right присваивается значение " + right + '\n');
                        }
                    }

                    catch
                    {
                        //так как мы просто отлавливаем исключения для того, чтобы программа дальше работала без вылетов, то здесь ничего нет
                    }

                    try
                    {
                        if (p < m)
                        {
                            if (array[i] > array[p]) { array[p] = array[i]; log("Элемент массива " + p + " приравниватеся к элементу массива " + i + '\n'); }
                            else if (array[i] > array[0]) { array[0] = array[i]; log("Элемент массива " + 0 + " приравнивается к элементу массива " + i + '\n'); }
                        }
                    }

                    catch
                    {
                       //так как мы просто отлавливаем исключения для того, чтобы программа дальше работала без вылетов, то здесь ничего нет
                    }

                }
                Console.WriteLine("Пара чисел с максимальной суммой элементов, которая делится на 120: " + left + " " + right);
                log("Пара чисел: " + left + " и " + right + '\n');
            }

            else { Console.WriteLine("Введено нечетное число"); log("Введено нечетное число, значит не все числа будут иметь пару, что требуется по условию задачи"); }
            Console.ReadKey();
        }
    }
}
