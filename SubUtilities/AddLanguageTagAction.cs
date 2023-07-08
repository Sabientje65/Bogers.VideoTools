namespace SubUtilities;

public class AddLanguageTagAction : IAction
{
    private readonly string _language;
    
    public AddLanguageTagAction(string language) => _language = $".{language}";
    
    public Task Apply(ActionContext context)
    {
        foreach (var srt in context.SrtFiles)
        {
            var extension = Path.GetExtension(srt.Name);
            var name = Path.GetFileNameWithoutExtension(srt.Name);
            if ( Path.GetExtension(name).Equals(_language, StringComparison.OrdinalIgnoreCase) ) continue;
            
            srt.Name = $"{name}.{_language}{extension}";
        }

        return Task.CompletedTask;
    }
}