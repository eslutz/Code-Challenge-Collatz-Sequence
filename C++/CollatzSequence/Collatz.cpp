#include "Collatz.h"

#include <sstream>

/**
 * The constructor for the Collatz class. Sets startingNumber
 * to the passed value and sets the Collatz Sequence for
 * that number. The starting value must be a positive integer.
 *
 * @param startingNumber the starting number of the Collatz Sequence
 * @throws out_of_range if the starting number less than or equal
 *                                  to zero is passed.
 */
Collatz::Collatz(const string& startingNumber) {
	try {
		BigInt bigintStartingNumber = BigInt(startingNumber);

		if (!startingNumber.empty() && bigintStartingNumber <= 0) {
			throw invalid_argument("Expected a non-negative integer, got \'" + startingNumber + "\'");
		}
		else {
			this->startingNumber = bigintStartingNumber;
			generateSequence();
		}
	}
	catch (...) {
		throw;
	}
}

/**
 * The getter for startingNumber.
 *
 * @return the starting number.
 */
[[maybe_unused]] string Collatz::getStartingNumber() {
	return startingNumber.to_string();
}

/**
 * The setter for the newStartingNumber of the Collatz Sequence.  When a new
 * starting number is set, the Collatz Sequence is automatically generated
 * for that number. The starting value must be a positive integer.
 *
 * @param newStartingNumber the starting number of the Collatz Sequence
 * @throws out_of_range if the starting number less than or equal
 *                                  to zero is passed.
 */
[[maybe_unused]] void Collatz::setStartingNumber(const string& newStartingNumber) {
	try {
		BigInt bigintStartingNumber = BigInt(newStartingNumber);

		if (!newStartingNumber.empty() && bigintStartingNumber <= 0) {
			throw invalid_argument("Expected a non-negative integer, got \'" + newStartingNumber + "\'");
		}
		else {
			this->startingNumber = bigintStartingNumber;
			generateSequence();
		}
	}
	catch (...) {
		throw;
	}
}

/**
 * The getter for the length of collatzSequence.
 *
 * @return the vector length.
 */
[[maybe_unused]] int Collatz::getSequenceLength()
{
	return static_cast<int>(collatzSequence.size());
}

/**
 * The getter for collatzSequence.
 *
 * @return a readonly list.
 */
[[maybe_unused]] vector<string> Collatz::getCollatzSequence() {
	vector<string> tmpSequence;

	for (const BigInt& number : collatzSequence) {
		tmpSequence.push_back(number.to_string());
	}

	const vector<string> immutableCollatzSequence = tmpSequence;
	return immutableCollatzSequence;
}

void Collatz::generateSequence() {
	BigInt currentNumber = startingNumber;
	// Initialize a new vector with the user number as the first element.
	vector<BigInt> sequence{ currentNumber };

	// Loop until the sequence reaches the end value of one.
	while (currentNumber > 1) {
		// If even, divide the number by 2.
		// If odd, multiply the number by 3, add 1, and divide by 2.
		currentNumber = currentNumber % 2 == 0 ? currentNumber / 2 : (BigInt(3) * currentNumber + 1) / 2;
		// Add the new number to the sequence list.
		sequence.push_back(currentNumber);
	}

	// Set the Collatz Sequence.
	collatzSequence = sequence;
}

/**
 * Builds a string with all the values in collatzSequence, with each
 * value on its own line.
 *
 * @return a string of the Collatz Sequence
 */
string Collatz::displaySequence() {
	// Build return string.
	stringstream displayString;
	for (auto& currentNumber : collatzSequence) {
		displayString << currentNumber << '\n';

	}

	// Returns the Collatz Sequence string to display.
	return displayString.str();
}
