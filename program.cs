class Program
{
    static void Main()
    {
        Graph graph = new Graph();

        // Load graph from text file
        graph.LoadFromFile("graph.txt");

        graph.Display();

        // QUESTION 2 Traversals
        graph.DepthFirstTraversal(1);
        graph.BreadthFirstTraversal(1);
    }
}

