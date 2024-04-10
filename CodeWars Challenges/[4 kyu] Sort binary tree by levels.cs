/*
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Value;
    
        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }
    }

    Your task is to return the list with elements from tree sorted by levels, which means the root element goes first, then root children (from left to right) are second and third, and so on.

    Return empty list if root is 'null'.

    Example 1 - following tree:

                        2
                8        9
                1  3     4   5
    Should return following list:

    [2,8,9,1,3,4,5]
    Example 2 - following tree:

                        1
                8        4
                    3        5
                                7
    Should return following list:

    [1,8,4,3,5,7]

 */

namespace TestConsole;

public class Kata
{
    public class Node(Node l, Node r, int v)
    {
        public Node Left = l;
        public Node Right = r;
        public int Value = v;
    }

    public static void Main(string[] args)
    {
        // Example 1
        Node root1 = new Node(
            new Node(new Node(null, null, 1), new Node(null, null, 3), 8),
            new Node(new Node(null, null, 4), new Node(null, null, 5), 9),
            2
        );

        // Example 2
        Node root2 = new Node(
            new Node(null, new Node(null, null, 3), 8),
            new Node(new Node(null, null, 5), new Node(null, new Node(null, null, 7), 7), 4),
            1
        );

        Node root3 = new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1);

        List<int> result1 = TreeByLevels(root1);
        List<int> result2 = TreeByLevels(root2);
        List<int> result3 = TreeByLevels(root3);

        Console.WriteLine("Example 1:");
        Console.WriteLine(string.Join(",", result1));
        Console.WriteLine("Example 2:");
        Console.WriteLine(string.Join(",", result2));

        Console.WriteLine("Example 3:");
        Console.WriteLine(string.Join(",", result3));
    }

    /// <summary>
    /// Este método recebe um nó root como entrada e retorna uma lista de inteiros representando a ordem dos elementos na árvore em níveis. 
    /// Começamos inicializando uma lista vazia result que conterá os elementos da árvore em ordem de nível.
    /// Em seguida, verificamos se o nó raiz é nulo.
    /// Se for, retornamos imediatamente uma lista vazia, já que não há elementos para percorrer.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static List<int> TreeByLevels(Node node)
    {
        List<int> result = [];
        if (node == null) return result;

        Queue<Node> queue = new();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                Node current = queue.Dequeue();
                result.Add(current.Value);

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        return result;
    }
}

/*
    Criamos uma fila queue para armazenar os nós que precisam ser processados. 
    Inicialmente, adicionamos o nó raiz à fila. Começamos um loop enquanto houver elementos na fila. 
    Dentro desse loop, obtemos o tamanho atual da fila, que representa o número de nós no nível atual da árvore (isso é importante para sabermos quantos nós devemos processar em cada nível).

    Então, iniciamos outro loop para processar cada nó no nível atual. Dentro deste loop, retiramos o nó da frente da fila (usando Dequeue) e adicionamos o valor do nó à lista de resultados. 
    Em seguida, verificamos se há filhos esquerdos e direitos para o nó atual. Se houver, os adicionamos à fila para que possam ser processados nos próximos níveis.
 */