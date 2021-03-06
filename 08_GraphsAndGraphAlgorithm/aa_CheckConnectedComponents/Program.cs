﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aa_CheckConnectedComponents
{
    class Program
    {
        static List<int>[] graph;
        static bool[] visited;

        static void Bfs(int n)
        {
            if (visited[n])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(n);
            visited[n] = true;

            while (queue.Count != 0)
            {
                var currNode = queue.Dequeue();

                Console.WriteLine(currNode);

                foreach (var child in graph[currNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        static void Dfs(int n)
        {
            if (!visited[n])
            {
                visited[n] = true;
                foreach (var child in graph[n])
                {
                    Dfs(child);
                }

                Console.Write($"{n} ");
            }
        }


        static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int>{3,6},
                new List<int>{2,3,4,5,6},
                new List<int>{1,4,5},
                new List<int>{0,1,5},
                new List<int>{1,2,6},
                new List<int>{1,2,3},
                new List<int>{0,1,4},
                new List<int>{8},
                new List<int>{7}
            };
            visited = new bool[graph.Length];

            var components = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    components++;
                    Console.Write($"Connected component {components}: ");
                    Dfs(i);
                    Console.WriteLine();
                }

            }

        }
    }
}
