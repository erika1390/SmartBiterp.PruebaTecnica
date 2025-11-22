namespace SmartBiterp.Domain.ValueObjects
{
    public sealed class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money() { } 

        public Money(decimal amount, string currency = "USD")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required.", nameof(currency));

            Amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
            Currency = currency.ToUpper();
        }

        public static Money operator +(Money a, Money b)
        {
            ValidateCurrencies(a, b);
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            ValidateCurrencies(a, b);
            return new Money(a.Amount - b.Amount, a.Currency);
        }

        public bool IsGreaterThan(Money other)
        {
            ValidateCurrencies(this, other);
            return Amount > other.Amount;
        }

        public bool IsLessThan(Money other)
        {
            ValidateCurrencies(this, other);
            return Amount < other.Amount;
        }

        private static void ValidateCurrencies(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot operate with different currencies.");
        }

        public bool Equals(Money? other)
        {
            if (other is null) return false;

            return Amount == other.Amount &&
                   Currency == other.Currency;
        }

        public override bool Equals(object? obj) => Equals(obj as Money);
        public override int GetHashCode() => HashCode.Combine(Amount, Currency);

        public override string ToString() => $"{Currency} {Amount:N2}";
    }
}