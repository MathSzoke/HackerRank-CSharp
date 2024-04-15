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
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    /*
        Objetivo do desafio:

        Retornar o menor ID dos passarinhos mais vistos. No array: [1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4] Por exemplo, o passarinho com o menor ID que mais foi visto é o número 3.
     */
    public static int migratoryBirds(List<int> arr)
    {
        int[] ar = arr.ToArray();

        // Agrupa os passarinhos pelo ID e conta quantos de cada ID há
        var counts = ar.GroupBy(x => x).Select(g => new { ID = g.Key, Count = g.Count() });

        // Encontra o número máximo de avistamentos
        int maxCount = counts.Max(x => x.Count);

        // Filtra os passarinhos que têm o número máximo de avistamentos e pega o de menor ID
        int result = counts.Where(x => x.Count == maxCount).Min(x => x.ID);

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        List<int> arr = [1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4];

        int result = Result.migratoryBirds(arr);

        Console.WriteLine(result);
    }
}
