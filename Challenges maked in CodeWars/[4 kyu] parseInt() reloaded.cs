/*
    In this kata we want to convert a string into an integer. The strings simply represent the numbers in words.

    Examples:

    "one" => 1
    "twenty" => 20
    "two hundred forty-six" => 246
    "seven hundred eighty-three thousand nine hundred and nineteen" => 783919
    Additional Notes:

    The minimum number is "zero" (inclusively)
    The maximum number, which must be supported is 1 million (inclusively)
    The "and" in e.g. "one hundred and twenty-four" is optional, in some cases it's present and in others it's not
    All tested numbers are valid, you don't need to validate them
 */

namespace TestConsole;

public class Parser
{
    public static void Main(string[] args)
    {
        Console.WriteLine(ParseInt("one thousand three hundred seven")); // 1307
    }

    public static int ParseInt(string s) => Convert(s);

    static int Convert(string word)
    {
        Dictionary<string, int> map = new()
        {
            { "zero", 0 }, { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 },
            { "eight", 8 }, { "nine", 9 }, { "ten", 10 }, { "eleven", 11 }, { "twelve", 12 }, { "thirteen", 13 }, { "fourteen", 14 },
            { "fifteen", 15 }, { "sixteen", 16 }, { "seventeen", 17 }, { "eighteen", 18 }, { "nineteen", 19 }, { "twenty", 20 },
            { "thirty", 30 }, { "forty", 40 }, { "fifty", 50 }, { "sixty", 60 }, { "seventy", 70 }, { "eighty", 80 },
            { "ninety", 90 }, { "hundred", 100 }, { "thousand", 1000 }, { "million", 1000000 }, { "billion", 1000000000 }
        };

        // Divide a palavra em palavras individuais
        string[] words = word.Split(' ');

        // Converte as palavras para números e soma
        int r = 0; // Resultado de tudo.
        int p = 0; // Número pacial

        foreach (var currentWord in words)
        {
            if (currentWord.Equals("hundred", StringComparison.CurrentCultureIgnoreCase))
            {
                // Se a palavra for "hundred", multiplicamos a p por 100
                p *= 100;
            }
            else if (currentWord.Equals("thousand", StringComparison.CurrentCultureIgnoreCase))
            {
                // Se a palavra for "thousand", multiplicamos a p por 1000 e adicionamos ao result
                r += p * 1000;
                p = 0;
            }
            else if (currentWord.Equals("million", StringComparison.CurrentCultureIgnoreCase))
            {
                // Se a palavra for "million", multiplicamos a p por 1000000 e adicionamos ao result
                r += p * 1000000;
                p = 0;
            }
            else if (currentWord.Contains('-', StringComparison.CurrentCultureIgnoreCase))
            {
                string[] wordSeparated = currentWord.Split('-');

                foreach (string w in wordSeparated)
                    if (map.TryGetValue(w.ToLower(), out int v)) p += v;

            }
            else if (map.TryGetValue(currentWord.ToLower(), out int v))
            {
                // Se a palavra for uma unidade ou dezena
                p += v;
            }
        }

        // Adiciona a p ao result final
        r += p;

        return r;
    }
}