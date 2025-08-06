public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Insert unique values only
        if (value == Data)
        {
            return; // Skip duplicates
        }
        
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Implement Contains
        if (value == Data)
        {
            return true;
        }
        
        if (value < Data)
        {
            return Left?.Contains(value) ?? false;
        }
        else
        {
            return Right?.Contains(value) ?? false;
        }
    }

    public int GetHeight()
    {
        // Problem 4: Calculate tree height
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}