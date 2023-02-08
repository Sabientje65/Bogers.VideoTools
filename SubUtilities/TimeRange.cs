public struct TimeRange
{
    public required TimeSpan From { get; init; }
    public required TimeSpan To { get; init; }

    public static TimeRange operator -(TimeRange range, TimeSpan offset) => new TimeRange
    {
        From = range.From - offset,
        To = range.To - offset
    };
    
    public static TimeRange operator +(TimeRange range, TimeSpan offset) => new TimeRange
    {
        From = range.From - offset,
        To = range.To - offset
    };
}