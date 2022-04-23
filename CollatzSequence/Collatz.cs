using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace CollatzSequence;

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
		get
		{
			return this._startingNumber;
		}

		set
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(StartingNumber), "The starting number must be a positive integer.");
			}
			this._startingNumber = value;
			CollatzSequence.Add(_startingNumber);
		}
	}

	/// <summary>
	/// The getter and setter for the list for storing the Collatz Sequence.
	/// </summary>
	private List<BigInteger> CollatzSequence { get; set; } = new List<BigInteger>();

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Collatz()
	{
		StartingNumber = 1;
		CollatzSequence.Add(1);
	}

	/// <summary>
	/// Constructor takes in the starting value for the sequence.
	/// </summary>
	/// <param name="startingNumber">The starting value for the sequence.</param>
	/// <exception cref="ArgumentOutOfRangeException">Exception if value <= 0 is passed.</exception>
	public Collatz(BigInteger startingNumber)
	{
		if (startingNumber <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(startingNumber), "The starting number must be a positive integer.");
		}

		StartingNumber = startingNumber;
	}

	/// <summary>
	/// Determines the Collatz Sequence from the starting number.
	/// </summary>
	/// <returns>The Collatz Sequence.</returns>
	public ReadOnlyCollection<BigInteger> GenerateSequence()
	{
		var currentNumber = StartingNumber;
		// Loop until the sequence reaches the end value of one.
		while (currentNumber > 1)
		{
			// If even, divide the number by 2.
			// If odd, multiply the number by 3, add 1, and divide by 2.
			currentNumber = currentNumber % 2 == 0 ? currentNumber / 2 : (3 * currentNumber + 1) / 2;
			// Add the new number to the sequence list.
			CollatzSequence.Add(currentNumber);
		}

		// Return the completed Collatz Sequence.
		return CollatzSequence.AsReadOnly();
	}

	/// <summary>
	/// Builds a string with each number of the sequence on a line to display.
	/// </summary>
	/// <returns>The Collatz Sequence as a string to display.</returns>
	public string DisplaySequence()
	{
		// Build return string.
		var sb = new StringBuilder();
		CollatzSequence.ForEach(number => sb.AppendLine(number.ToString("G", NumberFormatInfo.CurrentInfo)));

		// Returns the Collatz Sequence string to display.
		return sb.ToString();
	}
}

