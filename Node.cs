public class Node
{
    public int Label { get; }

    public Node(int label)
    {
        Label = label;
    }

    public override string ToString()
    {
        return Label.ToString();
    }
}
