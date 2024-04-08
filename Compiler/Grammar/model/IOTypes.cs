namespace Compiler.Grammar.model;

public class IoType
{
    public string Name { get; set; }
    public string Import { get; set; }

    public IoType(string name, string import)
    {
        this.Name = name;
        this.Import = import;
    }
}

public class IoTypes
{
    public static readonly IoType READ_INT = new IoType("@strsi", "constant [3 x i8] c\"%d\\00\", align 1");
    public static readonly IoType READ_FLOAT = new IoType("@strsf", "constant [3 x i8] c\"%f\\00\", align 1");
    public static readonly IoType WRITE_INT = new IoType("@strpi", "constant [4 x i8] c\"%d\\0A\\00\", align 1");
    public static readonly IoType WRITE_FLOAT = new IoType("@strpf", "constant [4 x i8] c\"%f\\0A\\00\", align 1");
    public static readonly IoType WRITE_STRING = new IoType("@strps", "constant [4 x i8] c\"%s\\0A\\00\", align 1");
}
