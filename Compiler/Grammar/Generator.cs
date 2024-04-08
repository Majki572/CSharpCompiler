using System.Globalization;

namespace Compiler.Grammar;



class IOType
{
    public string Name { get; set; }
    public string Import { get; set; }

    public IOType(string Name, string import)
    {
        this.Name = Name;
        this.Import = import;
    }
}

class IOTypes
{
    public static readonly IOType READ_INT = new IOType("@strsi", "constant [3 x i8] c\"%d\\00\", align 1");
    public static readonly IOType READ_FLOAT = new IOType("@strsf", "constant [3 x i8] c\"%f\\00\", align 1");
    public static readonly IOType WRITE_INT = new IOType("@strpi", "constant [4 x i8] c\"%d\\0A\\00\", align 1");
    public static readonly IOType WRITE_FLOAT = new IOType("@strpf", "constant [4 x i8] c\"%f\\0A\\00\", align 1");
    public static readonly IOType WRITE_STRING = new IOType("@strps", "constant [4 x i8] c\"%s\\0A\\00\", align 1");
}

public class Generator
{
    private string _code = "";
    public static int Reg = 1;

    public void Printf(String id, Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            _code += $"%{Reg} = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* {IOTypes.WRITE_INT.Name}, i32 0, i32 0), i32 %{id})\n";
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            _code += $"%{Reg} = fpext float %{id} to double\n";
            Reg++;
            _code += $"%{Reg} = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* {IOTypes.WRITE_FLOAT.Name}, i64 0, i64 0), double %{Reg - 1})\n";
        }
        else if (variable.Type == VariableType.STRING)
        {
            var str = (StringVariable)variable;
            _code += $"%{Reg} = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([{str.Length} x i8], [{str.Length} x i8]* {IOTypes.WRITE_STRING.Name}, i64 0, i64 0), i8* %{id})";
        }
        Reg++;
    }

    public void Scanf(String id, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            _code +=
                $"%{Reg} = call i32 (i8*, ...) @__isoc99_scanf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* {IOTypes.READ_INT.Name}, i64 0, i64 0), i32* noundef %{id})\n";
            Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            _code +=
                $"%{Reg} = call i32 (i8*, ...) @__isoc99_scanf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* {IOTypes.READ_FLOAT.Name}, i64 0, i64 0), float* noundef %{id})\n";
            Reg++;
        }
        else if (Type == VariableType.STRING)
        {

        }
    }

    public void Allocate(string id, Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            _code += $"%{id} = alloca i32, align 4\n";
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            _code += $"%{id} = alloca float, align 4\n";
        }
        else if (variable.Type == VariableType.STRING)
        {
            var str = (StringVariable)variable;
            _code += $"%{id} = alloca [{str.Length + 1} x i8]\n";
        }
    }

    public void Store(string id, Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            _code += $"store i32 {variable.Name}, i32* %{id}, align 4\n";
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            _code += $"store float {variable.Name}, float* %{id}, align 4\n";
        }
        else if (variable.Type == VariableType.STRING)
        {
            _code += $"store i8* %{Reg - 1}, i8** %{id}\n";
        }
    }

    public void Load(Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            _code += $"%{Reg} = load i32, i32* {variable.Name}, align 4\n";
            Reg++;
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            _code += $"%{Reg} = load float, float* {variable.Name}, align 4\n";
            Reg++;
        }
        else if (variable.Type == VariableType.STRING)
        {
            _code += $"%{Reg} = load i8*, i8** %{variable.Name}\n";
            Reg++;
        }
    }

    public void Add(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            _code += "%" + Reg + " = add i32 " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            _code += "%" + Reg + " = fadd float " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for add operation");
        }
    }

    public void Sub(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            _code += "%" + Reg + " = sub i32 " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            _code += "%" + Reg + " = fsub float " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for sub operation");
        }
    }

    public void Mul(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            _code += "%" + Reg + " = mul i32 " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            _code += "%" + Reg + " = fmul float " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for mul operation");
        }
    }

    public void Div(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            _code += "%" + Reg + " = sdiv i32 " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            _code += "%" + Reg + " = fdiv float " + val1 + ", " + val2 + "\n";
            Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for div operation");
        }
    }

    public string GenerateCode()
    {
        String code = "";
        code +=
            "source_fileName = \"main.c\"\ntarget datalayout = \"e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128\"\ntarget triple = \"x86_64-pc-linux-gnu\"\n";
        code += "declare i32 @printf(i8*, ...)\n";
        code += "declare i32 @__isoc99_scanf(i8*, ...)\n";
        code += $"{IOTypes.READ_INT.Name} = {IOTypes.READ_INT.Import}\n";
        code += $"{IOTypes.READ_FLOAT.Name} = {IOTypes.READ_FLOAT.Import}\n";
        code += $"{IOTypes.WRITE_INT.Name} = {IOTypes.WRITE_INT.Import}\n";
        code += $"{IOTypes.WRITE_FLOAT.Name} = {IOTypes.WRITE_FLOAT.Import}\n";
        code += "define dso_local i32 @main() #0 {\n";
        code += _code;
        code += "ret i32 0\n}\n";
        return code;
    }

    private string FloatToHex(string valueStr)
    {
        float value = float.Parse(valueStr, CultureInfo.InvariantCulture);
        long bits = BitConverter.DoubleToInt64Bits(value);
        string hexValue = bits.ToString("X16");
        return $"0x{hexValue}";
    }
}