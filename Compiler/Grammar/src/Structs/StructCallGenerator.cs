namespace Compiler.Grammar.src.Structs;

public class StructCallGenerator
{
    public static string AllocateStruct(string id, string structId)
    {
        return "%" + id + " = alloca %struct." + structId + "*\n";
    }
    
    public static string AssignStruct(string id, string structId, string value)
    {
        return "store %struct." + structId + "* null, %struct." + structId + "** " + id + "\n";
    }
    
    public static string AllocateStructSize(string id, string size)
    {
        return "%" + Generator.Reg++ + " = call i8* @malloc(i64 " + size + ")\n";
    }
    
    public static string BitcastStruct(string id, string structId)
    {
        return "%" + Generator.Reg++ + " = bitcast i8* " + id + " to %struct." + structId + "*\n";
    }
    
    public static string StoreStruct(string id, string structId, string valueId)
    {
        return "store %struct." + structId + "* " + valueId + ", %struct." + structId + "** " + id + "\n";
    }
    
    public static string LoadStruct(string id, string structId)
    {
        return "%" + Generator.Reg++ + " = load %struct." + structId + "*, %struct." + structId + "** " + id + "\n";
    }
    
    public static string LoadStructField(string id, string structId, string fieldId, string value)
    {
        return "%" + Generator.Reg++ + " = getelementptr inbounds (%struct." + structId + ", %struct." + structId + "* " + id + ", i32 0, i32 " + fieldId + ")\n";
    }
    
    // save is method assign from variables
}