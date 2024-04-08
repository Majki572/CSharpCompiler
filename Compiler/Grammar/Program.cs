using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler.Grammar;

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
        File.WriteAllText("output.ll", listener.GenerateCode());
    }
}