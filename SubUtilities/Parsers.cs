public class Parsers
{
    
    public static TimeSpan ParseOffset(string offset)
    {
        var isNegative = offset[0] == '-';
        if (isNegative) offset = offset[1..];

        var unit = offset[^1];
        offset = offset[..^1];

        var offsetValue = Int32.Parse(offset);
        if (isNegative) offsetValue = -offsetValue;

        return unit switch
        {
            's' => CreateTimeSpan(seconds: offsetValue),
            'm' => CreateTimeSpan(minutes: offsetValue),
            'h' => CreateTimeSpan(hours: offsetValue),
            _ => throw new ArgumentOutOfRangeException()
        };

        TimeSpan CreateTimeSpan(int hours = 0, int minutes = 0, int seconds = 0) => new TimeSpan(hours, minutes, seconds);
    }
    
}