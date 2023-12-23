using System;
using System.Collections.Generic;

namespace tenthSolution
{
  internal abstract class Program
  {
    /* Constant's */
    // d is the number of characters in the input alphabet
    private const int D = 256;

    private static void s_rubinKarpAlgorithmMethod(string pat, string txt, int q)
    {
      /* Variables */
      /* pat -> pattern
        txt -> text
        q -> A prime number
      */
      var m = pat.Length;
      var n = txt.Length;
      var p = 0; // hash value for pattern
      var t = 0; // hash value for txt
      var h = 1;
      int i;

      // The value of h would be "pow(d, M-1)%q"
      for (i = 0; i < m - 1; i++)
        h = (h * D) % q;

      // Calculate the hash value of pattern and first
      // window of text
      for (i = 0; i < m; i++)
      {
        p = (D * p + pat[i]) % q;
        t = (D * t + txt[i]) % q;
      }

      // Slide the pattern over text one by one
      for (i = 0; i <= n - m; i++)
      {
        // Check the hash values of current window of
        // text and pattern. If the hash values match
        // then only check for characters one by one
        if (p == t)
        {
          /* Check for characters one by one */
          int j;
          for (j = 0; j < m; j++)
            if (txt[i + j] != pat[j]) break;

          // if p == t and pat[0...M-1] = txt[i, i+1,
          // ...i+M-1]
          if (j == m)
            Console.WriteLine("Шаблон найден по индексу: " + i);
        }

        // Calculate hash value for next window of text:
        // Remove leading digit, add trailing digit
        if (i >= n - m) continue;
        t = (D * (t - txt[i] * h) + txt[i + m]) % q;

        // We might get negative value of t,
        // converting it to positive
        if (t < 0) t = (t + q);
      }
    }

    /* Главный метод */
    public static void Main()
    {
      const string text = "Какой-то текст в строке";
      const string pat = "то";

      // A prime number
      const int q = 101;

      // Function Call
      Console.WriteLine("Поиск алгоритмом Рабина-Карпа:");
      Console.WriteLine($"Текст для поиска: {text}");
      s_rubinKarpAlgorithmMethod(pat, text, q);
      Console.WriteLine();
    }
  }
}