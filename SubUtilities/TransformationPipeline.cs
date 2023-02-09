public class TransformationPipeline
{
    private readonly List<IAction> _transformations;
    
    public TransformationPipeline()
    {
        _transformations = new List<IAction>();
    }

    public void AddTransformation(IAction action) => _transformations.Add(action);

    public async Task<int> Run()
    {
        var context = new ActionContext();
        
        foreach (var transformation in _transformations)
        {
            await transformation.Apply(context);
            if (context.HasFailed) return context.ExitCode;
        }

        return context.ExitCode;
    }
}