namespace SmartBiterp.Domain.ValueObjects
{
    public sealed class Period : IEquatable<Period>
    {
        public int Year { get; }
        public int Month { get; }

        private Period() { }

        public Period(int year, int month)
        {
            if (year < 2000 || year > 2100)
                throw new ArgumentException("Year must be between 2000 and 2100.");

            if (month < 1 || month > 12)
                throw new ArgumentException("Month must be between 1 and 12.");

            Year = year;
            Month = month;
        }

        public DateRange ToDateRange()
        {
            var start = new DateTime(Year, Month, 1);
            var end = start.AddMonths(1).AddDays(-1);

            return new DateRange(start, end);
        }

        public bool Equals(Period? other)
        {
            if (other is null) return false;
            return Year == other.Year && Month == other.Month;
        }

        public override bool Equals(object? obj) => Equals(obj as Period);
        public override int GetHashCode() => HashCode.Combine(Year, Month);

        public override string ToString() => $"{Year}-{Month:D2}";
    }
}
