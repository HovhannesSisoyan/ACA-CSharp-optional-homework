class BinarySearchTreeNode
{
    public int value {get; set;}
    public BinarySearchTreeNode left {get; set;}
    public BinarySearchTreeNode right {get; set;}
    public BinarySearchTreeNode parent {get; set;}
    public BinarySearchTreeNode(int value)
    {
        this.parent = null;
        this.left = null;
        this.right = null;
        this.value = value;
    }

}