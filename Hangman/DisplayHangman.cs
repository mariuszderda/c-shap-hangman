namespace Hangman;

public class DisplayHangman
{
    public static void Display(int tries)
    {
        string[] stages =
        {
            // stage 0
            """
            --------
            |      |
            |      O
            |     /|\
            |      |
            |     / \
            |
            -

            """,
            // stage 1
            """
            --------
            |      |
            |      O
            |     /|\
            |      |
            |
            |     
            -

            """,
            // stage 2
            """
            --------
            |      |
            |      O
            |     /|\
            |      
            |
            |     
            -

            """,
            // stage 3
            """
            --------
            |      |
            |      O
            |     
            |  
            |
            |    
            -

            """,
            // stage 4
            """
            --------
            |      |
            |      
            |     
            |
            |
            |     
            -

            """,
            // stage 5
            """
            --------
            |      
            |      
            |     
            |      
            |
            |     
            -

            """,
        };
        Console.WriteLine(stages[tries]);
    }
}