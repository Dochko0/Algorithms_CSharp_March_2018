using System;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parent;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parent = Enumerable.Repeat(-1, graph.Length).ToArray();

        var maxFlow = 0;
        var start = 0;
        var end = graph.Length - 1;

        while (Bfs(start, end))
        {
            var pathFlow = int.MaxValue;
            var currNode = end;

            while (currNode != start)
            {
                var prevNode = parent[currNode];

                var currFlow = graph[prevNode][currNode];
                if (currFlow > 0 && currFlow < pathFlow)
                {
                    pathFlow = currFlow;
                }
                currNode = prevNode;
            }
            maxFlow += pathFlow;

            currNode = end;
            while (currNode != start)
            {
                var prevNode = parent[currNode];

                graph[prevNode][currNode] -= pathFlow;
                graph[currNode][prevNode] += pathFlow;

                currNode = prevNode;
            }
        }
        return maxFlow;
    }

    private static bool Bfs(int start, int end)
    {
        var visited = new bool[graph.Length];

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            for (int child = 0; child < graph[node].Length; child++)
            {
                if (graph[node][child] > 0 && !visited[child])
                {
                    queue.Enqueue(child);
                    parent[child] = node;
                    visited[child] = true;
                }
            }
        }
        return visited[end];
    }
}
