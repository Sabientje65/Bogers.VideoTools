public class OffsetTransformation : ITransformation
{
    private readonly TimeSpan _offset;
    
    public OffsetTransformation(TimeSpan offset)
    {
        _offset = offset;
    }
    
    public Task Apply(TransformationContext context)
    {
        foreach (var segment in context.Srt.Segments)
        {
            segment.AdjustTimeRange(_offset);
        }

        return Task.CompletedTask;
    }
}