import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import org.junit.jupiter.params.provider.ValueSource;

import java.math.BigInteger;

import static org.junit.jupiter.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.assertEquals;

class CollatzTests {
	@ParameterizedTest
	@CsvSource({
			"5, 5",
			"5555555555555555555555555555555555555555555555555555, 487"
	})
	@DisplayName("Call Collatz() constructor with valid argument")
	void collatzConstructorWithValidNumber(String startingNumber,
										   int sequenceCount) {
		var testSequence = new Collatz(new BigInteger(startingNumber));

		assertEquals(sequenceCount, testSequence.getCollatzSequence().size());
	}

	@ParameterizedTest
	@ValueSource(strings = {"0", "-5"})
	@DisplayName("Call Collatz() constructor with invalid argument")
	void collatzConstructorWithInvalidNumber(String startingNumber) {
		var expectedMessage = "The starting number must be a positive integer.";

		Exception ex = assertThrows(IllegalArgumentException.class, () ->
				new Collatz(new BigInteger(startingNumber)));
		assertEquals(expectedMessage, ex.getMessage());
	}

	@ParameterizedTest
	@ValueSource(strings = {"50", "5000", "5000000000000000000000000000000"})
	@DisplayName("Call setStartingNumber() with valid argument")
	void setStartingNumberWithValidNumber(String startingNumber) {
		var testSequence = new Collatz(BigInteger.ONE);
		var testStartingNumber = testSequence.getStartingNumber();

		assertEquals(BigInteger.ONE, testStartingNumber);

		testSequence.setStartingNumber(new BigInteger(startingNumber));

		testStartingNumber = testSequence.getStartingNumber();
		assertEquals(new BigInteger(startingNumber), testStartingNumber);
	}

	@ParameterizedTest
	@ValueSource(strings = {"0", "-5"})
	@DisplayName("Call setStartingNumber() with invalid argument")
	void setStartingNumberWithInvalidNumber(String startingNumber) {
		var testSequence = new Collatz(BigInteger.ONE);
		var expectedMessage = "The starting number must be a positive integer.";

		Exception ex = assertThrows(IllegalArgumentException.class, () ->
				testSequence.setStartingNumber(new BigInteger(startingNumber)));
		assertEquals(expectedMessage, ex.getMessage());
	}

	@Test
	@DisplayName("Call displaySequence() and get sequence string")
	void displaySequence() {
		var expectedString = "5\n8\n4\n2\n1\n";
		var sequence = new Collatz(BigInteger.valueOf(5));
		var returnedString = sequence.displaySequence();

		assertEquals(expectedString, returnedString);
	}
}
