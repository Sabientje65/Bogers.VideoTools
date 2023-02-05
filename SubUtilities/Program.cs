using System.CommandLine;
using System.Globalization;
using System.Text;

Console.WriteLine("YEP");


// sub-utils offset update -5s
var rootCmd = new RootCommand();
var subtitlesCmd = new Command("subtitles");
// var offsetUpdateCmd = new Command("update");

rootCmd.Add(subtitlesCmd);
// offsetCmd.Add(offsetUpdateCmd);


var offsetArg = new Option<TimeSpan>(
    name: "--offset",
    parseArgument: ctx => ParseOffset(ctx.Tokens[0].Value)
);

var fileArg = new Option<FileInfo>(name: "--file");

// create dto per command? subtitlesdto { [Argument("--offset")] TimeSpan offset, etc.. } ?
subtitlesCmd.Add(offsetArg);
subtitlesCmd.Add(fileArg);

subtitlesCmd.SetHandler(async ctx =>
{
    var offset = ctx.ParseResult.GetValueForOption(offsetArg);
    var file = ctx.ParseResult.GetValueForOption(fileArg);

    await using var srtFileStream = file.Open(FileMode.Open, FileAccess.ReadWrite);
    var srt = await SrtFile.Parse(srtFileStream);

    foreach (var segment in srt.Segments) segment.AdjustTimeRange(offset);

    srtFileStream.Seek(0, SeekOrigin.Begin);
    await srt.WriteToStream(srtFileStream);
});

await rootCmd.InvokeAsync(args);

// ITransformation -> each arg = transformation, build transformation pipeline?

// ITransformation.Apply(TransformationContext { SrtFile, Log, etc? })


static TimeSpan ParseOffset(string offset)
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


class SrtFile
{
    
    public SrtSegment[] Segments { get; }

    private SrtFile(SrtSegment[] segments)
    {
        Segments = segments;
    }


    public async Task WriteToStream(Stream target) => await WriteToStream(target, Encoding.UTF8);
    
    public async Task WriteToStream(Stream target, Encoding encoding)
    {
        var sortedSegments = Segments
            .OrderBy(segment => segment.TimeRange.From)
            .ToArray();

        await using var writer = new StreamWriter(target, encoding, leaveOpen: true);
        for (var index = 0; index < sortedSegments.Length; index++)
        {
            var segment = sortedSegments[index];
            var number = index + 1;

            await writer.WriteLineAsync(number.ToString());
            await writer.WriteAsync(segment.TimeRange.From.ToString("hh\\:mm\\:ss\\,fff"));
            await writer.WriteAsync(" --> ");
            await writer.WriteLineAsync(segment.TimeRange.To.ToString("hh\\:mm\\:ss\\,fff"));
            await writer.WriteAsync(segment.Text);
            
            // write segment separator for all but last segment
            if (index < sortedSegments.Length) await writer.WriteLineAsync();
        }
    }

    // try to sniff out encoding?
    public static async Task<SrtFile> Parse(Stream source) => await Parse(source, Encoding.UTF8);
    
    public static async Task<SrtFile> Parse(Stream source, Encoding encoding)
    {
        // we do not own the underlying stream
        using var reader = new StreamReader(source, encoding, leaveOpen: true);
        var textBuffer = new StringBuilder();
        
        // small optimization: read number of final segment -> pre-determine total segments
        var segments = new List<SrtSegment>();

        while (!reader.EndOfStream)
        {
            segments.Add(await ParseNextSegment());
        }

        return new SrtFile(segments.ToArray());
        
        
        async Task<SrtSegment> ParseNextSegment()
        {
            textBuffer!.Clear();
            
            //todo: validate
            
            var numberLine = await reader.ReadLineAsync();
            var rangeLine = await reader.ReadLineAsync();
            for (
                var textLine = await reader.ReadLineAsync(); 
                !String.IsNullOrEmpty(textLine); 
                textLine = await reader.ReadLineAsync()
            )
            {
                textBuffer.AppendLine(textLine);
            }

            var rangeFrom = rangeLine[.."00:00:00,000".Length];
            var rangeTo = rangeLine[^"00:00:00,000".Length..];
            
            return new SrtSegment
            {
                Number = Int32.Parse(numberLine),
                TimeRange = new TimeRange
                {
                    From = TimeSpan.ParseExact(rangeFrom, "hh\\:mm\\:ss\\,fff", CultureInfo.InvariantCulture),
                    To = TimeSpan.ParseExact(rangeTo, "hh\\:mm\\:ss\\,fff", CultureInfo.InvariantCulture)
                },
                Text = textBuffer.ToString()
            };
        }
    }
    
}

class SrtSegment
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

        _timeRange = new TimeRange
        {
            From = TimeRange.From + offset,
            To = TimeRange.To + offset,
        };
    }
}

public struct TimeRange
{
    public required TimeSpan From { get; init; }
    public required TimeSpan To { get; init; }
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