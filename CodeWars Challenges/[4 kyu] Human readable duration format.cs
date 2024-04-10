//  Your task in order to complete this Kata is to write a function which formats a duration, given as a number of seconds, in a human-friendly way.

//  The function must accept a non-negative integer. If it is zero, it just returns "now". Otherwise, the duration is expressed as a combination of years, days, hours, minutes and seconds.

//  It is much easier to understand with an example:

//  *For seconds = 62, your function should return 
//      "1 minute and 2 seconds"
//  * For seconds = 3662, your function should return
//      "1 hour, 1 minute and 2 seconds"
//  For the purpose of this Kata, a year is 365 days and a day is 24 hours.

//  Note that spaces are important.

//  Detailed rules
//  The resulting expression is made of components like 4 seconds, 1 year, etc. In general, a positive integer and one of the valid units of time, separated by a space. The unit of time is used in plural if the integer is greater than 1.

//  The components are separated by a comma and a space (", "). Except the last component, which is separated by " and ", just like it would be written in English.

//  A more significant units of time will occur before than a least significant one. Therefore, 1 second and 1 year is not correct, but 1 year and 1 second is.

//  Different components have different unit of times. So there is not repeated units like in 5 seconds and 1 second.

//  A component will not appear at all if its value happens to be zero. Hence, 1 minute and 0 seconds is not valid, but it should be just 1 minute.

//  A unit of time must be used "as much as possible". It means that the function should not return 61 seconds, but 1 minute and 1 second instead. Formally, the duration specified by of a component must not be greater than any valid more significant unit of time.

public class Kata
{
    public static void Main(string[] args) => Console.WriteLine(FormatDuration(253374061));
    public static string FormatDuration(int seconds)
    {
        // Se seconds for 0, retorna "now".
        if (seconds is 0) return "now";

        // "durations" contém a quantidade de segundos em um ano, dia, hora, minuto e segundo, respectivamente. "units" contém os nomes correspondentes.
        int[] durations = [365 * 24 * 60 * 60, 24 * 60 * 60, 60 * 60, 60, 1];
        string[] units = ["year", "day", "hour", "minute", "second"];

        /* Exemplo de saida da variavel "components":
         * 1 year
         * 195 days
         * 23 hours
         * 22 minutes
         * 33 seconds
        */
        var components = durations
            .Select((duration, index) =>
            {
                int value = seconds / duration;
                seconds %= duration;

                return value > 0 ? $"{value} {units[index]}{(value > 1 ? "s" : "")}" : null; // Adiciona um "s" em cada unidade tornando-os plural, como por exemplo: 1 year, 195 days, 23 hours, 22 minutes and 33 seconds
            }).Where(component => component is not null).ToList();

        return components.Count switch
        {
            // Se o componente houver apenas 1 item, tal como "45 seconds", irá retornar apenas este componente.
            1 => components.First()!,
            /* 
             * Concatena a string da variavel "components" com virgula para separar os anos, dias, horas, minutos e segundos. 
             * 
             * Exemplo de saida da concatenação da variavel "components":
             * 
             * 1 year, 195 days, 23 hours, 22 minutes and 33 seconds
            */
            > 1 => $"{string.Join(", ", components.Take(components.Count - 1))} and {components.Last()}",
            // Se não houver componentes (a lista está vazia), retornamos uma string vazia.
            _ => string.Empty
        };
    }
}