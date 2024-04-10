/*
    Problema:
    A empresa lançou um novo sistema interno e cada funcionário recebeu um nome de usuário.
    Os funcionários têm permissão para alterar seus nomes de usuário, mas apenas de uma maneira limitada.
    Mais especificamente, eles podem escolher letras em duas posições diferentes e trocá-las.
    Por exemplo, o nome de usuário "bigfish" pode ser alterado para "gibfish" (trocando 'b' por 'g') ou "bighisf" (trocando 'f' por 'h').
    O gerente gostaria de saber quais funcionários podem atualizar seus nomes de usuário de forma que o novo nome de usuário seja menor em ordem alfabética do que o nome de usuário original.
*/

public class Program
{
    static void Main()
    {
        List<string> usernames = new List<string> { "bee", "superhero", "ace" };
        List<string> results = PossibleChanges(usernames);
        foreach (string result in results)
        {
            Console.WriteLine(result);
        }
    }

    static List<string> PossibleChanges(List<string> usernames)
    {
        return usernames.Select(username =>
        {
            List<char> chars = username.ToList();
            for (int i = 0; i < chars.Count - 1; i++)
            {
                for (int j = i + 1; j < chars.Count; j++)
                {
                    if (chars[i] > chars[j])
                    {
                        chars[i] = username[j];
                        chars[j] = username[i];
                        return "YES";
                    }
                }
            }
            return "NO";
        }).ToList();
    }
}