using System;

namespace Base100Identifier
{
    /// <summary>
    /// Represents an base100 digit (0-99).
    /// </summary>
    public readonly struct Base100Digit
    {
        private const byte MinByteValue = 0;
        private const byte MaxByteValue = 99;

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
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure by using a specified <see cref="System.Byte"/> value.
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
            throw new ArgumentOutOfRangeException(nameof(value), value, "The value for an base100 digit has to be between 0 and 99.");
        }
    }
}