namespace Compiler.Grammar.model;

public class Variable
{
    public string Id { get; set; }
    public VariableType Type { get; set; }

    public Variable(string id, VariableType type)
    {
        this.Id = id;
        this.Type = type;
    }
}

public class StringVariable : Variable
{
    public int Length { get; set; }

    public StringVariable(string id) : base(id, VariableType.STRING)
    {
    }

    public StringVariable(string id, int length) : base(id, VariableType.STRING)
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