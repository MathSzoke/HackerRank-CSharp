using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	/// <summary>
	/// Gera todas as variações possíveis de um PIN observado, considerando os dígitos adjacentes.
	/// </summary>
	/// <param name="pin">O PIN observado.</param>
	/// <returns>Um array de strings contendo todas as variações possíveis do PIN, ordenadas em ordem crescente.</returns>
    public static string[] GetPINVariations(string pin)
    {
		// Cria um dicionário onde cada dígito do PIN é mapeado para os dígitos adjacentes
		var adjacentDigits = new Dictionary<char, char[]>
		{
			{ '0', new char[] { '0', '8' } },
			{ '1', new char[] { '1', '2', '4' } },
			{ '2', new char[] { '1', '2', '3', '5' } },
			{ '3', new char[] { '2', '3', '6' } },
			{ '4', new char[] { '1', '4', '5', '7' } },
			{ '5', new char[] { '2', '4', '5', '6', '8' } },
			{ '6', new char[] { '3', '5', '6', '9' } },
			{ '7', new char[] { '4', '7', '8' } },
			{ '8', new char[] { '5', '7', '8', '9', '0' } },
			{ '9', new char[] { '6', '8', '9' } }
		};

		// Inicializa uma lista para armazenar as variações do PIN
		var variations = new List<string>();

		// Chama o método recursivo para gerar as variações do PIN
		GenerateVariations(pin.ToCharArray(), 0, "", variations, adjacentDigits);

		// Ordena as variações em ordem crescente e converte para um array de strings
		return variations.OrderBy(v => v).ToArray();
    }

	/// <summary>
	/// Método auxiliar recursivo para gerar as variações do PIN.
	/// </summary>
	/// <param name="observedPIN">O PIN observado, representado como um array de caracteres.</param>
	/// <param name="index">O índice atual do dígito sendo considerado.</param>
	/// <param name="current">A variação atual do PIN sendo construída.</param>
	/// <param name="variations">A lista de variações do PIN.</param>
	/// <param name="adjacentDigits">Um dicionário mapeando cada dígito para os dígitos adjacentes.</param>
    private static void GenerateVariations(char[] observedPIN, int index, string current, List<string> variations, Dictionary<char, char[]> adjacentDigits)
    {
		// Verifica se chegou ao final do PIN
		if (index == observedPIN.Length)
		{
			// Adiciona a variação atual à lista de variações
			variations.Add(current);
			return;
		}

		// Obtém o dígito atual
		char digit = observedPIN[index];

		// Obtém os dígitos adjacentes ao dígito atual
		char[] possibleDigits = adjacentDigits[digit];

		// Para cada dígito adjacente, chama recursivamente o método para gerar as variações
		foreach (char possibleDigit in possibleDigits)
		{
			GenerateVariations(observedPIN, index + 1, current + possibleDigit, variations, adjacentDigits);
		}
    }
}
