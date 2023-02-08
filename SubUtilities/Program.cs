using System.CommandLine;


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

var fileArg = new Option<FileInfo>(name: "--file");

// create dto per command? subtitlesdto { [Argument("--offset")] TimeSpan offset, etc.. } ?
subtitlesCmd.Add(offsetArg);
subtitlesCmd.Add(fileArg);

subtitlesCmd.SetHandler(async ctx =>
{
    var offset = ctx.ParseResult.GetValueForOption(offsetArg);
    var pipeline = new TransformationPipeline();
    
    if(offset.HasValue) pipeline.AddTransformation(new OffsetTransformation(offset.Value));
    
    var file = ctx.ParseResult.GetValueForOption(fileArg);

    await using var srtFileStream = file.Open(FileMode.Open, FileAccess.ReadWrite);
    var srt = await SrtFile.Parse(srtFileStream);

    await pipeline.Run(srt);

    srtFileStream.Seek(0, SeekOrigin.Begin);
    await srt.WriteToStream(srtFileStream);
});

await rootCmd.InvokeAsync(args);

// ITransformation -> each arg = transformation, build transformation pipeline?

// ITransformation.Apply(TransformationContext { SrtFile, Log, etc? })


/*

Express timerange in 64 bit integer?

single span layout -> 
1   fraction
2   fraction
3   fraction
4   fraction
5   fraction
6   fraction
7   fraction
8   fraction
9  fraction
10  seconds
11  seconds
12  seconds
13  seconds
14  seconds
15  seconds
16  minutes
17  minutes
18  minutes
19  minutes
20  minutes
21  minutes
22  hours
23  hours
24  hours
25  hours
26  hours
27  hours

*/