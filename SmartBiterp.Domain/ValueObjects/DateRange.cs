namespace SmartBiterp.Domain.ValueObjects
{
    public sealed class DateRange : IEquatable<DateRange>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        private DateRange() { }

        public DateRange(DateTime start, DateTime end)
        {
            if (end < start)
                throw new ArgumentException("End date must be greater than or equal to start date.");

            Start = start.Date;
            End = end.Date;
        }

        public bool Contains(DateTime date)
        {
            var d = date.Date;
            return d >= Start && d <= End;
        }

        public bool Overlaps(DateRange other)
        {
            return Start <= other.End && other.Start <= End;
        }

        public bool Equals(DateRange? other)
        {
            if (other is null) return false;
            return Start == other.Start && End == other.End;
        }

        public override bool Equals(object? obj) => Equals(obj as DateRange);
        public override int GetHashCode() => HashCode.Combine(Start, End);

        public override string ToString() => $"{Start:yyyy-MM-dd} to {End:yyyy-MM-dd}";
    }
}