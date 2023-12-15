using System;

namespace ConsoleApp1
{
  internal abstract class Program
  {
    private static void s_stortHeap(int[] arr)
    {
        int N = arr.Length;
 
        for (int i = N / 2 - 1; i >= 0; i--)
            s_heapifyMethod(arr, N, i);

        for (int i = N - 1; i > 0; i--) {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
 
            s_heapifyMethod(arr, i, 0);
        }
    }

    private static void s_heapifyMethod(int[] arr, int N, int i)
    {
      int lessest = i; 
      int l = 2 * i + 1; 
      int r = 2 * i + 2; 

      if (l < N && arr[l] < arr[lessest])
        lessest = l;

      if (r < N && arr[r] < arr[lessest])
        lessest = r;

      if (lessest != i)
      {
        int swap = arr[i];
        arr[i] = arr[lessest];
        arr[lessest] = swap;

        s_heapifyMethod(arr, N, lessest);
      }
    }

    /* Главный метод */
    public static void Main()
    {
      int[] arr = { 12, 11, 13, 5, 6, 7 };
      int length = arr.Length;
      s_stortHeap(arr);

      for (int i = 0; i < arr.Length; i++)
        Console.WriteLine(arr[i]);
    }
  }
}
