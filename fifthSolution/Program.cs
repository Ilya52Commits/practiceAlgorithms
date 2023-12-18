using System;

namespace fifthSolution
{
  internal abstract class Program
  {
    /* binary search method */
    private static int s_binarySearch(int[] array, int item, int n) 
    {
      var low = 0;
      var high = array.Length - 1;

      while (low <= high)
      {
        var mid = (low + high) / 2;
        var guess = array[mid];

        if (item == guess)
          return mid;
        else if (item < guess) 
          high = mid - 1;
        else 
          low = mid + 1;
      }

      return -1; 
    }

    /* Main method */
    public static void Main()
    {
      int[] array = { 1, 3, 5, 7, 9 };

      Console.WriteLine(s_binarySearch(array, 1 , 5)); // 1 => 0
      Console.WriteLine(s_binarySearch(array, -2, 5)); // -1 => -1
    }
  }
}
