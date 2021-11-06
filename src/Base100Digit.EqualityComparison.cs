using System;

namespace Base100Identifier
{
    public partial struct Base100Digit : IEquatable<Base100Digit>, IEquatable<Base100Digit?>
    {
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
    }
}