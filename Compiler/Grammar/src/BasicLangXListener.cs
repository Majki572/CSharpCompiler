using Antlr4.Runtime.Misc;

namespace Compiler.Grammar.src;

public class BasicLangXListener : KermitLangBaseListener
{
    private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
    private readonly Stack<Variable> _stack = new Stack<Variable>();

    public override void ExitDeclare(KermitLangParser.DeclareContext context)
    {
        var id = context.ID().GetText();

        if (_variables.ContainsKey(id))
        {
            // error
        }
        
        if (context.INTEGER_NAME() != null && context.INTEGER() == null)
        {
            // error
        }
        
        if (context.REAL_NAME() != null && context.REAL() == null)
        {
            // error
        }
        
        if (context.BOOL_NAME() != null && context.BOOL() == null)
        {
            // error
        }
        
        if (context.STRING_NAME() != null && context.STRING() == null)
        {
            // error
        }
        
        if (context.NUMBER_NAME() != null && context.NUMBER() == null)
        {
            // error
        }
        
        if (context.INTEGER() != null)
        {
            var newVar = new Variable(id, VariableType.INT);
            _variables.Add(id, newVar);
            Generator.AllocateInteger(newVar.Value);
            Generator.AssignInteger(newVar.Value, context.INTEGER().GetText());
        }
        
        if (context.REAL() != null)
        {
            var newVar = new Variable(id, VariableType.REAL);
            _variables.Add(id, newVar);
            Generator.AllocateDouble(newVar.Value);
            Generator.AssignDouble(newVar.Value, context.REAL().GetText());
        }
        
        if (context.BOOL() != null)
        {
            var newVar = new Variable(id, VariableType.BOOL);
            _variables.Add(id, newVar);
            Generator.AllocateBool(newVar.Value);
            Generator.AssignBool(newVar.Value, context.BOOL().GetText());
        }
        
        if (context.STRING() != null)
        {
            var stringValue = id.Substring(1, id.Length - 2);
            var newVar = new StringVariable(stringValue, stringValue.Length);
            if (_variables.ContainsKey(stringValue))
            {
                // error
            }
            
            _variables.Add(id, newVar);
            Generator.AllocateString(newVar.Name, newVar.Length);
            Generator.AssignString(newVar.Name, context.STRING().GetText());
        }
        
        if (context.NUMBER() != null)
        {
            var newVar = new Variable(id, VariableType.NUMBER);
            _variables.Add(id, newVar);
            // TODO Implement number allocation
            //Generator.AllocateNumber(newVar.Name);
            //Generator.AssignNumber(newVar.Name, context.NUMBER().GetText());
        }
    }
    
    public override void ExitAssign(KermitLangParser.AssignContext context)
    {
        var id = context.ID(0).GetText();
        if (!_variables.ContainsKey(id))
        {
            // error
        }
        
        var variable = _variables[id];
        if (variable.Type == VariableType.INT && context.INTEGER() == null)
        {
            // error
        }
        if (variable.Type == VariableType.REAL && context.REAL() == null)
        {
            // error
        }
        if (variable.Type == VariableType.BOOL && context.BOOL() == null)
        {
            // error
        }
        if (variable.Type == VariableType.STRING && context.STRING() == null)
        {
            // error
        }
        if (variable.Type == VariableType.NUMBER && context.NUMBER() == null)
        {
            // error
        }
        if (context.ID(1) != null && !_variables.ContainsKey(context.ID(1).GetText()))
        {
            // error
        }
        if (context.ID(1) != null && _variables[context.ID(1).GetText()].Type != variable.Type)
        {
            // error
        }
        
        if (variable.Type == VariableType.INT)
        {
            Generator.AssignInteger(variable.Value, context.INTEGER().GetText());
        }
        if (variable.Type == VariableType.REAL)
        {
            Generator.AssignDouble(variable.Value, context.REAL().GetText());
        }
        if (variable.Type == VariableType.BOOL)
        {
            Generator.AssignBool(variable.Value, context.BOOL().GetText());
        }
        if (variable.Type == VariableType.STRING)
        {
            // TODO Implement string assignment
            //Generator.AssignString(variable.Name, context.STRING().GetText());
        }
        if (variable.Type == VariableType.NUMBER)
        {
            // TODO Implement number assignment
            //Generator.AssignNumber(variable.Name, context.NUMBER().GetText());
        }
    }

    public override void ExitPrint(KermitLangParser.PrintContext context)
    {
        Console.WriteLine("Print");
        var variable = _stack.Pop();
        if (variable.Type == VariableType.INT)
        {
            Generator.PrintIntegerValue(variable.Value);
        }
        if (variable.Type == VariableType.REAL)
        {
            Generator.PrintReal(variable.Value);
        }
        if (variable.Type == VariableType.BOOL)
        {
            // TODO Implement bool print
        }
        if (variable.Type == VariableType.STRING)
        {
            // TODO Implement string print
        }
        if (variable.Type == VariableType.NUMBER)
        {
            // TODO Implement number print
        }
    }
    
    public override void ExitRead(KermitLangParser.ReadContext context)
    {
        var id = context.ID().GetText();
        if (!_variables.ContainsKey(id))
        {
            // error
        }
        
        var variable = _variables[id];
        if (variable.Type == VariableType.INT)
        {
            Generator.ReadInteger(variable.Value);
        }
        if (variable.Type == VariableType.REAL)
        {
            Generator.ReadReal(variable.Value);
        }
        if (variable.Type == VariableType.BOOL)
        {
            // TODO Implement bool read
        }
        if (variable.Type == VariableType.STRING)
        {
            // TODO Implement string read
        }
        if (variable.Type == VariableType.NUMBER)
        {
            // TODO Implement number read
        }
    }

    public override void ExitExpression_base_add(KermitLangParser.Expression_base_addContext context)
    {
        base.ExitExpression_base_add(context);
    }

    public override void ExitExpression_base_sub(KermitLangParser.Expression_base_subContext context)
    {
        base.ExitExpression_base_sub(context);
    }
    
    public override void ExitExpression_base_mul(KermitLangParser.Expression_base_mulContext context)
    {
        base.ExitExpression_base_mul(context);
    }
    
    public override void ExitExpression_base_div(KermitLangParser.Expression_base_divContext context)
    {
        base.ExitExpression_base_div(context);
    }

    public override void ExitAnd(KermitLangParser.AndContext context)
    {
        base.ExitAnd(context);
    }

    public override void ExitOr(KermitLangParser.OrContext context)
    {
        base.ExitOr(context);
    }

    public override void ExitXor(KermitLangParser.XorContext context)
    {
        base.ExitXor(context);
    }

    public override void ExitNeg(KermitLangParser.NegContext context)
    {
        base.ExitNeg(context);
    }

    public override void ExitInt(KermitLangParser.IntContext context)
    {
        _stack.Push(new Variable(context.INTEGER().GetText(), VariableType.INT));
    }

    public override void ExitFloat(KermitLangParser.FloatContext context)
    {
        _stack.Push(new Variable(context.REAL().GetText(), VariableType.REAL));
    }

    public override void ExitId(KermitLangParser.IdContext context)
    {
        var id = context.ID().GetText();
        if (!_variables.ContainsKey(id))
        {
            // error
        }
        _stack.Push(_variables[id]);
    }

    public override void ExitBool(KermitLangParser.BoolContext context)
    {
        _stack.Push(new Variable(context.BOOL().GetText(), VariableType.BOOL));
    }
}