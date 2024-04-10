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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
	// Neste código, Count é um método de extensão LINQ que conta o número
    	// de elementos em uma sequência que atendem a determinada condição.
		
        int countPositive = arr.Count(x => x > 0);
        int countNegative = arr.Count(x => x < 0);
        int countZero = arr.Count(x => x == 0);

        Console.WriteLine(((float)countPositive / arr.Count).ToString("F6"));
        Console.WriteLine(((float)countNegative / arr.Count).ToString("F6"));
        Console.WriteLine(((float)countZero / arr.Count).ToString("F6"));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
