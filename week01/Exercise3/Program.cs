using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); // Para generar números aleatorios
        bool playAgain = true;

        while (playAgain)
        {
            // Generar un número mágico aleatorio entre 1 y 100
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int attempts = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I've chosen a number between 1 and 100. Try to guess it!");

            // Bucle para que el usuario siga adivinando hasta acertar
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                // Validar la entrada del usuario
                if (int.TryParse(input, out guess))
                {
                    attempts++; // Contar el intento
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! The number was {magicNumber}.");
                        Console.WriteLine($"It took you {attempts} attempts.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            // Preguntar si el usuario quiere volver a jugar
            Console.Write("Would you like to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing! Goodbye!");
            }
        }
    }
}