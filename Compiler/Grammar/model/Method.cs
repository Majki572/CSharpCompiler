namespace Compiler.Grammar.model;

public class Method
{
    public string Name { get; }
    public VariableType ReturnType { get; }
    public List<Variable> Parameters { get; } = new List<Variable>();

    public Method(string name, VariableType returnType)
    {
        Name = name;
        ReturnType = returnType;
    }
}