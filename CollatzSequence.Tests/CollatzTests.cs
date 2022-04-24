using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Xunit;

namespace CollatzSequence.Tests;

public static class CollatzTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(5555555555555555555)]
    public static void ValidNumberConstructorTest(BigInteger startingNumber)
    {
        var sequence = new Collatz(startingNumber);
        Assert.NotEqual(-1, sequence.CollatzSequence[0]);
        Assert.Equal(1, sequence.CollatzSequence.Last());
    }

    [Fact]
    public static void ReallyBigNumberConstructorTest()
    {
        var sequence = new Collatz(BigInteger.Parse("555555555555555555555555555555555555", NumberFormatInfo.CurrentInfo));
        Assert.NotEqual(-1, sequence.CollatzSequence[0]);
        Assert.Equal(1, sequence.CollatzSequence.Last());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public static void InvalidNumberThrowsExceptionConstructorTest(BigInteger startingNumber)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Collatz(startingNumber));
    }
}
