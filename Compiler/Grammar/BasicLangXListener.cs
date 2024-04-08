using Antlr4.Runtime.Misc;

namespace AntlrCSharp;

public class BasicLangXListener : LangXBaseListener
{
    private readonly Generator _generator = new Generator();
    private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
    private readonly Stack<Variable> _stack = new Stack<Variable>();

    public override void ExitExpr([NotNull] LangXParser.ExprContext context)
    {
        var id = context.ID().GetText();
        var value = _stack.Pop();
        
        _variables.Add(id, value);
        _generator.Allocate(id, value);
        _generator.Store(id, value);
    }

    public override void ExitWrite([NotNull] LangXParser.WriteContext context)
    {
        var variable = _stack.Pop();
        if (_variables.ContainsKey(variable.name))
        {
            _generator.Load(variable);
            var id = (Generator.Reg - 1).ToString();
            _generator.Printf(id, variable);
        }
        else
        {
            _generator.Printf(variable.name, variable);
        }
        
    }
    
    public override void ExitRead([NotNull] LangXParser.ReadContext context)
    {
        var id = context.ID().GetText();
        if (!_variables.ContainsKey(id))
        {
            throw new Exception("Variable not declared");
        }
        _generator.Scanf(id, _variables[id].type);
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

    public override void ExitString(LangXParser.StringContext context)
    {
        _stack.Push(new Variable(context.STRING().GetText(), VariableType.STRING));
    }
    
    public override void ExitAdd(LangXParser.AddContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();
        
        if (left.type != right.type)
        {
            throw new Exception("Type mismatch at add");
        }

        var type = left.type;
        _generator.Add(left.name, right.name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public override void ExitSub(LangXParser.SubContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();
        
        if (left.type != right.type)
        {
            throw new Exception("Type mismatch at sub");
        }
        
        var type = left.type;
        _generator.Sub(left.name, right.name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }
    
    public override void ExitMul(LangXParser.MulContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();
        
        if (left.type != right.type)
        {
            throw new Exception("Type mismatch at sub");
        }
        
        var type = left.type;
        _generator.Mul(left.name, right.name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public override void ExitDiv(LangXParser.DivContext context)
    {
        var right = _stack.Pop();
        var left = _stack.Pop();
        
        if (left.type != right.type)
        {
            throw new Exception("Type mismatch at sub");
        }
        
        var type = left.type;
        _generator.Div(left.name, right.name, type);
        _stack.Push(new Variable($"%{Generator.Reg - 1}", type));
    }

    public string GenerateCode()
    {
        return _generator.GenerateCode();
    }
}