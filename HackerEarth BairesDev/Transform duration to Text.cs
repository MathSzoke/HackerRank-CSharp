using System;

public class Solution
{
    /// <summary>
	/// Converte a duração em segundos em um texto legível, representando a duração em anos, dias, horas, minutos e segundos.
	/// </summary>
	/// <param name="seconds">O número de segundos a ser convertido.</param>
	/// <returns>Uma string representando a duração em termos de anos, dias, horas, minutos e segundos.</returns>
	public static string FormatDuration(int seconds)
	{
		// Verifica se a duração é zero e retorna "now" se verdadeiro
		if (seconds == 0)
			return "now";

		// Define as durações e unidades de tempo em ordem decrescente de valor
		int[] durations = { 365 * 24 * 60 * 60, 24 * 60 * 60, 60 * 60, 60, 1 };
		string[] units = { "year", "day", "hour", "minute", "second" };

		// Inicializa a string de resultado
		string result = "";

		// Variável para controlar se é o primeiro elemento a ser adicionado ao resultado
		bool isFirst = true;

		// Percorre as durações e unidades de tempo para calcular a duração em cada unidade
		for (int i = 0; i < durations.Length; i++)
		{
			int duration = durations[i];
			int count = seconds / duration;
			seconds %= duration;

			// Verifica se a contagem é maior que zero para adicionar a unidade ao resultado
			if (count > 0)
			{
				// Adiciona vírgula ou "and" conforme necessário
				if (!isFirst)
				{
					if (seconds == 0)
						result += " and ";
					else
						result += ", ";
				}

				// Adiciona a contagem e a unidade ao resultado
				result += $"{count} {units[i]}{(count > 1 ? "s" : "")}";
				isFirst = false;
			}
		}

		// Retorna o resultado
		return result;
	}
}
