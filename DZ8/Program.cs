using System;
using System.Data;
using System.Drawing;
using System.Xml;

namespace DZ8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(@"Выбери задачу
54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
62: Напишите программу, которая заполнит спирально массив 4 на 4.
q - выход из программы");



                string select = Console.ReadLine();
                switch (select)
                {
                    case "54":
                        Zad54();
                        break;
                    case "56":
                        Zad56();
                        break;
                    case "58":
                        Zad58();
                        break;
                    case "60":
                        Zad60();
                        break;
                    case "62":
                        Zad62();
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine();
            }
            
        }

        //Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
        static void Zad54()
        {
            Console.WriteLine("Введите m");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите n");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минимум");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимум");
            int max = int.Parse(Console.ReadLine());

            int[,] array = CreateArray2mInt(m, n, min, max);
            PrintArrayInt(array);
            Console.WriteLine();

            array = SotrBy(array);
            PrintArrayInt(array);

        }

        //Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов
        static void Zad56()
        {
            Console.WriteLine("Введите m");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите n");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минимум");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимум");
            int max = int.Parse(Console.ReadLine());

            int[,] array = CreateArray2mInt(m, n, min, max);
            PrintArrayInt(array);
            Console.WriteLine();

            Console.WriteLine(FindMinSum(array));
            

        }

        //Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
        static void Zad58()
        {
            int[,] array = CreateArray2mInt(2, 2, 1, 10);
            PrintArrayInt(array);
            Console.WriteLine();

            int[,] array2 = CreateArray2mInt(2, 3, 1, 10);
            PrintArrayInt(array2);
            Console.WriteLine();

            array = MultiplyArray(array, array2); 
            PrintArrayInt(array);


        }

        //Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

        static void Zad60() 
        {
            int[,,] array = CreateArray3mInt(2, 2, 2, 1, 100);
            PrinArray3D(array);
        }

        static void Zad62()
        {
            SpiralArray(4); //Можно любую размерность задать, универсально получилось
        }
        


        /// <summary>
        /// Создание массива
        /// </summary>
        /// <param name="m">Количество строк</param>
        /// <param name="n">Количество столбцов</param>
        /// <param name="min">Рандом минимальное</param>
        /// <param name="max">Рандом максимальное</param>
        /// <returns>Возвращает массив с заданными параметрами</returns>
        static int[,] CreateArray2mInt(int m, int n, int min, int max)
        {
            int[,] array = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = new Random().Next(min, max);
                }
            }
            return array;
        }

        /// <summary>
        /// Вывод массива на экран
        /// </summary>
        /// <param name="array">принимает массив</param>
        static void PrintArrayInt(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Сортирует массив от большего к меньшему в каждой строке
        /// </summary>
        /// <param name="matr">двумерный целочисленный массив</param>
        /// <returns>Отсортированный массив</returns>
        static int[,] SotrBy(int[,] matr)
        {

            int rows = 0;
            

            while (rows < matr.GetLength(1))
            {
                int min = matr[rows, 0];
                int columns = 0;
                for (int i = 0; i < matr.GetLength(1); i++)
                {

                    for (int j = 1; j < matr.GetLength(1) - i; j++)
                    {
                        if (min > matr[rows, j])
                        {
                            min = matr[rows, j];
                            columns = j;
                        }
                    }
                    int temp = matr[rows, columns];
                    matr[rows, columns] = matr[rows, matr.GetLength(1) - 1 - i];
                    matr[rows, matr.GetLength(1) -1 - i] = temp;
                    min = matr[rows, 0];
                    columns = 0;
                }


                rows++;

            }
            return matr;
        }

        /// <summary>
        /// считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов
        /// </summary>
        /// <param name="matr">Массив</param>
        /// <returns>номер строки в текстовом формате</returns>
        static string FindMinSum(int[,] matr)
        {
            int minRowsSum = 0;
            int min = int.MaxValue;
            

            for (int i = 0; i < matr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    sum += matr[i, j];
                }
                if (min > sum)
                {
                    min = sum;
                    minRowsSum = i;
                }
               
            }
            return $"{minRowsSum + 1} строка";

        }
        /// <summary>
        /// Возвращает произведение двух матриц
        /// </summary>
        /// <param name="matr">1 массив</param>
        /// <param name="matr2">2 массив</param>
        /// <returns>Возвращает произведение двух матриц</returns>
        static int[,] MultiplyArray(int[,] matr, int[,] matr2) 
        {
            if (matr.GetLength(0) == matr2.GetLength(0))
            {
                int[,] matrCopy = new int[matr.GetLength(0), matr.GetLength(1)];

                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        //matrCopy[i, j] = matr2[i, j] * matr[i, 0];
                        for (int k = 0; k < matr.GetLength(1); k++)
                        {
                            matrCopy[i, j] += matr[i, k] * matr2[k, j];
                        }
                    }
                }
                return matrCopy;
            }
            else
            {
                Console.WriteLine("Данные матрицы нельзя перемножить");
                return null;
            }
        }

        /// <summary>
        /// Создание трехмерного массива
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Возвращает трехмерный массив</returns>
        static int[,,] CreateArray3mInt(int x, int y, int z, int min, int max)
        {
            int[,,] array = new int[x, y, z];
            int number = 0;
            bool unique = true;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int m = 0; m < z; m++)
                    {
                        while (unique)
                        {
                            number = new Random().Next(min, max);
                            unique = TestNumberUniq(number, array);
                            if (!unique) array[i, j, m] = number;
                        }
                        unique = true;
                    }

                }
            }

            return array;
        }

        /// <summary>
        /// Проверка, на уникальность в трехмернном массиве
        /// </summary>
        /// <param name="number">Число для проверки на уникальность</param>
        /// <param name="array">массив в котором проверяем</param>
        /// <returns>Если число не уникальное возвращает TRUE</returns>
        static bool TestNumberUniq(int number, int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int m = 0; m < array.GetLength(2); m++)
                        {
                        if (array[i,j,m] == number)
                            return true;
                        }
                }
            }
            return false;
        }

        /// <summary>
        /// Выводим на экран трехмерный массив
        /// </summary>
        /// <param name="array">трех мерный массив</param>
        static void PrinArray3D(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int m = 0; m < array.GetLength(2); m++)
                    {
                        Console.Write($"{array[i, j, m]}({i},{j},{m}) ");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Выводит на экран спирально заполненый массив (квадратный)
        /// </summary>
        /// <param name="size">Размер массивв</param>
        static void SpiralArray(int size)
        {
            int[,] array = new int[size, size];

            int value = 1; 
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            int startX = 0;
            int endX = rows - 1;
            int startY = 0;
            int endY = columns - 1;

            while (value <= size * size)
            {
                // Вправо
                for (int i = startY; i <= endY; i++)
                {
                    array[startX, i] = value;
                    value++;
                }
                startX++; // Уменьшаем верхнюю границу

                // Вниз
                for (int i = startX; i <= endX; i++)
                {
                    array[i, endY] = value;
                    value++;
                }
                endY--; // Уменьшаем правую границу

                // Влево
                for (int i = endY; i >= startY; i--)
                {
                    array[endX, i] = value;
                    value++;
                }
                endX--; // Уменьшаем нижнюю границу

                // Вверх
                for (int i = endX; i >= startX; i--)
                {
                    array[i, startY] = value;
                    value++;
                }
                startY++; // Увеличиваем левую границу
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

    }
}