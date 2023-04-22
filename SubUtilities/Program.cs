using System.CommandLine;
using System.Text;
using SubUtilities;

// MatroskaVideo.Test();
//
// return;

// sub-utils offset update -5s
var rootCmd = new RootCommand();
var subtitlesCmd = new Command("subtitles");
// var offsetUpdateCmd = new Command("update");

rootCmd.Add(subtitlesCmd);
// offsetCmd.Add(offsetUpdateCmd);


var offsetArg = new Option<TimeSpan?>(
    name: "--offset",
    parseArgument: ctx =>
    {
        if (String.IsNullOrEmpty(ctx.Tokens[0].Value)) return null;
        return Parsers.ParseOffset(ctx.Tokens[0].Value);
    }
);

// TODO: Offer option for File, Embed, Stdout (default?), add pattern when dealing with multiple files?
// TODO: Add matcher for srt <> mkv (and other files?)
var outputArg = new Option<string>(name: "--output");

var fileMatcherArg = new Option<bool>(name: "--automatch", description: "Try to automatically match and rename files to match video files");

var fileArg = new Option<FileInfo>(name: "--file");

// create dto per command? subtitlesdto { [Argument("--offset")] TimeSpan offset, etc.. } ?
subtitlesCmd.Add(offsetArg);
subtitlesCmd.Add(fileArg);
subtitlesCmd.Add(fileMatcherArg);

subtitlesCmd.SetHandler(async ctx =>
{
    var offset = ctx.ParseResult.GetValueForOption(offsetArg);
    var source = ctx.ParseResult.GetValueForOption(fileArg)?.FullName ?? Environment.CurrentDirectory;
    var output = ctx.ParseResult.GetValueForOption(outputArg) ?? Environment.CurrentDirectory;
    var automatch = ctx.ParseResult.GetValueForOption(fileMatcherArg);
    
    var pipeline = new TransformationPipeline();
    
    pipeline.AddTransformation(new ScanForSrtFilesAction(source));
    if(offset.HasValue) pipeline.AddTransformation(new OffsetAction(offset.Value));
    if (automatch) pipeline.AddTransformation(new AutoMatchAction());
    pipeline.AddTransformation(new WriteToFileAction(output));

    // await using var srtFileStream = file.Open(FileMode.Open, FileAccess.ReadWrite);
    // var srt = await SrtFile.Parse(srtFileStream);

    ctx.ExitCode = await pipeline.Run();

    // srtFileStream.Seek(0, SeekOrigin.Begin);
    // await srt.WriteToStream(srtFileStream);
});

await rootCmd.InvokeAsync(args);


// ITransformation -> each arg = transformation, build transformation pipeline?

// ITransformation.Apply(TransformationContext { SrtFile, Log, etc? })
