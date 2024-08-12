public class Solution {
    public string AddBinary(string a, string b) // string a = 1010; string b = 1011
	{
        StringBuilder result = new StringBuilder(); // Construtor de string para o resultado final.
        int carry = 0; // "Carregador" com o inicio de valor de 0
        int i = a.Length - 1; // Tamanho da string de "a" - 1 para condizer com o tamanho total da string "a".
        int j = b.Length - 1; // Tamanho da string de "b" - 1 para condizer com o tamanho total da string "b".

		/*
			Enquanto i (no caso o valor inicial seria 3, pois o tamanho da length de a (4) - 1 é 3
			Ou j (no caso o valor inicial seria 3, pois o tamanho da length de b (4) - 1 é 3
			Ou carry maior que 0
		*/
        while (i >= 0 || j >= 0 || carry > 0) 
        {
            int sum = carry; // variavel de soma

            if (i >= 0) // Se i (a.length) é maior ou igual a 0
            {
				/*
					a variavel soma adiciona o valor resultante do calculo de "a" na posição i (simulando que seria no valor inicial, o valor de i é 3,
					portanto, ele captura o valor do a na posição 3, o que resultaria no valor de "0") menos "0".
					
					O calculo nessa ocasião funciona na seguinte forma:
					Em C#, os caracteres (char) são tratados internamente como números inteiros, de acordo com a tabela ASCII (ou Unicode).
					Por exemplo, o caractere '0' tem o valor ASCII de 48, '1' tem o valor 49, '2' tem o valor 50, e assim por diante.
					
					Quando você faz a subtração a[i] - '0', o que acontece é o seguinte:

					Suponha que a[i] seja o caractere '1'. No código ASCII, '1' tem o valor 49.
					O caractere '0' tem o valor 48.
					Então, a[i] - '0' é equivalente a 49 - 48, que resulta em 1.
					
					Isso transforma o caractere '1' no número inteiro 1.
					Da mesma forma, se a[i] for '0', a[i] - '0' resulta em 48 - 48 = 0.
                */
				sum += a[i] - '0';
                i--; // subtrai o valor de i em -1 para seguir na próxima sequencia da string "a"
            }

			/*
				Mesma coisa dos comentários acima
			*/
            if (j >= 0)
            {
                sum += b[j] - '0';
                j--;
            }

			/*
				Usei result.Insert(0, sum % 2) para adicionar o bit na posição correta (no início do resultado)
				
				No sistema binário, os únicos dígitos são 0 e 1. Quando você soma dois dígitos binários, existem apenas algumas possibilidades:

				0 + 0 = 0
				0 + 1 = 1
				1 + 0 = 1
				1 + 1 = 10 (em binário, 10 significa "0" com um "vai um" para o próximo dígito)
				Agora, considere a operação sum % 2:

				% é o operador módulo, que dá o resto da divisão de um número por outro. No caso de sum % 2, ele divide sum por 2 e retorna o resto.
				
				Quando somamos dois números binários e um possível "carry" (vai um):

				Se a soma for 0 ou 1: sum % 2 vai ser simplesmente sum. Ou seja, se sum é 0 ou 1, sum % 2 também será 0 ou 1.
				Se a soma for 2 (ou seja, 1 + 1): sum % 2 será 0, porque 2 dividido por 2 dá resto 0.
				Se a soma for 3 (ou seja, 1 + 1 + 1, se houve um "carry" anterior): sum % 2 será 1, porque 3 dividido por 2 dá resto 1.
				
								
				Se sum for 2 (como no caso de somar 1 + 1), o sum % 2 resulta em 0, que é o bit menos significativo (o bit "à direita").
				O "carry" é então calculado como sum / 2, que seria 1, indicando que há um "vai um" para o próximo bit.

				Se sum for 1 ou 0, sum % 2 simplesmente dá 1 ou 0, que é o valor que você coloca na posição atual do resultado.

				sum % 2 é usado para determinar o bit que deve ser colocado no resultado atual da soma.
				sum / 2 é usado para determinar se há um "vai um" (carry) para a próxima posição.
			*/
            result.Insert(0, sum % 2);
            carry = sum / 2;
        }

        return result.ToString();
    }
}
