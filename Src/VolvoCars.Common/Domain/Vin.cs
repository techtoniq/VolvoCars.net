namespace VolvoCars.Common.Domain
{
    public class Vin
    {
        #region Private Fields

        private readonly string _value;

        #endregion Private Fields

        #region Ctor

        public Vin(string vin)
        {
            if (string.IsNullOrWhiteSpace(vin))
                throw new ArgumentNullException(nameof(vin));

            if (vin.Length != 17)
                throw new ArgumentException("Invalid length (must be 17 characters)", nameof(vin));

            for (int i = 0; i < vin.Length; i++)
            {
                if ((vin[i] < 'A' || vin[i] > 'Z') && !Char.IsDigit(vin[i]))
                    throw new ArgumentException("All characters must be upper case alphanumeric only", nameof(vin));

                if (vin[i] == 'I' || vin[i] == 'O' || vin[i] == 'Q')
                    throw new ArgumentException($"Invalid character at position {i}", nameof(vin));
            }

            _value = vin;
        }

        #endregion Ctor

        #region Public Operators

        public static explicit operator Vin(string value)
        {
            Vin vin = new Vin(value);
            return vin;
        }

        public static implicit operator string(Vin vin)
        {
            return vin._value;
        }

        #endregion Public Operators

        #region Public Object Overrides

        public override string ToString()
        {
            return _value.ToString();
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Vin;

            if (other == null)
                return false;

            return _value.Equals(other._value);
        }

        #endregion Public Object Overrides
    }
}
