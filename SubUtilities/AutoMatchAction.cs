using System.Text.RegularExpressions;

namespace SubUtilities;

public class AutoMatchAction : IAction
{
    public Task Apply(ActionContext context)
    {
        var episodeNumberMatcher = new Regex(@"(\d+)");
        
        foreach (var srtFile in context.SrtFiles)
        {
            // for now, extract numbers -> try to match for episode
            var episodeMatch = episodeNumberMatcher.Match(Path.GetFileName(srtFile.Name));
            if (!episodeMatch.Success) continue;

            var episodeNumber = episodeMatch.Groups[1].Value.PadLeft(2, '0');
            var srtDirectory = Path.GetDirectoryName(srtFile.Name);
            var videoFiles = Directory.GetFiles(srtDirectory, "*E" + episodeNumber + "*.*");
            if (videoFiles.Length != 1) continue;

            // rename srt to match videofile
            var videoFile = videoFiles[0];
            srtFile.Name = Path.Combine(
                srtDirectory,
                Path.GetFileNameWithoutExtension(videoFile) + ".srt"    
            );
        }

        return Task.CompletedTask;
    }
}