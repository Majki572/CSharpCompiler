using Compiler.Grammar.model;

namespace Compiler.Grammar.src;

public class Generator
{
    public static string HeaderText = "";
    public static string MainText = "";
    public static int Reg = 1;

    public static String Generate()
    {
        String text = "";
        text += "declare i32 @printf(i8*, ...)\n";
        text += "declare i32 @__isoc99_scanf(i8*, ...)\n";
        text += "@strpi = constant [4 x i8] c\"%d\\0A\\00\"\n";
        text += "@strpd = constant [4 x i8] c\"%f\\0A\\00\"\n";
        text += "@strsi = constant [3 x i8] c\"%d\\00\"\n";
        text += "@strsd = constant [4 x i8] c\"%lf\\00\"\n";
        text += HeaderText;
        text += "define i32 @main() nounwind{\n";
        text += MainText;
        text += "ret i32 0 }\n";
        return text;
    }

    // Allocate
    public static void AllocateInteger(String id)
    {
        MainText += "%" + id + " = alloca i32\n";
    }

    public static void AllocateDouble(String id)
    {
        MainText += "%" + id + " = alloca double\n";
    }

    public static void AllocateBool(String id)
    {
        MainText += "%" + id + " = alloca i1\n";
    }

    public static void AllocateStringConst(String id, int length)
    {
        MainText += "%" + id + " = alloca [ " + (length + 1) + " x i8 ]\n";
        MainText += "%" + Reg + " = bitcast [ " + (length + 1) + " x i8 ]* %" + id + " to i8*\n";
        Reg++;
        HeaderText += "";
    }

    public static void AllocateString(String id, int length)
    {

    }

    // Assign
    public static void AssignInteger(String id, String value)
    {
        MainText += "store i32 " + value + ", i32* %" + id + "\n";
    }

    public static void AssignDouble(String id, String value)
    {
        MainText += "store double " + value + ", double* %" + id + "\n";
    }

    public static void AssignBool(String id, String value)
    {
        MainText += "store i1 " + value + ", i1* %" + id + "\n";
    }

    public static void AssignString(String id, String value)
    {

    }
    // Load
    public static void LoadInteger(String id)
    {
        MainText += "%" + Reg + "= load i32, i32* %" + id + "\n";
        Reg++;
    }

    public static void LoadDouble(String id)
    {
        MainText += "%" + Reg + "= load double, double* %" + id + "\n";
        Reg++;
    }

    public static void LoadBool(String id)
    {
        MainText += "%" + Reg + "= load i1, i1* %" + id + "\n";
        Reg++;
    }

    public static void LoadString(String id)
    {

    }


    // Print
    public static void PrintInteger(String id)
    {
        MainText += "%" + Reg + "= load i32, i32* %" + id + "\n";
        Reg++;
        MainText += "%" + Reg + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 %" + (Reg - 1) + ")\n";
        Reg++;
    }

    public static void PrintIntegerValue(String value)
    {
        MainText += "%" + Reg + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i32 0, i32 0), i32 " + value + ")\n";
        Reg++;
    }

    public static void PrintReal(String id)
    {
        MainText += "%" + Reg + "= load double, double* %" + id + "\n";
        Reg++;
        MainText += "%" + Reg + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i32 0, i32 0), double %" + (Reg - 1) + ")\n";
        Reg++;
    }

    public static void PrintRealValue(String value)
    {
        MainText += "%" + Reg + " = call i32 (i8*, ...) @printf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* @.str, i64 0, i64 0), double noundef " + value + ")\n";
        Reg++;
    }

    public static void PrintBool(String id)
    {
        MainText += "%" + Reg + "= load i1, i1* %" + id + "\n";
        Reg++;
        MainText += "%" + Reg + " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i1 0, i1 0), i1 %" + (Reg - 1) + ")\n";
        Reg++;
    }

    public static void PrintString(String id)
    {

    }
    public static void PrintNumber(String id)
    {

    }
    // Read
    public static void ReadInteger(String id)
    {
        MainText += "%" + Reg + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsi, i32 0, i32 0), i32* %" + id + ")\n";
        Reg++;
    }

    public static void ReadReal(String id)
    {
        MainText += "%" + Reg + " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strsd, i32 0, i32 0), double* %" + id + ")\n";
        Reg++;
    }

    public static void ReadBool(String id) { }

    public static void ReadString(String id) { }

    public static void ReadNumber(String id) { }

    // Add
    public static void AddIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = add i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    public static void AddReals(String value1, String value2)
    {
        MainText += "%" + Reg + " = fadd double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    public static void AddStrings(String value1, String value2)
    {

    }
    // Sub
    public static void SubIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = sub i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    public static void SubReals(String value1, String value2)
    {
        MainText += "%" + Reg + " = fsub double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // Mul
    public static void MulIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = mul i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    public static void MulReals(String value1, String value2)
    {
        MainText += "%" + Reg + " = fmul double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // Div
    public static void DivIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = div i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    public static void DivReals(String value1, String value2)
    {
        MainText += "%" + Reg + " = fdiv double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // And
    public static void AndBool(String value1, String value2)
    {

    }

    // Or
    public static void OrBool(String value1, String value2)
    {

    }

    // Xor
    public static void XorBool(String value1, String value2)
    {

    }
}