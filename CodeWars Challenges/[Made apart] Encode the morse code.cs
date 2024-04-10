
    private static void Main(string[] args)
    {
        string encode = "SOS! THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.";

        Console.WriteLine(Encode(encode));
    }


    private static readonly Dictionary<char, string> _morseCode = new()
    {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'E', "."},
        {'F', "..-."},
        {'G', "--."},
        {'H', "...."},
        {'I', ".."},
        {'J', ".---"},
        {'K', "-.-"},
        {'L', ".-.."},
        {'M', "--"},
        {'N', "-."},
        {'O', "---"},
        {'P', ".--."},
        {'Q', "--.-"},
        {'R', ".-."},
        {'S', "..."},
        {'T', "-"},
        {'U', "..-"},
        {'V', "...-"},
        {'W', ".--"},
        {'X', "-..-"},
        {'Y', "-.--"},
        {'Z', "--.."},
        {'0', "-----"},
        {'1', ".----"},
        {'2', "..---"},
        {'3', "...--"},
        {'4', "....-"},
        {'5', "....."},
        {'6', "-...."},
        {'7', "--..."},
        {'8', "---.."},
        {'9', "----."},
        {'.', ".-.-.-"},
        {',', "--..--"},
        {'?', "..--.."},
        {'\'', ".----."},
        {'!', "-.-.--"},
        {'/', "-..-."},
        {'(', "-.--."},
        {')', "-.--.-"},
        {'&', ".-..."},
        {':', "---..."},
        {';', "-.-.-."},
        {'=', "-...-"},
        {'+', ".-.-."},
        {'-', "-....-"},
        {'_', "..--.-"},
        {'\"', ".-..-."},
        {'$', "...-..-"},
        {'@', ".--.-."},
        {' ', "/"}
    };

    public static string Encode(string message)
    {
        message = message.ToUpper();
        string encodedMessage = "";
        foreach (char character in message)
        {
            if (_morseCode.TryGetValue(character, out string? value))
            {
                encodedMessage += value + " ";
            }
            else
            {
                encodedMessage += character + " ";
            }
        }
        return encodedMessage.Trim();
    }