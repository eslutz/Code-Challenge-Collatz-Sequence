import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Driver {
	public static void main(String[] args) {
		var scanner = new Scanner(System.in);

		// Display welcome message.
		System.out.println("Welcome to the Collatz Conjecture Sequence Generator!");

		// Initialize variable for keeping track of if the program is running.
		var quitProgram = false;
		// Start program loop until the user quits.
		while (!quitProgram)
		{
			// Prompt the user for input.
			System.out.print("\nEnter a positive integer (enter q to quit) => ");
			var userInput = scanner.nextLine();

			// Check if user wants to quit the program.
			quitProgram = new ArrayList<>(List.of("q", "quit")).contains(userInput.toLowerCase());
			if (quitProgram)
			{
				continue;
			}

			BigInteger userNumber;
			try {
				// Attempt to parse the input as BigInteger.
				userNumber = new BigInteger(userInput);
				// Check that it is a positive integer.
				if (userNumber.compareTo(BigInteger.ZERO) <= 0) {
					throw new NumberFormatException();
				}
			}
			catch (NumberFormatException e) {
				// Prompt user for input again.
				System.out.println("\nNot a valid positive integer. Try again.");
				continue;
			}

			// Instantiate new Collatz instance, passing in user number.
			var collatzSequence = new Collatz(userNumber);
			// Print out the Collatz Sequence.
			System.out.println(collatzSequence.displaySequence());
			System.out.printf("Sequence Length: %d\n", collatzSequence.getSequenceLength());
		}
		// Display goodbye message.
		System.out.println("\nGoodbye!");
	}
}
