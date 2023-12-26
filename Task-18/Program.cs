using System;
using System.Collections.Generic;

// Class to represent a graph
class Graph
{
  // No. of vertices
  private int V;

  // Array containing adjacency lists
  private List<int>[] adj;

  // Constructor
  public Graph(int V)
  {
    this.V = V;
    adj = new List<int>[V];
    for (int i = 0; i < V; i++)
    {
      adj[i] = new List<int>();
    }
  }

  // Function to add an edge to graph
  public void AddEdge(int v, int w)
  {
    // Add w to v's list
    adj[v].Add(w);
  }

  // A recursive function used by TopologicalSort
  private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
  {
    // Mark the current node as visited
    visited[v] = true;

    // Recur for all the vertices adjacent to this vertex
    foreach (var i in adj[v])
    {
      if (!visited[i])
      {
        TopologicalSortUtil(i, visited, stack);
      }
    }

    // Push current vertex to stack which stores result
    stack.Push(v);
  }

  // The function to do Topological Sort. It uses recursive TopologicalSortUtil
  public void TopologicalSort()
  {
    Stack<int> stack = new Stack<int>();

    // Mark all the vertices as not visited
    bool[] visited = new bool[V];
    for (int i = 0; i < V; i++)
    {
      visited[i] = false;
    }

    // Call the recursive helper function to store Topological Sort starting from all vertices one by one
    for (int i = 0; i < V; i++)
    {
      if (!visited[i])
      {
        TopologicalSortUtil(i, visited, stack);
      }
    }

    // Print contents of stack
    Console.Write("Following is a Topological Sort of the given graph: ");
    while (stack.Count > 0)
    {
      Console.Write(stack.Pop() + " ");
    }
    Console.WriteLine(); // Add a new line for better formatting
  }
}

// Driver Code
class Program
{
  static void Main()
  {
    // Create a graph given in the above diagram
    Graph g = new Graph(6);
    g.AddEdge(5, 2);
    g.AddEdge(5, 0);
    g.AddEdge(4, 0);
    g.AddEdge(4, 1);
    g.AddEdge(2, 3);
    g.AddEdge(3, 1);

    Console.WriteLine("");

    // Function Call
    g.TopologicalSort();
  }
}