namespace Compiler.Grammar.src.Variables;

public class ShortGenerator
{
    public static string AllocateShort(string id)
    {
        return id + " = alloca i16\n";
    }
    
    public static string AssignShort(string id, string value)
    {
        return "store i16 " + value + ", i16* " + id + "\n";
    }
    
    public static string LoadShort(string id)
    {
        return "%" + Generator.Reg++ + " = load i16, i16* " + id + "\n";
    }
    
    public static string MapShort(string id)
    {
        return "%" + Generator.Reg++ + " = sext i16 " + id + " to i32\n";
    }
    
    public static string PrintShort(string id)
    {
        return "%" + Generator.Reg++ + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 " + id + ")\n";
    }
    
    public static string ReadShort(string id)
    {
        return "%" + Generator.Reg++ + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i16* " + id + ")\n";
    }
    
    public static string AddShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = add i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string SubShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = sub i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string MulShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = mul i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string DivShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = sdiv i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string EqualShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp eq i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string NotEqualShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp ne i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessThanShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp slt i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterThanShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp sgt i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessThanOrEqualShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp sle i32 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterThanOrEqualShort(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp sge i32 " + id1 + ", " + id2 + "\n";
    }
}