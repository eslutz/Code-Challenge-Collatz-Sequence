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
			"50, 18",
			"5000, 23",
			"5000000, 98",
			"5000000000, 89",
			"5000000000000000000000000000000000000, 448"
	})
	@DisplayName("Call Collatz() constructor with valid argument")
	void collatzConstructorWithValidNumberTest(String startingNumber,
										   int sequenceCount) {
		var testSequence = new Collatz(new BigInteger(startingNumber));

		assertEquals(sequenceCount, testSequence.getSequenceLength());
	}

	@ParameterizedTest
	@ValueSource(strings = {"0", "-5"})
	@DisplayName("Call Collatz() constructor with invalid argument")
	void collatzConstructorWithInvalidNumberTest(String startingNumber) {
		var expectedMessage = "The starting number must be a positive integer.";

		Exception ex = assertThrows(IllegalArgumentException.class, () ->
				new Collatz(new BigInteger(startingNumber)));
		assertEquals(expectedMessage, ex.getMessage());
	}

	@ParameterizedTest
	@ValueSource(strings = {"5", "50", "5000", "5000000", "5000000000", "5000000000000000000000000000000000000"})
	@DisplayName("Call setStartingNumber() with valid argument")
	void setStartingNumberWithValidNumberTest(String startingNumber) {
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
	void setStartingNumberWithInvalidNumberTest(String newStartingNumber) {
		var testSequence = new Collatz(BigInteger.ONE);
		var expectedMessage = "The starting number must be a positive integer.";

		Exception ex = assertThrows(IllegalArgumentException.class, () ->
				testSequence.setStartingNumber(
						new BigInteger(newStartingNumber)));
		assertEquals(expectedMessage, ex.getMessage());
	}

	@Test
	@DisplayName("Call displaySequence() and get sequence string")
	void displaySequenceTest() {
		var expectedString = "5\n8\n4\n2\n1\n";
		var testSequence = new Collatz(BigInteger.valueOf(5));
		var returnedString = testSequence.displaySequence();

		assertEquals(expectedString, returnedString);
	}
}
