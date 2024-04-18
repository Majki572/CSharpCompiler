namespace Compiler.Grammar.model;

public class Struct
{
    public string Name { get; }
    public List<Variable> Fields { get; } = new List<Variable>();

    public Struct(string name)
    {
        Name = name;
    }
    
    public int CountSize()
    {
        int size = 0;
        foreach (var field in Fields)
        { 
            size += Util.Util.MapTypeSize(field);
        }
        return size;
    }
}

public class StructVariable : Variable
{
    public Struct Struct { get; set; }

    public StructVariable(string id, Struct structType) : base(id, VariableType.STRUCT)
    {
        Struct = structType;
    }
}