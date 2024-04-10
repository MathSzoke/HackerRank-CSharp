namespace TestsConsole;

public class Program
{
    private static void Main(string[] args)
    {
        string decodedMessage = DecodeMorse(DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011"));

        Console.WriteLine(decodedMessage);
    }

    public static string DecodeBits(string bits)
    {
        var cleanedBits = bits.Trim('0');
        var rate = GetRate();
        return cleanedBits
          .Replace(GetDelimiter(7, "0"), "   ")
          .Replace(GetDelimiter(3, "0"), " ")
          .Replace(GetDelimiter(3, "1"), "-")
          .Replace(GetDelimiter(1, "1"), ".")
          .Replace(GetDelimiter(1, "0"), "");

        string GetDelimiter(int len, string c) => Enumerable.Range(0, len * rate).Aggregate("", (acc, _) => acc + c);
        int GetRate() => GetLengths("0").Union(GetLengths("1")).Min();
        IEnumerable<int> GetLengths(string del) => cleanedBits.Split(del, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Length);
    }

    public static string DecodeMorse(string morseCode)
    {
        return morseCode
          .Split("   ")
          .Aggregate("", (res, word) => $"{res}{ConvertWord(word)} ")
          .Trim();

        string ConvertWord(string word) => word.Split(' ').Aggregate("", (wordRes, c) => wordRes + MorseCode.Get(c));
    }
}

public class MorseCode
{
    public static string Get(string code)
    {
        if (code == "...---...") // Verificação para o código especial SOS
        {
            return "SOS";
        }
		
        if (_morseCode.TryGetValue(code, out char character))
        {
            return character.ToString();
        }
        else
        {
            return " ";
        }
    }

    private static readonly Dictionary<string, char> _morseCode = new()
    {
        {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'},
        {".", 'E'}, {"..-.", 'F'}, {"--.", 'G'}, {"....", 'H'},
        {"..", 'I'}, {".---", 'J'}, {"-.-", 'K'}, {".-..", 'L'},
        {"--", 'M'}, {"-.", 'N'}, {"---", 'O'}, {".--.", 'P'},
        {"--.-", 'Q'}, {".-.", 'R'}, {"...", 'S'}, {"-", 'T'},
        {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'},
        {"-.--", 'Y'}, {"--..", 'Z'},
        {"-----", '0'}, {".----", '1'}, {"..---", '2'}, {"...--", '3'},
        {"....-", '4'}, {".....", '5'}, {"-....", '6'}, {"--...", '7'},
        {"---..", '8'}, {"----.", '9'},
        {".-.-.-", '.'}, {"--..--", ','}, {"..--..", '?'}, {".----.", '\''},
        {"-.-.--", '!'}, {"-..-.", '/'}, {"-.--.", '('}, {"-.--.-", ')'},
        {".-...", '&'}, {"---...", ':'}, {"-.-.-.", ';'}, {"-...-", '='},
        {".-.-.", '+'}, {"-....-", '-'}, {"..--.-", '_'}, {".-..-.", '\"'},
        {"...-..-", '$'}, {".--.-.", '@'}, {"/", ' '}
    };
}