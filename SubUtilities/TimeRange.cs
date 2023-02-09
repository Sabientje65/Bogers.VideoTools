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


/*

Express timerange in 64 bit integer?

single span layout -> 
1   fraction
2   fraction
3   fraction
4   fraction
5   fraction
6   fraction
7   fraction
8   fraction
9  fraction
10  seconds
11  seconds
12  seconds
13  seconds
14  seconds
15  seconds
16  minutes
17  minutes
18  minutes
19  minutes
20  minutes
21  minutes
22  hours
23  hours
24  hours
25  hours
26  hours
27  hours

*/