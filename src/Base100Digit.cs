using System;

namespace Base100Identifier
{
    /// <summary>
    /// Represents an base100 digit (0-99).
    /// </summary>
    public readonly partial struct Base100Digit
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
            ThrowIfValueIsOutOfRange(in value);
            Value = value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.SByte"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is less than <see cref="Base100Digit.MinValue"/> or larger
        /// than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in sbyte value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.Int16"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is less than <see cref="Base100Digit.MinValue"/> or larger
        /// than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in short value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.UInt16"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is larger than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in ushort value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.Int32"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is less than <see cref="Base100Digit.MinValue"/> or larger
        /// than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in int value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.UInt32"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is larger than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in uint value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is less than <see cref="Base100Digit.MinValue"/> or larger
        /// than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in nint value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is larger than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in nuint value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is less than <see cref="Base100Digit.MinValue"/> or larger
        /// than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in long value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Base100Digit"/> structure 
        /// by using a specified <see cref="System.UInt64"/> value.
        /// </summary>
        /// <param name="value">
        /// The value to initialize the <see cref="Base100Digit"/> structure with.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When <paramref name="value"/> is larger than <see cref="Base100Digit.MaxValue"/>.
        /// </exception>
        public Base100Digit(in ulong value)
        {
            ThrowIfValueIsOutOfRange(in value);
            Value = (byte)value;
        }
        
        private static void ThrowIfValueIsOutOfRange(in byte value)
        {
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in sbyte value)
        {
            if (value < MinByteValue) ThrowValueIsOutOfRangeException(value);
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in short value)
        {
            if (value < MinByteValue) ThrowValueIsOutOfRangeException(value);
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in ushort value)
        {
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in int value)
        {
            if (value < MinByteValue) ThrowValueIsOutOfRangeException(value);
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in uint value)
        {
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in nint value)
        {
            if (value < MinByteValue) ThrowValueIsOutOfRangeException(value);
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in nuint value)
        {
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in long value)
        {
            if (value < MinByteValue) ThrowValueIsOutOfRangeException(value);
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowIfValueIsOutOfRange(in ulong value)
        {
            if (value > MaxByteValue) ThrowValueIsOutOfRangeException(value);
        }
        
        private static void ThrowValueIsOutOfRangeException(in object? value)
        {
            throw new ArgumentOutOfRangeException(
                paramName: nameof(value), 
                actualValue: value, 
                message: "Value was either too large or too small for an base100 digit. The value has to be between 0 and 99.");
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="Base100Digit"/>.
        /// </returns>
        /// <seealso cref="Object.GetHashCode"/>
        public override int GetHashCode() => Value;
    }
}