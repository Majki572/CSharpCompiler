namespace Compiler.Grammar;

public class Variable
{
    public string Name { get; set; }
    public VariableType Type { get; set; }

    public Variable(string name, VariableType type)
    {
        this.Name = name;
        this.Type = type;
    }
}

public class StringVariable : Variable
{
    public int Length { get; set; }

    public StringVariable(string name) : base(name, VariableType.STRING)
    {
    }

    public StringVariable(string name, int length) : base(name, VariableType.STRING)
    {
        this.Length = length;
    }
}

public enum VariableType
{
    INT,
    FLOAT,
    ID,
    STRING
}