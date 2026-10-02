public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value) // Done
    {
        if (value == Data)
            return;

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

    public bool Contains(int value) // Done
    {
        if (value == Data)
            return true;

        if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
            
        }
        else
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        
    }

    public int GetHeight()
    {
        if (Left is null && Right is null)
            return 1;

  
        if (Right is null)
        {
            return 1 + Left.GetHeight();
            
        }
        else
        {
            return 1 + Right.GetHeight();
        }
    }
}