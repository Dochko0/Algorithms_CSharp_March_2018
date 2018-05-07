using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int[] depths;
    private static int[] lowpoint;
    private static int?[] parent;

    private static List<int> articulationpoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[targetGraph.Length];
        depths = new int[targetGraph.Length];
        lowpoint = new int[targetGraph.Length];
        parent = new int?[targetGraph.Length];
        articulationpoints = new List<int>();

        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node])
            {
                FindArticulationPoints(node, 1);
            }
        }
        return articulationpoints;

    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoint[node] = depth;

        int childCount = 0;
        bool isArticulationPoint = false;

        foreach (var child in graph[node])
        {
            if (!visited[child])
            {
                parent[child] = node;
                FindArticulationPoints(child, depth + 1);
                childCount++;

                if (lowpoint[child] >= depths[node])
                {
                    isArticulationPoint = true;
                }

                lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);

            }
            else if(child!=parent[node])
            {
                lowpoint[node] = Math.Min(lowpoint[node], depths[child]);
            }
        }

        if (parent[node]==null && childCount>1 || parent[node]!=null && isArticulationPoint)
        {
            articulationpoints.Add(node);
        }
    }
}
