using System;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        // Додаємо ключі до бінарного дерева пошуку
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(70);
        bst.Insert(60);
        bst.Insert(80);

        Console.WriteLine("Прямий обхід:");
        bst.InOrderTraversal();
        Console.WriteLine();

        Console.WriteLine("Симетричний обхід:");
        bst.PreOrderTraversal();
        Console.WriteLine();

        Console.WriteLine("Зворотний обхід:");
        bst.PostOrderTraversal();
        Console.WriteLine();

        Console.ReadLine();
    }
}

class Node
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertNode(root, data);
    }

    private Node InsertNode(Node node, int data)
    {
        if (node == null)
        {
            node = new Node(data);
        }
        else if (data < node.Data)
        {
            node.Left = InsertNode(node.Left, data);
        }
        else
        {
            node.Right = InsertNode(node.Right, data);
        }

        return node;
    }

    public void InOrderTraversal()
    {
        InOrderTraversal(root);
    }

    private void InOrderTraversal(Node node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InOrderTraversal(node.Right);
        }
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversal(root);
    }

    private void PreOrderTraversal(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Data + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversal(root);
    }

    private void PostOrderTraversal(Node node)
    {
        if (node != null)
        {
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Data + " ");
        }
    }
}