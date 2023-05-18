namespace SubUtilities.Matroska;

public enum ElementType
{
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-signed-integer-element
    /// </summary>
    SignedInteger,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-unsigned-integer-element
    /// </summary>
    UnsignedInteger,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-float-element
    /// </summary>
    Float,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-string-element
    /// </summary>
    ASCIIString,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-utf-8-element
    /// </summary>
    Utf8String,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-date-element
    /// </summary>
    Date,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-master-element
    /// </summary>
    Master,
        
    /// <summary>
    /// https://www.rfc-editor.org/rfc/rfc8794.pdf#name-binary-element
    /// </summary>
    Binary,
    
    /// <summary>
    /// Unknown element type, can be consumed but not meaningfully used
    /// </summary>
    Unknown
}