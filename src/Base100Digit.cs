using System;
using System.Globalization;
using System.Threading;

namespace Base100Identifier
{
    /// <summary>
    /// Represents an base100 digit (0-99).
    /// </summary>
    public readonly struct Base100Digit : IEquatable<Base100Digit>, IEquatable<Base100Digit?>, IFormattable
    {
        private const byte MinByteValue = 0;
        
        private const byte MaxByteValue = 99;

        private const string DefaultNumericFormat = "D2";

        // No constant expression because the CurrentCulture could be changed at runtime.
        private static IFormatProvider DefaultFormatProvider => 
            Thread.CurrentThread.CurrentCulture.NumberFormat;

        /// <summary>
        /// Represents the smallest possible value of a <see cref="Base100Digit"/>. 
        /// </summary>
        public static readonly Base100Digit MinValue = new Base100Digit(MinByteValue);
        
        /// <summary>
        /// Represents the largest possible value of a <see cref="Base100Digit"/>. 
        /// </summary>
        public static readonly Base100Digit MaxValue = new Base100Digit(MaxByteValue); 
        
        /// <summary>
        /// Value of the base100 digit.
        /// </summary>
        public readonly byte Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.Byte"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is larger than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in byte value)
        {
            ThrowIfValueIsOutOfRange(value);
            Value = value;
        }
        
        private static void ThrowIfValueIsOutOfRange(in byte value)
        {
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }

        private static void ThrowValueIsOutOfRangeException(in object? value)
        {
            throw new ArgumentOutOfRangeException(
                paramName: nameof(value), 
                actualValue: value, 
                message: "The value for an base100 digit has to be between 0 and 99.");
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="Base100Digit"/>.
        /// </returns>
        /// <seealso cref="Object.GetHashCode"/>
        public override int GetHashCode() => Value;

        #region ToString() && IFormattable Implementation
        
        /// <summary>
        /// Converts the value of the current <see cref="Base100Digit"/> object to its 
        /// equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of the value of this object, which consists of a 
        /// sequence of two decimal digits that range from 0 to 9 with a leading zero.
        /// </returns>
        /// <example>
        /// The following example displays multiple <see cref="Base100Digit"/> values. 
        /// Note that the ToString() method is not called explicitly in the example. 
        /// Instead, it is called implicitly, because of the use of the 
        /// <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting">composite formatting</see> feature.
        /// <code>
        /// Console.WriteLine(new Base100Digit(0));
        /// Console.WriteLine(new Base100Digit(1));
        /// Console.WriteLine(new Base100Digit(16));
        /// Console.WriteLine(new Base100Digit(42));
        /// Console.WriteLine(new Base100Digit(99));
        ///
        /// // The example displays the following output to the console if the current
        /// // culture is en-US:
        /// //       00
        /// //       01
        /// //       16
        /// //       42
        /// //       99
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>
        /// The return value is formatted with the numeric format specifier ("D2") and the 
        /// <see cref="NumberFormatInfo"/> object for the thread current culture. To define 
        /// the formatting of the <see cref="Base100Digit"/> value's string representation, 
        /// call the <see cref="ToString"/> method. To define both the format specifiers and 
        /// culture used to create the string representation of a 
        /// <see cref="Base100Digit"/> value, call the <see cref="ToString"/> method.
        /// </para>
        /// <para>
        /// .NET provides extensive formatting support, which is described in greater detail 
        /// in the following formatting topics:
        /// <list type="bullet">
        ///     <item>
        ///         <description>For more information about numeric format specifiers, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">Standard Numeric Format Strings</see> and <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</see>.</description>
        ///     </item>
        ///     <item>
        ///         <description>For more information about formatting, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types">Formatting Types.</see></description>
        ///     </item>
        /// </list>
        /// </para>
        /// <para>
        /// For information about the thread current culture, see <see cref="Thread.CurrentCulture"/>.
        /// </para>
        /// </remarks>
        /// <seealso cref="ToString(string?)"/>
        /// <seealso cref="ToString(IFormatProvider?)"/>
        /// <seealso cref="ToString(string?, IFormatProvider?)"/>
        public override string ToString() => ToString(DefaultNumericFormat, DefaultFormatProvider);

        /// <summary>
        /// Converts the value of the current <see cref="Base100Digit"/> object to its equivalent 
        /// string representation using the specified format.
        /// </summary>
        /// <param name="format">
        /// A numeric format string.
        /// </param>
        /// <returns>
        /// The string representation of the current <see cref="Base100Digit"/> object, formatted 
        /// as specified by the <paramref name="format"/> parameter.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="format"/> includes an unsupported specifier. Supported format specifiers 
        /// are listed in the Remarks section.
        /// </exception>
        /// <example>
        /// The following example initializes a <see cref="Base100Digit"/> value and displays it 
        /// to the console using each of the supported standard format strings and a custom format string. 
        /// The example is run with en-US as the current culture.
        /// <code>
        /// string[] formats = {"C3", "D4", "e1", "E2", "F1", "G", "N1",
        ///                     "P0", "X4", "0000.0000"};
        /// var digit = new Base100Digit(85);
        /// foreach (string format in formats)
        ///    Console.WriteLine("'{0}' format specifier: {1}",
        ///                      format, digit.ToString(format));
        /// 
        /// // The example displays the following output to the console if the
        /// // current culture is en-us:
        /// //       'C3' format specifier: $85.000
        /// //       'D4' format specifier: 0085
        /// //       'e1' format specifier: 8.5e+001
        /// //       'E2' format specifier: 8.50E+001
        /// //       'F1' format specifier: 85.0
        /// //       'G' format specifier: 85
        /// //       'N1' format specifier: 85.0
        /// //       'P0' format specifier: 8,500%
        /// //       'X4' format specifier: 0055
        /// //       '0000.0000' format specifier: 0085.0000
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>
        /// The <paramref name="format"/> parameter can be either a standard or a custom numeric 
        /// format string. All standard numeric format strings other than "R" (or "r") are supported, 
        /// as are all custom numeric format characters. If <paramref name="format"/> is <see keyword="null" /> 
        /// or an empty string (""), the return value is formatted with the numeric format specifier ("D2").
        /// </para>
        /// <para>
        /// The return value of this function is formatted using the <see cref="NumberFormatInfo"/> 
        /// object for the thread current culture. For information about the thread current culture, 
        /// see <see cref="Thread.CurrentCulture"/>.CurrentCulture. To provide formatting information 
        /// for cultures other than the current culture, call the <see cref="Base100Digit.ToString(string?, IFormatProvider?)"/> method.
        /// </para>
        /// <para>
        /// .NET provides extensive formatting support, which is described in greater detail in the following formatting topics:
        /// <list type="bullet">
        ///     <item>
        ///         <description>For more information about numeric format specifiers, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">Standard Numeric Format Strings</see> and <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</see>.</description>
        ///     </item>
        ///     <item>
        ///         <description>For more information about formatting, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types">Formatting Types.</see></description>
        ///     </item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <seealso cref="ToString"/>
        /// <seealso cref="ToString(IFormatProvider?)"/>
        /// <seealso cref="ToString(string?, IFormatProvider?)"/>
        public string ToString(string? format) => ToString(format, DefaultFormatProvider);

        /// <summary>
        /// Converts the numeric value of the current <see cref="Base100Digit"/> object to its equivalent 
        /// string representation using the specified culture-specific formatting information.
        /// </summary>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information.
        /// </param>
        /// <returns>
        /// The string representation of the value of this object in the format specified by 
        /// the <paramref name="formatProvider"/> parameter.
        /// </returns>
        /// <example>
        /// The following example iterates an array of <see cref="Base100Digit"/> values and displays 
        /// each of them to the console by calling the <see cref="ToString(IFormatProvider?)"/> method 
        /// with different format providers.
        /// <code>
        /// Base100Digit[] digits = {new(0), new(1), new(14), new(42), new(99)};
        /// CultureInfo[] providers = { new CultureInfo("en-us"),
        ///                             new CultureInfo("fr-fr"),
        ///                             new CultureInfo("de-de"),
        ///                             new CultureInfo("es-es") };
        ///
        /// foreach (Base100Digit digit in digits)
        /// {
        ///     foreach (CultureInfo provider in providers)
        ///         Console.Write("{0,3} ({1})      ", digit.ToString(provider), provider.Name);
        ///
        ///     Console.WriteLine();
        /// }
        /// // The example displays the following output to the console:
        /// //     00 (en-US)       00 (fr-FR)       00 (de-DE)       00 (es-ES)      
        /// //     01 (en-US)       01 (fr-FR)       01 (de-DE)       01 (es-ES)      
        /// //     14 (en-US)       14 (fr-FR)       14 (de-DE)       14 (es-ES)      
        /// //     42 (en-US)       42 (fr-FR)       42 (de-DE)       42 (es-ES)      
        /// //     99 (en-US)       99 (fr-FR)       99 (de-DE)       99 (es-ES) 
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>
        /// The return value is formatted with the numeric format specifier ("D2").
        /// </para>
        /// <para>
        /// If <paramref name="formatProvider"/> is <see keyword="null"/> or a <see cref="NumberFormatInfo"/> 
        /// object cannot be obtained from <paramref name="formatProvider"/>, the return value is formatted using 
        /// the <see cref="NumberFormatInfo"/> object for the thread current culture. For information about the 
        /// thread current culture, see <see cref="Thread.CurrentCulture"/>.
        /// </para>
        /// <para>
        /// .NET provides extensive formatting support, which is described in greater detail in the following formatting topics:
        /// <list type="bullet">
        ///     <item>
        ///         <description>For more information about numeric format specifiers, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">Standard Numeric Format Strings</see> and <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</see>.</description>
        ///     </item>
        ///     <item>
        ///         <description>For more information about formatting, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types">Formatting Types.</see></description>
        ///     </item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <seealso cref="ToString"/>
        /// <seealso cref="ToString(string?)"/>
        /// <seealso cref="ToString(string?, IFormatProvider?)"/>
        public string ToString(IFormatProvider? formatProvider) => ToString(DefaultNumericFormat, formatProvider);

        /// <summary>
        /// Converts the value of the current <see cref="Base100Digit"/> object to its equivalent string 
        /// representation using the specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">
        /// A standard or custom numeric format string.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information.
        /// </param>
        /// <returns>
        /// The string representation of the current <see cref="Base100Digit"/> object, formatted as specified 
        /// by the format and provider parameters.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="format"/> includes an unsupported specifier. Supported format specifiers are listed in the Remarks section.
        /// </exception>
        /// <example>
        /// The following example uses the standard "N" format string and four different <see cref="CultureInfo"/> objects 
        /// to display the string representation of a <see cref="Base100Digit"/> value to the console.
        /// <code>
        /// Base100Digit digit = new(90);
        /// CultureInfo[] providers = { new CultureInfo("en-us"),
        ///                             new CultureInfo("fr-fr"),
        ///                             new CultureInfo("es-es"),
        ///                             new CultureInfo("de-de") };
        ///
        /// foreach (CultureInfo provider in providers)
        ///     Console.WriteLine("{0} ({1})", digit.ToString("N2", provider), provider.Name);
        ///
        /// // The example displays the following output to the console:
        /// //     90.00 (en-US)
        /// //     90,00 (fr-FR)
        /// //     90,00 (es-ES)
        /// //     90,00 (de-DE)
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>
        /// The <see cref="ToString(string?, IFormatProvider?)"/> method formats a <see cref="Base100Digit"/> value 
        /// in a specified format of a specified culture. To format a number by using the default ("D2") format of 
        /// the current culture, call the <see cref="ToString"/> method. To format a number by using a specified format 
        /// of the current culture, call the <see cref="ToString(string?)"/> method.
        /// </para>
        /// <para>
        /// The <paramref name="format"/> parameter can be either a standard or a custom numeric format string. 
        /// All standard numeric format strings other than "R" (or "r") are supported, as are all custom numeric format characters. 
        /// If <paramref name="format"/> is <see keyword="null"/> or an empty string (""), the return value of this method 
        /// is formatted with the numeric format specifier ("D2").
        /// </para>
        /// <para>
        /// The <paramref name="formatProvider"/> parameter is an object that implements the <see cref="IFormatProvider"/> interface. 
        /// Its <see cref="IFormatProvider.GetFormat(Type?)"/> method returns a <see cref="NumberFormatInfo"/> object that provides 
        /// culture-specific information about the format of the string that is returned by this method. The object that implements 
        /// <see cref="IFormatProvider"/> can be any of the following:
        /// <list type="bullet">
        ///     <item>
        ///         <description>A <see cref="CultureInfo"/> object that represents the culture whose formatting rules are to be used.</description>
        ///     </item>
        ///     <item>
        ///         <description>A <see cref="NumberFormatInfo"/> object that contains specific numeric formatting information for this value.</description>
        ///     </item>
        ///     <item>
        ///         <description>A custom object that implements <see cref="IFormatProvider"/>.</description>
        ///     </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="formatProvider"/> is <see keyword="null"/> or a <see cref="NumberFormatInfo"/> 
        /// object cannot be obtained from <paramref name="formatProvider"/>, the return value is formatted using 
        /// the <see cref="NumberFormatInfo"/> object for the thread current culture. For information about the 
        /// thread current culture, see <see cref="Thread.CurrentCulture"/>.
        /// </para>
        /// <para>
        /// .NET provides extensive formatting support, which is described in greater detail in the following formatting topics:
        /// <list type="bullet">
        ///     <item>
        ///         <description>For more information about numeric format specifiers, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">Standard Numeric Format Strings</see> and <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</see>.</description>
        ///     </item>
        ///     <item>
        ///         <description>For more information about formatting, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types">Formatting Types.</see></description>
        ///     </item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <seealso cref="ToString"/>
        /// <seealso cref="ToString(string?)"/>
        /// <seealso cref="ToString(IFormatProvider?)"/>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            Value.ToString(
                format: DefaultFormatIfNullOrEmpty(format),
                provider: DefaultFormatProviderIfNull(formatProvider));

        private static string DefaultFormatIfNullOrEmpty(string? format) =>
            string.IsNullOrEmpty(format) ? DefaultNumericFormat : format;

        private static IFormatProvider DefaultFormatProviderIfNull(IFormatProvider? formatProvider) =>
            formatProvider ?? DefaultFormatProvider;
        
        #endregion

        #region Equality Comparison Implementation

        public override bool Equals(object? obj) => obj is Base100Digit digit && Equals(digit);
        
        public bool Equals(Base100Digit? other) => other.HasValue && Equals(other.Value);
        
        public bool Equals(Base100Digit other) => other.Value == Value;
        
        public static bool operator ==(Base100Digit left, Base100Digit right) => left.Value == right.Value;
        
        public static bool operator !=(Base100Digit left, Base100Digit right) => left.Value != right.Value;

        public static bool operator ==(Base100Digit? left, Base100Digit? right)
        {
            if (left.HasValue) return left.Value.Equals(right);
            else return !right.HasValue;
        }

        public static bool operator !=(Base100Digit? left, Base100Digit? right)
        {
            if (left.HasValue) return !left.Value.Equals(right);
            else return right.HasValue;
        }

        #endregion
    }
}