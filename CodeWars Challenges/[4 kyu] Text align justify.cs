/*
    Your task in this Kata is to emulate text justification in monospace font. You will be given a single-lined text and the expected justification width. The longest word will never be greater than this width.

    Here are the rules:

    Use spaces to fill in the gaps between words.
    Each line should contain as many words as possible.
    Use '\n' to separate lines.
    Gap between words can't differ by more than one space.
    Lines should end with a word not a space.
    '\n' is not included in the length of a line.
    Large gaps go first, then smaller ones ('Lorem--ipsum--dolor--sit-amet,' (2, 2, 2, 1 spaces)).
    Last line should not be justified, use only one space between words.
    Last line should not contain '\n'
    Strings with one word do not need gaps ('somelongword\n').
    Example with width=30:

    Lorem  ipsum  dolor  sit amet,
    consectetur  adipiscing  elit.
    Vestibulum    sagittis   dolor
    mauris,  at  elementum  ligula
    tempor  eget.  In quis rhoncus
    nunc,  at  aliquet orci. Fusce
    at   dolor   sit   amet  felis
    suscipit   tristique.   Nam  a
    imperdiet   tellus.  Nulla  eu
    vestibulum    urna.    Vivamus
    tincidunt  suscipit  enim, nec
    ultrices   nisi  volutpat  ac.
    Maecenas   sit   amet  lacinia
    arcu,  non dictum justo. Donec
    sed  quam  vel  risus faucibus
    euismod.  Suspendisse  rhoncus
    rhoncus  felis  at  fermentum.
    Donec lorem magna, ultricies a
    nunc    sit    amet,   blandit
    fringilla  nunc. In vestibulum
    velit    ac    felis   rhoncus
    pellentesque. Mauris at tellus
    enim.  Aliquam eleifend tempus
    dapibus. Pellentesque commodo,
    nisi    sit   amet   hendrerit
    fringilla,   ante  odio  porta
    lacus,   ut   elementum  justo
    nulla et dolor.
    Also you can always take a look at how justification works in your text editor or directly in HTML (css: text-align: justify).

    Have fun :)
 */

using System.Text;

namespace TestConsole;

public class Kata
{
    public static void Main(string[] args) => Console.WriteLine(Justify("Lorem     ipsum  dolor  sit amet, consectetur  adipiscing  elit. Vestibulum    sagittis   dolor mauris,  at  elementum  ligula tempor  eget.  In quis rhoncus nunc,  at  aliquet orci. Fusce at   dolor   sit   amet  felis suscipit   tristique.   Nam  a imperdiet   tellus.  Nulla  eu vestibulum    urna.    Vivamus tincidunt  suscipit  enim, nec ultrices   nisi  volutpat  ac. Maecenas   sit   amet  lacinia arcu,  non dictum justo. Donec sed  quam  vel  risus faucibus euismod.  Suspendisse  rhoncus rhoncus  felis  at  fermentum. Donec lorem magna, ultricies a nunc    sit    amet,   blandit fringilla  nunc. In vestibulum velit    ac    felis   rhoncus pellentesque. Mauris at tellus enim.  Aliquam eleifend tempus dapibus. Pellentesque commodo, nisi    sit   amet   hendrerit fringilla,   ante  odio  porta lacus,   ut   elementum  justo nulla et dolor.", 30));

    // O método principal para justificação de texto
    public static string Justify(string str, int width)
    {
        // Divida a string em palavras usando espaços como delimitadores
        var words = str.Split(' ');

        // Lista para armazenar as linhas justificadas
        var lines = new List<string>();

        // Lista para armazenar palavras da linha atual
        var currentLine = new List<string>();

        // Variável para rastrear a largura atual da linha
        var currentWidth = 0;

        // Itera sobre todas as palavras na string
        foreach (var word in words)
        {
            // Se a adição da palavra exceder a largura desejada, cria uma nova linha
            if (currentWidth + word.Length + currentLine.Count > width)
            {
                // Adiciona a linha atual à lista de linhas
                lines.Add(CreateLine(currentLine, currentWidth, width));

                // Limpa a linha atual e redefine a largura atual
                currentLine.Clear();
                currentWidth = 0;
            }

            // Adiciona a palavra à linha atual e atualiza a largura
            currentLine.Add(word);
            currentWidth += word.Length;
        }

        // Adiciona a última linha à lista de linhas
        lines.Add(CreateLine(currentLine, currentWidth, width, true));

        // Combina todas as linhas em uma única string usando '\n' como separador   
        return string.Join("\n", lines);
    }

    // Método para criar uma linha justificada
    private static string CreateLine(List<string> words, int currentWidth, int targetWidth, bool lastLine = false)
    {
        // Calcula o número de espaços que precisam ser adicionados
        var spacesToAdd = targetWidth - currentWidth;
        var spaceCount = words.Count - 1;

        // Se não houver espaços ou for a última linha, retorna a linha sem espaços adicionais
        if (spaceCount == 0 || lastLine)
        {
            return string.Join(" ", words);
        }

        // Calcula a quantidade de espaços entre as palavras e os espaços extras
        var spacesBetweenWords = spacesToAdd / spaceCount;
        var extraSpaces = spacesToAdd % spaceCount;

        // Constrói a linha justificada
        return words[0] + string.Join("", Enumerable.Range(1, spaceCount)
            .Select(i => new string(' ', spacesBetweenWords + (i <= extraSpaces ? 1 : 0)) + words[i]));
    }
}