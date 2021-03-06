﻿using System;
using System.Collections.Generic;
using System.Linq;

public class StronglyConnectedComponents
{
    private static List<int>[] graph;
    private static List<int>[] reverseGraph;
    private static bool[] visited;

    private static Stack<int> stack = new Stack<int>();

    private static List<List<int>> stronglyConnectedComponents;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[graph.Length];
        BuildReversedGraph();

        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node])
            {
                Dfs(node);
            }
        }

        stronglyConnectedComponents = new List<List<int>>();
        visited = new bool[graph.Length];
        while (stack.Count>0)
        {
            var node = stack.Pop();

            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDfs(node);
            }

        }
        return stronglyConnectedComponents;

    }

    private static void BuildReversedGraph()
    {
        reverseGraph = new List<int>[graph.Length];
        for (int node = 0; node < reverseGraph.Length; node++)
        {
            reverseGraph[node] = new List<int>();
        }

        for (int node = 0; node < graph.Length; node++)
        {
            foreach (var child in graph[node])
            {
                reverseGraph[child].Add(node);
            }
        }
    }

    private static void ReverseDfs(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            stronglyConnectedComponents.Last().Add(node);

            foreach (var child in reverseGraph[node])
            {
                ReverseDfs(child);
            }
        }
       
    }


    private static void Dfs(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;

            foreach (var child in graph[node])
            {
                Dfs(child);
            }
            stack.Push(node);
        }
    }
}
