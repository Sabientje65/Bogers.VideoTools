using Microsoft.VisualBasic;

namespace SubUtilities;

public class ScanForSrtFilesAction : IAction
{
    private readonly string _location;
    
    public ScanForSrtFilesAction(string location)
    {
        _location = location;
    }
    
    public async Task Apply(ActionContext context)
    {
        await foreach (var srt in EnumerateSrts())
        {
            context.SrtFiles.Add(srt);
        }
    }

    private async IAsyncEnumerable<SrtFile> EnumerateSrts()
    {
        var attrs = File.GetAttributes(_location);
        
        // assume file, check for existance?
        if (!attrs.HasFlag(FileAttribute.Directory))
        {
            await using var fs = File.OpenRead(_location);
            yield return await SrtFile.Parse(fs);
            yield break;
        }

        foreach (var srtFile in Directory.EnumerateFiles(_location, "*.srt"))
        {
            await using var fs = File.OpenRead(srtFile);
            yield return await SrtFile.Parse(fs);
        }
    }
}