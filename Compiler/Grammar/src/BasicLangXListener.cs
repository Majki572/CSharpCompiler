using Antlr4.Runtime.Misc;

namespace Compiler.Grammar.src;

public class BasicLangXListener : LangXBaseListener
{
    private readonly IGeneratorActions _generator = new Generator();
    private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
    private readonly Stack<Variable> _stack = new Stack<Variable>();

    public override void ExitAssignIntFloat(LangXParser.AssignIntFloatContext context)
    {
        var variable = _stack.Pop();
        _variables.Add(context.ID().GetText(), variable);
        _generator.Allocate(context.ID().GetText(), variable);
        _generator.Store(context.ID().GetText(), variable);
    }

    public override void ExitWrite(LangXParser.WriteContext context)
    {
        var variable = _stack.Pop();
        _generator.Printf(variable.Name, variable);
    }

    public override void ExitWriteVar(LangXParser.WriteVarContext context)
    {
        var id = context.ID().GetText();
        if (!_variables.ContainsKey(id))
        {
            throw new Exception("Variable not declared");
        }
        _generator.Write(id, _variables[id]);
    }

    public override void ExitW([NotNull] LangXParser.WriteContext context)
    {
        
        if (_variables.ContainsKey(variable.Name))
        {
            _generator.Load(variable);
            var id = (Generator.Reg - 1).ToString();
            _generator.Write(id, variable);
        }
        else
        {
            
        }

    }

    public override void ExitRead([NotNull] LangXParser.ReadContext context)
    {
        var id = context.ID().GetText();
        if (!_variables.ContainsKey(id))
        {
            throw new Exception("Variable not declared");
        }
        _generator.Read(id, _variables[id].Type);
    }
    
    public override void ExitExpr([NotNull] LangXParser.ExprContext context)
    {
        var id = context.ID().GetText();
        var value = _stack.Pop();

        _variables.Add(id, value);
        _generator.Allocate(id, value);
        _generator.Store(id, value);
    }

    public override void ExitInt(LangXParser.IntContext context)
    {
        _stack.Push(new Variable(context.INT().GetText(), VariableType.INT));
    }

    public override void ExitFloat(LangXParser.FloatContext context)
    {
        _stack.Push(new Variable(context.FLOAT().GetText(), VariableType.FLOAT));
    }

    public override void ExitId(LangXParser.IdContext context)
    {
        var id = context.ID().GetText();
        _stack.Push(_variables[id]);
    }

    // public override void ExitString(LangXParser.StringContext context)
    // {
    //     _stack.Push(new StringVariable(context.STRING().GetText(), context.STRING().GetText().Length));
    // }

    public override void ExitStringConst(LangXParser.StringConstContext context)
    {
        var id = context.ID().GetText();
        var value = context.STRING().GetText().Substring(1, context.STRING().GetText().Length - 2);
        _variables.Add(id, new StringVariable(id, value.Length));
        _generator.CreateConstantString(id, value);
    }

    public override void ExitAdd(LangXParser.AddContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();

        if (left.Type != right.Type)
        {
            throw new Exception("Type mismatch at add");
        }
        
        var type = left.Type;
        _generator.Add(left.Name, right.Name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public override void ExitSub(LangXParser.SubContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();

        if (left.Type != right.Type)
        {
            throw new Exception("Type mismatch at sub");
        }

        var type = left.Type;
        _generator.Sub(left.Name, right.Name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public override void ExitMul(LangXParser.MulContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();

        if (left.Type != right.Type)
        {
            throw new Exception("Type mismatch at mul");
        }

        var type = left.Type;
        _generator.Mul(left.Name, right.Name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public override void ExitDiv(LangXParser.DivContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();

        if (left.Type != right.Type)
        {
            throw new Exception("Type mismatch at div");
        }

        var type = left.Type;
        _generator.Div(left.Name, right.Name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public string GenerateCode()
    {
        return _generator.GenerateCode();
    }
}