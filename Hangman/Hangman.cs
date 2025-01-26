namespace Hangman;

public class Hangman
{
    private readonly List<string> _wordList;
    private int _maxLives = 6;
    private char _guess;

    private bool _win = false;
    List<char> _guessedLetters = new List<char>();
    private static readonly Random Getrandom = new Random();

    public Hangman(List<string> wordList)
    {
        _wordList = wordList;
    }

    public int GetRandomNumber(int max)
    {
        lock (Getrandom) // synchronize
        {
            return Getrandom.Next(0, max);
        }
    }


    public string GetRandomWord()
    {
        var index = GetRandomNumber(_wordList.Count);
        var word = _wordList[index];
        _wordList.RemoveAt(index);
        return word;
    }


    public void game(string word)
    {
        var currentLives = _maxLives;
        Console.WriteLine("Welcome to Hangman!");
        while (currentLives > 0 && !_win)
        {
            Console.Write("Guessed letters:");
            foreach (char c in word)
            {
                if (_guessedLetters.Contains(c))
                {
                    Console.Write($" {c} ");
                }
                else
                {
                    Console.Write(" _ ");
                }
            }

            Console.WriteLine();

            Console.Write("Given letters: ");
            if (_guessedLetters.Count > 0)
            {
                foreach (var g in _guessedLetters)
                {
                    var upperLitter = g.ToString().ToUpper();
                    Console.Write($"{upperLitter}, ");
                }
            }
            

            Console.Write("\nPlease guess a letter! ");

            try
            {
                _guess = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("You can enter a one character, EMPTY IS EMPTY (:. Please try again");
                continue;
            }

            Console.WriteLine($"CHAR: {_guess}");

            if (word.Contains(_guess) && !_guessedLetters.Contains(_guess))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect!");
                Console.ResetColor();
                currentLives--;
            }

            Console.WriteLine();
            Console.WriteLine($"Attempt left: {currentLives}");

            _guessedLetters.Add(_guess);

            bool wordCompleted = true;

            foreach (char c in word)
            {
                if (!_guessedLetters.Contains(c))
                    wordCompleted = false;
            }

            _win = wordCompleted;
        }

        if (currentLives > 0)
        {
            Console.WriteLine("You WIN, play again (:!");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("You lose, bye :(!");
            Console.WriteLine();
        }
    }
}