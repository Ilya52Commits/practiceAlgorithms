using System;
using System.Collections.Generic;
using System.IO;

namespace Task_19;
internal abstract class Program
{
  /* Константа */
  private const int V = 9;

  #region Methods
  // поиск максимальной дистанции
  private static int s_minDistanceMethod(IReadOnlyList<int> dist, IReadOnlyList<bool> sptSet)
  {
    int min = int.MaxValue, minIndex = -1;

    for (var v = 0; v < V; v++)
    {
      if (sptSet[v] || dist[v] >= min) continue;
      min = dist[v];
      minIndex = v;
    }

    return minIndex;
  }

  private static void s_printSolution(IReadOnlyList<int> dist, List<int> path)
  {
    Console.WriteLine("Расстояние вершины от источника");
    for (var i = 0; i < V; i++)
      Console.WriteLine(i + "\t\t" + dist[i]);

    Console.WriteLine("\nВершины на пути с минимальными затратами:");
    foreach (var vertex in path)
      Console.WriteLine("B" + (vertex + 1));
  }
  
  /* Метод Декстра */
  private static void s_dijkstraMethod(int[,] graph, int src)
  {
    var dist = new int[V]; 

    var sptSet = new bool[V];

    for (var i = 0; i < V; i++)
    {
      dist[i] = int.MaxValue;
      sptSet[i] = false;
    }

    dist[src] = 0;

    for (var count = 0; count < V - 1; count++)
    {
      var u = s_minDistanceMethod(dist, sptSet);

      sptSet[u] = true;

      for (var v = 0; v < V; v++)
      {
        if (!sptSet[v] && graph[u, v] != 0 &&
            dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
          dist[v] = dist[u] + graph[u, v];
      }
    }

    var path = new List<int>();
    for (var i = 0; i < V; i++)
    {
      if (dist[i] != int.MaxValue)
        path.Add(i);
    }

    s_printSolution(dist, path);
  }
  #endregion

  /* Главный метод */
  public static void Main()
  {
    var graph = new int[13, 13];

    using var sr = new StreamReader("matrix.txt");
    for (var i = 0; i < 13; i++)
    {
      var line = sr.ReadLine();
      var values = line.Split(' ');

      for (var j = 0; j < 13; j++)
        graph[i, j] = int.Parse(values[j]);
    }

    for (var i = 0; i < 13; i++)
    {
      for (var j = 0; j < 13; j++)
        Console.Write(graph[i, j] + " ");
      Console.WriteLine();
    }

    s_dijkstraMethod(graph, 0);
  }
}