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
    [InlineData("50", 18)]
    [InlineData("5000", 23)]
    [InlineData("5000000", 98)]
    [InlineData("5000000000", 89)]
    [InlineData("5000000000000000000000000000000000000", 448)]
    public static void ValidNumberConstructorTest(string startingInput, int expectedCount)
    {
        var startingNumber = BigInteger.Parse(startingInput, NumberFormatInfo.CurrentInfo);
        var sequence = new Collatz(startingNumber);
        Assert.Equal(expectedCount, sequence.GetSequenceLength());
        Assert.NotEqual(-1, sequence.CollatzSequence[0]);
        Assert.Equal(1, sequence.CollatzSequence.Last());
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-5")]
    public static void InvalidNumberConstructorTest(string startingInput)
    {
        var startingNumber = BigInteger.Parse(startingInput, NumberFormatInfo.CurrentInfo);
        Assert.Throws<ArgumentOutOfRangeException>(() => new Collatz(startingNumber));
    }

    [Theory]
    [InlineData("5")]
    [InlineData("50")]
    [InlineData("5000")]
    [InlineData("5000000")]
    [InlineData("5000000000")]
    [InlineData("5000000000000000000000000000000000000")]
    public static void ValidNumberSetterTest(string newStartingNumberString)
    {
        var sequence = new Collatz(BigInteger.One);
        Assert.Equal(BigInteger.One, sequence.StartingNumber);

        var newStartingNumber = BigInteger.Parse(newStartingNumberString, NumberFormatInfo.CurrentInfo);
        sequence.StartingNumber = newStartingNumber;
        Assert.Equal(newStartingNumber, sequence.StartingNumber);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-5")]
    public static void InvalidNumberSetterTest(string newStartingNumberString)
    {
        var sequence = new Collatz(BigInteger.One);

        var newStartingNumber = BigInteger.Parse(newStartingNumberString, NumberFormatInfo.CurrentInfo);
        Assert.Throws<ArgumentOutOfRangeException>(() => sequence.StartingNumber = newStartingNumber);
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
