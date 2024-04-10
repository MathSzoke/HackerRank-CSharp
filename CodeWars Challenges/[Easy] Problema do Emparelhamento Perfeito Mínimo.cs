/*
    O problema dado é conhecido como o "Problema do Emparelhamento Perfeito Mínimo".
    Ele envolve encontrar a atribuição ótima de uma lista de equipes (representadas por suas posições ao longo de uma estrada)
    a uma lista de trabalhos (também representados por suas posições ao longo da mesma estrada),
    de modo que a soma das distâncias percorridas por todas as equipes seja minimizada.

    Por exemplo, se tivermos equipes nas posições {1, 3, 5} e trabalhos nas posições {3, 5, 7},
    uma atribuição possível seria {1 → 3, 3 → 5, 5 → 7}, resultando em uma distância total percorrida de 6 unidades.
*/

public class Program
{
    static void Main()
    {
        List<int> crewId = new List<int> { 5, 3, 1, 4, 6 };
        List<int> jobId = new List<int> { 9, 8, 3, 15, 1 };
        Console.WriteLine(GetMinCost(crewId, jobId));  // Saída: 17

        crewId = new List<int> { 5, 1, 4, 2 };
        jobId = new List<int> { 4, 7, 9, 10 };
        Console.WriteLine(GetMinCost(crewId, jobId));  // Saída: 18
    }

    static long GetMinCost(List<int> crewId, List<int> jobId) => crewId.OrderBy(c => c)
                     .Zip(jobId.OrderBy(j => j), (c, j) => Math.Abs((long)c - j))
                     .Sum();
}