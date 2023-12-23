using System;

namespace tenthSolution;
internal abstract class Program
{
  /* Количество символов во входном алфавите */
  private const int NumbersAlphabet = 256;
  
  /* Метод алгоритма Рабина-Карпа */
  private static void s_rubinKarpAlgorithmMethod(string pat, string text, int q)
  {
    // длина строки элемента для поиска
    var patLength = pat.Length; 
    // длина основной строки
    var textLength = text.Length;
    // хэш-значение для шаблона
    var patHash = 0;
    // хэш-значение для текста
    var textHash = 0;
    // значение шага
    var h = 1;

    // значение h будет равно "pow(d, M-1)%q".
    for (var i = 0; i < patLength - 1; i++)
      h = (h * NumbersAlphabet) % q;

    // вычислите хэш-значение шаблона и первого окна текста
    for (var i = 0; i < patLength; i++)
    {
      patHash = (NumbersAlphabet * patHash + pat[i]) % q;
      textHash = (NumbersAlphabet * textHash + text[i]) % q;
    }

    // перемещайте шаблон по тексту один за другим
    for (var i = 0; i <= textLength - patLength; i++)
    {
      // Проверьте хэш-значения текущего окна 
      // текста и шаблона. Если хэш-значения совпадают,
      // то проверяйте только символы один за другим
      if (patHash == textHash)
      {
        // проверяйте наличие символов один за другим
        int j;
        for (j = 0; j < patLength; j++)
          if (text[i + j] != pat[j]) break;

        // if p == t and pat[0...M-1] = txt[i, i+1,
        // ...i+M-1]
        if (j == patLength)
          Console.WriteLine("Шаблон найден по индексу: " + i);
      }

      // вычислить хэш-значение для следующего текстового окна:
      // удалите начальную цифру, добавьте конечную цифру
      if (i >= textLength - patLength) continue;
      textHash = (NumbersAlphabet * (textHash - text[i] * h) + text[i + patLength]) % q;

      // мы могли бы получить отрицательное значение t,
      // преобразуя его в положительный
      if (textHash < 0) textHash = (textHash + q);
    }
  }

  /* Главный метод */
  public static void Main()
  {
    // исходный текст
    const string text = "Какой-то текст в строке";
    // фрагмент для поиска
    const string pat = "то";
    // простое число
    const int q = 101;
    
    // вывод результат алгоритма
    Console.WriteLine("Поиск алгоритмом Рабина-Карпа:");
    Console.WriteLine($"Текст для поиска: {text}");
    s_rubinKarpAlgorithmMethod(pat, text, q);
    Console.WriteLine();
  }
}