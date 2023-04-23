using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace SubUtilities;

[DebuggerDisplay("{Name}")]
public class SrtFile
{
    
    public string Name { get; set; } // TODO: Set via ctor?
    
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
        // faster than invoking readline constantly..
        var sourceString = await new StreamReader(source, encoding, leaveOpen: true).ReadToEndAsync(); 
        
        // we do not own the underlying stream
        using var reader = new StringReader(sourceString);
        var textBuffer = new StringBuilder();
        
        // small optimization: read number of final segment -> pre-determine total segments
        var segments = new List<SrtSegment>();

        while (reader.Peek() != -1)
        {
            segments.Add(await ParseNextSegment());
        }

        return new SrtFile(segments.ToArray());
        
        
        async Task<SrtSegment> ParseNextSegment()
        {
            textBuffer!.Clear();
            
            //todo: validate
            
            var numberLine = (await reader.ReadLineAsync()).Trim();
            var rangeLine = (await reader.ReadLineAsync()).Trim();
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