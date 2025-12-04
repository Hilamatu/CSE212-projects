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
        

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        else // value == Data
        {
            // Do nothing, no duplicates allowed
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            //Search the left subtree
            if (Left is not null)
            {
                return Left.Contains(value);
            }
        }
        else // value > Data
        {
            // Search the right subtree
            if (Right is not null)
            {
                return Right.Contains(value);
            }
        }
        return false;
    }

    public int GetHeight()
    {
        if (Left == null && Right == null)//If null, it is a leaf
        {
            return 1;
        }
        int LeftHeight = Left?.GetHeight() ?? 0;//If null, return 0 
        int RightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(LeftHeight, RightHeight);//Add 1 for the current node and use MAX to get the taller subtree
        
    }
}