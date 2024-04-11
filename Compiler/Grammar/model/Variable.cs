namespace Compiler.Grammar;

public class Variable
{
    public string Value { get; set; }
    public VariableType Type { get; set; }

    public Variable(string value, VariableType type)
    {
        this.Value = value;
        this.Type = type;
    }
}

public class StringVariable : Variable
{
    public int Length { get; set; }

    public StringVariable(string value) : base(value, VariableType.STRING)
    {
    }

    public StringVariable(string value, int length) : base(value, VariableType.STRING)
    {
        this.Length = length;
    }
}

public enum VariableType
{
    INT,
    REAL,
    BOOL,
    STRING,
    NUMBER
}