using System.Diagnostics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Compiler.Grammar;
using Compiler.Grammar.src;

namespace AntlrCSharp;

public class Program()
{
    public static void Main(string[] args)
    {
        var sep = Path.DirectorySeparatorChar;
        var path = $"..{sep}..{sep}..{sep}Grammar{sep}";
        var input = File.ReadAllText(path + "langX.test");

        AntlrInputStream inputStream = new AntlrInputStream(input);
        LangXLexer lexer = new LangXLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        LangXParser parser = new LangXParser(commonTokenStream);
        IParseTree parseTree = parser.start();

        var listener = new BasicLangXListener();
        ParseTreeWalker.Default.Walk(listener, parseTree);

        // create file from generated code
        // save the file as output.ll in Grammar directory
        var outputFile = @"C:\Users\jakub\Documents\CSharpCompiler\Compiler\Grammar\output.ll";
        File.WriteAllText(outputFile, listener.GenerateCode());
        Console.WriteLine("File generated successfully");
        
        // compile the file
        // var process = new Process();
        // process.StartInfo.FileName = @"C:\Program Files\LLVM\bin\clang++.exe";
        // process.StartInfo.Arguments = $"-o {outputFile.Replace(".ll", ".exe")} {outputFile}";
        // process.Start();
        // process.WaitForExit();
    }   
}