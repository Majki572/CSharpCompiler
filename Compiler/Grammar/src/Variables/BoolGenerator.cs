namespace Compiler.Grammar.src.Variables;

public class BoolGenerator
{
    public static string AllocateBool(string id)
    {
        return id + " = alloca i1\n";
    }
    
    public static string AssignBool(string id, string value)
    {
        return "store ii " + value + ", ii* " + id + "\n";
    }
    
    public static string LoadBool(string id)
    {
        return Generator.GetRegInc() + " = load ii, ii* " + id + "\n";
    }
    
    public static string MapBool(string id)
    {
        return Generator.GetRegInc() + " = zext i1 " + id + " to i32\n";
    }
    
    public static string PrintBool(string id)
    {
        return Generator.GetRegInc() + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 " + id + ")\n";
    }
    
    public static string ReadBool(string id)
    {
        return Generator.GetRegInc() + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* " + id + ")\n";
    }
    
    public static string AndBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = and i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string OrBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = or i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string NotBool(string id)
    {
        return Generator.GetRegInc() + " = xor i1 " + id + ", 1\n";
    }
    
    public static string EqualBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp eq i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string NotEqualBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp ne i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp sgt i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterEqualBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp sge i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp slt i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessEqualBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp sle i1 " + id1 + ", " + id2 + "\n";
    }
    
    public static string XorBool(string id1, string id2)
    {
        return Generator.GetRegInc() + " = xor i1 " + id1 + ", " + id2 + "\n";
    }
}