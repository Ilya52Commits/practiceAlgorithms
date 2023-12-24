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
    // Initialize min value
    int min = int.MaxValue, minIndex = -1;

    for (var v = 0; v < V; v++)
    {
      if (sptSet[v] || dist[v] >= min) continue;
      min = dist[v];
      minIndex = v;
    }

    return minIndex;
  }

  // print solution
  private static void s_printSolution(IReadOnlyList<int> dist, List<int> path)
  {
    Console.WriteLine("Vertex Distance from Source");
    for (var i = 0; i < V; i++)
      Console.WriteLine(i + "\t\t" + dist[i]);

    Console.WriteLine("\nVertices in the path with minimum cost:");
    foreach (var vertex in path)
      Console.WriteLine("B" + (vertex + 1));
  }
  
  /* Dijkstra method */
  private static void s_dijkstraMethod(int[,] graph, int src)
  {
    var dist = new int[V]; // The output array. dist[i]
    // will hold the minimum
    // distance from src to i

    // sptSet[i] will true if vertex
    // i is included in shortest path
    // tree or shortest distance from
    // src to i is finalized
    var sptSet = new bool[V];

    // Initialize all distances as
    // MAX_VALUE and stpSet[] as false
    for (var i = 0; i < V; i++)
    {
      dist[i] = int.MaxValue;
      sptSet[i] = false;
    }

    // Distance of source vertex
    // from itself is always 0
    dist[src] = 0;

    // Find shortest path for all vertices
    for (var count = 0; count < V - 1; count++)
    {
      // Pick the minimum distance vertex
      // from the set of vertices not yet
      // processed. u is always equal to
      // src in the first iteration.
      var u = s_minDistanceMethod(dist, sptSet);

      // Mark the picked vertex as processed
      sptSet[u] = true;

      // Update dist value of the adjacent
      // vertices of the picked vertex.
      for (var v = 0; v < V; v++)
      {
        // Update dist[v] only if it is not in
        // sptSet, there is an edge from u
        // to v, and the total weight of the path
        // from src to v through u is less
        // than the current value of dist[v]
        if (!sptSet[v] && graph[u, v] != 0 &&
            dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
          dist[v] = dist[u] + graph[u, v];
      }
    }

    // Store the vertices in the path with minimum cost
    var path = new List<int>();
    for (var i = 0; i < V; i++)
    {
      if (dist[i] != int.MaxValue)
        path.Add(i);
    }

    // print the constructed distance array and the vertices in the path
    s_printSolution(dist, path);
  }
  #endregion

  /* Main method */
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