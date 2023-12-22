using System;

namespace eighthSolution
{
    internal abstract class Program
    {
        #region Methods
        /* Поиск максимального значения в блоке */
        private static int s_findMaxValueOfBlockMethod(int[] arr, int left, int right)
        {
            // присваиваем первый элемент
            int max = arr[0]; 

            // проходимся по блоку
            for (int i = left; i < right; i++)
                // если элемент меньше элемента массива
                if (max < arr[i])
                    // то присваиваем его
                    max = arr[i];
  
            // возвращаем максимальное значение
            return max;
        }

        /* Поиск максимального значения в массиве */
        private static int s_findMaxValueOfArrayMethod(int[] arr)
        {
            // создаём размерность N
            int n = (int)Math.Sqrt(arr.Length) + 1;
            // создаём размер блока
            int blockSize = (arr.Length / n);
            // создаём массив максимальных элементов
            int[] arrayMax = new int[n];

            // проходимся по блокам
            for (int i = 0; i < n; i++)
            {
                // создаём начало блока
                int arrLeft = i * blockSize;
                // создаём конец блока
                int arrRight = Math.Min((i + 1) * blockSize, arr.Length);
                // ищем максимальный элемент и добалвяем его в массив
                arrayMax[i] += s_findMaxValueOfBlockMethod(arr, arrLeft, arrRight);
            }
            
            // вызываем поиск максимального элемента массива
            // и возвращаем результат
            return s_findMaxValueOfBlockMethod(arrayMax, 0, arrayMax.Length); 
        }

        /* Изменение элемента массива */
        private static void s_getValueMethod(int[] arr, int[] maxArr, int i, int x)
        {
            arr[i] = x;
            for (int j = 0; j < maxArr[j]; j++)
            {

            }
        }
        #endregion

        /* Главный метод */
        public static void Main()
        {
            // создаём массив
            int[] array = { 1, 5, 2, 4, 6, 1, 3, 5, 7, 8, 1, 9 };

            // выводим массив
            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            // выводим максимальный элемент
            Console.WriteLine($"\nМаксимальный элемент в массиве: {s_findMaxValueOfArrayMethod(array)}");
        }
    }
}


// сайт с алгоритмами: https://e-maxx.ru/algo/sqrt_decomposition
