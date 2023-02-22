using System.CodeDom.Compiler;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SubUtilities;

public class MatroskaSchemaCodeGenerator
{

    private XDocument _schema { get; init; }
    private IndentedTextWriter _writer { get; init; }
    private XmlNamespaceManager _nsManager { get; init; }

    
    // TODO: Take input stream/output stream
    public static void Run()
    {
        using var source = File.OpenRead(@"E:\src\Bogers.VideoTools\SubUtilities\TestFiles\ebml_matroska.xml");
        using var destination = File.Open(@"E:\src\Bogers.VideoTools\SubUtilities\MatroskaRegistry.Generated.cs", FileMode.Create);

        var schema = XDocument.Load(source);
        var nsManager = new XmlNamespaceManager(new NameTable());
        nsManager.AddNamespace("default", schema.Root.GetDefaultNamespace().NamespaceName);
        

        var instance = new MatroskaSchemaCodeGenerator
        {
            _schema = schema,
            _writer = new IndentedTextWriter(new StreamWriter(destination), "  "),
            _nsManager = nsManager
        };

        instance.DeclareHeader();
        instance.DeclareUsings();
        instance.DeclareNamespace();
        instance.DeclareElements();
        
        instance._writer.Flush();
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
        _writer.WriteLine();
    }
    
    private void DeclareNamespace()
    {
        _writer.WriteLine("namespace SubUtilities.Generated;");
        _writer.WriteLine();
    }

    private void DeclareElements()
    {
        using var elementEnumerator = _schema.XPathSelectElements("//default:element", _nsManager).GetEnumerator();
        elementEnumerator.MoveNext(); // consume first element
        DeclareElement(elementEnumerator.Current);

        while (elementEnumerator.MoveNext())
        {
            _writer.WriteLine();
            DeclareElement(elementEnumerator.Current);
        }
    }

    private void DeclareElement(XElement element)
    {
        DeclareDocumentation(element);

        var name = element.Attribute("name")?.Value;
        var path = element.Attribute("path")?.Value;
        var id = element.Attribute("id")?.Value;
        var type = element.Attribute("type")?.Value;
        var length = element.Attribute("length")?.Value;
        var minOccurs = element.Attribute("minOccurs")?.Value;
        var maxOccurs = element.Attribute("maxOccurs")?.Value;

        var declaration = $$"""
public class Matroska{{name}} {
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
        string netType, 
        string value
    )
    {
        if (String.IsNullOrEmpty(value)) value = "null";
        else if (netType == "string") value = $"@\"{value}\"";

        return $"public {netType}? {name} => {value};";
    }
    
    private void DeclareDocumentation(XElement element)
    {
        var documentation = element.XPathSelectElement("//default:documentation", _nsManager);
        if (documentation == null) return;
        
        _writer.WriteLine("""
/// <summary>
/// {0}
/// </summary>
""", documentation.Value);
    }
}