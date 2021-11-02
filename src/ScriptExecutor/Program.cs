using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using PowerAssert;
using System.IO;

class Program
{
    async static Task Main(string[] args)
    {
        var originalStdOut = Console.Out;
        var capturedConsoleOutput = new StringWriter();
        Console.SetOut(capturedConsoleOutput);
        var fileStream = File.OpenRead(args[0]);

        var script = CSharpScript.Create(fileStream);
        script.Compile();
        await script.RunAsync();

        var output = capturedConsoleOutput.ToString().Trim();
        Console.SetOut(originalStdOut);

        PAssert.IsTrue(() => output == "Hello, World!");
    }
}
