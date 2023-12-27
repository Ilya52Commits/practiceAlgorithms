using System;
using System.Collections.Generic;

// Класс для представления графика
class Graph
{
  // Количество вершин
  private int V;

  // Массив, содержащий списки смежности
  private List<int>[] adj;

  // Конструктор
  public Graph(int V)
  {
    this.V = V;
    adj = new List<int>[V];
    for (int i = 0; i < V; i++)
    {
      adj[i] = new List<int>();
    }
  }

  // Функция для добавления ребра к графику
  public void AddEdge(int v, int w)
  {
    // Добавьте w в список v
    adj[v].Add(w);
  }

  // Рекурсивная функция, используемая в топологической сортировке
  private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
  {
    // Отметьте текущий узел как посещенный
    visited[v] = true;

    // Повторяется для всех вершин, смежных с этой вершиной
    foreach (var i in adj[v])
    {
      if (!visited[i])
      {
        TopologicalSortUtil(i, visited, stack);
      }
    }

    // Переместите текущую вершину в стек, в котором хранится результат
    stack.Push(v);
  }

  // Функция для выполнения топологической сортировки. Она использует рекурсивный TopologicalSortUtil
  public void TopologicalSort()
  {
    Stack<int> stack = new Stack<int>();

    // Отметьте все вершины как не посещенные
    bool[] visited = new bool[V];
    for (int i = 0; i < V; i++)
    {
      visited[i] = false;
    }

    // Вызовите рекурсивную вспомогательную функцию для сохранения топологической сортировки, начиная со всех вершин по очереди
    for (int i = 0; i < V; i++)
    {
      if (!visited[i])
      {
        TopologicalSortUtil(i, visited, stack);
      }
    }

    // Распечатать содержимое стопки
    Console.Write("Ниже приведен топологический вид данного графа: ");
    while (stack.Count > 0)
    {
      Console.Write(stack.Pop() + " ");
    }
    Console.WriteLine(); // Добавьте новую строку для лучшего форматирования
  }
}

// Driver Code
class Program
{
  static void Main()
  {
    Graph g = new Graph(6);
    g.AddEdge(5, 2);
    g.AddEdge(5, 0);
    g.AddEdge(4, 0);
    g.AddEdge(4, 1);
    g.AddEdge(2, 3);
    g.AddEdge(3, 1);

    Console.WriteLine("");

    g.TopologicalSort();
  }
}