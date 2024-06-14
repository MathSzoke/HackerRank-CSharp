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
     * Complete the 'gridSearch' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING_ARRAY G
     *  2. STRING_ARRAY P
     */

    public static string gridSearch(List<string> G, List<string> P)
    {
        int G_rows = G.Count; // Conta a quantidade de linhas na lista
        int P_rows = P.Count; // Conta a quantidade de linhas na lista
        int G_columns = G[0].Length; // Conta a quantidade de colunas na lista
        int P_columns = P[0].Length; // Conta a quantidade de colunas na lista
        bool found = false; // Sinaliza se os itens da lista P foram encontradas dentro do corpo da lista G, redundante ao tamanho de itens na lista P.
                            // Por exemplo, se o P tem 3 itens sendo 3x3 e G tem 9 itens sendo 9x9, deve-se encontrar os itens de P dentro de 6x6 da lista G.

        for (int i = 0; i <= G_rows - P_rows; i++) // Reduzindo o tanto de linha da lista G para se encaixar dentro do quadrante indicado.
        {
            for (int j = 0; j <= G_columns - P_columns; j++) // Reduzindo o tamanho de colunas da lista G para se encaixar dentro do quadrante indicado.
            {
                bool match = true; // Se combina ou não combina o item da lista P com a lista G
                for (int k = 0; k < P_rows; k++) // Para cada item da lista P
                {
                    /*
                     * Nesta explicação vemos o que o if abaixo faz e como acontece a validação:
                     * 
                     *  • G[i + k]: Esta expressão pega a linha da matriz G que está a k linhas abaixo da linha inicial i.
                     * 
                     *  • .Substring(j, P_columns): De dentro desta linha, pega uma substring que começa na coluna j e se estende por P_columns caracteres.
                     *      Basicamente, estamos extraindo uma porção da linha G[i + k] que corresponde ao comprimento da linha da matriz P.
                     *  • P[k]: Esta é a linha k da matriz P.
                     *  • !=: O operador de desigualdade verifica se a substring extraída de G não é igual à linha correspondente em P.
                     */
                    if (G[i + k].Substring(j, P_columns) != P[k])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) // Se o item combina
                {
                    found = true;
                    break;
                }
            }
            if (found) break;
        }

        return found ? "YES" : "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        List<string> G =
        [
            "7283455864",
            "6731158619",
            "8988242643",
            "3830589324",
            "2229505813",
            "5633845374",
            "6473530293",
            "7053106601",
            "0834282956",
            "4607924137"
        ];

        List<string> P =
        [
            "9505",
            "3845",
            "3530"
        ];

        Console.WriteLine(Result.gridSearch(G, P));
    }
}
