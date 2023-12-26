using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Task_15;
internal abstract class Program
{
  const string pathFile = @"D:\ISP-42\Krasnenkov\Task-15\bin\Debug\";

  /* Класс, содержащий структуру вершины */
  public class Edge
  {
    #region Parameters
    // Хранит, куда направлено ребро
    public string To;
    // Вес ребра
    public int? Weight;
    #endregion

    // Конструктор
    public Edge(string to, int? weight) => (To, Weight) = (to, weight);
  }

  /* Класс, содержащий структуру списка смежности */
  public class Graph
  {
    private Dictionary<string, List<Edge>> _adjacencyList;

    #region Constructors
    // Констуктор по умолчанию
    public Graph() => _adjacencyList = new Dictionary<string, List<Edge>>();
    // Конструктор копирования
    public Graph(Graph other) =>
      _adjacencyList = new Dictionary<string, List<Edge>>(other._adjacencyList);
    // Конструктор добавления из файла
    public Graph(string path) => AddFromFile(path);
    #endregion

    #region Methods
    // Добавление из файла 
    public bool AddFromFile(string path)
    {
      // создаём новый объект
      _adjacencyList = new Dictionary<string, List<Edge>>();
      // читаем файл 
      var lines = File.ReadAllLines($@"{path}file.txt");
            var vertexes = lines[1].Trim().Split(' ');
        var listAdjacency = lines.Skip(2).ToArray();

        foreach (var vertex in vertexes)
          _adjacencyList[vertex] = new List<Edge> { new Edge("", null) };

        var rowCount = listAdjacency.Length;
        var columnCount = listAdjacency[0].Split(' ').Length;
        var listAdjacencyArr = new string[rowCount, columnCount];

        for (var i = 0; i < rowCount; i++)
        {
          var values = listAdjacency[i].Split(' ');
          for (var j = 0; j < columnCount; j++)
            listAdjacencyArr[i, j] = values[j];
        }

        for (var i = 0; i < listAdjacencyArr.GetLength(0); i++)
        {
          for (var j = 1; j < listAdjacencyArr.GetLength(1); j++)
          {
            if (listAdjacencyArr[i, j] != "0")
              _adjacencyList[(i + 1).ToString()].Add(new Edge(j.ToString(), int.Parse(listAdjacencyArr[i, j])));
          }
        }
      return true;
    }

    public void AddVertex(string vertex)
    {
      if (!_adjacencyList.ContainsKey(vertex))
      {
        _adjacencyList[vertex] = new List<Edge>();
      }
    }

    public void AddEdge(string from, string to, int? weight)
    {
      if (!_adjacencyList.ContainsKey(from))
      {
        AddVertex(from);
      }

      if (!_adjacencyList.ContainsKey(to))
      {
        AddVertex(to);
      }

      _adjacencyList[from].Add(new Edge(to, weight));
    }

    // Вывод списка смежности
    public void OutputAdjacencyList()
    {
      Console.WriteLine("Список смежности: ");
      foreach (var key in _adjacencyList)
      {
        foreach (var value in key.Value)
        {
          string answer = "null";
          if (value.To != "")
            answer = value.To; 
          Console.WriteLine($"{key.Key}: {answer}, {value.Weight}");

        }
        Console.WriteLine();
      }
    }

    // Вывод матрицы смежности
    public void OutputsAdjacencyMatrix()
    {
      var vertices = _adjacencyList.Keys.ToList();
      var n = vertices.Count;
      var matrix = new int[n, n];

      for (var i = 0; i < n; i++)
      {
        for (var j = 0; j < n; j++)
          matrix[i, j] = 0;
      }

      for (var i = 0; i < n; i++)
      {
        var vertex = vertices[i];
        var edges = _adjacencyList[vertex];

        foreach (var edge in edges)
        {
          if (edge.To != "")
          {
            var j = vertices.IndexOf(edge.To);
            matrix[i, j] = edge.Weight ?? 1;
          }
        }
      }

      Console.WriteLine("Матрица смежности:");
      Console.Write("  ");

      for (var i = 0; i < n; i++)
        Console.Write(vertices[i] + " ");

      Console.WriteLine();
      for (var i = 0; i < n; i++)
      {
        Console.Write(vertices[i] + " ");

        for (var j = 0; j < n; j++)
          Console.Write(matrix[i, j] + " ");

        Console.WriteLine();
      }
    }

    /* Вывод матрицы инцидентносни */
    public int[,] GetIncidenceMatrix()
    {
      List<string> vertices = _adjacencyList.Keys.ToList();
      int[,] matrix = new int[vertices.Count, _adjacencyList.Count];

      for (int i = 0; i < vertices.Count; i++)
      {
        for (int j = 0; j < _adjacencyList[vertices[i]].Count; j++)
        {
          string toVertex = _adjacencyList[vertices[i]][j].To;
          int? weight = _adjacencyList[vertices[i]][j].Weight;

          if (vertices.Contains(toVertex))
          {
            int toVertexIndex = vertices.IndexOf(toVertex);
            matrix[i, toVertexIndex] = weight.HasValue ? weight.Value : 1;
          }
        }
      }

      return matrix;
    }

    // обход в ширину
      public List<string> BreadthFirstSearch(string startVertex, string endVertex)
      {
      List<string> visited = new List<string>();
      Queue<string> queue = new Queue<string>();
      Dictionary<string, string> parentMap = new Dictionary<string, string>();

      visited.Add(startVertex);
      queue.Enqueue(startVertex);

      while (queue.Count > 0)
      {
        string currentVertex = queue.Dequeue();

        if (currentVertex == endVertex)
        {
          break;
        }

        foreach (Edge edge in _adjacencyList[currentVertex])
        {
          if (!visited.Contains(edge.To))
          {
            visited.Add(edge.To);
            queue.Enqueue(edge.To);
            parentMap[edge.To] = currentVertex;
          }
        }
      }

      if (!visited.Contains(endVertex))
      {
        return null; // No path found
      }

      List<string> shortestPath = new List<string>();
      string vertex = endVertex;

      while (vertex != startVertex)
      {
        shortestPath.Insert(0, vertex);
        vertex = parentMap[vertex];
      }

      shortestPath.Insert(0, startVertex);

      return shortestPath;
    }

    // обход в глубину
    public List<string> DepthFirstSearch(string startVertex, string endVertex)
    {
      List<string> visited = new List<string>();
      Stack<string> stack = new Stack<string>();
      Dictionary<string, string> parentMap = new Dictionary<string, string>();

      visited.Add(startVertex);
      stack.Push(startVertex);

      while (stack.Count > 0)
      {
        string currentVertex = stack.Pop();

        if (currentVertex == endVertex)
        {
          break;
        }

        foreach (Edge edge in _adjacencyList[currentVertex])
        {
          if (!visited.Contains(edge.To))
          {
            visited.Add(edge.To);
            stack.Push(edge.To);
            parentMap[edge.To] = currentVertex;
          }
        }
      }

      if (!visited.Contains(endVertex))
      {
        return null; // No path found
      }

      List<string> path = new List<string>();
      string vertex = endVertex;

      while (vertex != startVertex)
      {
        path.Insert(0, vertex);
        vertex = parentMap[vertex];
      }

      path.Insert(0, startVertex);

      return path;
    }

    #endregion
  }

  /* Главный метод */
  public static void Main()
  {
    Graph graph = new Graph();

    //graph.AddFromFile(pathFile);
    graph.AddEdge("A", "B", 1);
    graph.AddEdge("A", "C", 2);
    graph.AddEdge("B", "D", 3);
    graph.AddEdge("C", "E", 4);
    graph.AddEdge("D", "E", 5);
    graph.OutputAdjacencyList();
    graph.OutputsAdjacencyMatrix();

    int[,] incidenceMatrix = graph.GetIncidenceMatrix();

    // Вывод матрицы инцидентности
    Console.WriteLine("\nМатрица инциденстности:");
    for (int i = 0; i < incidenceMatrix.GetLength(0); i++)
    {
      for (int j = 0; j < incidenceMatrix.GetLength(1); j++)
        Console.Write(incidenceMatrix[i, j] + " ");
      Console.WriteLine();
    }

    List<string> bfsResult = graph.BreadthFirstSearch("A", "E");

    Console.WriteLine("\nBFS traversal:");
    foreach (string vertex in bfsResult)
    {
      Console.Write(vertex + " ");
    }
    Console.WriteLine();

    List<string> path = graph.DepthFirstSearch("A", "E");

    if (path != null)
    {
      Console.WriteLine("Path found:");
      foreach (string vertex in path)
      {
        Console.Write(vertex + " ");
      }
    }
    else
    {
      Console.WriteLine("No path found.");
    }
  }
}

/*
 Сводки для дополнения:
  1. Оптимизировать считывание; 
  2. Доработатиь вывод матрицы инцидентности
 */