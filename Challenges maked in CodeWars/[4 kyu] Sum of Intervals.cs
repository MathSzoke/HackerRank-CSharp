/*
    Write a function called sumIntervals/sum_intervals that accepts an array of intervals, and returns the sum of all the interval lengths. Overlapping intervals should only be counted once.

    Intervals
    Intervals are represented by a pair of integers in the form of an array. The first value of the interval will always be less than the second value. Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.

    Overlapping Intervals
    List containing overlapping intervals:

    [
       [1, 4],
       [7, 10],
       [3, 5]
    ]
    The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, we can treat the interval as [1, 5], which has a length of 4.

    Examples:
    sumIntervals( [
       [1, 2],
       [6, 10],
       [11, 15]
    ] ) => 9

    sumIntervals( [
       [1, 4],
       [7, 10],
       [3, 5]
    ] ) => 7

    sumIntervals( [
       [1, 5],
       [10, 20],
       [1, 6],
       [16, 19],
       [5, 11]
    ] ) => 19

    sumIntervals( [
       [0, 20],
       [-100000000, 10],
       [30, 40]
    ] ) => 100000030

    sumIntervals( [
       [-245, -218],
       [-194, -179],
       [-155, -119]
    ] ) => 78
    Tests with large intervals
    Your algorithm should be able to handle large intervals. All tested intervals are subsets of the range [-1000000000, 1000000000].
 */

namespace TestConsole;

public class Intervals
{
    public static void Main(string[] args)
    {
        Console.WriteLine(SumIntervals([(1, 2), (6, 10), (11, 15)]));
    }

    public static int SumIntervals((int, int)[] intervals)
    {
        // Ordena os intervalos pelo início
        intervals = [.. intervals.OrderBy(i => i.Item1)];

        // Lista para armazenar os intervalos mesclados
        var mergedIntervals = new List<(int, int)>();

        // Itera sobre os intervalos ordenados
        foreach (var interval in intervals)
        {
            // Verifica se a lista está vazia ou se não há sobreposição com o último intervalo
            if (mergedIntervals.Count is 0 || interval.Item1 > mergedIntervals.Last().Item2)
            {
                // Se a lista está vazia ou não há sobreposição, adiciona o intervalo
                mergedIntervals.Add(interval);
            }
            else if (interval.Item2 > mergedIntervals.Last().Item2)
            {
                // Se há sobreposição, mas o final do novo intervalo é maior, estende o último intervalo
                mergedIntervals[^1] = (mergedIntervals.Last().Item1, interval.Item2);
                // O uso de ^1 acessa o último elemento da lista, equivalente a mergedIntervals[mergedIntervals.Count - 1]
            }
        }

        // Calcula a soma dos comprimentos dos intervalos
        return mergedIntervals.Sum(interval => interval.Item2 - interval.Item1);
    }
}