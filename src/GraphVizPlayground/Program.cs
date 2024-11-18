

using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;

var graph = new DotGraph().WithIdentifier("MyGraph");

var directedGraph = new DotGraph().WithIdentifier("MyDirectedGraph").Directed();
var myNode = new DotNode()
    .WithIdentifier("MyNode")
    .WithShape(DotNodeShape.Ellipse)
    .WithLabel("My node!")
    .WithFillColor(DotColor.Coral)
    .WithFontColor(DotColor.Black)
    .WithStyle(DotNodeStyle.Dotted)
    .WithWidth(0.5)
    .WithHeight(0.5)
    .WithPenWidth(1.5);

// Add the node to the graph
graph.Add(myNode);

// Create an edge with identifiers
var myEdge = new DotEdge().From("Node1").To("Node2");

await using var writer = new StringWriter();
var context = new CompilationContext(writer, new CompilationOptions());
await graph.CompileAsync(context);

var result = writer.GetStringBuilder().ToString();

// Save it to a file
File.WriteAllText("graph.dot", result);
