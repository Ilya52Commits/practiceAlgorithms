using System;
using System.Collections.Generic;

namespace secondSolution;
internal abstract class Program
{
  /* Bucket sorting method */
  private static void s_bucketSort(IList<int> arr, int arrSize)
  { 
    // Создание временного массива "карманов" в количестве,
    // достаточном для хранения всех возможных элементов
    var bucket = new int[10][];
    for (var i = 0; i < 10; i++)
      bucket[i] = new int[arrSize + 1];
    
    // инициализация массива bucket
    for (var x = 0; x < 10; x++)
      bucket[x][arrSize] = 0;
    // основной цикл для каждого разряда
    for (var digit = 1; digit <= 1000000000; digit *= 10)
    {
      // заепись в массив bucket 
      for (var i = 0; i < arrSize; i++)
      {
        // получение цифр 0-9
        var dig = (arr[i] / digit) % 10;
        // добавить число в массив bucket и увеличивает счётчик
        bucket[dig][bucket[dig][arrSize]++] = arr[i];
      }
      // запись карманов в массив
      var idx = 0;
      for (var x = 0; x < 10; x++)
      {
        for (var y = 0; y < bucket[x][arrSize]; y++)
          arr[idx++] = bucket[x][y];
        // обнуление массива bucket
        bucket[x][arrSize] = 0;
      }
    }
    for (var i = 0; i < 10; i++)
      bucket[i] = null;
  }
  
  /* Main method */
  public static void Main()
  {
    int[] array = { 100, 97, 3, 28, 15, 17, 6, 127 };
    var arraySize = array.Length;

    s_bucketSort(array, arraySize);

    foreach (var value in array)
      Console.WriteLine(value);
  }
}