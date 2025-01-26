// See https://aka.ms/new-console-template for more information
namespace Hangman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var di = new DirectoryInfo("../../../");
            var path = di.FullName + "words.txt";

            var readFile = new ReadFile();
            var wordlist = readFile.ReadWordsList(path);

            var hangman = new Hangman(wordlist);
            var word = hangman.GetRandomWord();
            hangman.game(word);
        }
    }
}

