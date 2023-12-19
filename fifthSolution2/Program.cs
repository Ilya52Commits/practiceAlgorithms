using System;
using System.Collections.Generic;

namespace fifthSolution;
internal abstract class Program
{ 
  /* Метод бинарного поиска */
  private static int s_binarySearchMethod(IReadOnlyList<int> array, int item)
  {
    // обозначаем левую границу
    var left = 0;
    // обозначает правую границу
    var right = array.Count - 1;

    // выполняем цикл, пока левая граница
    // не будет равна правой
    while (left <= right)
    {
      // вычисляем середину диапазона поиска
      var mid = (left + right) / 2;
      // присваиваем элеммент масива в переменную
      var guess = array[mid];

      // если элеммент равен нужному
      // значению, то возвращаем его
      if (item == guess)
        return mid;
      
      // если элемент больше, то отнимаем от
      // него еденицу, и присваиваем к правой границе
      if (item < guess)
        right = mid - 1;
      else
      // иначе присваиваем к левой границе
        left = mid + 1;
    }

    // если индекс не найден,
    // то возвращаем -1
    return -1;
  }

  /* Главный метод */
  public static void Main()
  {
    // обозначаем массив
    int[] array = { 1, 3, 5, 7, 9 };
    // вызыв метода 
    Console.WriteLine(s_binarySearchMethod(array, 1)); // 1 => 0
    Console.WriteLine(s_binarySearchMethod(array, -2)); // -1 => -1
  }
}