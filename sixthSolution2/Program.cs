using System;

namespace sixthSolution
{
    internal abstract class Program
    {
        /* fibonaccian search method */
        private static int s_fibonaccianSearch(int[] arr, int n, int x)
        {
            /* Инициализация чисел Фибоначчи */
            var fibMMm2 = 0; // (m-2)-е число Фибоначчи
            var fibMMm1 = 1; // (m-1)-е число Фибоначчи
            var fibM = fibMMm2 + fibMMm1; // m-e число Фибоначчи
            var offset = -1; // отмечаем выбранный диапазон

            /* Находим диапазон чисел Фибоначчи, в котором находится число n */
            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            while (fibM > 1)
            {
                // Проверяем, является ли fibMm2 допустимым местоположением
                var i = Math.Min(offset + fibMMm2, n - 1);

                /* Если X больше, чем значение индекса fibMm2,
                исключить подмассив массива от offset to i */
                if (arr[i] < x)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                }
                /* Если X меньше, чем значение индекса fibMm2,
                исключить подмассив массива после i+1 */
                else if (arr[i] > x)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                }
                /* Элемент найден. Возвращаем индекс */
                else return i;
            }

            /* сравнение последнего элемента с x */
            if (fibMMm1 == x && arr[offset + 1] == x)
                return offset + 1;

            /*Элемент не найден. Возвращаем -1 */
            return -1;
        }

        /* Main method */
        public static void Main()
        {
            int[] array = { 1, 4, 5, 7, 9, 11, 13, 16, 18, 20, 25, 27, 30, 32, 33, 36, 39, 41, 44, 47, 51, 53, 55 };

            Console.WriteLine(s_fibonaccianSearch(array, 23, 27));
        }
    }
}
