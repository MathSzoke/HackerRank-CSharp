using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY ar
     */

    // Este método recebe três argumentos: n, k e uma lista de inteiros ar
    public static int divisibleSumPairs(int n, int k, List<int> ar)
    {
        // Inicializa uma variável de saída para contar os pares divisíveis encontrados
        int output = 0;

        // Converte a lista de inteiros em um array de inteiros para facilitar o acesso aos elementos
        int[] arr = ar.ToArray();

        // Loop externo para percorrer todos os elementos do array
        for (int i = 0; i < n; i++)
        {
            // Loop interno para percorrer os elementos a partir do próximo elemento após o atual (i + 1)
            for (int j = i + 1; j < n; j++)
            {
                // Verifica se a soma dos elementos nos índices i e j é divisível por k
                if ((arr[i] + arr[j]) % k == 0)
                {
                    // Incrementa a variável de saída se a condição for verdadeira
                    output++;
                }
            }
        }

        // Retorna o total de pares divisíveis encontrados
        return output;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.divisibleSumPairs(n, k, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
