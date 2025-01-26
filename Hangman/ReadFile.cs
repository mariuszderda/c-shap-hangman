namespace Hangman;

public class ReadFile
{
    public List<string> ReadWordsList(string path)
    {
        var wordsList = File.ReadLines(path);
        return wordsList.ToList();

    }
}