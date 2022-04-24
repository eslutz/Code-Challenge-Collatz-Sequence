using CollatzSequence;
using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Xunit;

namespace CollatzSequenceTests;

public static class CollatzTests
{

    [Theory]
    [InlineData("5", 5)]
    [InlineData("5555555555555555555555555555555555555555555555555555", 487)]
    public static void ValidNumberConstructorTest(string startingInput, int expectedCount)
    {
        var startingNumber = BigInteger.Parse(startingInput, NumberFormatInfo.CurrentInfo);
        var sequence = new Collatz(startingNumber);
        Assert.Equal(expectedCount, sequence.CollatzSequence.Count);
        Assert.NotEqual(-1, sequence.CollatzSequence[0]);
        Assert.Equal(1, sequence.CollatzSequence.Last());
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-5")]
    public static void InvalidNumberThrowsExceptionConstructorTest(string startingInput)
    {
        var startingNumber = BigInteger.Parse(startingInput, NumberFormatInfo.CurrentInfo);
        Assert.Throws<ArgumentOutOfRangeException>(() => new Collatz(startingNumber));
    }

    [Theory]
    [InlineData("5", 5, "50", 18)]
    [InlineData("5", 5, "5000", 23)]
    public static void ValidNumberSetterTest(string startingInput, int expectedCount, string updatedInput, int updatedCount)
    {
        var startingNumber = BigInteger.Parse(startingInput, NumberFormatInfo.CurrentInfo);
        var sequence = new Collatz(startingNumber);
        Assert.Equal(expectedCount, sequence.CollatzSequence.Count);
        sequence.StartingNumber = BigInteger.Parse(updatedInput, NumberFormatInfo.CurrentInfo);
        Assert.Equal(updatedCount, sequence.CollatzSequence.Count);
        Assert.NotEqual(-1, sequence.CollatzSequence[0]);
        Assert.Equal(1, sequence.CollatzSequence.Last());
    }

    [Theory]
    [InlineData("5", "0")]
    [InlineData("5", "-5")]
    public static void InvalidNumberThrowsExceptionSetterTest(string startingInput, string updatedInput)
    {
        var startingNumber = BigInteger.Parse(startingInput, NumberFormatInfo.CurrentInfo);
        var sequence = new Collatz(startingNumber);
        Assert.Throws<ArgumentOutOfRangeException>(() => sequence.StartingNumber = BigInteger.Parse(updatedInput, NumberFormatInfo.CurrentInfo));
    }

    [Fact]
    public static void DisplaySequenceTest()
	{
        var expectedString = "5\n8\n4\n2\n1\n";
        var sequence = new Collatz((BigInteger)5);
        var returnedString = sequence.DisplaySequence();
        Assert.Equal(expectedString, returnedString);
    }
}
