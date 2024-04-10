//  Find the missing letter
//  Write a method that takes an array of consecutive (increasing) array as input and that returns the missing letter in the array.

//  You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
//  The array will always contain array in only one case.

//  Example:

//  ['a', 'b', 'c', 'd', 'f']-> 'e'
//  ['O', 'Q', 'R', 'S']-> 'P'
//  (Use the English alphabet with 26 array!)

//  Have fun coding it and please don't forget to vote and rank this kata! :-)

//  I have also created other katas. Take a look if you enjoyed this kata!

public class Kata
{
    public static void Main(string[] args) => Console.WriteLine(FindMissingLetter(['O', 'Q', 'R', 'S']));
	
    public static char FindMissingLetter(char[] array) => (char)(array.Zip(array.Skip(1), (a, b) => (a, b)).First(pair => pair.b - pair.a != 1).a + 1);
}


//  Exemplo com['a', 'b', 'c', 'd', 'f']:

//  Zip:
//  A função Zip combina elementos correspondentes das duas sequências, criando pares ordenados. Aqui, estamos combinando 'a' com 'b', 'b' com 'c', 'c' com 'd', 'd' com 'f'. Então, temos:
//  ('a', 'b'), ('b', 'c'), ('c', 'd'), ('d', 'f')

//  Skip:
//  A função Skip(1) cria uma nova sequência que começa a partir do segundo elemento. Então, temos:
//  ('b', 'c'), ('c', 'd'), ('d', 'f')

//  First:
//  A função First(pair => pair.b - pair.a != 1) encontra o primeiro par onde a diferença entre os elementos não é igual a 1. Neste caso, o par ('d', 'f') é o primeiro que atende a essa condição, pois a diferença entre 'd' e 'f' é 2.

//  Cálculo do caractere ausente:
//  Adicionamos 1 ao valor do primeiro elemento desse par ('d' + 1), o que nos dá 'e'.