using System;
using System.Collections.Generic;

namespace Task_13;
internal abstract class Program
{
  /* Рекурсивный метод посчёта суммы */
  private static int s_calculateMethod(IReadOnlyList<int> array, int left, int right)
  {
    // если начало массива
    // равно концу массива
    if (left == right)
      // вернуть элемент массива
      return array[left];

    // левый элемент для подсчёта
    var leftValue = 0;
    // пправый элемент для подсчёта
    var rightValue = 0; 
    
    // проходим по массиву
    for (var i = 0; i < right; i++)
    {
      // делим длину массива
      var mid = (left + right) / 2;
      // вызываем рекурсивный метод для левого элемента
      leftValue = s_calculateMethod(array, left, mid);
      // вызываем рекурсивный метод для правого элемента
      rightValue = s_calculateMethod(array, mid + 1, right);
    }

    // возвращаем сумму массива
    return leftValue + rightValue; 
  }
  
  /* Главный метод */
  public static void Main()
  {
    // создаём массив
    int[] array = [1, 3, 5, 3, 6, 7, 9];
    // выводим массив
    Console.Write("Массив: ");
    foreach (var value in array)
      Console.Write(value + " ");
    Console.WriteLine();
    // вызываем рекурсивный метод
    Console.WriteLine($"Сумма элементов массива: " + 
    $"{s_calculateMethod(array, 0, array.Length - 1)}");
  }
}
