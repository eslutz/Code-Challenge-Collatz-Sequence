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

            // Attempt to parse the input as an unsigned long value.
            var vaildNumberInput = BigInteger.TryParse(userInput, out BigInteger userNumber);

            // If the user didn't input a valid number, enter loop.
            while ((!vaildNumberInput || userNumber <= 0) && !quitProgram)
            {
                // Prompt user for input again.
                Console.WriteLine("\nNot a valid positive integer. Try again.");
                Console.Write("Enter a positive integer (enter q to quit) => ");
                userInput = Console.ReadLine();

                // Check if user wants to quit the program.
                quitProgram = new[] { "q", "quit" }.Contains(userInput, StringComparer.InvariantCultureIgnoreCase);
                if (quitProgram)
                {
                    continue;
                }

                // Attempt to parse the input as an unsigned long value.
                vaildNumberInput = BigInteger.TryParse(userInput, out userNumber);
            }

            // Call collatz method, passing in the users number.
            // Assign returned value.
            var collatzSequence = GetCollatzSequence(userNumber);

            // Print out the Collatz Sequence.
            collatzSequence.ForEach(number => Console.WriteLine(number));
        }
		Console.WriteLine("\nGoodbye!");
    }

    /// <summary>
    /// Determines the Collatz Sequence for a number.
    /// </summary>
    /// <param name="number">Positive integer starting point.</param>
    /// <returns>The Collatz Sequence.</returns>
    static List<BigInteger> GetCollatzSequence(BigInteger number)
    {
        // Initializing Collatz Sequence list with starting number.
        var collatzSequence = new List<BigInteger>() { number };

        // Loop until the sequence reaches the end value of one.
        do
        {
            // If even, divide the number by 2.
            // If odd, multiply the number by 3, add 1, and divide by 2.
            number = number % 2 == 0 ? number / 2 : (3 * number + 1) / 2;
            // Add the new number to the sequence list.
            collatzSequence.Add(number);
        }
        while (number > 1);

        // Return the completed Collatz Sequence.
        return collatzSequence;
    }
}
