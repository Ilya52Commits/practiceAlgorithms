using System;
using System.IO;

namespace Task_20
{
  internal class Program
  {
    private const int INF = int.MaxValue; // Значение, обозначающее бесконечность

    static void Main()
    {
        int[,] graph = ReadGraphFromFile("matrix.txt");

        int[,] shortestPaths = FloydWarshall(graph);

        PrintShortestPaths(shortestPaths);
    }

    static int[,] ReadGraphFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        int n = lines.Length;
        int[,] graph = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] values = lines[i].Split(' ');
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = int.Parse(values[j]);
            }
        }

        return graph;
    }

    static int[,] FloydWarshall(int[,] graph)
    {
        int n = graph.GetLength(0);
        int[,] dist = new int[n, n];

        // Инициализация массива расстояний
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dist[i, j] = graph[i, j];
                if (i != j && dist[i, j] == 0)
                {
                    dist[i, j] = INF;
                }
            }
        }

        // Поиск кратчайших путей
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(dist[i, k] + " "); 
                }
                Console.WriteLine();
            }

        return dist;
    }

    static void PrintShortestPaths(int[,] shortestPaths)
    {
        int n = shortestPaths.GetLength(0);

        Console.WriteLine("Кратчайшие пути между вершинами:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (shortestPaths[i, j] == INF)
                {
                    Console.Write("INF ");
                }
                else
                {
                    Console.Write(shortestPaths[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
  }
}