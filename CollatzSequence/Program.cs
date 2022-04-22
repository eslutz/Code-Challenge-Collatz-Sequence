namespace CollatzSequence;

internal class Program
{
    static void Main(string[] args)
    {
		// Prompt the user for input.
		Console.Write("Enter a positive integer => ");
        var userInput = Console.ReadLine();
        // Attempt to parse the input as an unsigned long value.
        var vaildNumberInput = ulong.TryParse(userInput, out ulong userNumber);

        // If the user didn't input a valid number, enter loop.
        while (!vaildNumberInput)
        {
            // Prompt user for input again.
            Console.WriteLine("Not a valid positive integer. Try again.");
            Console.Write("Enter a positive integer => ");
            userInput = Console.ReadLine();
            // Attempt to parse the input as an unsigned long value.
            vaildNumberInput = ulong.TryParse(userInput, out userNumber);
        }

        // Call collatz method, passing in the users number.
        // Assign returned value.
        var collatzSequence = GetCollatzSequence(userNumber);

        // Print out the Collatz Sequence.
        collatzSequence.ForEach(Console.WriteLine);
    }

    /// <summary>
    /// Determines the Collatz Sequence for a number.
    /// </summary>
    /// <param name="number">Positive integer starting point.</param>
    /// <returns>The Collatz Sequence.</returns>
    static List<ulong> GetCollatzSequence(ulong number)
    {
        // Initializing Collatz Sequence list with starting number.
        var collatzSequence = new List<ulong>() { number };

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
