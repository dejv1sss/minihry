using System;

class Program
{
    static void Main()
    {
        Console.Title = "Kámen - Nůžky - Papír";
        Random rnd = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            Console.Clear();
            Console.WriteLine("Hra: Kámen - Nůžky - Papír");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1 = Kámen");
            Console.WriteLine("2 = Nůžky");
            Console.WriteLine("3 = Papír");
            Console.Write("\nZadej svou volbu (1-3): ");

            int playerChoice;
            while (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 3)
            {
                Console.Write("Neplatný vstup. Zadej číslo 1-3: ");
            }

            int compChoice = rnd.Next(1, 4); // 1 = kámen, 2 = nůžky, 3 = papír

            Console.WriteLine($"\nTy: {ChoiceToText(playerChoice)}");
            Console.WriteLine($"Počítač: {ChoiceToText(compChoice)}\n");

            // Vyhodnocení
            if (playerChoice == compChoice)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((playerChoice == 1 && compChoice == 2) ||
                     (playerChoice == 2 && compChoice == 3) ||
                     (playerChoice == 3 && compChoice == 1))
            {
                Console.WriteLine("Vyhrál jsi! 🎉");
            }
            else
            {
                Console.WriteLine("Prohrál jsi. 😢");
            }

            Console.Write("\nChceš hrát znovu? (A/N): ");
            string? again = Console.ReadLine()?.Trim().ToUpper();
            playAgain = (again == "A" || again == "Y" || again == "ANO");
        }

        Console.WriteLine("\nDíky za hru! Stiskni libovolnou klávesu pro konec.");
        Console.ReadKey();
    }

    static string ChoiceToText(int choice)
    {
        return choice switch
        {
            1 => "Kámen",
            2 => "Nůžky",
            3 => "Papír",
            _ => "???"
        };
    }
}
