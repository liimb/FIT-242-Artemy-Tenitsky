using System.Runtime.InteropServices;

namespace Lab.UnsafeTree;

public unsafe class UnsafeBinaryTree
{
    public static void Main(string[] args)
    {
        TreeNode* root = (TreeNode*)Marshal.AllocHGlobal(sizeof(TreeNode));
            
        Console.WriteLine("Введите коренной элемент: "); 
        root->Number = int.Parse(Console.ReadLine()); 
        root->Name = Console.ReadLine(); 
        root->LeftNode = null; 
        root->RightNode = null;
        
        Console.WriteLine("Введите число элементов: ");
        int count = int.Parse(Console.ReadLine()); 
        for (int i = 0; i < count; i++) 
        { 
            TreeNode* newNode = (TreeNode*)Marshal.AllocHGlobal(sizeof(TreeNode)); 
            
            Console.WriteLine("Введите элемент:");
            newNode->Number = int.Parse(Console.ReadLine());
            newNode->Name = Console.ReadLine();
            newNode->LeftNode = null;
            newNode->RightNode = null;
            TreeNode* current = root;
            
            while (true)
            {
                if (newNode->Number < current->Number)
                {
                    if (current->LeftNode == null)
                    {
                        current->LeftNode = newNode;
                        break;
                    }
                    current = current->LeftNode;
                }
                else if (newNode->Number > current->Number)
                {
                    if (current->RightNode == null)
                    {
                        current->RightNode = newNode;
                        break;
                    }
                    current = current->RightNode;
                }
                else
                {
                    Console.WriteLine("Элемент с таким номером уже существует");
                    break;
                }
            }
        }
    }
}
