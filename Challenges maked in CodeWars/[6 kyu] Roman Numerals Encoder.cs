public class RomanConvert
{
    public static string Solution(int n)
    {
        if (n < 1 || n > 3999)
        {
            throw new ArgumentException("Input must be between 1 and 3999 (inclusive).");
        }

        string result = "";

        // Definindo os símbolos romanos e seus valores correspondentes
        string[] romanSymbols = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"]; // 13
        int[] values = 	[1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1]; // 13

        for (int i = 0; i < values.Length; i++)
        {
            while (n >= values[i])
            {
                result += romanSymbols[i]; // Adiciona continuamente os números romanos convertidos.
                n -= values[i]; // Remove o valor inteiro do número romano, por exemplo, se passarem 1990 de parametro, após chegar nessa linha irá remover o 1 e sobrar 990, depois irá remover o 9 e deixar 90
            }
        }

        return result;
    }
}