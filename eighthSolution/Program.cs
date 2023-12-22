using System;
using System.Collections.Generic;

namespace eighthSolution;
internal abstract class Program
{
  #region Variables
  /* Создаём массив */
  private static readonly int[] Array = { 1, 5, 2, 4, 6, 1, 3, 5, 7, 8, 9 };
  /* Создаём размер блока */
  private static readonly int N = (int)Math.Sqrt(Array.Length) + 1;
  /* Массив максимальных элементов в блоке */
  private static readonly int[] B = new int[N];
  #endregion
  
  #region Methods
  /* Поиск максимального значения в диапазоне */
  private static int s_findMaxValueMethod(int left, int right)
  {
    var max = Array[left];
    var c1 = left / N;
    var c2 = right / N;
       
    for (var i = 0; i < N; i++)
    {
      var arrLeft = i * N;
      var arrRight = Math.Min((i + 1) * N, Array.Length);
      B[i] += s_findMaxValueBlock(arrLeft, arrRight);
    }
    
    if (c1 == c2)
    {
      for (var i = left; i <= right; ++i)
        if (max < Array[i])
          max = Array[i];
    }
    else
    {
      for (int i = left, end = (c1 + 1) * N - 1; i <= end; ++i)
        if (max < Array[i])
          max = Array[i];
      for (var i= c1 + 1; i <= c2 - 1; ++i)
        if (max < Array[i])
          max = Array[i];
      for (var i= c2 * N; i <= right; ++i)
        if (max < Array[i])
          max = Array[i];
    }
    
    return max; 
  }

  /* Нахождение максимального элемента в блоке */
  private static int s_findMaxValueBlock(int left, int right)
  {
    var max = 0; 
    
    // проходимся по блоку
    for (var i = left; i < right; i++)
      // если элемент меньше элемента массива
      if (max < Array[i])
        // то присваиваем его
        max = Array[i];
  
    // возвращаем максимальное значение
    return max;
  }

  /* Изменение элемента массива */
  private static void s_getValueMethod(int index, int value)
  {
    Array[index] = value;
    var blockIndex = (index / N);
    var max = Array[blockIndex * N]; 
    for (var i = blockIndex * N; i < index + N; i++)
      if (max < Array[i])
        max = Array[i];

    B[blockIndex] = max; 
  }
  #endregion

  /* Главный метод */
  public static void Main()
  {
    // выводим максимальный элемент
    Console.WriteLine(s_findMaxValueMethod(1,3));
    s_getValueMethod(8, 3);
    
    foreach (var value in Array)
      Console.WriteLine(value);
    foreach (var value in B)
      Console.WriteLine(value);
  }
}