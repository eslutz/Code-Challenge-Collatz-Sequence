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
            var collatzSequence = new Collatz(userNumber);
            var test = collatzSequence.GenerateSequence();
			Console.WriteLine(collatzSequence.DisplaySequence());
        }
        Console.WriteLine("\nGoodbye!");
    }

    
}
