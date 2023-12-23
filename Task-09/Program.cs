using System;
using System.IO;

namespace Task_09;
internal abstract class Program
{
  /* Метод прямого поиска */
  private static int s_straightFind(int start, string stroka, string obraz)
  {
    int i, j;
    var n = stroka.Length;
    var m = obraz.Length;
    i = -1 + start;
    do
    {
      j = 0;
      i++;
      while (j < m && stroka[i + j] == obraz[j])
      {
        j++;
      }
    } while (j < m && i < n - m);

    return j == m ? i : -1; 
  }
  
  /* Главный метод */
  public static void Main()
  {
    const int start = 0;
    var stroka = File.ReadAllText("file.txt");
    Console.Write("Введите слово для поиска: ");
    var obraz = Console.ReadLine();

    var result = s_straightFind(start, stroka, obraz);
    Console.WriteLine(result != -1
      ? $"Слово '{obraz}' найдено в позиции {result} в строке '{stroka}'."
      : $"Слово '{obraz}' не найдено в строке '{stroka}'.");
  }
}