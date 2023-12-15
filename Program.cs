using System;

namespace ConsoleApp1
{
  internal abstract class Program
  {
    private static void s_storyPiramida(int[] data, int n)
    {
      for (int i = n / 2; i >= 0; i--)
      {
        if (2 * i < n)
          if (data[i] < data[2 * i])
          {
            var rotate = data[i];
            data[i] = data[2 * i];
            data[2 * i] = rotate;
          }


        if (2 * i + 1 < n)
          if (data[i] < data[2 * i + 1])
          {
            var rotate = data[i];
            data[i] = data[2 * i + 1];
            data[2 * i + 1] = rotate;
          }
      }

    }

    /* Главный метод */    
    public static void Main()
    {
      int[] arr = { 12, 11, 13, 5, 6, 7 };
      int length = arr.Length;
      s_storyPiramida(arr, length);

      for (int i = 0; i < arr.Length; i++)
        Console.WriteLine(arr[i]);
    }
  }
}
