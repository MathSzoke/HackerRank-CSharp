/*
    We need to sum big numbers and we require your help.

    Write a function that returns the sum of two numbers. The input numbers are strings and the function must return a string.

    Example
    add("123", "321"); -> "444"
    add("11", "99");   -> "110"
    Notes
    The input numbers are big.
    The input is a string of only digits
    The numbers are positives
 */

using System.Numerics;

namespace TestConsole;

public class Kata
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Add("15615641651651", "15615641651651"));
    }

    // Este método converte string para BigInt, realizando um calculo de soma para essas strings, mas antes, é verificado se os valores de string é null ou vázio, se não for, faz a conta, se não retorna 0.
    public static string Add(string a, string b) => !string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b) ? (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString() : 0.ToString();
}