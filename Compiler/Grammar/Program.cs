using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace AntlrCSharp;

public class Program()
{
    public static void Main(string[] args)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var input = File.ReadAllText(@"langX.test");
        
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