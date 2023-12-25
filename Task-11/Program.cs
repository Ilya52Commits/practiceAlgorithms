using System;
using System.IO;

namespace Task_12;
internal abstract class Program
{
  static void KMPSearch(string pat, string txt)
  {
    int M = pat.Length;
    int N = txt.Length;

    int[] lps = new int[M];

    int j = 0;

    computeLPSArray(pat, M, lps);

    int i = 0;
    while ((N - i) >= (M - j)) {
      if (pat[j] == txt[i]) {
        j++;
        i++;
      }
      if (j == M) {
        Console.Write("Данный текст "
                      + "находится на индексе " + (i - j) + "\n");
        j = lps[j - 1];
      }

      else if (i < N && pat[j] != txt[i]) {

        if (j != 0)
          j = lps[j - 1];
        else
          i = i + 1;
      }
    }
  }

  static void computeLPSArray(string pat, int M, int[] lps)
  {
    int len = 0;
    int i = 1;
    lps[0] = 0;

    while (i < M) {
      if (pat[i] == pat[len]) {
        len++;
        lps[i] = len;
        i++;
      }
      else
      {
        if (len != 0) 
          len = lps[len - 1];
        else
        {
          lps[i] = len;
          i++;
        }
      }
    }
  }

  public static void Main()
  {
    var stroka = File.ReadAllText("file.txt");
    Console.Write("Введите слово для поиска: ");
    var obraz = Console.ReadLine();
    //string txt = "ABABDABACDABABCABAB";
    //string pat = "ABABCABAB";
    KMPSearch(obraz, stroka);
  }
}