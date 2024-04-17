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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */

    /// <summary>
    /// Obletivo:
    ///     Formar um quadrado mágico, na qual consiste em ter diferentes tamanhos, sendo 3x3, 4x4, etc...
    ///     O valor calculado de soma cada linha, coluna e diagonal deve retorar o mesmo valor da Constante mágica
    /// </summary>
    /// <param name="s"></param>
    /// <returns>int: o custo total mínimo da conversão do quadrado de entrada num quadrado mágico</returns>
    public static int formingMagicSquare(List<List<int>> s)
    {
        // Define todas as permutações possíveis de um quadrado mágico 3x3
        int[][][] possiblePermutations = [
            [[8, 1, 6], [3, 5, 7], [4, 9, 2]],
            [[6, 1, 8], [7, 5, 3], [2, 9, 4]],
            [[4, 9, 2], [3, 5, 7], [8, 1, 6]],
            [[2, 9, 4], [7, 5, 3], [6, 1, 8]],
            [[8, 3, 4], [1, 5, 9], [6, 7, 2]],
            [[4, 3, 8], [9, 5, 1], [2, 7, 6]],
            [[6, 7, 2], [1, 5, 9], [8, 3, 4]],
            [[2, 7, 6], [9, 5, 1], [4, 3, 8]],
        ];

        // Inicializa o custo mínimo com o maior valor possível de um inteiro
        int minCost = int.MaxValue;

        // Para cada permutação, calcula o custo de conversão da matriz de entrada para a permutação atual
        foreach (var p in possiblePermutations)
        {
            // Inicializa o custo total para esta permutação
            int cost = 0;

            // Calcula o custo absoluto da diferença entre os elementos da matriz de entrada e da permutação atual
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cost += Math.Abs(s[i][j] - p[i][j]);
                }
            }

            // Atualiza o custo mínimo encontrado até agora
            minCost = Math.Min(minCost, cost);
        }

        // Retorna o menor custo total encontrado
        return minCost;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        List<List<int>> s =
        [
            [4, 9, 2],
            [3, 5, 7],
            [8, 1, 5],
        ];

        int result = Result.formingMagicSquare(s);

        Console.WriteLine(result);
    }
}
