using System.Numerics;

namespace CollatzSequence;

internal class Program
{
    static void Main(string[] args)
    {
        // Display welcome message.
		Console.WriteLine("Welcome to the Collatz Conjecture Sequence Generator!");

        // Initialize variable for keeping track of if the program is running.
        var quitProgram = false;
        // Start program loop until the user quits.
        while (!quitProgram)
        {
            // Prompt the user for input.
            Console.Write("\nEnter a positive integer (enter q to quit) => ");
            var userInput = Console.ReadLine();

            // Check if user wants to quit the program.
            quitProgram = new[] { "q", "quit" }.Contains(userInput, StringComparer.InvariantCultureIgnoreCase);
            if (quitProgram)
            {
                continue;
            }

            // Attempt to parse the input as BigInteger.
            var validBigInt = BigInteger.TryParse(userInput, out BigInteger userNumber);

            // Check if user entered a valid number.
            if (!validBigInt || userNumber <= 0)
            {
                // Prompt user for input again.
                Console.WriteLine("\nNot a valid positive integer. Try again.");
                continue;
            }

            // Instantiate new Collatz instance, passing in user number.
            var collatzSequence = new Collatz(userNumber);
            // Print out the Collatz Sequence. 
            Console.WriteLine(collatzSequence.DisplaySequence());
        }
        // Display goodbye message.
        Console.WriteLine("\nGoodbye!");
    }
}

// todo: Create test project.
