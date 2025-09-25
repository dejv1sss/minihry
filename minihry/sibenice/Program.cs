using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Šibenice (Hangman)";
        Random rnd = new Random();
        bool playAgain = true;

        // seznam slov pro hádání
        string[] words = { "PROGRAMOVANI", "VISUALSTUDIO", "GITHUB", "SIBENICE", "POCITAC", "KLAVESNICE", "OBRAZOVKA" };

        while (playAgain)
        {
            string word = words[rnd.Next(words.Length)];
            HashSet<char> guessed = new HashSet<char>();
            int maxFails = 7;
            int fails = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hra: Šibenice\n");

                // vykreslení slova
                bool allRevealed = true;
                foreach (char c in word)
                {
                    if (guessed.Contains(c))
                        Console.Write(c + " ");
                    else
                    {
                        Console.Write("_ ");
                        allRevealed = false;
                    }
                }

                Console.WriteLine($"\n\nŠpatné pokusy: {fails}/{maxFails}");
                Console.WriteLine("Hádaná písmena: " + string.Join(", ", guessed));

                if (allRevealed)
                {
                    Console.WriteLine("\n🎉 Gratuluji! Uhodl jsi celé slovo!");
                    break;
                }

                if (fails >= maxFails)
                {
                    Console.WriteLine($"\n😢 Prohrál jsi! Slovo bylo: {word}");
                    break;
                }

                Console.Write("\nZadej písmeno: ");
                string? input = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
                {
                    Console.WriteLine("Musíš zadat právě jedno písmeno! (Stiskni Enter)");
                    Console.ReadKey();
                    continue;
                }

                char letter = input[0];
                if (guessed.Contains(letter))
                {
                    Console.WriteLine("Toto písmeno už jsi hádal. (Stiskni Enter)");
                    Console.ReadKey();
                    continue;
                }

                guessed.Add(letter);
                if (!word.Contains(letter))
                {
                    fails++;
                }
            }

            Console.Write("\nChceš hrát znovu? (A/N): ");
            string? again = Console.ReadLine()?.Trim().ToUpper();
            playAgain = (again == "A" || again == "Y" || again == "ANO");
        }

        Console.WriteLine("\nDíky za hru! Stiskni libovolnou klávesu pro konec.");
        Console.ReadKey();
    }
}
