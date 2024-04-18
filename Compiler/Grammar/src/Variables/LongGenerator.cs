namespace Compiler.Grammar.src.Variables;

public class LongGenerator
{
    public static string AllocateLong(string id)
    {
        return id + " = alloca i64\n";
    }
    
    public static string AssignLong(string id, string value)
    {
        return "store i64 " + value + ", i64* " + id + "\n";
    }
    
    public static string LoadLong(string id)
    {
        return "%" + Generator.Reg++ + " = load i64, i64* " + id + "\n";
    }
    
    public static string PrintLong(string id)
    {
        return "%" + Generator.Reg++ + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 " + id + ")\n";
    }
    
    public static string ReadLong(string id)
    {
        return "%" + Generator.Reg++ + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* " + id + ")\n";
    }
    
    public static string AddLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = add i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string SubLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = sub i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string MulLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = mul i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string DivLong(string id1, string id2) 
    {
        return "%" + Generator.Reg++ + " = sdiv i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string EqualLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp eq i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string NotEqualLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp ne i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessThanLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp slt i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterThanLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp sgt i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string LessThanOrEqualLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp sle i64 " + id1 + ", " + id2 + "\n";
    }
    
    public static string GreaterThanOrEqualLong(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = icmp sge i64 " + id1 + ", " + id2 + "\n";
    }
}