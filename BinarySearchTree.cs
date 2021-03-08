using System.Collections;
class BinarySearchTree : IEnumerable
{
    private BinarySearchTreeNode root = null;

    public IEnumerator GetEnumerator()
    {
        Stack stack = new Stack();
        stack.Push(this.root);
        while(stack.Count > 0)
        {
            BinarySearchTreeNode tempNode = (BinarySearchTreeNode)stack.Pop();
            yield return tempNode.value;
            if (tempNode.right != null) {
                stack.Push(tempNode.right);
            }
            if (tempNode.left != null) {
                stack.Push(tempNode.left);
            }
        }
    }
    public void Add(int value)
    {
        BinarySearchTreeNode newNode = new BinarySearchTreeNode(value);
        BinarySearchTreeNode tempParentNode = null;
        BinarySearchTreeNode tempNode = this.root;
        while (tempNode != null)
        {
            tempParentNode = tempNode;
            if (newNode.value < tempNode.value)
            {
                tempNode = tempNode.left;
            }
            else
            {
                tempNode = tempNode.right;
            }
        }
        newNode.parent = tempParentNode;
        if (tempParentNode == null)
        {
            this.root = newNode;
        }
        else
            if (newNode.value < tempParentNode.value)
            {
                tempParentNode.left = newNode;
            }
        else
        {
            tempParentNode.right = newNode;
        }
    }
    public void Delete(int value)
    {
        BinarySearchTreeNode nodeToBeDeleted = FindNode(value);
        if (nodeToBeDeleted.left == null)
        {
            replaceSubtrees(nodeToBeDeleted, nodeToBeDeleted.right);
        }
        else
            if (nodeToBeDeleted.right == null)
            {
                replaceSubtrees(nodeToBeDeleted, nodeToBeDeleted.left);
            }
        else
        {
            BinarySearchTreeNode temp = MinNode(nodeToBeDeleted.right);
            if (temp.parent != nodeToBeDeleted)
            {
                replaceSubtrees(temp, temp.right);
                temp.right = nodeToBeDeleted.right;
                temp.right.parent = temp;
            }
            replaceSubtrees(nodeToBeDeleted, temp);
            temp.left = nodeToBeDeleted.left;
            temp.left.parent = temp;
        }
        #region Helper methods for delete
        void replaceSubtrees(BinarySearchTreeNode subtreeToBeReplacedWith, BinarySearchTreeNode subtreeToReplace)
        {
            if (subtreeToBeReplacedWith.parent == null)
            {
                this.root = subtreeToReplace;
            }
            else
                if (subtreeToBeReplacedWith == subtreeToBeReplacedWith.parent.left)
                {
                    subtreeToBeReplacedWith.parent.left = subtreeToReplace;
                }
            else
            {
                subtreeToBeReplacedWith.parent.right = subtreeToReplace;
            }
            if  (subtreeToReplace != null)
            {
                subtreeToReplace.parent = subtreeToBeReplacedWith.parent;
            }
        }
        BinarySearchTreeNode MinNode(BinarySearchTreeNode subtreeRoot)
        {
            while (subtreeRoot.left != null)
            {
                subtreeRoot = subtreeRoot.left;
            }
            return subtreeRoot;
        }
        BinarySearchTreeNode FindNode(int value)
        {
            BinarySearchTreeNode temp = this.root;
            while (value != temp.value)
            {
                if (value < temp.value)
                {
                    temp = temp.left;
                }
            else
            {
                temp = temp.right;
            }
            }
            return temp;
        }
        #endregion
    }
}