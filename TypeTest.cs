class Typetext
{
    const char DELETE = '\b';
    static void Main(string[] args)
    {
        Console.Clear();

        // stats variables
        int score = 0;
        float wpm = 0; // words per minute
        float accuracy = 0;

        // text variables
        int words = args.Length;
        string text = String.Join(" ", args);
        bool[] letters_accuracy = new bool[text.Length];
        int i = 0;

        // setup start and print the text
        var startPos = Console.GetCursorPosition();
        Console.Write(text);
        Console.SetCursorPosition(startPos.Left, startPos.Top);

        // wait for first input before starting timer
        char key = Console.ReadKey(true).KeyChar;
        DateTime startTime = DateTime.Now;

        while (i < text.Length)
        {
            if (key == DELETE && i != 0)
            {
                // delete last char and go back
                i--;
                Console.SetCursorPosition(i, startPos.Top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{text[i]}{DELETE}");

                // maintain accuracy calculation
                if (letters_accuracy[i])
                {
                    letters_accuracy[i] = true;
                    accuracy--;
                }
            }
            else if (key != DELETE)
            {
                // check if the user wrote the char correctly
                if (key == text[i])
                {
                    // green for correct
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    letters_accuracy[i] = true;
                    accuracy++;
                }
                else
                {
                    // red for false
                    Console.ForegroundColor = ConsoleColor.Red;
                    letters_accuracy[i] = false;
                }
                // write the key and go to the next iteration
                Console.Write(key);
                i++;
            }

            // get next input
            if (i != text.Length) key = Console.ReadKey(true).KeyChar;
        }
        // reset the console color
        Console.ForegroundColor = ConsoleColor.White;

        // calculate stats
        wpm = words / ((float)(DateTime.Now - startTime).TotalMinutes);
        accuracy = accuracy != 0 ? accuracy / text.Length : 0;
        score = (int)(accuracy * wpm);

        // print stats
        Console.WriteLine("\n");
        Console.WriteLine($"Words: {words}");
        Console.WriteLine($"Words per minute: {wpm}");
        Console.WriteLine($"Accuracy: {(int)(accuracy * 100)}%");
        Console.WriteLine($"Score: {score}");
    }
}