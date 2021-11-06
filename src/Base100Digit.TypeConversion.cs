using System;

namespace Base100Identifier
{
    public partial struct Base100Digit : IConvertible
    {
        private const string ExceptionMessage_ConversionNotSupported = "This conversion is not supported.";
        
        public static implicit operator byte(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator sbyte(Base100Digit base100Digit) => (sbyte)base100Digit.Value;
        public static implicit operator short(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator ushort(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator int(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator uint(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator nint(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator nuint(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator long(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator ulong(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator float(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator double(Base100Digit base100Digit) => base100Digit.Value;
        public static implicit operator decimal(Base100Digit base100Digit) => base100Digit.Value;

        public static explicit operator Base100Digit(byte value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(exception.Message, exception);
            }
        }

        public static explicit operator Base100Digit(sbyte value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }
        public static explicit operator Base100Digit(short value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }
        
        public static explicit operator Base100Digit(ushort value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }
        
        public static explicit operator Base100Digit(int value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }

        public static explicit operator Base100Digit(uint value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }
        
        public static explicit operator Base100Digit(nint value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }

        public static explicit operator Base100Digit(nuint value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }

        public static explicit operator Base100Digit(long value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }

        public static explicit operator Base100Digit(ulong value)
        {
            try
            {
                return new Base100Digit(value);
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message, 
                    innerException: exception);
            }
        }

        public static explicit operator Base100Digit(float value)
        {
            try
            {
                return new Base100Digit(Convert.ToByte(value));
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message,
                    innerException: exception);
            }
        }
        
        public static explicit operator Base100Digit(double value)
        {
            try
            {
                return new Base100Digit(Convert.ToByte(value));
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message,
                    innerException: exception);
            }
        }

        public static explicit operator Base100Digit(decimal value)
        {
            try
            {
                return new Base100Digit(Convert.ToByte(value));
            }
            catch (Exception exception)
            {
                throw new InvalidCastException(
                    message: exception.Message,
                    innerException: exception);
            }
        }
         
        /// <inheritdoc/>
        byte IConvertible.ToByte(IFormatProvider? provider) => Value;     
        
        /// <inheritdoc/>
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => (sbyte)Value;

        /// <inheritdoc/>
        short IConvertible.ToInt16(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        int IConvertible.ToInt32(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        uint IConvertible.ToUInt32(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        long IConvertible.ToInt64(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => Value;
        
        /// <inheritdoc/>
        float IConvertible.ToSingle(IFormatProvider? provider) => Value;
        
        /// <inheritdoc/>
        double IConvertible.ToDouble(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => Value;

        /// <inheritdoc/>
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) =>
            Convert.ChangeType(this, conversionType, provider);
        
        /// <inheritdoc/>
        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        
        /// <inheritdoc/>
        bool IConvertible.ToBoolean(IFormatProvider? provider) =>
            throw new InvalidCastException(ExceptionMessage_ConversionNotSupported);

        /// <inheritdoc/>
        char IConvertible.ToChar(IFormatProvider? provider) =>
            throw new InvalidCastException(ExceptionMessage_ConversionNotSupported);

        /// <inheritdoc/>
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) =>
            throw new InvalidCastException(ExceptionMessage_ConversionNotSupported);
    }
}