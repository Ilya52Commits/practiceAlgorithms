using System;

namespace seventhSolution
{
  internal abstract class Program
  {
    /* interpolation search method */
    private static int s_interpolationgSearch(int[] a, int n, int key) 
    {
      // изначально устанавливаем нижний индекс на начало массива,
      // а верний на конец массива
      int lo = 0;
      int hi = n - 1;
      int mid = -1;
      int index = -1;

      while (lo <= hi)
      {
        mid = lo + (((hi - lo) / (a[hi] - a[lo])) * (key - a[lo])); 

        if (a[mid] == key) 
        {
          index = mid;
          break;
        }
        else 
        {
          if (a[mid] < key)
          {
            // если значение в ячейке с индексом mid меньше,
            // то смещаем нижюю границу
            lo = mid + 1;
          } 
          else
          {
            // в случае, если значение больше, то смещаем верхнюю границу
            hi = mid - 1;
          }
        }
      }

      return index;
    }

    /* Main method */
    public static void Main()
    {
      int[] array = { 1, 4, 5, 7, 9, 11, 13, 16, 18, 20, 25, 27, 30, 32, 33, 36, 39, 41, 44, 47, 51, 53, 55 };

      Console.WriteLine(s_interpolationgSearch(array, 23, 27));
    }
  }
}
