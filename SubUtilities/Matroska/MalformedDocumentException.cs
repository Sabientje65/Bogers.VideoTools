namespace SubUtilities.Matroska;

public class MalformedDocumentException : Exception
{
    public MalformedDocumentException(string message) : base(message)
    {
    }
        
    public MalformedDocumentException(string message, string documentationLink) : base(
        message + "\r\n" + "For more information, see: " + documentationLink
    )
    {
    }
}