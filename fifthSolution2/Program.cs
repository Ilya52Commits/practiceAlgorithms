using System;
using System.Collections.Generic;

namespace fifthSolution;
internal abstract class Program
{ 
  /* Binary search method */
  private static int s_binarySearch(IReadOnlyList<int> array, int item)
  {
    var left = 0;
    var right = array.Count - 1;

    while (left <= right)
    {
      var mid = (left + right) / 2;
      var guess = array[mid];

      if (item == guess)
        return mid;
      
      if (item < guess)
        right = mid - 1;
      else
        left = mid + 1;
    }

    return -1;
  }

  /* Main method */
  public static void Main()
  {
    int[] array = { 1, 3, 5, 7, 9 };

    Console.WriteLine(s_binarySearch(array, 1)); // 1 => 0
    Console.WriteLine(s_binarySearch(array, -2)); // -1 => -1
  }
}