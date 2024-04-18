using Compiler.Grammar.model;
using Compiler.Grammar.src.Actions;
using Compiler.Grammar.src.Actions.Expression;
using Compiler.Grammar.src.Methods;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src;

public class Generator
{
    public static bool IsMain = true;
    public static bool IsFunction = false;
    
    public static string HeaderText = "";
    public static string MainText = "";
    // public static string FunctionsText = "";
    public static int Reg = 1;
    public static int Reg2 = 2;
    public static int MethodReg = 0;
    public static int Br = 0;
    public static string Buffer = "";
    public static bool FunctionFlag = false;
    public static Stack<int> BrStack = new Stack<int>();

    public static String Generate()
    {
        String text = "";
        text += "declare i32 @printf(i8*, ...)\n";
        text += "declare i32 @__isoc99_scanf(i8*, ...)\n";
        text += "declare noalias i8* @malloc(i64)\n";
        text += "declare i8* @strcpy(i8*, i8*)\n";
        text += "declare i8* @strcat(i8*, i8*)\n";

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
        // text += "define i32 @main() nounwind{\n";
        // text += MainText;
        // text += "ret i32 0 }\n";
        text += MainText;

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

    public static void Declare(Variable variable, Variable value)
    {
        MainText += DeclareGenerator.Declare(variable, value);
    }

    public static void Assign(Variable variable, Variable newVariable)
    {
        MainText += AssignGenerator.Assign(variable, newVariable);
    }

    public static void Print(Variable variable)
    {
        MainText += PrintGenerator.Print(variable);
    }

    public static void Read(Variable variable)
    {
        MainText += ReadGenerator.Read(variable);
    }

    public static void Add(Variable variable1, Variable variable2)
    {
        MainText += AddGenerator.Add(variable1, variable2);
    }

    public static void Sub(Variable variable1, Variable variable2)
    {
        MainText += SubGenerator.Sub(variable1, variable2);
    }

    public static void Mul(Variable variable1, Variable variable2)
    {
        MainText += MulGenerator.Mul(variable1, variable2);
    }

    public static void Div(Variable variable1, Variable variable2)
    {
        MainText += DivGenerator.Div(variable1, variable2);
    }

    public static void And(Variable variable1, Variable variable2)
    {

    }

    public static void Or(Variable variable1, Variable variable2)
    {

    }

    public static void Xor(Variable variable1, Variable variable2)
    {

    }

    public static void If(Variable variable)
    {

    }

    public static void Func(Variable variable)
    {

    }

    public static void FuncCall(Variable variable)
    {

    }

    public static void LoadVariable(Variable variable)
    {
        MainText += LoadVariableGenerator.LoadVariable(variable);
    }

    public static void LoadStringVariable(string id, string value)
    {
        HeaderText += StringGenerator.AllocateConstantString(id, value);
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
    public static void IfStart()
    {
        Br++;
        MainText += "br i1 %" + (Reg - 1) + ", label %true" + Br + ", label %false" + Br + "\n";
        MainText += "true" + Br + ":\n";
        BrStack.Push(Br);
    }

    public static void IfEnd()
    {
        int b = BrStack.Pop();
        MainText += "br label %false" + b + "\n";
        MainText += "false" + b + ":\n";
    }

    // While
    public static void WhileStart()
    {
        Br++;
        MainText += "br label %whileCondition" + Br + "\n";
        MainText += "whileCondition" + Br + ":\n";
        BrStack.Push(Br);
    }

    public static void WhileConditionEnd()
    {
        int b = BrStack.Peek();
        MainText += "br i1 %" + (Reg - 1) + ", label %whileTrue" + b + ", label %whileFalse" + b + "\n";
        MainText += "whileTrue" + b + ":\n";
    }

    public static void WhileEnd()
    {
        int b = BrStack.Pop();
        MainText += "br label %whileCondition" + b + "\n";
        MainText += "whileFalse" + b + ":\n";
    }

    // Comparisions

    public static void Equal(string operation)
    {
        MainText += "%" + Reg + " = " + operation + " %" + (Reg - 2) + ", %" + (Reg - 1) + "\n";
        Reg++;
    }

    public static void NotEqual(string operation)
    {
        MainText += "%" + Reg + " = " + operation + " %" + (Reg - 2) + ", %" + (Reg - 1) + "\n";
        Reg++;
    }

    public static void LessThan(string operation)
    {
        MainText += "%" + Reg + " = " + operation + " %" + (Reg - 2) + ", %" + (Reg - 1) + "\n";
        Reg++;
    }

    public static void GreaterThan(string operation)
    {
        MainText += "%" + Reg + " = " + operation + " %" + (Reg - 2) + ", %" + (Reg - 1) + "\n";
        Reg++;
    }

    public static void LessOrEqual(string operation)
    {
        MainText += "%" + Reg + " = " + operation + " %" + (Reg - 2) + ", %" + (Reg - 1) + "\n";
        Reg++;
    }

    public static void GreaterOrEqual(string operation)
    {
        MainText += "%" + Reg + " = " + operation + " %" + (Reg - 2) + ", %" + (Reg - 1) + "\n";
        Reg++;
    }

    // Methods
    // id should be with @id
    public static string CallMethod(string id, VariableType? type, Variable[] parameters)
    {
        var call = "call " + Util.Util.MapType(type) + " " + id + "(";
        foreach (var parameter in parameters)
        {
            call += Util.Util.MapType(parameter.Type) + " %" + parameter.Id + ", ";
        }

        return call.Remove(call.Length - 2) + ")";
    }

    public static void DeclareMethod(string id, VariableType? type)
    {
        MethodReg = 0;
        IsFunction = true;
        IsMain = false;
        MainText += MethodDeclareGenerator.DeclareMethod(id, type);
    }

    public static void DeclareMethodParameters(Variable[] parameters)
    {
        MainText += MethodDeclareGenerator.ParseParameters(parameters);
        
        // this is required but I have no idea why
        MethodReg++;
    }

    public static void Return(string id, VariableType? type)
    {
        MainText += MethodDeclareGenerator.Return(id, type);
    }

    public static void EndMethod()
    {
        MainText += MethodDeclareGenerator.EndMethod();
        IsFunction = false;
        IsMain = true;
    }
    
    public static void FunctionCall(Method method, Variable[] parameters)
    {
        MainText += GetRegInc() + " = call " + Util.Util.MapType(method.ReturnType) + " " + method.Name + "(";
        foreach (var parameter in parameters)
        {
            MainText += Util.Util.MapType(parameter.Type) + " " + parameter.Id + ", ";
        }
        MainText = MainText.Remove(MainText.Length - 2) + ")\n";
        Reg++;
    }

    // Function
    // public static void FuncStart(string id, string parameters)
    // {
    //     Buffer = MainText;
    //     Reg2 = Reg;
    //     MainText = "define i32 @" + id + "(" + parameters + ") nounwind {\n";
    //     Reg = 2;
    // }

    // public static void FuncEnd()
    // {
    //     MainText += "ret i32 0\n";
    //     MainText += "}\n";
    //     HeaderText += MainText;
    //     MainText = Buffer;
    //     Reg = Reg2;
    // }

    // public static void FuncCall(String id, String parameters)
    // {
    //     MainText += "%" + Reg + " = call i32 @" + id + "(" + parameters + ")\n";
    //     Reg++;
    // }

    public static string GetId(string id)
    {
        return "%" + id;
    }

    public static string GetReg()
    {
        if (IsMain)
        {
            return "%" + Reg;
        }

        if (IsFunction)
        {
            return "%" + MethodReg;
        }

        return "";
    }
    
    public static string GetRegInc()
    {
        if (IsMain)
        {
            return "%" + Reg++;
        }

        if (IsFunction)
        {
            return "%" + MethodReg++;
        }

        return "";
    }

    public static string GetReg(int sub)
    {
        if (IsMain)
        {
            return "%" + (Reg - sub);   
        }

        if (IsFunction)
        {
            return "%" + (MethodReg - sub);
        }
        
        return "";
    }
}