using System;
using System.Collections.Generic;

namespace seventhSolution;

internal abstract class Program
{
  /* Interpolation search method */
  private static int s_interpolationSearchMethod(IReadOnlyList<int> a, int n, int key)
  {
    // изначально устанавливаем нижний индекс на начало массива,
    // а верний на конец массива
    var left = 0;
    var height = n - 1;
    var index = -1;

    while (left <= height)
    {
      var mid = left + (((height - left) / (a[height] - a[left])) * (key - a[left]));

      if (a[mid] == key)
      {
        index = mid;
        break;
      }

      if (a[mid] < key)
      {
        // если значение в ячейке с индексом mid меньше,
        // то смещаем нижюю границу
        left = mid + 1;
      }
      else
      {
        // в случае, если значение больше, то смещаем верхнюю границу
        height = mid - 1;
      }
    }

    return index;
  }

  /* Main method */
  public static void Main()
  {
    int[] array = { 1, 4, 5, 7, 9, 11, 13, 16, 18, 20, 25, 27, 30, 32, 33, 36, 39, 41, 44, 47, 51, 53, 55 };
    Console.WriteLine(s_interpolationSearchMethod(array, 23, 27));
  }
}