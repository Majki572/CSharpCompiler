namespace Compiler.Grammar.src.Structs;

public class StructCallGenerator
{
    public static string AllocateStruct(string id, string structId)
    {
        return id + " = alloca " + structId + "*\n";
    }
    
    public static string AssignStruct(string id, string structId, string value)
    {
        return "store " + structId + "* null, " + structId + "** " + id + "\n";
    }
    
    public static string AllocateStructSize(int size)
    {
        return Generator.GetRegInc() + " = call i8* @malloc(i64 " + size + ")\n";
    }
    
    public static string BitcastStruct(string id, string structId)
    {
        return Generator.GetRegInc() + " = bitcast i8* " + id + " to " + structId + "*\n";
    }
    
    public static string StoreStruct(string id, string structId, string valueId)
    {
        return "store " + structId + "* " + valueId + ", " + structId + "** " + id + "\n";
    }
    
    public static string LoadStruct(string id, string structId)
    {
        return Generator.GetRegInc() + " = load " + structId + "*, " + structId + "** " + id + "\n";
    }
    
    public static string LoadStructField(string id, string structId, string fieldId)
    {
        return Generator.GetRegInc() + " = getelementptr inbounds " + structId + ", " + structId + "* " + id + ", i32 0, i32 " + fieldId + "\n";
    }
    
    // save is method assign from variables
}