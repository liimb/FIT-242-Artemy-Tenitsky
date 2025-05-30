namespace Lab.UnsafeTree;

public unsafe struct TreeNode
{
    public int Number;
    public string Name;
    public TreeNode* LeftNode;
    public TreeNode* RightNode;
}
