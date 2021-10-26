using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Base100Identifier.UnitTests
{
    public class Base100DigitTests
    {
        public static IEnumerable<object[]> ValidBase100DigitValues => Enumerable
            .Range(start: 0, count: 100)
            .Select(number => new object[] { (byte)number });

        public static IEnumerable<object[]> InvalidBase100DigitValues => Enumerable
            .Range(start: 100, count: 156) //156 = 256 (byte values from 0 to 255) - 100 (base100 digits from 0 to 99)
            .Select(number => new object[] { (byte)number });

        [Fact]
        public void MinValue_ShoulEqual_0()
        {
            Assert.Equal(expected: 0, actual: Base100Digit.MinValue.Value);
        }

        [Fact]
        public void MaxValue_ShoulEqual_99()
        {
            Assert.Equal(expected: 99, actual: Base100Digit.MaxValue.Value);
        }

        [Fact]
        public void ValueOfDefaultInitialization_ShoulEqual_0()
        {
            Assert.Equal(expected: 0, actual: (new Base100Digit()).Value);
            Assert.Equal(expected: 0, actual: default(Base100Digit).Value);
        }

        [Theory]
        [MemberData(nameof(ValidBase100DigitValues))]
        public void Value_ShouldEqual_InitilizationValue(in byte value)
        {
            Base100Digit digit = new Base100Digit(value);
            Assert.Equal(expected: value, actual: digit.Value);
        }

        [Theory]
        [MemberData(nameof(InvalidBase100DigitValues))]
        public void Constructor_ShouldThrow_ArgumentOutOfRangeException_WhenValueIsLargerThan99(in byte value)
        {
            byte valueCopy = value; //needed because lambda-expressions can't contain in-Parameters
            Assert.Throws<ArgumentOutOfRangeException>(() => new Base100Digit(valueCopy));
        }

        [Theory]
        [MemberData(nameof(ValidBase100DigitValues))]
        public void GetHashCode_ShouldReturn_InitilizationValue(in byte value)
        {
            Base100Digit digit = new Base100Digit(value);
            Assert.Equal(expected: value, actual: digit.GetHashCode());
        }
    }
}