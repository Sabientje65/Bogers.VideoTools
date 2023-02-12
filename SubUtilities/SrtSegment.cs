namespace SubUtilities;

public class SrtSegment
{
    private TimeRange _timeRange;
    
    public required int Number { get; init; }

    public required TimeRange TimeRange
    {
        get => _timeRange;
        init => _timeRange = value;
    }
    
    // type -> containing specific information in regards to text parts (bold, italic, color, etc)?
    public required string Text { get; init; }

    public void AdjustTimeRange(TimeSpan offset)
    {
        // should we include a reference to our containing file to also update numbering?
        // Maybe include autonumbering -> sort based on range?

        _timeRange += offset;
    }
}