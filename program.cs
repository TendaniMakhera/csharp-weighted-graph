class Program
{
    static void Main()
    {
        Graph graph = new Graph();

        graph.AddEdge(1, 2, 5);
        graph.AddEdge(1, 3, 10);
        graph.AddEdge(2, 3, 3);
        graph.AddEdge(3, 4, 2);

        graph.Display();
    }
}
