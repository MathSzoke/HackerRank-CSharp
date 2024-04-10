/*
    How can you tell an extrovert from an introvert at NSA?
    Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.

    I found this joke on USENET, but the punchline is scrambled. Maybe you can decipher it?
    According to Wikipedia, ROT13 is frequently used to obfuscate jokes on USENET.

    For this task you're only supposed to substitute characters. Not spaces, punctuation, numbers, etc.

    Test examples:

    "EBG13 rknzcyr." -> "ROT13 example."

    "This is my first ROT13 excercise!" -> "Guvf vf zl svefg EBG13 rkprepvfr!"
 */

namespace TestConsole;

public class Kata
{
    public static void Main(string[] args) => Console.WriteLine(Rot13("EBG13 rknzcyr."));

    //Matriz de Letras: Cria uma matriz chamada alphabetic contendo as letras do alfabeto.
    public static string[] alphabetic = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    public static string Rot13(string input) => string.Join("", input.Select(l => char.IsLetter(l) ? char.IsUpper(l) ? alphabetic[(char.ToUpper(l) - 'A' + 13) % 26] : alphabetic[(char.ToUpper(l) - 'A' + 13) % 26].ToLower() : l.ToString())).ToString();
}

/*
    Este método Rot13 realiza as seguintes operações:

    LINQ e Select: Utiliza LINQ para percorrer cada caractere (l) na string de entrada (input).

    Verificação de Letra: Verifica se o caractere é uma letra usando char.IsLetter.

    Índice no Alfabeto: Obtém o índice da letra no alfabeto, convertendo para maiúscula com char.ToUpper.

    Rotação de César: Aplica a rotação de César, adicionando 13 ao índice e usando o operador % para garantir que a rotação ocorra dentro do intervalo de 0 a 25.

    ============================================================================================================================================================

    Rotação de César:
    A Rotação de César é uma técnica de criptografia clássica que consiste em deslocar as letras do alfabeto por um número fixo de posições. Neste caso, estamos usando uma rotação de 13 posições,
    também conhecida como ROT13. Isso significa que cada letra é substituída pela letra que está 13 posições à frente dela no alfabeto.

    Adicionando 13 ao Índice:
    Vamos considerar o alfabeto de A a Z, onde A tem índice 0, B tem índice 1, e assim por diante. Ao adicionar 13 ao índice de uma letra e usar o operador %,
    garantimos que a rotação ocorra dentro do intervalo de 0 a 25 (o tamanho do alfabeto).

    Exemplo:
    Vamos pegar a letra 'A' como exemplo. No alfabeto, 'A' tem índice 0. Se adicionarmos 13 a esse índice, obtemos 13. Usando o operador % 26,
    garantimos que o resultado fique dentro do intervalo de 0 a 25. Portanto, 13 % 26 é igual a 13.

    Agora, se aplicarmos essa lógica para cada letra:

    'B' (índice 1) + 13 % 26 = 14
    'C' (índice 2) + 13 % 26 = 15
    ...
    'M' (índice 12) + 13 % 26 = 25
    'N' (índice 13) + 13 % 26 = 0 (volta para o início)

    Essa adição de 13 e o uso do operador % garantem que a rotação seja feita de forma circular no alfabeto, voltando para o início quando atinge o final.

    Visualização:

    A B C D E F G H I J K L M
    ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓
    N O P Q R S T U V W X Y Z

    ============================================================================================================================================================

    Maiúscula ou Minúscula: Se a letra original for maiúscula, retorna a letra resultante da rotação de César em maiúscula. Se for minúscula, retorna a letra resultante em minúscula.

    Não Letra: Se o caractere não for uma letra, mantém o caractere original.

    Join e Retorna: Usa string.Join para concatenar os caracteres resultantes de volta em uma string e retorna o resultado final.
 */