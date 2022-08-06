using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CollatzSequence;

/// <summary>
/// Collatz class for generating a Collatz Sequence from a starting value.
/// </summary>
public class Collatz
{
	/// <summary>
	/// The starting value for generating the Collatz Sequence.
	/// </summary>
	private BigInteger _startingNumber;

	/// <summary>
	/// The getter and setter for _startingNumber.
	/// </summary>
	public BigInteger StartingNumber
	{
		get => _startingNumber;

		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value), "The starting number must be a positive integer.");
			}
			_startingNumber = value;
			CollatzSequence = GenerateSequence();
		}
	}

	/// <summary>
	/// The getter for the list of the Collatz Sequence.
	/// </summary>
	public ReadOnlyCollection<BigInteger> CollatzSequence { get; private set; }

	/// <summary>
	/// Constructor takes in the starting value for the sequence and generates the Collatz Sequence.
	/// Sets sequence to -1 if an overflow exception is thrown during sequence generation.
	/// </summary>
	/// <param name="number">The starting value for the sequence.</param>
	/// <exception cref="ArgumentOutOfRangeException">Exception if value <= 0 is passed.</exception>
	public Collatz(BigInteger number)
	{
		if (number <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(number), "The starting number must be a positive integer.");
		}

		// Set starting number from input.
		_startingNumber = number;


		// Set the complete sequence.
		CollatzSequence = GenerateSequence();
	}

	/// <summary>
	/// Generates the Collatz Sequence from the starting number
	/// </summary>
	/// <returns>ReadOnly copy of the Collatz Sequence.</returns>
	private ReadOnlyCollection<BigInteger> GenerateSequence()
	{
		// Initialize a new BigInteger with _startingNumber, to then modify.
		var currentNumber = _startingNumber;
		// Initialize a new list with the user number as the first element.
		var sequence = new List<BigInteger>() { currentNumber };

		// Due to the nature of BigInteger, and overflow exception may be thrown.
		try
		{
			// Loop until the sequence reaches the end value of one.
			while (currentNumber > 1)
			{
				// If even, divide the number by 2.
				// If odd, multiply the number by 3, add 1, and divide by 2.
				currentNumber = currentNumber % 2 == 0 ? currentNumber / 2 : 3 * currentNumber + 1;
				// Add the new number to the sequence list.
				sequence.Add(currentNumber);
			}
		}
		// Catch the overflow exception.
		catch (OverflowException)
		{
			// Clear the list and set the first element to -1 to indicate Collatz failure.
			sequence.Clear();
			sequence.Add(-1);
		}

		// Returns the Collatz Sequence.
		return sequence.AsReadOnly();
	}

	/// <summary>
	/// Returns the length of the sequence.
	/// </summary>
	/// <returns>The integer value of the length of the sequence.</returns>
	public int GetSequenceLength()
	{
		return CollatzSequence.ToList().Count;
	}

	/// <summary>
	/// Builds a string with each number of the sequence on a line to display.
	/// </summary>
	/// <returns>The Collatz Sequence as a string to display.</returns>
	public string DisplaySequence()
	{
		// Build return string.
		var sb = new StringBuilder();
		foreach(var number in CollatzSequence)
		{
			sb.AppendLine(number.ToString("G", NumberFormatInfo.CurrentInfo));
		}

		// Returns the Collatz Sequence string to display.
		return sb.ToString();
	}
}
