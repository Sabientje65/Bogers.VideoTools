namespace SubUtilities.Matroska;

public static class WellKnownEBMLIds
{
    /// <summary>
    /// Master element
    /// \EBML
    /// </summary>
    public const int EBML = 0x1A45DFA3;

    /// <summary>
    /// Version element, uint
    /// \EBML\EBMLVersion
    ///
    /// Document version
    /// </summary>
    public const int Version = 0x4286;

    /// <summary>
    /// ReadVersion element, uint
    /// \EBML\EBMLReadVersion
    ///
    /// Minimum version for reading
    /// </summary>
    public const int ReadVersion = 0x42F7;

    /// <summary>
    /// MaxIdLength, uint
    /// \EBML\EBMLMaxIDLength
    /// 
    /// Maximum element id length, defaults to 4
    /// </summary>
    public const int MaxIdLength = 0x42F2;
    
    /// <summary>
    /// MaxSizeLength, uint
    /// \EBML\EBMLMaxSizeLength
    /// 
    /// Maximum element size, defaults to 8
    /// </summary>
    public const int MaxSizeLength = 0x42F3;
    
    /// <summary>
    /// Doctype, string
    /// \EBML\DocType
    ///
    /// A string that describes and identifies the content of the EBML Body that follows this EBML Header.
    /// </summary>
    public const int DocType = 0x4282;
    
    /// <summary>
    /// DocTypeVersion, uint
    /// \EBML\DocTypeVersion
    ///
    /// Defaults to 1
    /// The version of DocType interpreter used to create the EBML Document.
    /// </summary>
    public const int DocTypeVersion = 0x4287;
    
    /// <summary>
    /// DocTypeReadVersion, uint
    /// \EBML\DocTypeReadVersion
    ///
    /// Defaults to 1
    /// The minimum DocType version an EBML Reader has to support to read this EBML Document. The value of the DocTypeReadVersion Element MUST be less than or equal to the value of the DocTypeVersion Element.
    /// </summary>
    public const int DocTypeReadVersion = 0x4285;
    
    /// <summary>
    /// DocTypeExtension, master
    /// \EBML\DocTypeExtension
    ///
    /// A DocTypeExtension adds extra Elements to the main DocType+DocTypeVersion tuple it's attached to. An EBML Reader MAY know these extra Elements and how to use them. A DocTypeExtension MAY be used to iterate between experimental Elements before they are integrated into a regular DocTypeVersion. Reading one DocTypeExtension version of a DocType+DocTypeVersion tuple doesn't imply one should be able to read upper versions of this DocTypeExtension.
    /// </summary>
    public const int DocTypeExtension = 0x4281;
    
    /// <summary>
    /// DocTypeExtensionName, String
    /// \EBML\DocTypeExtension\DocTypeExtensionName
    ///
    /// The name of the DocTypeExtension to differentiate it from other DocTypeExtensions of the same DocType+DocTypeVersion tuple. A DocTypeExtensionName value MUST be unique within the EBML Header.
    /// </summary>
    public const int DocTypeExtensionName = 0x4283;
    
    /// <summary>
    /// DocTypeExtensionVersion, uint
    /// \EBML\DocTypeExtension\DocTypeExtensionVersion
    ///
    /// The version of the DocTypeExtension. Different DocTypeExtensionVersion values of the same DocType + DocTypeVersion + DocTypeExtensionName tuple MAY contain completely different sets of extra Elements. An EBML Reader MAY support multiple versions of the same tuple, only one version of the tuple, or not support the tuple at all.
    /// </summary>
    public const int DocTypeExtensionVersion = 0x4284;

    /// <summary>
    /// Cyclic Redundancy Check
    /// </summary>
    public const int CRC32 = 0xBF;
    
    /// <summary>
    /// Void, binary
    ///
    /// Element no data, used for marking wiped sectors, reserved space, etc.
    /// </summary>
    public const int Void = 0xEC;

    public static IDictionary<int, string> Lookup = new Dictionary<int, string>
    {
        { EBML, nameof(EBML) },
        { Version, nameof(Version) },
        { ReadVersion, nameof(ReadVersion) },
        { MaxIdLength, nameof(MaxIdLength) },
        { MaxSizeLength, nameof(MaxSizeLength) },
        { DocType, nameof(DocType) },
        { DocTypeVersion, nameof(DocTypeVersion) },
        { DocTypeReadVersion, nameof(DocTypeReadVersion) },
        { DocTypeExtension, nameof(DocTypeExtension) },
        { DocTypeExtensionName, nameof(DocTypeExtensionName) },
        { DocTypeExtensionVersion, nameof(DocTypeExtensionVersion) },
    };
}