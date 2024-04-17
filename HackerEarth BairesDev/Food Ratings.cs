using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    /// <summary>
	/// Encontra o prato mais bem avaliado com base nas avaliações fornecidas.
	/// </summary>
	/// <param name="n">O número de avaliações.</param>
	/// <param name="ratings">As avaliações dos pratos, representadas como um array de arrays onde cada subarray contém o ID do prato e a avaliação.</param>
	/// <returns>O ID do prato mais bem avaliado.</returns>
	public static int FindHighestRatedDish(int n, int[][] ratings)
	{
		// Dicionário para armazenar as avaliações de cada prato
		Dictionary<int, List<int>> dishRatings = new Dictionary<int, List<int>>();
		
		// Itera sobre as avaliações para armazenar as avaliações de cada prato no dicionário
		foreach (var rating in ratings)
		{
			int dishId = rating[0];
			int dishRating = rating[1];
			
			if (!dishRatings.ContainsKey(dishId))
			{
				dishRatings[dishId] = new List<int>();
			}
			
			dishRatings[dishId].Add(dishRating);
		}
		
		// Variáveis para armazenar o ID do prato mais bem avaliado e sua avaliação média
		int highestRatedDishId = -1;
		double highestAvgRating = double.MinValue;
		
		// Itera sobre o dicionário para encontrar o prato mais bem avaliado
		foreach (var kvp in dishRatings)
		{
			double avgRating = kvp.Value.Average();
			
			// Verifica se o prato atual tem uma avaliação média maior que a maior avaliação média encontrada até agora
			// ou se tem a mesma avaliação média, mas um ID menor
			if (avgRating > highestAvgRating || (avgRating == highestAvgRating && kvp.Key < highestRatedDishId))
			{
				highestAvgRating = avgRating;
				highestRatedDishId = kvp.Key;
			}
		}
		
		// Retorna o ID do prato mais bem avaliado
		return highestRatedDishId;
	}

}
