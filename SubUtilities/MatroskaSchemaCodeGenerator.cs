using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace SubUtilities;

public class MatroskaSchemaCodeGenerator
{

    private EBMLSchemaRoot _root { get; init; }
    private IndentedTextWriter _writer { get; init; }


    // TODO: Take input stream/output stream
    public static void Run()
    {
        var destfile = @"E:\src\Bogers.VideoTools\SubUtilities\MatroskaRegistry.Generated.cs";
        var destfileTmp = destfile + ".tmp";
        
        using var source = File.OpenRead(@"E:\src\Bogers.VideoTools\SubUtilities\TestFiles\ebml_matroska.xml");
        using var destination = File.Open(destfileTmp, FileMode.Create);
        
        var serializer = new XmlSerializer(typeof(EBMLSchemaRoot));
        var root = (EBMLSchemaRoot)serializer.Deserialize(source);

        var instance = new MatroskaSchemaCodeGenerator
        {
            _root = root,
            _writer = new IndentedTextWriter(new StreamWriter(destination), "  ")
        };

        instance.DeclareHeader();
        instance.DeclareUsings();
        instance.DeclareNamespace();
        instance.DeclareElementInterface();
        instance.DeclareElementRegistry();
        instance.DeclareElements();
        
        instance._writer.Flush();
        destination.Close();
        
        File.Move(destfileTmp, destfile, true);
    }

    private void DeclareHeader()
    {
        _writer.WriteLine("""
/**
* THIS FILE HAS BEEN AUTOMATICALLY GENERATED, ANY ALTERATIONS MADE TO THE CONTENT OF THIS FILE MAY BE OVERRIDDEN AT ANY TIME
* DO NOT RELY ON MANUAL CHANGES
*/
""");
        _writer.WriteLine();
    }

    private void DeclareUsings()
    {
        _writer.WriteLine("using System;");
        _writer.WriteLine("using System.Collections.Generic;");
        _writer.WriteLine();
    }
    
    private void DeclareNamespace()
    {
        _writer.WriteLine("namespace SubUtilities.Generated;");
        _writer.WriteLine();
    }

    private void DeclareElementInterface()
    {
        var declaration = $$"""
public interface IMatroskaElement {
    {{PropertyDeclaration("Path", "string")}}
    {{PropertyDeclaration("Id", "long")}}
    {{PropertyDeclaration("Type", "string")}}
    {{PropertyDeclaration("Length", "string")}}
    {{PropertyDeclaration("MinOccurs", "int")}}
    {{PropertyDeclaration("MaxOccurs", "int")}}
}
""";
        
        _writer.WriteLine(declaration);
        _writer.WriteLine();
    }

    private void DeclareElementRegistry()
    {
        var elements = _root.Elements;
        
        var declaration = $$"""
public class MatroskaElementRegistry {

    // register known elements
    private static readonly IDictionary<long, IMatroskaElement> _elements = new Dictionary<long, IMatroskaElement> {
        {{ String.Join(",\r\n        ", elements.Select( x => $"{{ {x.Id}, new Matroska{x.Name}() }}" )) }}
    };

    public static IMatroskaElement? FindElement(long id) => _elements.TryGetValue(id, out var element) ? element : null;

}
""";
        
        _writer.WriteLine(declaration);
        _writer.WriteLine();
    }

    private void DeclareElements()
    {
        using var elementEnumerator = _root.Elements.GetEnumerator();
        elementEnumerator.MoveNext(); // consume first element
        DeclareElement(elementEnumerator.Current);

        while (elementEnumerator.MoveNext())
        {
            _writer.WriteLine();
            DeclareElement(elementEnumerator.Current);
        }
    }

    private void DeclareElement(EBMLSchemaElement element)
    {
        DeclareDocumentation(element);

        var name = element.Name;
        var path = element.Path;
        var id = element.Id;
        var type = element.Type;
        var length = element.Length;
        var minOccurs = element.MinOccurs;
        var maxOccurs = element.MaxOccurs;

        var declaration = $$"""
public class Matroska{{name}} : IMatroskaElement {
    {{PropertyDeclaration("Path", "string", path)}}
    {{PropertyDeclaration("Id", "long", id)}}
    {{PropertyDeclaration("Type", "string", type)}}
    {{PropertyDeclaration("Length", "string", length)}}
    {{PropertyDeclaration("MinOccurs", "int", minOccurs)}}
    {{PropertyDeclaration("MaxOccurs", "int", maxOccurs)}}
}
""";
        
        _writer.WriteLine(declaration);
    }
    
    private string PropertyDeclaration(
        string name,
        string netType
    )
    {
        return $"public {netType}? {name} {{ get; }}";
    }

    private string PropertyDeclaration(
        string name,
        string netType, 
        string value
    )
    {
        if (String.IsNullOrEmpty(value)) value = "null";
        else if (netType == "string") value = $"@\"{value}\"";

        return $"public {netType}? {name} => {value};";
    }
    
    private void DeclareDocumentation(EBMLSchemaElement element)
    {
        var documentation = element.Documentation?.Value;
        
        if (documentation == null) return;

        var declaration = $"""
/// <summary>
/// { String.Join("\r\n/// ", documentation.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ) }
/// </summary>
""";
        
        _writer.WriteLine(declaration);
    }

    // TODO: Generator?
    [XmlRoot("EBMLSchema", Namespace = "urn:ietf:rfc:8794")]
    public  class EBMLSchemaRoot
    {
        [XmlAttribute("docType")]
        public string DocType { get; set; }
        
        [XmlAttribute("version")]
        public int Version { get; set; }

        [XmlAttribute("ebml")]
        public string EBML { get; set; } // nullable
        
        [XmlElement("element")]
        public List<EBMLSchemaElement> Elements { get; set; }
    }

    public  class EBMLSchemaElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }
        
        [XmlAttribute("minOccurs")]
        public string MinOccurs { get; set; } // nullable
        
        [XmlAttribute("maxOccurs")]
        public string MaxOccurs { get; set; } // nullable
        
        [XmlAttribute("range")]
        public string Range { get; set; }
        
        [XmlAttribute("length")]
        public string Length { get; set; }
        
        [XmlAttribute("default")]
        public string Default { get; set; }
        
        [XmlAttribute("type")]
        public string Type { get; set; }
        
        [XmlAttribute("unkownsizeallowed")]
        public bool UnknownSizeAllowed { get; set; }
        
        [XmlAttribute("recursive")]
        public bool Recursive { get; set; }
        
        [XmlAttribute("recurring")]
        public bool Recurring { get; set; }
        
        [XmlAttribute("minver")]
        public string MinVer { get; set; } // nullable
        
        [XmlAttribute("maxver")]
        public string MaxVer { get; set; } // nullable
        
        [XmlElement("documentation")]
        public EBMLSchemaDocumentationElement Documentation { get; set; }
        
        [XmlElement("implementation_note")]
        public EBMLSchemaImplementationNoteElement ImplementationNote { get; set; }
        
        [XmlElement("enum")]
        public EBMLSchemaEnumElement[] Enum { get; set; }
        
        [XmlElement("extension")]
        public EBMLSchemaExtensionElement Extension { get; set; }
    }

    public  class EBMLSchemaDocumentationElement
    {
        [XmlAttribute("lang")]
        public string Lang { get; set; }
        
        [XmlAttribute("purpose")]
        public string Purpose { get; set; }
        
        [XmlText]
        public string Value { get; set; }
    }

    public  class EBMLSchemaImplementationNoteElement
    {
        [XmlAttribute("note_attribute")]
        public string Note { get; set; }
    }

    public  class EBMLSchemaEnumElement
    {
        [XmlAttribute("label")]
        public string Label { get; set; }
        
        [XmlAttribute("value")]
        public string Value { get; set; }
    }

    public class EBMLSchemaExtensionElement
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}