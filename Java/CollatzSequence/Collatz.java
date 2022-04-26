import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Collatz {
	private BigInteger startingNumber;

	private List<BigInteger> collatzSequence;

	public Collatz(BigInteger startingNumber) {
		if (startingNumber.compareTo(BigInteger.ZERO) <= 0) {
			throw new IllegalArgumentException("The starting number must be a positive integer.");
		}
		else {
			this.startingNumber = startingNumber;
			generateSequence();
		}
	}

	public BigInteger getStartingNumber() {
		return this.startingNumber;
	}

	public void setStartingNumber(BigInteger startingNumber) throws IllegalArgumentException {
		if (startingNumber.compareTo(BigInteger.ZERO) <= 0) {
			throw new IllegalArgumentException("The starting number must be a positive integer.");
		}
		else {
			this.startingNumber = startingNumber;
			generateSequence();
		}
	}

	public List<BigInteger> getCollatzSequence() {
		return Collections.unmodifiableList(this.collatzSequence);
	}

	private void generateSequence() {
		var currentNumber = startingNumber;
		// Initialize a new list with the user number as the first element.
		var sequence = new ArrayList<>(List.of(currentNumber));

		// Due to the nature of BigInteger, and overflow exception may be thrown.
		try
		{
			// Loop until the sequence reaches the end value of one.
				while (!currentNumber.equals(BigInteger.ONE))
				{
				// If even, divide the number by 2.
				// If odd, multiply the number by 3, add 1, and divide by 2.
				currentNumber = currentNumber.mod(BigInteger.TWO).equals(BigInteger.ZERO) ? currentNumber.divide(BigInteger.TWO) : (currentNumber.multiply(BigInteger.valueOf(3)).add(BigInteger.ONE)).divide(BigInteger.TWO);
				// Add the new number to the sequence list.
				sequence.add(currentNumber);
			}
		}
		// Catch the overflow exception.
		catch (Exception ex)
		{
			// Clear the list and set the first element to -1 to indicate Collatz failure.
			sequence.clear();
			sequence.add(BigInteger.valueOf(-1));
		}

		// Set the Collatz Sequence.
		this.collatzSequence = sequence;
	}

	public String DisplaySequence()
	{
		// Build return string.
		var sb = new StringBuilder();
		for (BigInteger number : collatzSequence) {
			sb.append(number);
			sb.append('\n');
		}

		// Returns the Collatz Sequence string to display.
		return sb.toString();
	}
}
