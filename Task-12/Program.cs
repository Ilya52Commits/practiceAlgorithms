using System;
using System.Collections.Generic;

namespace eleventhSolution;
internal abstract class Program
{
  #region Method
  /* Метод алгоритма Бойера и Мура */
  private static void s_boyerMooreAlgorithmMethod(IReadOnlyList<char> text, IReadOnlyList<char> pat)
  {
    // длина текста
    var textCount = text.Count;
    // длина элемента поиска
    var patCount = pat.Count;
    // сдвиг шаблона по отношению к тексту
    var s = 0;
    
    var bpos = new int[patCount + 1];
    var shift = new int[patCount + 1];

    // инициализируйте все вхождения shift равным 0
    for (var i = 0; i < patCount + 1; i++)
      shift[i] = 0;

    // выполните предварительную обработку
    s_preprocessStrongSuffix(shift, bpos, pat, patCount);
    s_preprocessSecondCase(shift, bpos, patCount);

    while (s <= textCount - patCount)
    {
      var j = patCount - 1;

      // Продолжайте уменьшать индекс j шаблона,
      // пока символы шаблона и текста совпадают
      // при этом сдвиге
      while (j >= 0 && pat[j] == text[s + j])
        j--;

      // Если шаблон присутствует при текущем сдвиге,
      // то индекс j станет равным -1 после
      // описанного выше цикла
      if (j < 0)
      {
        Console.Write($"Шаблонн содержится при сдвиге = {s}\n");
        s += shift[0];
      }
      else
        // pat[i] != pat[s+j] сдвигайте шаблон
        // shift[j+1] раз
        s += shift[j + 1];
    }
  }

  /* Предварительная обработка для случая 2 */
  private static void s_preprocessSecondCase(IList<int> shift, IReadOnlyList<int> bpos, int m)
  {
    int i;
    var j = bpos[0];
    for (i = 0; i <= m; i++)
    {
      // установите положение границы первого
      // символа шаблона для всех индексов в
      // массиве shift, имеющих shift[i] = 0
      if (shift[i] == 0)
        shift[i] = j;

      // если суффикс становится короче, чем
      // bpos[0], используйте положение следующей
      // по ширине границы в качестве значения j
      if (i == j)
        j = bpos[j];
    }
  }

  /* Метод предварительной обработки суффикса */
  private static void s_preprocessStrongSuffix(IList<int> shift, IList<int> bpos, IReadOnlyList<char> pat, int m)
  {
    // m - длина узора
    int i = m, j = m + 1;
    bpos[i] = j;

    while (i > 0)
    {
      /* если символ в позиции i-1 не
      эквивалентен символу в позиции j-1, то
      продолжайте поиск границы справа от
      шаблона */
      while (j <= m && pat[i - 1] != pat[j - 1])
      {
        /* символ, предшествующий появлению
        в шаблоне P, отличается от несоответствующего символа
        в P, мы прекращаем пропускать вхождения
        и сдвигаем шаблон с i на j */
        if (shift[j] == 0)
          shift[j] = j - i;

        // обновите положение следующей границы
        j = bpos[j];
      }
      /* p[i-1] совпадает с p[j-1], граница найдена.
      сохраните начальное положение границы */
      i--; j--;
      bpos[i] = j;
    }
  }
  #endregion

  /* Главный метод */
  public static void Main()
  {
    // исходная строки
    var text = "ABAAAABAACD".ToCharArray();
    // элемент для поиска
    var pat = "ABAAC".ToCharArray();
    
    // вывод результата алгоритма
    Console.WriteLine("Поиск алгоритмом Бойера и Мура:");
    s_boyerMooreAlgorithmMethod(text, pat);
  }
}