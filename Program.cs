using System;
using System.Collections.Generic;

namespace ConsoleApp1;
internal abstract class Program
{
  #region Methods 
  /* Pyramid sorting method */
  private static void s_pyramidSortingMethod(int[] arr)
  {
    var n = arr.Length;
 
    for (var i = n / 2 - 1; i >= 0; i--)
      s_buildingPyramidMethod(arr, n, i);

    for (var i = n - 1; i > 0; i--) 
    {
      (arr[0], arr[i]) = (arr[i], arr[0]);
      s_buildingPyramidMethod(arr, i, 0);
    }
  }

  /* Method of building a pyramid */
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

  /* Main method */
  public static void Main()
  {
    int[] array = { 12, 11, 13, 5, 6, 7 };
      
    s_pyramidSortingMethod(array);
      
    foreach (var value in array)
      Console.WriteLine(value);
  }
}