using System.Text.RegularExpressions;

namespace SubUtilities;

public class AutoMatchAction : IAction
{
    private readonly IEpisodeNumberExtractor[] _episodeNumberExtractors;
    
    private readonly IEpisodeMatcher[] _episodeMatchers = {
        new PrefixEpisodeMatcher("E"),
        new PrefixEpisodeMatcher(" - "),
        new PrefixEpisodeMatcher(" ")
    };

    public AutoMatchAction(MatchMode matchMode = MatchMode.Default)
    {
        // we should attempt to infer matchmode by looking at filename shapes (S... = season based, E... = episode based)
        _episodeNumberExtractors = new []{
            new RegexEpisodeNumberExtractor(new Regex(@"E(\d+)")),
            new RegexEpisodeNumberExtractor(new Regex(@"(\d+)"))
        };

        if (matchMode == MatchMode.MultiSeason)
        {
            _episodeNumberExtractors = _episodeNumberExtractors.Select(x => new MultiSeasonEpisodeNumberExtractor(x)).ToArray();
        }
    }

    public Task Apply(ActionContext context)
    {
        foreach (var srtFile in context.SrtFiles)
        {
            // for now, extract numbers -> try to match for episode
            var episodeNumber = _episodeNumberExtractors
                    .FirstOrDefault(x => x.CanExtract(srtFile))
                    ?.Extract(srtFile);
            
            if (String.IsNullOrEmpty(episodeNumber)) continue;

            episodeNumber = episodeNumber.PadLeft(2, '0');
            var srtDirectory = Path.GetDirectoryName(srtFile.Name);
            var videoFiles = Directory.EnumerateFiles(srtDirectory)
                .Where(f => _episodeMatchers.Any(em => em.IsMatch(f, episodeNumber)))
                .ToArray();
            
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
    
    private interface IEpisodeNumberExtractor
    {
        string Extract(SrtFile srt);

        bool CanExtract(SrtFile srt);
    }

    private class MultiSeasonEpisodeNumberExtractor : IEpisodeNumberExtractor
    {
        private readonly IEpisodeNumberExtractor _matcher;
        
        // when we're dealing with subtitles for multiple seasons, implicitly track episode numbers by simply tracking the absolute amount of episodes matched
        // we're assuming matches will be made in order with no gaps being present
        private int _absoluteEpisodeNumber;

        public MultiSeasonEpisodeNumberExtractor(IEpisodeNumberExtractor matcher) => _matcher = matcher;

        public string Extract(SrtFile srt)
        {

            return (++_absoluteEpisodeNumber).ToString();
        }

        public bool CanExtract(SrtFile srt) => _matcher.CanExtract(srt);
    }

    private class RegexEpisodeNumberExtractor : IEpisodeNumberExtractor
    {
        private readonly Regex _regex;
        
        public RegexEpisodeNumberExtractor(Regex regex)
        {
            _regex = regex;
        }

        public string Extract(SrtFile srt)
        {
            return _regex.Match(Path.GetFileName(srt.Name))
                .Groups[1].Value;
        }

        public bool CanExtract(SrtFile srt)
        {
            return _regex.IsMatch(Path.GetFileName(srt.Name));
        }
    }
    
    private interface IEpisodeMatcher
    {
        bool IsMatch(string file, string episode);
    }

    private class PrefixEpisodeMatcher : IEpisodeMatcher
    {
        private readonly string _prefix;

        public PrefixEpisodeMatcher(string prefix) => _prefix = prefix;

        public bool IsMatch(string file, string episode)
        {
            if (Path.GetExtension(file) == ".srt") return false;
            
            var prefix = _prefix + episode;
            return Path.GetFileName(file).Contains(prefix);
        }
    }
    
    public enum MatchMode
    {
        /// <summary>
        /// Default, simply match by episode number
        /// </summary>
        Default,
        
        /// <summary>
        /// SRTs for multiple seasons, video files for only a single season
        /// </summary>
        MultiSeason
    }
}