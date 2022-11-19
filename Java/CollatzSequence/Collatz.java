import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 * Collatz class for generating a Collatz Sequence from a starting value.
 *
 * @author Eric Slutz
 */
public class Collatz {
	private BigInteger startingNumber;

	private List<BigInteger> collatzSequence;

	/**
	 * The constructor for the <code>Collatz</code> class. Sets
	 * <code>startingNumber</code> to the passed value and sets the Collatz
	 * Sequence for that number. The starting value must be a positive integer.
	 *
	 * @param startingNumber the starting number of the Collatz Sequence.
	 * @throws IllegalArgumentException if the starting number less than or
	 *                                  equal to zero is passed.
	 */
	public Collatz(BigInteger startingNumber) throws IllegalArgumentException {
		if (startingNumber.compareTo(BigInteger.ZERO) <= 0) {
			throw new IllegalArgumentException("The starting number must be " +
					"a positive integer.");
		} else {
			this.startingNumber = startingNumber;
			this.collatzSequence = generateSequence();
		}
	}

	/**
	 * The getter for <code>startingNumber</code>.
	 *
	 * @return the starting number.
	 */
	public BigInteger getStartingNumber() {
		return this.startingNumber;
	}

	/**
	 * The setter for the <code>startingNumber</code> of the Collatz Sequence.
	 * When a new starting number is set, the Collatz Sequence is automatically
	 * generated for that number. The starting value must be a positive integer.
	 *
	 * @param startingNumber the starting number of the Collatz Sequence.
	 * @throws IllegalArgumentException if the starting number less than or
	 *                                  equal to zero is passed.
	 */
	public void setStartingNumber(BigInteger startingNumber)
			throws IllegalArgumentException {
		if (startingNumber.compareTo(BigInteger.ZERO) <= 0) {
			throw new IllegalArgumentException("The starting number must be " +
					"a positive integer.");
		} else {
			this.startingNumber = startingNumber;
			this.collatzSequence = generateSequence();
		}
	}

	/**
	 * The getter for <code>collatzSequence</code>.
	 *
	 * @return a readonly list.
	 */
	public List<BigInteger> getCollatzSequence() {
		return Collections.unmodifiableList(this.collatzSequence);
	}

	/**
	 * Returns the length of the sequence.
	 *
	 * @return the integer value of the length of the sequence.
	 */
	public int getSequenceLength() {
		return collatzSequence.size();
	}

	/**
	 * Builds a string with all the values in <code>collatzSequence</code>, with
	 * each value on its own line.
	 *
	 * @return a string of the Collatz Sequence.
	 */
	public String displaySequence() {
		// Build return string.
		var sb = new StringBuilder();
		for (BigInteger number : collatzSequence) {
			sb.append(number);
			sb.append('\n');
		}

		// Returns the Collatz Sequence string to display.
		return sb.toString();
	}

	/**
     * Generates the Collatz Sequence from the starting number.
     *
     * @return a bigint array of the sequence.
     */
	private List<BigInteger> generateSequence() {
		var currentNumber = startingNumber;
		// Initialize a new list with the user number as the first element.
		var sequence = new ArrayList<>(List.of(currentNumber));

		// Loop until the sequence reaches the end value of one.
		while (!currentNumber.equals(BigInteger.ONE)) {
			// If even, divide the number by 2.
			// If odd, multiply the number by 3, add 1, and divide by 2.
			currentNumber = currentNumber.mod(BigInteger.TWO)
					.equals(BigInteger.ZERO) ?
					currentNumber.divide(BigInteger.TWO) :
					currentNumber.multiply(BigInteger.valueOf(3))
							.add(BigInteger.ONE);
			// Add the new number to the sequence list.
			sequence.add(currentNumber);
		}

		// Set the Collatz Sequence.
		return sequence;
	}
}
