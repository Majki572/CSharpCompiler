using Compiler.Grammar.model;

namespace Compiler.Grammar.src.Variables;

public class StringGenerator
{
    // id in format of const @id
    public static string AllocateConstantString(string id, string value)
    {
        return id + " = private unnamed_addr constant [" + (value.Length + 1) + " x i8] c\"" + value + "\\00\"\n";
    }
    
    public static string AllocateString(string id)
    {
        return id + " = alloca i8*\n";
    }
    
    public static string AllocateStringSize(string id, int size)
    {
        var res = Generator.GetRegInc() + " = call i8* @malloc(i64 " + (size + 1) + ")\n";
        res += "store i8* %" + (Generator.Reg - 1) + ", i8** " + id + "\n";
        return res;
    }
    
    public static string AssignString(string id, string value)
    {
        return Generator.GetRegInc() + " = call i8* @strcpy(i8* " + id + ", i8* " + value + ")\n"; 
    }
    
    // id in format of const @id and constId in format of @const
    public static string AssignConstantString(string id, string constId, int constLength)
    {
        return Generator.GetRegInc() + " = call i8* @strcpy(i8* " + id + ", i8* getelementptr inbounds ([" + (constLength + 1) + " x i8], [" + (constLength + 1) + " x i8]* " + constId + ", i64 0, i64 0))\n";
    }
    
    public static string LoadString(string id)
    {
        return Generator.GetRegInc() + " = load i8*, i8** " + id + "\n";
    }
    
    public static string PrintString(string id)
    {
        return Generator.GetRegInc() + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* " + id + ")\n";
    }
    
    public static string ReadString(string id)
    {
        return Generator.GetRegInc() + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* " + id + ")\n";
    }
    
    // adding string id2 to id1 / id2 may be a constant string
    public static string AddString(string id1, string id2)
    {
        return Generator.GetRegInc() + " = call i8* @strcat(i8* " + id1 + ", i8* " + id2 + ")\n";
    }
    
    public static string GetConstString(StringVariable variable)
    {
        return $"getelementptr inbounds ([{variable.Length + 1} x i8], [{variable.Length + 1} x i8]* {variable.Id}, i64 0, i64 0)";
    }
    
    public static string EqualString(string id1, string id2)
    {
        return Generator.GetRegInc() + " = call i32 @strcmp(i8* " + id1 + ", i8* " + id2 + ")\n";
    }
}