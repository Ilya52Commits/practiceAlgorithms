using System;
using System.Collections.Generic;

internal struct Edge : IComparable<Edge>
{
  public int n1, n2; // направление (вершины)
  public int w; // вес ребра

  public int CompareTo(Edge other)
  {
    return w.CompareTo(other.w);
  }
}

internal abstract class Program
{
  private static List<Edge> s_kruskal(Edge[] edges, int n)
  {
    var mst = new List<Edge>();
    Array.Sort(edges);

    var parent = new int[n];
    for (var i = 0; i < n; i++)
    {
      parent[i] = i;
    }

    for (int i = 0; i < n; i++)
    {
      var root1 = s_find(edges[i].n1, parent);
      var root2 = s_find(edges[i].n2, parent);
      if (root1 == root2) continue;
      s_union(root1, root2, parent);
      mst.Add(edges[i]);
    }

    return mst;
  }

  private static int s_find(int v, IReadOnlyList<int> parent) => parent[v] == v ? v : s_find(parent[v], parent);

  private static void s_union(int v1, int v2, int[] parent)
  {
    var root1 = s_find(v1, parent);
    var root2 = s_find(v2, parent);
    parent[root2] = root1;
  }
  
  public static void Main()
  {
    // Пример использования
    var edges = new Edge[100]; // массив ребер графа
    edges[0] = new Edge { n1 = 0, n2 = 1, w = 5 };
    edges[1] = new Edge { n1 = 1, n2 = 2, w = 3 };
    edges[2] = new Edge { n1 = 2, n2 = 3, w = 2 };

    var n = edges.Length;
    var mst = s_kruskal(edges, n);
    
    // Выведите минимальный каркас графа
    foreach (var e in mst)
      Console.WriteLine($"{e.n1} - {e.n2} ({e.w})"); 
  }
}