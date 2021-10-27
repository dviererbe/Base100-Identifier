using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using System.Globalization;

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
        public void Constructor_ShouldThrow_ArgumentOutOfRangeException_WhenValueIsLargerThan99(byte value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Base100Digit(value));
        }

        [Theory]
        [MemberData(nameof(ValidBase100DigitValues))]
        public void GetHashCode_ShouldReturn_InitilizationValue(in byte value)
        {
            Base100Digit digit = new Base100Digit(value);
            Assert.Equal(expected: value, actual: digit.GetHashCode());
        }

        [Theory]
        [InlineData((byte)00, "00")]
        [InlineData((byte)09, "09")]
        [InlineData((byte)10, "10")]
        [InlineData((byte)99, "99")]
        public void ToString_ShouldReturn_ExpectedStringRepresentation(in byte value, string expectedStringRepresentation)
        {
            Base100Digit digit = new(value);
            Assert.Equal(
                expected: expectedStringRepresentation, 
                actual: digit.ToString());
        }

        [Theory]
        [InlineData((byte)00, null, "00")]
        [InlineData((byte)00, "", "00")]
        [InlineData((byte)09, null, "09")]
        [InlineData((byte)09, "", "09")]
        [InlineData((byte)85, null, "85")]
        [InlineData((byte)85, "", "85")]
        [InlineData((byte)85, "C3", "$85.000")]
        [InlineData((byte)85, "D4", "0085")]
        [InlineData((byte)85, "e1", "8.5e+001")]
        [InlineData((byte)85, "E2", "8.50E+001")]
        [InlineData((byte)85, "F1", "85.0")]
        [InlineData((byte)85, "G", "85")]
        [InlineData((byte)85, "N1", "85.0")]
        [InlineData((byte)85, "P0", "8,500%")]
        [InlineData((byte)85, "X4", "0055")]
        [InlineData((byte)85, "0000.0000", "0085.0000")]
        public void ToString_WithSpecificFormat_ShouldReturn_ExpectedStringRepresentation(in byte value, string? format, string expectedStringRepresentation)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Base100Digit digit = new(value);

            Assert.Equal(
                expected: expectedStringRepresentation, 
                actual: digit.ToString(format));
        }

        [Theory]
        [InlineData((byte)00, null, "00")]
        [InlineData((byte)00, "en-US", "00")]
        [InlineData((byte)00, "fr-FR", "00")]
        [InlineData((byte)00, "de-DE", "00")]
        [InlineData((byte)00, "es-ES", "00")]
        [InlineData((byte)01, null, "01")]
        [InlineData((byte)01, "en-US", "01")]
        [InlineData((byte)01, "fr-FR", "01")]
        [InlineData((byte)01, "de-DE", "01")]
        [InlineData((byte)01, "es-ES", "01")]
        [InlineData((byte)14, null, "14")]
        [InlineData((byte)14, "en-US", "14")]
        [InlineData((byte)14, "fr-FR", "14")]
        [InlineData((byte)14, "de-DE", "14")]
        [InlineData((byte)14, "es-ES", "14")]
        [InlineData((byte)42, null, "42")]
        [InlineData((byte)42, "en-US", "42")]
        [InlineData((byte)42, "fr-FR", "42")]
        [InlineData((byte)42, "de-DE", "42")]
        [InlineData((byte)42, "es-ES", "42")]
        [InlineData((byte)99, null, "99")]
        [InlineData((byte)99, "en-US", "99")]
        [InlineData((byte)99, "fr-FR", "99")]
        [InlineData((byte)99, "de-DE", "99")]
        [InlineData((byte)99, "es-ES", "99")]
        public void ToString_WithSpecificFormatProvider_ShouldReturn_ExpectedStringRepresentation(in byte value, string? culture, string expectedStringRepresentation)
        {
            CultureInfo? cultureInfo = culture switch {
                not null => new CultureInfo(culture),
                _ => null 
            };
        
            Base100Digit digit = new(value);

            Assert.Equal(
                expected: expectedStringRepresentation, 
                actual: digit.ToString(cultureInfo));
        }

        [Theory]
        [InlineData((byte)00, null, null, "00")]
        [InlineData((byte)06, null, null, "06")]
        [InlineData((byte)14, null, null, "14")]
        [InlineData((byte)42, null, null, "42")]
        [InlineData((byte)99, null, null, "99")]
        [InlineData((byte)00, "", null, "00")]
        [InlineData((byte)06, "", null, "06")]
        [InlineData((byte)14, "", null, "14")]
        [InlineData((byte)42, "", null, "42")]
        [InlineData((byte)99, "", null, "99")]
        [InlineData((byte)00, null, "en-US", "00")]
        [InlineData((byte)06, null, "en-US", "06")]
        [InlineData((byte)14, null, "en-US", "14")]
        [InlineData((byte)42, null, "en-US", "42")]
        [InlineData((byte)99, null, "en-US", "99")]
        [InlineData((byte)00, "", "en-US", "00")]
        [InlineData((byte)06, "", "en-US", "06")]
        [InlineData((byte)14, "", "en-US", "14")]
        [InlineData((byte)42, "", "en-US", "42")]
        [InlineData((byte)99, "", "en-US", "99")]
        [InlineData((byte)00, null, "de-DE", "00")]
        [InlineData((byte)06, null, "de-DE", "06")]
        [InlineData((byte)14, null, "de-DE", "14")]
        [InlineData((byte)42, null, "de-DE", "42")]
        [InlineData((byte)99, null, "de-DE", "99")]
        [InlineData((byte)00, "", "de-DE", "00")]
        [InlineData((byte)06, "", "de-DE", "06")]
        [InlineData((byte)14, "", "de-DE", "14")]
        [InlineData((byte)42, "", "de-DE", "42")]
        [InlineData((byte)99, "", "de-DE", "99")]
        [InlineData((byte)85, "C3", "en-US", "$85.000")]
        [InlineData((byte)85, "D4", "en-US", "0085")]
        [InlineData((byte)85, "e1", "en-US", "8.5e+001")]
        [InlineData((byte)85, "E2", "en-US", "8.50E+001")]
        [InlineData((byte)85, "F1", "en-US", "85.0")]
        [InlineData((byte)85, "G", "en-US", "85")]
        [InlineData((byte)85, "N1", "en-US", "85.0")]
        [InlineData((byte)85, "P0", "en-US", "8,500%")]
        [InlineData((byte)85, "X4", "en-US", "0055")]
        [InlineData((byte)85, "0000.0000", "en-US", "0085.0000")]
        [InlineData((byte)85, "C3", "de-DE", "85,000 €")]
        [InlineData((byte)85, "D4", "de-DE", "0085")]
        [InlineData((byte)85, "e1", "de-DE", "8,5e+001")]
        [InlineData((byte)85, "E2", "de-DE", "8,50E+001")]
        [InlineData((byte)85, "F1", "de-DE", "85,0")]
        [InlineData((byte)85, "G", "de-DE", "85")]
        [InlineData((byte)85, "N1", "de-DE", "85,0")]
        [InlineData((byte)85, "P0", "de-DE", "8.500 %")]
        [InlineData((byte)85, "X4", "de-DE", "0055")]
        [InlineData((byte)85, "0000.0000", "de-DE", "0085,0000")]
        public void ToString_WithSpecificFormatAndFormatProvider_ShouldReturn_ExpectedStringRepresentation(in byte value, string? format, string? culture, string expectedStringRepresentation)
        {
            CultureInfo? cultureInfo = culture switch {
                not null => new CultureInfo(culture),
                _ => null 
            };
        
            Base100Digit digit = new(value);

            Assert.Equal(
                expected: expectedStringRepresentation, 
                actual: digit.ToString(format, cultureInfo));
        }

        [Theory]
        [InlineData((byte)00, "r")]
        [InlineData((byte)00, "R")]
        [InlineData((byte)06, "r")]
        [InlineData((byte)06, "R")]
        [InlineData((byte)14, "r")]
        [InlineData((byte)14, "R")]
        [InlineData((byte)42, "r")]
        [InlineData((byte)42, "R")]
        [InlineData((byte)99, "r")]
        [InlineData((byte)99, "R")]
        public void ToString_WithInvalidFormat_ShouldThrow_FormatException(in byte value, string invalidFormat)
        {
            Base100Digit digit = new(value);

            Assert.Throws<FormatException>(() => digit.ToString(invalidFormat));
            Assert.Throws<FormatException>(() => digit.ToString(invalidFormat, formatProvider: null));
            Assert.Throws<FormatException>(() => digit.ToString(invalidFormat, formatProvider: new CultureInfo("en-US")));
            Assert.Throws<FormatException>(() => digit.ToString(invalidFormat, formatProvider: new CultureInfo("fr-FR")));
            Assert.Throws<FormatException>(() => digit.ToString(invalidFormat, formatProvider: new CultureInfo("de-DE")));
            Assert.Throws<FormatException>(() => digit.ToString(invalidFormat, formatProvider: new CultureInfo("es-ES")));
        }
    }
}