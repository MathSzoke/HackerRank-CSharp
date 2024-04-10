//  There is an array with some numbers. All numbers are equal except for one. Try to find it!

//  findUniq([ 1, 1, 1, 2, 1, 1 ]) === 2
//  findUniq([0, 0, 0.55, 0, 0]) === 0.55
//  It’s guaranteed that array contains at least 3 numbers.

//  The tests contain some very huge arrays, so think about performance.

//  This is the first kata in series:

//  Find the unique number (this kata)
//  Find the unique string
//  Find The Unique

public class Kata
{
    public static void Main(string[] args) => Console.WriteLine(GetUnique([-2, 2, 2, 2]));

    public static int GetUnique(IEnumerable<int> numbers) => numbers.GroupBy(n => n).First(x => x.Count() is 1).Key;
}

// GroupBy(n => n):
// GroupBy é um método LINQ que agrupa elementos com base em uma chave. Neste caso, ele está agrupando os números na coleção com base no próprio número (n).

// Para detalhar um pouco mais sobre o agrupamento de vários números iguais, teremos o seguinte resultado para um Array com os seguintes valores agrupados:

// ArrayDeNumeros = {1, 2, 3, 2, 1, 4, 5, 4};
// Ao agrupar utilizando o método GroupBy, os números e grupos ficarão assim:
// Grupo 1: {1, 1}
// Grupo 2: {2, 2}
// Grupo 3: {3} -----> Este é o primeiro grupo com apenas 1 elemento a ser constado no método First com a condição passada.
// Grupo 4: {4, 4}
// Grupo 5: {5} -----> Este é o segundo grupo com apenas 1 elemento, portanto, não deverá ser constado no método First.

// First(x => x.Count() is 1):
// First é outro método LINQ que retorna o primeiro elemento que atende a uma condição específica. Aqui, a condição é dada por x => x.Count() is 1, 
// o que significa que estamos procurando o primeiro grupo onde o número de elementos no grupo (Count()) é igual a 1.

// .Key:
// O método Key é usado para obter a chave do grupo. Neste caso, a chave do grupo é o número único que ocorre uma única vez na coleção.