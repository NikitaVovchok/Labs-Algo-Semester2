using System;

class Program
{
    static void Main(string[] args)
    {
        // Створюємо вузли дерева виразу
        Node root = new Node('*');
        Node left = new Node('+', new Node('5'), new Node('3'));
        Node right = new Node('-', new Node('7'), new Node('2'));

        // Встановлюємо дочірні вузли
        root.Left = left;
        root.Right = right;

        // Виводимо вираз у інфіксній формі
        Console.WriteLine("Вираз у інфіксній формі:");
        InfixTraversal(root);
        Console.WriteLine();

        // Обчислюємо значення виразу
        int result = EvaluateExpression(root);
        Console.WriteLine("Значення виразу: " + result);

        Console.ReadLine();
    }

    static void InfixTraversal(Node node)
    {
        if (node != null)
        {
            if (node.Data != '+' && node.Data != '-' && node.Data != '*' && node.Data != '/')
            {
                Console.Write(node.Data);
            }
            else
            {
                Console.Write("(");
                InfixTraversal(node.Left);
                Console.Write(node.Data);
                InfixTraversal(node.Right);
                Console.Write(")");
            }
        }
    }

    static int EvaluateExpression(Node node)
    {
        if (node == null)
            return 0;

        // Якщо вузол є листком (число), повертаємо його значення
        if (node.Left == null && node.Right == null)
            return int.Parse(node.Data.ToString());

        // Обчислюємо значення лівого та правого піддерева
        int leftValue = EvaluateExpression(node.Left);
        int rightValue = EvaluateExpression(node.Right);

        // Виконуємо операцію залежно від оператора
        switch (node.Data)
        {
            case '+':
                return leftValue + rightValue;
            case '-':
                return leftValue - rightValue;
            case '*':
                return leftValue * rightValue;
            case '/':
                return leftValue / rightValue;
            default:
                throw new Exception("Невалідний оператор");
        }
    }
}

class Node
{
    public char Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(char data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    public Node(char data, Node left, Node right)
    {
        Data = data;
        Left = left;
        Right = right;
    }
}