namespace SubUtilities;

public class ActionContext
{
    public List<SrtFile> SrtFiles { get; } = new List<SrtFile>();

    // actual output is to be written to stdout/stderr by individual action
    public int ExitCode { get; private set; }

    public bool HasFailed => ExitCode != 0;

    public void Fail(int code) => ExitCode = code;
}