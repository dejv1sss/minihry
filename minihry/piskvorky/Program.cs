using System;

class Program
{
    static char[] board = new char[9];
    static char currentPlayer;

    static void Main()
    {
        Console.Title = "Piškvorky (Tic-Tac-Toe)";
        do
        {
            InitBoard();
            currentPlayer = 'X';
            PlayGame();
        } while (AskPlayAgain());

        Console.WriteLine("Díky za hraní! (Stiskni libovolnou klávesu)");
        Console.ReadKey();
    }

    static void InitBoard()
    {
        for (int i = 0; i < 9; i++) board[i] = (char)('1' + i); // zobrazíme čísla pro volbu
    }

    static void PlayGame()
    {
        bool gameFinished = false;
        while (!gameFinished)
        {
            Console.Clear();
            DrawBoard();
            int move = GetMove();
            board[move] = currentPlayer;

            if (CheckWin(currentPlayer))
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"Hráč {currentPlayer} vyhrál!");
                gameFinished = true;
            }
            else if (IsDraw())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Remíza!");
                gameFinished = true;
            }
            else
            {
                SwitchPlayer();
            }
        }
    }

    static void DrawBoard()
    {
        Console.WriteLine(" Piškvorky - hrajte zadáním čísla 1-9\n");
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} \n");
    }

    static int GetMove()
    {
        while (true)
        {
            Console.Write($"Hráč {currentPlayer}, zadej číslo pole (1-9): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int pos))
            {
                pos -= 1; // index od 0
                if (pos >= 0 && pos < 9)
                {
                    if (board[pos] != 'X' && board[pos] != 'O')
                    {
                        return pos;
                    }
                    else
                    {
                        Console.WriteLine("Toto pole už je obsazeno. Zkus to znovu.");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatné číslo. Musíš zadat hodnotu 1 až 9.");
                }
            }
            else
            {
                Console.WriteLine("Neplatný vstup. Zadej číslo 1-9.");
            }
        }
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool CheckWin(char player)
    {
        int[,] wins = new int[,]
        {
            {0,1,2}, {3,4,5}, {6,7,8}, // řádky
            {0,3,6}, {1,4,7}, {2,5,8}, // sloupce
            {0,4,8}, {2,4,6}           // diagonály
        };

        for (int i = 0; i < wins.GetLength(0); i++)
        {
            if (board[wins[i, 0]] == player &&
                board[wins[i, 1]] == player &&
                board[wins[i, 2]] == player)
            {
                return true;
            }
        }

        return false;
    }

    static bool IsDraw()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] != 'X' && board[i] != 'O') return false;
        }
        return true;
    }

    static bool AskPlayAgain()
    {
        while (true)
        {
            Console.Write("Chceš hrát znovu? (A = ano / N = ne): ");
            string? resp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(resp)) continue;
            resp = resp.Trim().ToUpperInvariant();
            if (resp == "A" || resp == "Y" || resp == "ANO") return true;
            if (resp == "N" || resp == "NE") return false;
            Console.WriteLine("Neplatná volba. Zadej A (ano) nebo N (ne).");
        }
    }
}
