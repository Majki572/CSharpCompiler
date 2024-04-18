using Antlr4.Runtime.Misc;
using Compiler.Grammar.model;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

namespace Compiler.Grammar.src;

public class BasicLangXListener : KermitLangBaseListener
{
    private readonly ScopedVariables _scopedVariables = new ScopedVariables();
    
    private readonly Dictionary<string, string> _constants = new Dictionary<string, string>();
    private readonly Stack<Variable> _stack = new Stack<Variable>();
    private VariableType _currentType;
    public static List<string> Errors = new List<string>();
    
    public virtual void ExitStart([NotNull] KermitLangParser.StartContext context) { }
    public virtual void ExitBase_statement([NotNull] KermitLangParser.Base_statementContext context) { }

    public override void EnterDeclare(KermitLangParser.DeclareContext context)
    {
        _currentType = Util.Util.MapType(context.type().GetText());
    }

    public override void ExitDeclare(KermitLangParser.DeclareContext context)
    {
        try
        {
            var id = MakeId(context.ID().GetText());
            var variable = _stack.Pop();
            var isValid = true;

            if (_scopedVariables.GetVariable(id) != null)
            {
                AddError(context.Start.Line, $"Variable {id} is already defined in this scope.");
                isValid = false;
            }

            if (_currentType == VariableType.STRING && variable.Type == VariableType.STRING_CONST)
            {
                
            } 
            else if (variable.Type != _currentType)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to assign {variable.Type} to {_currentType}");
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            Variable newVar = null;
            if (_currentType == VariableType.STRING || _currentType == VariableType.STRING_CONST)
            {
                if (variable is StringVariable strVar)
                {
                    newVar = new StringVariable(id, strVar.Length, _currentType); 
                }
            }
            else
            {
                newVar = new Variable(id, _currentType);
            }
            
            _scopedVariables.AddVariable(id, newVar);
            Generator.Declare(newVar, variable);
        }
        catch (Exception e)
        {

        }
    }

    public override void EnterAssign(KermitLangParser.AssignContext context)
    {
        var id = MakeId(context.ID().GetText());
        var variable = _scopedVariables.GetVariable(id);
        if (variable == null)
        {
            AddError(context.Start.Line, $"Variable {context.ID().GetText()} is not declared in this scope.");
            return;
        }

        _currentType = variable.Type;
    }

    public override void ExitAssign(KermitLangParser.AssignContext context)
    {
        try
        {
            var id = MakeId(context.ID().GetText());
            var variable = _scopedVariables.GetVariable(id);
            var newVariable = _stack.Pop();
            var isValid = true;
            
            if (_scopedVariables.GetVariable(id) == null)
            {
                AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
                isValid = false;
            }
            
            if (_currentType == VariableType.STRING && newVariable.Type == VariableType.STRING_CONST)
            {
                
            } 
            else if (_currentType != newVariable.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to assign {newVariable.Type} to {_currentType}");
                isValid = false;
            }
            
            if (!isValid)
            {
                return;
            }
            
            Generator.Assign(variable, newVariable);
        }
        catch (Exception e)
        {
        }

    }

    public override void ExitPrint(KermitLangParser.PrintContext context)
    {
        try
        {
            var variable = _stack.Pop();
            Generator.Print(variable);
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitRead(KermitLangParser.ReadContext context)
    {
        var id = MakeId(context.ID().GetText());
        var isValid = true;

        if (_scopedVariables.GetVariable(id) == null)
        {
            AddError(context.Start.Line, $"Variable is not defined in this scope.");
            isValid = false;
        }

        var variable = _scopedVariables.GetVariable(id);
        
        if (variable == null)
        {
            AddError(context.Start.Line, $"Cannot get variable.");
            isValid = false;
        }
        
        if (!isValid)
        {
            return;
        }

        if (variable != null) Generator.Read(variable);
    }

    public override void EnterIfStatement([NotNull] KermitLangParser.IfStatementContext context)
    {
    }

    public override void ExitIfStatement([NotNull] KermitLangParser.IfStatementContext context) { }
    void ExitWhileBlock([NotNull] KermitLangParser.WhileBlockContext context) { }
    void ExitStructDefinition([NotNull] KermitLangParser.StructDefContext context) { }
    void ExitType([NotNull] KermitLangParser.TypeContext context) { }

    public override void ExitExpressionBaseAdd(KermitLangParser.ExpressionBaseAddContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (!(left.Type.Equals(right.Type)) &&
                (left.Type != VariableType.STRING && left.Type != VariableType.STRING_CONST))
            {
                AddError(context.Start.Line, $"Type mismatch when trying to add {right} to {left}");
                isValid = false;
            }
            
            if (!isValid)
            {
                _stack.Push(left);
                _stack.Push(right);
            }
            
            Generator.Add(left, right);
            if (left.Type is VariableType.STRING or VariableType.STRING_CONST)
            {
                if (left is StringVariable strVar && right is StringVariable strVar2)
                {
                    _stack.Push(new StringVariable(Generator.GetReg(1), strVar.Length + strVar2.Length, VariableType.STRING));
                }
            }
            else
            {
                _stack.Push(new Variable(Generator.GetReg(1), left.Type));
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitExpressionBaseSub(KermitLangParser.ExpressionBaseSubContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to substract {right} from {left}");
                isValid = false;
            }
            
            if (left.Type is VariableType.STRING or VariableType.STRING_CONST)
            {
                AddError(context.Start.Line, $"Cannot substract strings.");
                isValid = false;
            }

            if (!isValid)
            {
                _stack.Push(left);
                _stack.Push(right);
            }
            
            Generator.Sub(left, right);
            _stack.Push(new Variable(Generator.GetReg(1), left.Type));
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitExpressionBaseMul(KermitLangParser.ExpressionBaseMulContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to add {right} to {left}");
                isValid = false;
            }

            if (!isValid)
            {
                _stack.Push(left);
                _stack.Push(right);
            }
            
            Generator.Mul(left, right);
            _stack.Push(new Variable(Generator.GetReg(1), left.Type));
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitExpressionBaseDiv(KermitLangParser.ExpressionBaseDivContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to add {right} to {left}");
                isValid = false;
            }
            
            if (!isValid)
            {
                _stack.Push(left);
                _stack.Push(right);
            }
            
            Generator.Div(left, right);
            _stack.Push(new Variable(Generator.GetReg(1), left.Type));
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitAnd(KermitLangParser.AndContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to and {right} with {left}");
                isValid = false;
            }

            if (left.Type != VariableType.BOOL && right.Type != VariableType.BOOL)
            {
                AddError(context.Start.Line, $"Only accept bools.");
                isValid = false;
            }

            Generator.And(left, right);
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitOr(KermitLangParser.OrContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to or {right} with {left}");
                isValid = false;
            }

            if (left.Type != VariableType.BOOL && right.Type != VariableType.BOOL)
            {
                AddError(context.Start.Line, $"Only accept bools.");
                isValid = false;
            }

            Generator.Or(left, right);

            if (!isValid)
            {
                _stack.Push(left);
                _stack.Push(right);
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitXor(KermitLangParser.XorContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to xor {right} with {left}");
                isValid = false;
            }

            if (left.Type != VariableType.BOOL && right.Type != VariableType.BOOL)
            {
                AddError(context.Start.Line, $"Only accept bools.");
                isValid = false;
            }

            Generator.Xor(left, right);

            if (!isValid)
            {
                _stack.Push(left);
                _stack.Push(right);
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitId(KermitLangParser.IdContext context)
    {
        var id = MakeId(context.ID().GetText());
        var isValid = true;
        
        if (_scopedVariables.GetVariable(id) == null && id != "")
        {
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
            isValid = false;
        }
        
        var variable = _scopedVariables.GetVariable(id);
        if (variable == null)
        {
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
            isValid = false;
        }
        
        if (!isValid)
        {
            return;
        }
        
        Generator.LoadVariable(variable);
        
        if (variable.Type.Equals(VariableType.STRING) || variable.Type.Equals(VariableType.STRING_CONST))
        {
            if (variable is StringVariable strVar)
            {
                _stack.Push(new StringVariable(Generator.GetReg(1), strVar.Length, VariableType.STRING));   
            }
        }
        else
        {
            _stack.Push(new Variable(Generator.GetReg(1), variable.Type));
        }
    }

    public override void ExitString(KermitLangParser.StringContext context)
    {
        var value = context.STRING().GetText();
        var constantId = "@str." + _constants.Count;
        var constantValue = value.Substring(1, value.Length - 2);
        
        if (_constants.Any(x => x.Value == constantValue))
        {
            constantId = _constants.First(x => x.Value == constantValue).Key;
        }
        else
        {
            Generator.LoadStringVariable(constantId, constantValue);
            _constants.Add(constantId, constantValue);
        }
        _stack.Push(new  StringVariable(constantId, constantValue.Length, VariableType.STRING_CONST));
    }

    public override void ExitBool(KermitLangParser.BoolContext context)
    {
        _stack.Push(new Variable(context.BOOL().GetText(), VariableType.BOOL));
    }
    public override void ExitNumber([NotNull] KermitLangParser.NumberContext context)
    {
        _stack.Push(new Variable(context.NUMBER().GetText(), _currentType));
    }
    void ExitIf_statement([NotNull] KermitLangParser.If_statementContext context) { }
    void ExitWhileLoop([NotNull] KermitLangParser.WhileLoopContext context) { }
    void ExitFunctionDef([NotNull] KermitLangParser.FunctionDefContext context) { }
    void ExitNoParameters([NotNull] KermitLangParser.NoParametersContext context) { }
    void ExitParameterList([NotNull] KermitLangParser.ParameterListContext context) { }
    void ExitParameterDeclare([NotNull] KermitLangParser.ParameterDeclareContext context) { }
    void ExitFunctionInvoke([NotNull] KermitLangParser.FunctionInvokeContext context) { }
    void ExitArgumentList([NotNull] KermitLangParser.ArgumentListContext context) { }
    void ExitStatement_block([NotNull] KermitLangParser.Statement_blockContext context) { }
    void ExitStructDef([NotNull] KermitLangParser.StructDefContext context) { }
    void ExitStructMembers([NotNull] KermitLangParser.StructMembersContext context) { }

    public virtual void ExitExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context) { }
    public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
    public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
    public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
    public virtual void VisitErrorNode([NotNull] IErrorNode node) { }

    private void AddError(int line, string msg)
    {
        Errors.Add($"Error in line {line}: {msg}");
    }

    private string MakeId(string id)
    {
        return "%" + id;
    }
}