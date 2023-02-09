public class WriteToFileAction : IAction
{
    private readonly string _destination;
    
    public WriteToFileAction(string destination)
    {
        _destination = destination;
    }

    public async Task Apply(ActionContext context)
    {
        if (context.SrtFiles.Count == 0) return;
        
        // assume directory
        if (!Path.GetExtension(_destination).Equals(".srt"))
        {
            Directory.CreateDirectory(_destination);
        }

        for (var idx = 0; idx < context.SrtFiles.Count; idx++)
        {
            var file = GetOutputPath(context, context.SrtFiles[idx]);
            await using var fs = File.Open(file, FileMode.Create, FileAccess.Read);
            await context.SrtFiles[idx].WriteToStream(fs);
        }
    }

    private string GetOutputPath(ActionContext context, SrtFile srt)
    {
        if (!Path.GetExtension(_destination).Equals(".srt"))
        {
            return Path.Combine(_destination, srt.Name);
        }

        return context.SrtFiles.IndexOf(srt) == 0
            ? _destination
            : $"{Path.GetFileNameWithoutExtension(_destination)}_{context.SrtFiles.IndexOf(srt)}.srt";
    }
}