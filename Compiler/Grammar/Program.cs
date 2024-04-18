using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Compiler.Grammar.src;

namespace Compiler.Grammar;

public class Program()
{
    public static void Main(string[] args)
    {
        var sep = Path.DirectorySeparatorChar;
        var path = $"..{sep}..{sep}..{sep}Grammar{sep}";
        var input = File.ReadAllText(path + "test/langX-big.test");

        var inputStream = new AntlrInputStream(input);
        var lexer = new KermitLangLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new KermitLangParser(commonTokenStream);
        var parseTree = parser.start();

        var listener = new BasicLangXListener();
        ParseTreeWalker.Default.Walk(listener, parseTree);

        // create file from generated code
        // save the file as output.ll in Grammar directory
        var outputFile = path + "target/output.ll"; //@"C:\Users\jakub\Documents\CSharpCompiler\Compiler\Grammar\output.ll";
        Console.WriteLine(Generator.Generate());
        File.WriteAllText(outputFile, Generator.Generate());
        Console.WriteLine("File generated successfully");

        // compile the file
        // var process = new System.Diagnostics.Process();
        // process.StartInfo.FileName = @"C:\Program Files\LLVM\bin\clang++.exe";
        // process.StartInfo.Arguments = $"-o {outputFile.Replace(".ll", ".exe")} {outputFile}";
        // process.Start();
        // process.WaitForExit();
    }
}