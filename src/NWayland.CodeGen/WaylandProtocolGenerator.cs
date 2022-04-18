using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NWayland.CodeGen
{
    public partial class WaylandProtocolGenerator
    {
        private readonly WaylandGeneratorHints _hints;
        private readonly Dictionary<string, string> _protocolFullNames = new();
        private readonly Dictionary<string, string> _protocolNamespaces = new();

        public WaylandProtocolGenerator(IEnumerable<WaylandProtocolGroup> protocolGroups, WaylandGeneratorHints hints)
        {
            _hints = hints;
            foreach(var g in protocolGroups)
            foreach (var p in g.Protocols)
            {
                _protocolNamespaces.Add(p.Name, g.Namespace + "." + Pascalize(p.Name));
                foreach (var i in p.Interfaces)
                {
                    var fullName = ProtocolNamespace(p.Name) + "." + Pascalize(i.Name);
                    if (_protocolFullNames.ContainsKey(i.Name))
                        throw new ArgumentException(
                            $"Can't add {i.Name} from {p.Name}, {i.Name} is already associated to {_protocolFullNames[i.Name]}");
                    _protocolFullNames.Add(i.Name, fullName);

                }
            }
        }

        public string Generate(WaylandProtocol protocol)
        {
            var unit = CompilationUnit();
            unit = Generate(unit, protocol);
            var cw = new AdhocWorkspace();
            var formatted = Microsoft.CodeAnalysis.Formatting.Formatter.Format(unit, cw, cw.Options
                .WithChangedOption(CSharpFormattingOptions.NewLineForMembersInObjectInit, true)
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInObjectCollectionArrayInitializers, true)
                .WithChangedOption(CSharpFormattingOptions.NewLineForMembersInAnonymousTypes, true)
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, true)
            );

            return formatted.ToFullString();
        }

        private CompilationUnitSyntax Generate(CompilationUnitSyntax code, WaylandProtocol protocol)
        {
            code = code.AddUsings(UsingDirective(IdentifierName("System")))
                .AddUsings(UsingDirective(IdentifierName("System.Collections.Generic")))
                .AddUsings(UsingDirective(IdentifierName("System.Linq")))
                .AddUsings(UsingDirective(IdentifierName("System.Text")))
                .AddUsings(UsingDirective(IdentifierName("NWayland.Protocols.Wayland")))
                .AddUsings(UsingDirective(IdentifierName("NWayland.Interop")))
                .AddUsings(UsingDirective(IdentifierName("System.Threading.Tasks")));

            var ns = NamespaceDeclaration(ProtocolNamespaceSyntax(protocol.Name));

            foreach (var @interface in protocol.Interfaces)
            {
                var cl = ClassDeclaration(Pascalize(@interface.Name))
                    .WithModifiers(new SyntaxTokenList(
                        Token(SyntaxKind.PublicKeyword),
                        Token(SyntaxKind.SealedKeyword),
                        Token(SyntaxKind.UnsafeKeyword),
                        Token(SyntaxKind.PartialKeyword)))
                    .AddBaseListTypes(
                        SimpleBaseType(ParseTypeName("NWayland.Protocols.Wayland.WlProxy")));
                cl = WithSummary(cl, @interface.Description);
                cl = WithSignature(cl, @interface);
                cl = WithRequests(cl, protocol, @interface);
                cl = WithEvents(cl, protocol, @interface);
                cl = WithEnums(cl, protocol, @interface);
                cl = WithFactory(cl, @interface)
                    .AddMembers(DeclareConstant("string", "InterfaceName", MakeLiteralExpression(@interface.Name)))
                    .AddMembers(DeclareConstant("int", "InterfaceVersion", MakeLiteralExpression(@interface.Version)));

                if (@interface.Name != "wl_display")
                {
                    var ctor = ConstructorDeclaration(cl.Identifier)
                        .AddModifiers(Token(SyntaxKind.PublicKeyword))
                        .WithParameterList(ParameterList(
                            SeparatedList(new[]
                            {
                                Parameter(Identifier("handle")).WithType(ParseTypeName("IntPtr")),
                                Parameter(Identifier("version")).WithType(ParseTypeName("int")),
                                Parameter(Identifier("display"))
                                    .WithType(ParseTypeName("NWayland.Protocols.Wayland.WlDisplay"))
                            }))).WithBody(Block())
                        .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer,
                            ArgumentList(SeparatedList(new[]
                            {
                                Argument(IdentifierName("handle")),
                                Argument(IdentifierName("version")),
                                Argument(IdentifierName("display"))
                            }))));
                    cl = cl.AddMembers(ctor);
                }

                ns = ns.AddMembers(cl);
            }

            return code.AddMembers(ns);
        }
    }
}
