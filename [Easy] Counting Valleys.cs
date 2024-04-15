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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    /// <summary>
    /// Conta o número de vales atravessados durante uma caminhada com base na sequência de passos fornecida.
    /// </summary>
    /// <param name="steps">O número total de passos na caminhada.</param>
    /// <param name="path">Uma string representando a sequência de passos, onde 'U' indica um passo para cima e 'D' indica um passo para baixo.</param>
    /// <returns>O número de vales atravessados durante a caminhada.</returns>
    public static int countingValleys(int steps, string path)
    {
        // Inicializa variáveis para rastrear a altitude atual e o número de vales atravessados
        int altitude = 0;
        int valleys = 0;

        // Itera através de cada passo no caminho
        foreach (char step in path)
        {
            // Se o passo for uma subida, incrementa a altitude
            if (step == 'U')
            {
                altitude++;
                // Se a altitude se tornar 0, significa que o hiker saiu de um vale
                if (altitude == 0)
                {
                    // Incrementa o contador de vales
                    valleys++;
                }
            }
            // Se o passo for uma descida, decrementa a altitude
            else if (step == 'D')
            {
                altitude--;
            }
        }

        // Retorna o número total de vales atravessados
        return valleys;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
