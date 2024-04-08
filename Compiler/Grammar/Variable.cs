namespace AntlrCSharp;

public class Variable
{
    public string name { get; set; }
    public VariableType type { get; set; }
    
    public Variable(string name, VariableType type)
    {
        this.name = name;
        this.type = type;
    }
}

public class StringVariable : Variable
{
    public int length { get; set; }
    
    public StringVariable(string name) : base(name, VariableType.STRING)
    {
    }
    
    public StringVariable(string name, int length) : base(name, VariableType.STRING)
    {
        this.length = length;
    }
}

public enum VariableType
{
    INT,
    FLOAT,
    ID,
    STRING
}