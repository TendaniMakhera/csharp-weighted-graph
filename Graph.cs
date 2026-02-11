using System;
using System.Collections.Generic;

public class Graph
{
    private readonly Dictionary<int, Node> nodes = new();
    private readonly Dictionary<Node, List<Edge>> adjacencyList = new();

    public void AddNode(int label)
    {
        if (!nodes.ContainsKey(label))
        {
            Node node = new Node(label);
            nodes[label] = node;
            adjacencyList[node] = new List<Edge>();
        }
    }

    public void AddEdge(int from, int to, int weight)
    {
        if (!nodes.ContainsKey(from)) AddNode(from);
        if (!nodes.ContainsKey(to)) AddNode(to);

        Node fromNode = nodes[from];
        Node toNode = nodes[to];

        Edge edge1 = new Edge(fromNode, toNode, weight);
        Edge edge2 = new Edge(toNode, fromNode, weight);

        adjacencyList[fromNode].Add(edge1);
        adjacencyList[toNode].Add(edge2);
    }

    public void Display()
    {
        foreach (var pair in adjacencyList)
        {
            Console.Write(pair.Key + " -> ");
            foreach (var edge in pair.Value)
            {
                Console.Write($"({edge.To},{edge.Weight}) ");
            }
            Console.WriteLine();
        }
    }
}
