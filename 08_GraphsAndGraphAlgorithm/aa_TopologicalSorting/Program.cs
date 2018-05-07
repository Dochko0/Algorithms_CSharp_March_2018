using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aa_TopologicalSorting
{
    class Program
    {
        static List<int>[] graph;
        static HashSet<int> GetNodesWithIncomingEdges()
        {
            var nodeWithIncomingEdges = new HashSet<int>();

            graph
                .SelectMany(s => s)
                .ToList()
                .ForEach(e => nodeWithIncomingEdges.Add(e));

            return nodeWithIncomingEdges;
        }


        static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int>{1,2},
                new List<int>{3,4},
                new List<int>{5},
                new List<int>{2,5},
                new List<int>{3},
                new List<int>{ }
            };

            var result = new List<int>();
            var nodes = new HashSet<int>();

            var nodeWithIncomingEdges = GetNodesWithIncomingEdges();

            for (int i = 0; i < graph.Length; i++)
            {
                if (!nodeWithIncomingEdges.Contains(i))
                {
                    nodes.Add(i);
                }
            }
            while (nodes.Count!=0)
            {
                var currNode = nodes.First();
                nodes.Remove(currNode);

                result.Add(currNode);

                var children = graph[currNode].ToList();
                graph[currNode] = new List<int>();

                var leftNodeWithIncomingEdges = GetNodesWithIncomingEdges();

                foreach (var child in children)
                {
                    if (!leftNodeWithIncomingEdges.Contains(child))
                    {
                        nodes.Add(child);
                    }
                }
            }
            if (graph.SelectMany(s => s).Any())
            {
                Console.WriteLine("Sorry!");
            }
            else
            {
                Console.WriteLine(string.Join(" ",result));
            }
        }
    }
}
