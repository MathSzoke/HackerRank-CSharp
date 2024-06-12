class Result
{
    /*
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        if (h < 1 || h > 12 || m < 0 || m >= 60)
            return "";

        Dictionary<int, string> hours = GetHourDictionary();
        Dictionary<int, string> minutes = GetMinuteDictionary();

        return m switch
        {
            0 => $"{hours[h]} o' clock",
            15 => $"quarter past {hours[h]}",
            30 => $"half past {hours[h]}",
            45 => $"quarter to {hours[h % 12 + 1]}",
            < 30 => $"{minutes[m]} {(m == 1 ? "minute" : "minutes")} past {hours[h]}",
            _ => $"{minutes[60 - m]} {((60 - m) == 1 ? "minute" : "minutes")} to {hours[h % 12 + 1]}",
        };
    }

    private static readonly string[] ones =
    {
        "zero", "one", "two", "three", "four",
        "five", "six", "seven", "eight", "nine",
        "ten", "eleven", "twelve", "thirteen",
        "fourteen", "fifteen", "sixteen", "seventeen",
        "eighteen", "nineteen"
    };

    private static readonly string[] tens =
    {
        "", "", "twenty", "thirty", "forty",
        "fifty"
    };

    public static Dictionary<int, string> GetHourDictionary()
    {
        var hourDictionary = new Dictionary<int, string>();
        for (int i = 1; i <= 12; i++)
        {
            hourDictionary[i] = ones[i];
        }
        return hourDictionary;
    }

    public static Dictionary<int, string> GetMinuteDictionary()
    {
        var minuteDictionary = new Dictionary<int, string>();
        for (int i = 0; i < 60; i++)
        {
            if (i < 20)
            {
                minuteDictionary[i] = ones[i];
            }
            else
            {
                string numberInWords = tens[i / 10];
                if (i % 10 > 0)
                {
                    numberInWords += " " + ones[i % 10];
                }
                minuteDictionary[i] = numberInWords;
            }
        }
        return minuteDictionary;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int h = 5;
        int m = 47;

        string result = Result.timeInWords(h, m);

        Console.WriteLine(result);
    }
}
