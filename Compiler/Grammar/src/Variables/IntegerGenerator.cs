namespace Compiler.Grammar.src.Variables;

public class IntegerGenerator
{
    public static string AllocateInteger(string id)
    {
        return id + " = alloca i32\n";
    }
    
    public static string AssignInteger(string id, string value)
    {
        return "store i32 " + value + ", i32* " + id + "\n";
    }
    
    public static string LoadInteger(string id)
    {
        return Generator.GetRegInc() + " = load i32, i32* " + id + "\n";
    }
    
    public static string PrintInteger(string id)
    {
        return Generator.GetRegInc() + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 " + id + ")\n";
    }
    
    public static string ReadInteger(string id)
    {
        return Generator.GetRegInc() + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* " + id + ")\n";
    }
    
    public static string AddInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = add i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string SubInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = sub i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string MulInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = mul i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string DivInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = sdiv i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string EqualInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp eq i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string NotEqualInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp ne i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessThanInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp slt i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterThanInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp sgt i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessThanOrEqualInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp sle i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterThanOrEqualInteger(string id1, string id2)
    {
        return Generator.GetRegInc() + " = icmp sge i32 " + id1 + ", " + id2 + "\n";
    }
}