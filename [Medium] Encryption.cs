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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        s = s.Replace(" ", ""); // Remover espaços em branco

        int l = s.Length;

        double column = Math.Ceiling(Math.Sqrt(l)); // Math.Sqrt faz o calculo da raiz quadrada do número passado pelo parametro.
                                                    // Math.Ceiling faz o arredondamento para cima do número passado pelo parametro.

        StringBuilder result = new();

        for (int i = 0; i < column; i++) // columns
        {
            for (int j = i; j < l; j += (int)column) // rows
            {
                result.Append(s[j]);
            }
            result.Append(' '); // Adicionar um espaço após cada coluna
        }

        return result.ToString().Trim(); // Remover o espaço extra no final e retornar
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string s = "haveaniceday";

        string result = Result.encryption(s); // input example: haveaniceday

        Console.WriteLine(result); // output expected: hae and via ecy
    }
}
