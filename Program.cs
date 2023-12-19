using System;
using System.Collections.Generic;

namespace ConsoleApp1;
internal abstract class Program
{
  #region Methods 
  /* Метод сортировки пирамидой */
  private static void s_pyramidSortingMethod(IList<int> arr)
  {
    // присваиваем длину массива
    var n = arr.Count;
    
    for (var i = n / 2 - 1; i >= 0; i--)
      s_buildingPyramidMethod(arr, n, i);

    for (var i = n - 1; i > 0; i--) 
    {
      (arr[0], arr[i]) = (arr[i], arr[0]);
      s_buildingPyramidMethod(arr, i, 0);
    }
  }

  /* Метод построение пирамиды */
  private static void s_buildingPyramidMethod(IList<int> arr, int n, int i)
  {
    while (true)
    {
      var less = i;
      var l = 2 * i + 1;
      var r = 2 * i + 2;

      if (l < n && arr[l] < arr[less]) less = l;

      if (r < n && arr[r] < arr[less]) less = r;

      if (less != i)
      {
        (arr[i], arr[less]) = (arr[less], arr[i]);
        i = less;
        continue;
      }

      break;
    }
  }
  #endregion

  /* Главный метод */
  public static void Main()
  {
    int[] array = { 12, 11, 13, 5, 6, 7 };
      
    s_pyramidSortingMethod(array);
      
    foreach (var value in array)
      Console.WriteLine(value);
  }
}