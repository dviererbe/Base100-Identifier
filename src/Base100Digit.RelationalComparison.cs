using System;

namespace Base100Identifier
{
    public partial struct Base100Digit : IComparable<Base100Digit>, IComparable<Base100Digit?>, IComparable
    {
        // See https://docs.microsoft.com/en-us/dotnet/api/System.IComparable.CompareTo?view=net-5.0#returns for more
        // information about the value.
        private const int RelativeSortOrderComparedToNull = 1;
        
        public int CompareTo(Base100Digit other) => Value.CompareTo(other.Value);
        
        public int CompareTo(Base100Digit? other) => 
            other.HasValue
                ? CompareTo(other.Value)
                : RelativeSortOrderComparedToNull;

        public int CompareTo(object? obj)
        {
            if (obj is null) return RelativeSortOrderComparedToNull;
            if (obj is Base100Digit digit) return CompareTo(digit);

            throw new ArgumentException(
                paramName: nameof(obj),
                message: $"Object must be of type {nameof(Base100Digit)}");
        }
        
        public static bool operator <(Base100Digit left, Base100Digit right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Base100Digit left, Base100Digit right)
        {
            return left.CompareTo(right) > 0;
        }
        
        public static bool operator <=(Base100Digit left, Base100Digit right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Base100Digit left, Base100Digit right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}