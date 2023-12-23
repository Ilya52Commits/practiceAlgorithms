using System;
using System.IO;

namespace thirdsSolution;
internal abstract class Program
{
  #region Methods
  /* Функция проверки конца серии */
  private static bool s_moveMath(FileStream abc)
  {
    int tmp;
    tmp = abc.ReadByte(); // Чтение одного байта из потока
    tmp = abc.ReadByte();
    if (tmp != '\'') abc.Seek(-2, SeekOrigin.Current); // Перемещение указателя позиции в потоке
    else abc.Seek(1, SeekOrigin.Current);
    return tmp == '\'' ? true : false;
  }
  
  /* Функция сотрировки */
  private static void s_sortingMethod()
  {
    FileStream f, f1, f2;
    int a = 0, b = 0;
    int x, y;
    int flag;
    x = y = 1;
    while (x > 0 && y > 0)
    {
      flag = 1;
      x = 0;
      y = 0;
      f = File.OpenRead("file.txt");
      f1 = File.Create("1.txt");
      f2 = File.Create("2.txt");
      using (StreamReader reader = new StreamReader(f))
      using (StreamWriter writer1 = new StreamWriter(f1))
      using (StreamWriter writer2 = new StreamWriter(f2))
      {
        if (!reader.EndOfStream)
        {
          Console.WriteLine(reader);
          a = int.Parse(Convert.ToString(reader));
          writer1.Write(a + " ");
        }
        if (!reader.EndOfStream)
        {
          b = int.Parse(reader.ReadLine());
        }
        while (!reader.EndOfStream)
        {
          if (b < a)
          {
            switch (flag)
            {
              case 1:
                {
                  writer1.Write("' ");
                  flag = 2;
                  x++;
                  break;
                }
              case 2:
                {
                  writer2.Write("' ");
                  flag = 1;
                  y++;
                  break;
                }
            }
          }
          if (flag == 1)
          {
            writer1.Write(b + " ");
            x++;
          }
          else
          {
            writer2.Write(b + " ");
            y++;
          }
          a = b;
          b = int.Parse(reader.ReadLine());
        }
        if (y > 0 && flag == 2) { writer2.Write("'"); }
        if (x > 0 && flag == 1) { writer1.Write("'"); }
      }

      f2.Close();
      f1.Close();
      f.Close();

      //слияние
      f = File.Create("file.txt");
      f1 = File.OpenRead("1.txt");
      f2 = File.OpenRead("2.txt");
      using (StreamReader reader1 = new StreamReader(f1))
      using (StreamReader reader2 = new StreamReader(f2))
      using (StreamWriter writer = new StreamWriter(f))
      {
        if (!reader1.EndOfStream)
        {
          a = int.Parse(reader1.ReadLine());
        }
        if (!reader2.EndOfStream)
        {
          b = int.Parse(reader2.ReadLine());
        }
        bool X1, X2;
        while (!reader1.EndOfStream && !reader2.EndOfStream)
        {
          X1 = X2 = false;
          while (!X1 && !X2)
          {
            if (a <= b)
            {
              writer.Write(a + " ");
              X1 = s_moveMath(f1);
              a = int.Parse(reader1.ReadLine());
            }
            else
            {
              writer.Write(b + " ");
              X2 = s_moveMath(f2);
              b = int.Parse(reader2.ReadLine());
            }
          }
          while (!X1)
          {
            writer.Write(a + " ");
            X1 = s_moveMath(f1);
            a = int.Parse(reader1.ReadLine());
          }
          while (!X2)
          {
            writer.Write(b + " ");
            X2 = s_moveMath(f2);
            b = int.Parse(reader2.ReadLine());
          }
        }
        X1 = X2 = false;
        while (!X1 && !reader1.EndOfStream)
        {
          writer.Write(a + " ");
          X1 = s_moveMath(f1);
          a = int.Parse(reader1.ReadLine());
        }
        while (!X2 && !reader2.EndOfStream)
        {
          writer.Write(b + " ");
          X2 = s_moveMath(f2);
          b = int.Parse(reader2.ReadLine());
        }
      }

      f2.Close();
      f1.Close();
      f.Close();
    }
  }
  #endregion

  /* Главный метод */
  public static void Main()
  {

    // Вызов функции сортировки
    s_sortingMethod();

    Console.WriteLine("Сортировка завершена.");
  }
}