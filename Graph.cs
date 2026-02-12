using System;
using System.Collections.Generic;
using System.IO;

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

    public void DepthFirstTraversal(int startLabel)
    {
        if (!nodes.ContainsKey(startLabel))
        {
            Console.WriteLine("Start node does not exist.");
            return;
        }

        HashSet<Node> visited = new();
        Console.Write("DFS Traversal: ");
        DFS(nodes[startLabel], visited);
        Console.WriteLine();
    }

    private void DFS(Node node, HashSet<Node> visited)
    {
        visited.Add(node);
        Console.Write(node + " ");

        foreach (var edge in adjacencyList[node])
        {
            if (!visited.Contains(edge.To))
            {
                DFS(edge.To, visited);
            }
        }
    }

  
    public void BreadthFirstTraversal(int startLabel)
    {
        if (!nodes.ContainsKey(startLabel))
        {
            Console.WriteLine("Start node does not exist.");
            return;
        }

        HashSet<Node> visited = new();
        Queue<Node> queue = new();

        queue.Enqueue(nodes[startLabel]);
        visited.Add(nodes[startLabel]);

        Console.Write("BFS Traversal: ");

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.Write(current + " ");

            foreach (var edge in adjacencyList[current])
            {
                if (!visited.Contains(edge.To))
                {
                    visited.Add(edge.To);
                    queue.Enqueue(edge.To);
                }
            }
        }

        Console.WriteLine();
    }



    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using StreamReader reader = new StreamReader(filePath);

        int nodeCount = int.Parse(reader.ReadLine());
        int edgeCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < nodeCount; i++)
        {
            AddNode(i + 1);
        }

        for (int i = 0; i < edgeCount; i++)
        {
            string[] parts = reader.ReadLine().Split(' ');
            int from = int.Parse(parts[0]);
            int to = int.Parse(parts[1]);
            int weight = int.Parse(parts[2]);

            AddEdge(from, to, weight);
        }
    }
}
