namespace Compiler.Grammar.src.Variables;

public class FloatGenerator
{
    public static string AllocateFloat(string id)
    {
        return id + " = alloca float\n";
    }
    
    public static string AssignFloat(string id, string value)
    {
        return "store float " + value + ", float* " + id + "\n";
    }
    
    public static string LoadFloat(string id)
    {
        return "%" + Generator.Reg++ + " = load float, float* " + id + "\n";
    }
    
    public static string PrintFloat(string id)
    {
        var res = "%" + Generator.Reg++ + " = fpext float " + id + " to double\n";
        res += "%" + Generator.Reg + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %" + (Generator.Reg - 1) + ")\n";
        Generator.Reg++;
        return res;
    }
    
    public static string ReadFloat(string id)
    {
        return "%" + Generator.Reg++ + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* " + id + ")\n";
    }
    
    public static string AddFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fadd float " + id1 + ", " + id2 + "\n";
    }
    
    public static string SubFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fsub float " + id1 + ", " + id2 + "\n";
    }
    
    public static string MulFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fmul float " + id1 + ", " + id2 + "\n";
    }
    
    public static string DivFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fdiv float " + id1 + ", " + id2 + "\n";
    }
    
    public static string EqualFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fcmp oeq float " + id1 + ", " + id2 + "\n";
    }
    
    public static string NeFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fcmp one float " + id1 + ", " + id2 + "\n";
    }
    
    public static string GtFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fcmp ogt float " + id1 + ", " + id2 + "\n";
    }
    
    public static string GeFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fcmp oge float " + id1 + ", " + id2 + "\n";
    }
    
    public static string LtFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fcmp olt float " + id1 + ", " + id2 + "\n";
    }
    
    public static string LeFloat(string id1, string id2)
    {
        return "%" + Generator.Reg++ + " = fcmp ole float " + id1 + ", " + id2 + "\n";
    }
}