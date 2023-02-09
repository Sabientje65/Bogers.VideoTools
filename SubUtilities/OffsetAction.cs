public class OffsetAction : IAction
{
    private readonly TimeSpan _offset;
    
    public OffsetAction(TimeSpan offset)
    {
        _offset = offset;
    }
    
    public Task Apply(ActionContext context)
    {
        foreach (var srtFile in context.SrtFiles)
        {
            foreach (var segment in srtFile.Segments)
            {
                segment.AdjustTimeRange(_offset);
            }    
        }
        
        

        return Task.CompletedTask;
    }
}