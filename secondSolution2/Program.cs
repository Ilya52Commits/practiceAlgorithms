using System;

namespace secondSolution
{
    internal abstract class Program
    {
        /* bucket sorting mathod */
        private static void s_bucketSort(int[] arr, int arrSize)
        {
            int max = arrSize;
            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов
            int[][] bucket = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                bucket[i] = new int[max + 1];
            }
            // инициализация массива bucket
            for (int x = 0; x < 10; x++)
                bucket[x][max] = 0;
            // основной цикл для каждого разряда
            for (int digit = 1; digit <= 1000000000; digit *= 10)
            {
                // заепись в массив bucket 
                for (int i = 0; i < max; i++)
                {
                    // получение цифр 0-9
                    int dig = (arr[i] / digit) % 10;
                    // добавить число в массив bucket и увеличивает счётчик
                    bucket[dig][bucket[dig][max]++] = arr[i];
                }
                // запись карманов в массив
                int idx = 0;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < bucket[x][max]; y++)
                    {
                        arr[idx++] = bucket[x][y];
                    }
                    // обнуление массива bucket
                    bucket[x][max] = 0;
                }
            }
            for (int i = 0; i < 10; i++)
                bucket[i] = null;

            bucket = null;

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }


        /* Main method */
        public static void Main()
        {
            int[] array = { 100, 97, 3, 28, 15, 17, 6, 127 };
            int arraySize = array.Length;

            s_bucketSort(array, arraySize);
        }
    }
}