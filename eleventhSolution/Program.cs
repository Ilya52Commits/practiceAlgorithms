using System;
using System.Collections.Generic;

namespace eleventhSolution
{
  internal class Program
  {
    /* Boyer and Moore algorithm method */
    private static void s_boyerMooreAlgorithmMethod(IReadOnlyList<char> text, char[] pat)
    {
      // s is shift of the pattern 
      // with respect to text
      int s = 0;
      var m = pat.Length;
      var n = text.Count;

      var bpos = new int[m + 1];
      var shift = new int[m + 1];

      // initialize all occurrence of shift to 0
      for (var i = 0; i < m + 1; i++)
        shift[i] = 0;

      // do preprocessing
      s_preprocessStrongSuffix(shift, bpos, pat, m);
      s_preprocessSecondCase(shift, bpos, m);

      while (s <= n - m)
      {
        var j = m - 1;

        /* Keep reducing index j of pattern while
        characters of pattern and text are matching
        at this shift s*/
        while (j >= 0 && pat[j] == text[s + j])
          j--;

        /* If the pattern is present at the current shift,
        then index j will become -1 after the above loop */
        if (j < 0)
        {
          Console.Write($"Шаблонн содержится при сдвиге = {s}\n");
          s += shift[0];
        }
        else
          /*pat[i] != pat[s+j] so shift the pattern
          shift[j+1] times */
          s += shift[j + 1];
      }
    }

    // preprocessing for case 2
    private static void s_preprocessSecondCase(IList<int> shift, IReadOnlyList<int> bpos, int m)
    {
      int i;
      var j = bpos[0];
      for (i = 0; i <= m; i++)
      {
        /* set the border position of the first character
        of the pattern to all indices in array shift
        having shift[i] = 0 */
        if (shift[i] == 0)
          shift[i] = j;

        /* suffix becomes shorter than bpos[0],
        use the position of next widest border
        as value of j */
        if (i == j)
          j = bpos[j];
      }
    }

    // preprocess suffix method
    private static void s_preprocessStrongSuffix(IList<int> shift, IList<int> bpos, IReadOnlyList<char> pat, int m)
    {
      // m is the length of pattern 
      int i = m, j = m + 1;
      bpos[i] = j;

      while (i > 0)
      {
        /*if character at position i-1 is not
        equivalent to character at j-1, then
        continue searching to right of the
        pattern for border */
        while (j <= m && pat[i - 1] != pat[j - 1])
        {
          /* the character preceding the occurrence of t
          in pattern P is different than the mismatching
          character in P, we stop skipping the occurrences
          and shift the pattern from i to j */
          if (shift[j] == 0)
            shift[j] = j - i;

          //Update the position of next border 
          j = bpos[j];
        }
        /* p[i-1] matched with p[j-1], border is found.
        store the beginning position of border */
        i--; j--;
        bpos[i] = j;
      }
    }

    static void Main(string[] args)
    {

      Console.WriteLine("Поиск алгоритмом Бойера и Мура:");
      var text2 = "ABAAAABAACD".ToCharArray();
      var pat2 = "ABA".ToCharArray();
      s_boyerMooreAlgorithmMethod(text2, pat2);
    }
  }
}
