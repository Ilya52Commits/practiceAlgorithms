using System;

namespace eighthSolution;
internal abstract class Program
{
  #region Variables
  /* Создаём массив */
  private static readonly int[] Array = { 1, 5, 2, 4, 6, 1, 3, 5, 7, 8, 9 };
  /* Создаём размер блока */
  private static readonly int N = (int)Math.Sqrt(Array.Length) + 1;
  /* Массив максимальных элементов в блоке */
  private static readonly int[] ArrayMax = new int[N];
  #endregion
  
  #region Methods
  /* Поиск максимального значения в диапазоне */
  private static int s_findMaxValueMethod(int left, int right)
  {
    // обозначаем максимальный
    // элемент как начальный
    var max = Array[left];
    // считаем начальный блок 
    var c1 = left / N;
    // считаем конечный блок
    var c2 = right / N;
    
    // если начальный блок равен конечному
    if (c1 == c2)
    {
      // проходимся от левого до правого диапазона
      for (var i = left; i <= right; ++i)
        // если элемент массива
        // больше максимального
        if (max < Array[i])
          // присваиваем новый
          // максимальный элемент
          max = Array[i]; 
    }
    else
    {
      // проходимся от
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

  /* Построение массива максимальных элементов */
  private static void s_buildArrayMaxValueMethod()
  {
    for (var i = 0; i < N; i++)
    {
      var arrLeft = i * N;
      var arrRight = Math.Min((i + 1) * N, Array.Length);
      ArrayMax[i] += s_findMaxValueBlock(arrLeft, arrRight);
    }
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
    int k = blockIndex * N;
    for (var i = 0; i < N; i++)
    {
      if (k >= Array.Length)
        return; 
      if (max < Array[k])
        max = Array[k];
      k++;
    }

    ArrayMax[blockIndex] = max; 
  }
  #endregion

  /* Главный метод */
  public static void Main()
  {
    // вывод массива
    foreach (var value in Array)
      Console.Write(value + " ");
    Console.WriteLine();
    // построение массива максимальных элементов
    s_buildArrayMaxValueMethod();
    // вывод массива максимальных элементов
    for (int i = 0; i < ArrayMax.Length - 1; i++)
      Console.Write(ArrayMax[i] + " ");
    Console.WriteLine();
    // выводим максимальный элемент
    Console.WriteLine($"Максимальный элемет в диапазоне: {s_findMaxValueMethod(1, 3)}");
    // изменяем элемент массива
    s_getValueMethod(8, 3);
    // выводим исходный массив после изменения
    foreach (var value in Array)
      Console.Write(value + " ");
    Console.WriteLine();
    // выводим массив максимальных элементов после изменения
    for (int i = 0; i < ArrayMax.Length - 1; i++)
      Console.Write(ArrayMax[i] + " ");
  }
}