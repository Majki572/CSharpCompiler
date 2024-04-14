using Compiler.Grammar.model;

namespace Compiler.Grammar.src;

public class Generator
{
    public static string HeaderText = "";
    public static string MainText = "";
    public static int Reg = 1;
    public static int Reg2 = 2;
    public static int Buff = 0;
    public static string Buffer = "";
    public static Stack<int> BrStack = new Stack<int>();

    public static String Generate()
    {
        String text = "";
        text += "declare i32 @printf(i8*, ...)\n";
        text += "declare i32 @__isoc99_scanf(i8*, ...)\n";
        text += "declare noalias i8* @malloc(i64 noundef)\n";
        text += "declare i8* @strcpy(i8* noundef, i8* noundef)\n";
        text += "declare i8* @strcat(i8* noundef, i8* noundef)\n";

        text += "@strpd = constant [4 x i8] c\"%d\\0A\\00\"\n";
        text += "@strplld = constant [6 x i8] c\"%lld\\0A\\00\"\n";
        text += "@strpf = constant [4 x i8] c\"%f\\0A\\00\"\n";
        text += "@strplf = constant [5 x i8] c\"%lf\\0A\\00\"\n";

        text += "@strshd = constant [4 x i8] c\"%hd\\00\"\n";
        text += "@strsd = constant [3 x i8] c\"%d\\00\"\n";
        text += "@strslld = constant [5 x i8] c\"%lld\\00\"\n";
        text += "@strsf = constant [3 x i8] c\"%f\\00\"\n";
        text += "@strslf = constant [4 x i8] c\"%lf\\00\"\n";

        text += "@strss = constant [3 x i8] c\"%s\\00\"\n";
        text += "@strps = constant [4 x i8] c\"%s\\0A\\00\"\n";
        text += HeaderText;
        text += "define i32 @main() nounwind{\n";
        text += MainText;
        text += "ret i32 0 }\n";

        var errors = BasicLangXListener.Errors;
        if (errors.Any())
        {
            foreach (var error in errors)
            {
                Console.Error.WriteLine(error);
            }
            Environment.Exit(1);
        }
        return text;
    }

    // Allocate
    public static void AllocateShort(String id)
    {
        MainText += "%" + id + " = alloca i16\n";
    }

    public static void AllocateInteger(String id)
    {
        MainText += "%" + id + " = alloca i32\n";
    }

    public static void AllocateLong(String id)
    {
        MainText += "%" + id + " = alloca i64\n";
    }

    public static void AllocateFloat(String id)
    {
        MainText += "%" + id + " = alloca float\n";
    }

    public static void AllocateDouble(String id)
    {
        MainText += "%" + id + " = alloca double\n";
    }

    public static void AllocateBool(String id)
    {
        MainText += "%" + id + " = alloca i1\n";
    }

    public static void AllocateStringConst(String id, String value, int length)
    {
        HeaderText += "@" + id + " = private unnamed_addr constant [ " + (length + 1) + " x i8 ] c\"" + value +
                      "\\00\"\n";
    }

    public static void AllocateString(String id)
    {
        MainText += "%" + id + " = alloca i8*\n";
    }

    public static void MallocStringSize(String id, String length)
    {
        MainText += "%" + Reg + " = call i8* @malloc(i64 " + length + ")\n";
        Reg++;
        MainText += "store i8* %" + (Reg - 1) + ", i8** %" + id + "\n";
    }

    public static void AssignString(String id, String value, int length)
    {
        MainText += $"%{Reg} = load i8*, i8** %{id}\n";
        Reg++;
        MainText +=
            $"%{Reg} = call i8* @strcpy(i8* noundef %{Reg - 1}, i8* noundef {value})\n";
        Reg++;
    }

    public static void AssignStringConst(String id, String value, int length)
    {
        MainText += $"%{Reg} = load i8*, i8** %{id}\n";
        Reg++;
        MainText +=
            $"%{Reg} = call i8* @strcpy(i8* noundef %{Reg - 1}, i8* getelementptr inbounds ([{length + 1} x i8], [{length + 1} x i8]* @{value}, i64 0, i64 0))\n";
        Reg++;
    }

    // Assign
    public static void AssignShort(String id, String value)
    {
        MainText += "store i16 " + value + ", i16* %" + id + "\n";
    }
    public static void AssignShort32(String id)
    {
        MainText += $"%{Reg} = trunc i32 %{Reg - 1} to i16\n";
        Reg++;
        MainText += "store i16 %" + (Reg - 1) + ", i16* " + id + "\n";
    }
    public static void AssignInteger(String id, String value)
    {
        MainText += "store i32 " + value + ", i32* %" + id + "\n";
    }
    public static void AssignLong(String id, String value)
    {
        MainText += "store i64 " + value + ", i64* %" + id + "\n";
    }
    public static void AssignFloat(String id, String value)
    {
        MainText += "store float " + value + ", float* %" + id + "\n";
    }
    public static void AssignDouble(String id, String value)
    {
        MainText += "store double " + value + ", double* %" + id + "\n";
    }
    public static void AssignBool(String id, String value)
    {
        MainText += "store i1 " + value + ", i1* %" + id + "\n";
    }

    // Load
    public static void LoadShort(String id)
    {
        MainText += "%" + Reg + "= load i16, i16* %" + id + "\n";
        Reg++;
    }
    public static void MapShort(String id)
    {
        MainText += $"%{Reg} = sext i16 %{id} to i32\n";
        Reg++;
    }
    public static void LoadInteger(String id)
    {
        MainText += "%" + Reg + "= load i32, i32* %" + id + "\n";
        Reg++;
    }
    public static void LoadLong(String id)
    {
        MainText += "%" + Reg + "= load i64, i64* %" + id + "\n";
        Reg++;
    }
    public static void LoadFloat(String id)
    {
        MainText += "%" + Reg + "= load float, float* %" + id + "\n";
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
        MainText += "%" + Reg + "= load i8*, i8** %" + id + "\n";
        Reg++;
    }


    // Print
    public static void PrintShort(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 " +
                    id + ")\n";
        Reg++;
    }
    public static void PrintInteger(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 " +
                    (id) + ")\n";
        Reg++;
    }
    public static void PrintLong(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 " +
                    (id) + ")\n";
        Reg++;
    }
    public static void PrintFloat(String id)
    {
        MainText += $"%{Reg} = fpext float {id} to double\n";
        Reg++;
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %" +
                    (Reg - 1) + ")\n";
        Reg++;
    }
    public static void PrintDouble(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double " +
                    id + ")\n";
        Reg++;
    }
    public static void PrintBool(String id)
    {
        MainText += "%" + Reg + "= load i1, i1* %" + id + "\n";
        Reg++;
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpi, i1 0, i1 0), i1 %" +
                    (Reg - 1) + ")\n";
        Reg++;
    }

    public static void PrintString(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* " +
                    id + ")\n";
        Reg++;
    }

    public static void PrintNumber(String id)
    {

    }

    // Read
    public static void ReadShort(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strshd, i64 0, i64 0), i16* %" + id + ")\n";
        Reg++;
    }
    public static void ReadInteger(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %" + id + ")\n";
        Reg++;
    }
    public static void ReadLong(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* %" + id + ")\n";
        Reg++;
    }
    public static void ReadFloat(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* %" + id + ")\n";
        Reg++;
    }
    public static void ReadDouble(String id)
    {
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strslf, i64 0, i64 0), double* %" +
                    id + ")\n";
        Reg++;
    }

    public static void ReadString(String id)
    {
        MallocStringSize(id, 256.ToString());
        LoadString(id);
        MainText += "%" + Reg +
                    " = call i32 (i8*, ...) @__isoc99_scanf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %" +
                    (Reg - 1) + ")\n";
        Reg++;
    }

    public static void ReadBool(string variableId)
    {
        throw new NotImplementedException();
    }

    // Add
    public static void AddShorts(String value1, String value2)
    {
        MainText += "%" + Reg + " = add i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void AddIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = add i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void AddLongs(String value1, String value2)
    {
        MainText += "%" + Reg + " = add i64 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void AddFloats(String value1, String value2)
    {
        MainText += "%" + Reg + " = fadd float " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void AddDoubles(String value1, String value2)
    {
        MainText += "%" + Reg + " = fadd double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    public static void AddStrings(String value1, StringVariable variable1, String value2, StringVariable variable2)
    {
        AllocateString($"{Reg}");
        Reg++;
        MallocStringSize($"{Reg - 1}", (variable1.Length + variable2.Length + 1).ToString());
        MainText += "%" + Reg + " = call i8* @strcat(i8* %" + (Reg - 1) + ", i8* " + value1 + ")\n";
        Reg++;
        MainText += "%" + Reg + " = call i8* @strcat(i8* %" + (Reg - 1) + ", i8* " + value2 + ")\n";
        Reg++;
    }
    public static string GetConstString(StringVariable variable)
    {
        return $"getelementptr inbounds ([{variable.Length + 1} x i8], [{variable.Length + 1} x i8]* @{variable.Id}, i64 0, i64 0)";
    }

    // Sub
    public static void SubShorts(String value1, String value2)
    {
        MainText += "%" + Reg + " = sub i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void SubIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = sub i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void SubLongs(String value1, String value2)
    {
        MainText += "%" + Reg + " = sub i64 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void SubFloats(String value1, String value2)
    {
        MainText += "%" + Reg + " = fsub float " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void SubDoubles(String value1, String value2)
    {
        MainText += "%" + Reg + " = fsub double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // Mul
    public static void MulShorts(String value1, String value2)
    {
        MainText += "%" + Reg + " = mul i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void MulIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = mul i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void MulLongs(String value1, String value2)
    {
        MainText += "%" + Reg + " = mul i64 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void MulFloats(String value1, String value2)
    {
        MainText += "%" + Reg + " = fmul float " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void MulDouble(String value1, String value2)
    {
        MainText += "%" + Reg + " = fmul double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // Div
    public static void DivShorts(String value1, String value2)
    {
        MainText += "%" + Reg + " = sdiv i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void DivIntegers(String value1, String value2)
    {
        MainText += "%" + Reg + " = sdiv i32 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void DivLongs(String value1, String value2)
    {
        MainText += "%" + Reg + " = sdiv i64 " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void DivFloats(String value1, String value2)
    {
        MainText += "%" + Reg + " = fdiv float " + value1 + ", " + value2 + "\n";
        Reg++;
    }
    public static void DivDouble(String value1, String value2)
    {
        MainText += "%" + Reg + " = fdiv double " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // And
    public static void AndBool(String value1, String value2)
    {
        MainText += "%" + Reg + " = and i1 " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // Or
    public static void OrBool(String value1, String value2)
    {
        MainText += "%" + Reg + " = or i1 " + value1 + ", " + value2 + "\n";
        Reg++;
    }


    // Xor
    public static void XorBool(String value1, String value2)
    {
        MainText += "%" + Reg + " = xor i1 " + value1 + ", " + value2 + "\n";
        Reg++;
    }

    // If
    public static void IfStart(String conditionVariable)
    {
        MainText += "br i1" + conditionVariable + ", label %true" + Buff + ", label %false" + Buff + "\n";
        MainText += "true" + Buff + ":\n";
        var b = Buff;
        BrStack.Push(b);
        Buff++;
    }

    public static void IfEnd()
    {
        int b = BrStack.Pop();
        MainText += "br label %false" + b + "\n";
        MainText += "false" + b + ":\n";
    }

    // Function
    public static void FuncStart(string id, string parameters)
    {
        Buffer = MainText;
        Reg2 = Reg;
        MainText = "define i32 @" + id + "(" + parameters + ") nounwind {\n";
        Reg = 2;
    }

    public static void FuncEnd()
    {
        MainText += "ret i32 0\n";
        MainText += "}\n";
        HeaderText += MainText;
        MainText = Buffer;
        Reg = Reg2;
    }

    public static void FuncCall(String id, String parameters)
    {
        MainText += "%" + Reg + " = call i32 @" + id + "(" + parameters + ")\n";
        Reg++;
    }
}