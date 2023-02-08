public class TransformationPipeline
{
    private readonly List<ITransformation> _transformations;
    
    public TransformationPipeline()
    {
        _transformations = new List<ITransformation>();
    }

    public void AddTransformation(ITransformation transformation) => _transformations.Add(transformation);

    public async Task Run(SrtFile srt)
    {
        var context = new TransformationContext { Srt = srt };
        
        foreach (var transformation in _transformations)
        {
            await transformation.Apply(context);
        }
    }
}