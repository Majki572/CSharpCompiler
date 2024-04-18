using System.Globalization;
using Antlr4.Runtime.Misc;
using Compiler.Grammar.model;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

namespace Compiler.Grammar.src;

public class BasicLangXListener : KermitLangBaseListener
{
    private readonly ScopedVariables _scopedVariables = new ScopedVariables();
    
    private readonly Dictionary<string, Method> _methods = new Dictionary<string, Method>();
    private Method _currentMethod;
    
    private readonly Dictionary<string, Struct> _structs = new Dictionary<string, Struct>();
    private Struct _currentStruct;
    
    private readonly Dictionary<string, string> _constants = new Dictionary<string, string>();
    private readonly Stack<Variable> _stack = new Stack<Variable>();
    private VariableType _currentType;
    public static List<string> Errors = new List<string>();

    public virtual void EnterStart([NotNull] KermitLangParser.StartContext context)
    {
        _scopedVariables.EnterScope();
    }

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
            var variable = CreateEmptyVariable(_currentType);
            if (_stack.Count != 0)
            {
                variable = _stack.Pop();    
            }
            var isValid = true;

            if (_scopedVariables.LookupVariable(id) != null)
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

            _scopedVariables.DeclareVariable(id, newVar);
            Generator.Declare(newVar, variable);
        }
        catch (Exception e)
        {

        }
    }

    public override void EnterAssign(KermitLangParser.AssignContext context)
    {
        var id = MakeId(context.ID().GetText());
        var variable = _scopedVariables.LookupVariable(id);
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
            var variable = _scopedVariables.LookupVariable(id);
            var newVariable = _stack.Pop();
            var isValid = true;

            if (_scopedVariables.LookupVariable(id) == null)
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

        if (_scopedVariables.LookupVariable(id) == null)
        {
            AddError(context.Start.Line, $"Variable is not defined in this scope.");
            isValid = false;
        }

        var variable = _scopedVariables.LookupVariable(id);

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
        _scopedVariables.EnterScope();
    }

    public override void ExitIfStatement([NotNull] KermitLangParser.IfStatementContext context)
    {
        _scopedVariables.ExitScope();
    }

    public override void EnterIfStatementBlock([NotNull] KermitLangParser.IfStatementBlockContext context)
    {
        Generator.IfStart();
    }
    public override void ExitIfStatementBlock([NotNull] KermitLangParser.IfStatementBlockContext context)
    {
        Generator.IfEnd();
    }
    public override void EnterWhileStatement([NotNull] KermitLangParser.WhileStatementContext context)
    {
        _scopedVariables.EnterScope();
        Generator.WhileStart();
    }

    public override void ExitWhileStatement([NotNull] KermitLangParser.WhileStatementContext context)
    {
        _scopedVariables.ExitScope();
    }
    public override void ExitWhileCondition([NotNull] KermitLangParser.WhileConditionContext context)
    {
        Generator.WhileConditionEnd();
    }

    public override void EnterWhileStatementBlock([NotNull] KermitLangParser.WhileStatementBlockContext context)
    {

    }
    public override void ExitWhileStatementBlock([NotNull] KermitLangParser.WhileStatementBlockContext context)
    {
        Generator.WhileEnd();
    }

    public override void ExitEqual([NotNull] KermitLangParser.EqualContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to compare {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                Generator.Equal(OperationManager.EqualsConvertToLLVMOperation(VariableType.SHORT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.SHORT));
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                Generator.Equal(OperationManager.EqualsConvertToLLVMOperation(VariableType.INT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.INT));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                Generator.Equal(OperationManager.EqualsConvertToLLVMOperation(VariableType.FLOAT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.FLOAT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                Generator.Equal(OperationManager.EqualsConvertToLLVMOperation(VariableType.DOUBLE));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.DOUBLE));
            }

            if (left.Type == VariableType.BOOL && right.Type == VariableType.BOOL && isValid)
            {
                Generator.Equal(OperationManager.EqualsConvertToLLVMOperation(VariableType.BOOL));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.BOOL));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                Generator.Equal(OperationManager.EqualsConvertToLLVMOperation(VariableType.LOGNLONG));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.LOGNLONG));
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void ExitNotEqual([NotNull] KermitLangParser.NotEqualContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to compare {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                Generator.NotEqual(OperationManager.NotEqualConvertToLLVMOperation(VariableType.SHORT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.SHORT));
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                Generator.NotEqual(OperationManager.NotEqualConvertToLLVMOperation(VariableType.INT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.INT));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                Generator.NotEqual(OperationManager.NotEqualConvertToLLVMOperation(VariableType.FLOAT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.FLOAT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                Generator.NotEqual(OperationManager.NotEqualConvertToLLVMOperation(VariableType.DOUBLE));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.DOUBLE));
            }

            if (left.Type == VariableType.BOOL && right.Type == VariableType.BOOL && isValid)
            {
                Generator.NotEqual(OperationManager.NotEqualConvertToLLVMOperation(VariableType.BOOL));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.BOOL));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                Generator.NotEqual(OperationManager.NotEqualConvertToLLVMOperation(VariableType.LOGNLONG));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.LOGNLONG));
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitLessThan([NotNull] KermitLangParser.LessThanContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to compare {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                Generator.LessThan(OperationManager.LessThanConvertToLLVMOperation(VariableType.SHORT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.SHORT));
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                Generator.LessThan(OperationManager.LessThanConvertToLLVMOperation(VariableType.INT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.INT));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                Generator.LessThan(OperationManager.LessThanConvertToLLVMOperation(VariableType.FLOAT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.FLOAT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                Generator.LessThan(OperationManager.LessThanConvertToLLVMOperation(VariableType.DOUBLE));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.DOUBLE));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                Generator.LessThan(OperationManager.LessThanConvertToLLVMOperation(VariableType.LOGNLONG));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.LOGNLONG));
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitGreaterThan([NotNull] KermitLangParser.GreaterThanContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to compare {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                Generator.GreaterThan(OperationManager.GreaterThanConvertToLLVMOperation(VariableType.SHORT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.SHORT));
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                Generator.GreaterThan(OperationManager.GreaterThanConvertToLLVMOperation(VariableType.INT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.INT));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                Generator.GreaterThan(OperationManager.GreaterThanConvertToLLVMOperation(VariableType.FLOAT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.FLOAT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                Generator.GreaterThan(OperationManager.GreaterThanConvertToLLVMOperation(VariableType.DOUBLE));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.DOUBLE));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                Generator.GreaterThan(OperationManager.GreaterThanConvertToLLVMOperation(VariableType.LOGNLONG));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.LOGNLONG));
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitLessThanEqual([NotNull] KermitLangParser.LessThanEqualContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to compare {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                Generator.LessOrEqual(OperationManager.LessOrEqualConvertToLLVMOperation(VariableType.SHORT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.SHORT));
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                Generator.LessOrEqual(OperationManager.LessOrEqualConvertToLLVMOperation(VariableType.INT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.INT));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                Generator.LessOrEqual(OperationManager.LessOrEqualConvertToLLVMOperation(VariableType.FLOAT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.FLOAT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                Generator.LessOrEqual(OperationManager.LessOrEqualConvertToLLVMOperation(VariableType.DOUBLE));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.DOUBLE));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                Generator.LessOrEqual(OperationManager.LessOrEqualConvertToLLVMOperation(VariableType.LOGNLONG));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.LOGNLONG));
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitGreaterThanEqual([NotNull] KermitLangParser.GreaterThanEqualContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (left.Type != right.Type)
            {
                AddError(context.Start.Line, $"Type mismatch when trying to compare {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                Generator.GreaterOrEqual(OperationManager.GreaterOrEqualConvertToLLVMOperation(VariableType.SHORT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.SHORT));
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                Generator.GreaterOrEqual(OperationManager.GreaterOrEqualConvertToLLVMOperation(VariableType.INT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.INT));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                Generator.GreaterOrEqual(OperationManager.GreaterOrEqualConvertToLLVMOperation(VariableType.FLOAT));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.FLOAT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                Generator.GreaterOrEqual(OperationManager.GreaterOrEqualConvertToLLVMOperation(VariableType.DOUBLE));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.DOUBLE));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                Generator.GreaterOrEqual(OperationManager.GreaterOrEqualConvertToLLVMOperation(VariableType.LOGNLONG));
                _stack.Push(new Variable(Generator.GetReg(1), VariableType.LOGNLONG));
            }
        }
        catch (Exception e)
        {

        }
    }


    public void ExitType([NotNull] KermitLangParser.TypeContext context) { }

    public override void ExitExpressionBaseAdd(KermitLangParser.ExpressionBaseAddContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (!left.Type.Equals(right.Type) &&
                left.Type != VariableType.STRING && left.Type != VariableType.STRING_CONST)
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

        if (_scopedVariables.LookupVariable(id) == null && id != "")
        {
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
            isValid = false;
        }

        var variable = _scopedVariables.LookupVariable(id);
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
        _stack.Push(new StringVariable(constantId, constantValue.Length, VariableType.STRING_CONST));
    }

    public override void ExitBool(KermitLangParser.BoolContext context)
    {
        _stack.Push(new Variable(context.BOOL().GetText(), VariableType.BOOL));
    }
    public override void ExitNumber([NotNull] KermitLangParser.NumberContext context)
    {
        var value = context.NUMBER().GetText();
        _stack.Push(new Variable(value, _currentType));
    }
    
    public override void EnterFunctionDef([NotNull] KermitLangParser.FunctionDefContext context)
    {
        _stack.Clear();
        _scopedVariables.EnterScope();
        var type = Util.Util.MapType(context.type().GetText());
        var id = "@" + context.ID().GetText();
        _currentMethod = new Method(id, type);
        
        Generator.DeclareMethod(id, type);
    }
    
    public override void ExitFunctionReturnStatement([NotNull] KermitLangParser.FunctionReturnStatementContext context)
    {
        _currentType = _currentMethod.ReturnType;
        var value = _stack.Pop();
        Generator.Return(value.Id, _currentType);
    }
    public override void ExitFunctionDef([NotNull] KermitLangParser.FunctionDefContext context)
    {
        _methods.Add(_currentMethod.Name, _currentMethod);
        _scopedVariables.ExitScope();
        Generator.EndMethod();
    }
    public override void ExitNoParameters([NotNull] KermitLangParser.NoParametersContext context)
    {
        Generator.DeclareMethodParameters(Array.Empty<Variable>());
    }
    public override void ExitParameterList([NotNull] KermitLangParser.ParameterListContext context)
    {
        foreach (var parameter in context.parameter())
        {
            var type = Util.Util.MapType(parameter.type().GetText());
            var id = MakeId(parameter.ID().GetText());
            _currentMethod.Parameters.Add(new Variable(id, type));
            _scopedVariables.DeclareVariable(id, new Variable(id, type));
        }
        Generator.DeclareMethodParameters(_currentMethod.Parameters.ToArray());
    }

    public override void ExitFunctionInvoke([NotNull] KermitLangParser.FunctionInvokeContext context)
    {
        var fucntionId = "@" + context.ID().GetText();
        var arguments = _stack.Reverse().ToList();
        _stack.Clear();
        var method = _methods[fucntionId];
                
        Console.WriteLine(arguments.Count);
        Console.WriteLine(method.Parameters.Count);
        if (arguments.Count() != method.Parameters.Count)
        {
            AddError(context.Start.Line, $"Invalid number of arguments for function {fucntionId}");
            return;
        }
        
        Generator.FunctionCall(method, arguments.ToArray());
        Console.WriteLine(method.ReturnType);
        Console.WriteLine(method.Name);
        if (Util.Util.MapType(method.ReturnType) != "void")
            _stack.Push(new Variable(Generator.GetReg(1), method.ReturnType));
    }

    public virtual void ExitExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context) { }
    public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
    public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
    public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
    public virtual void VisitErrorNode([NotNull] IErrorNode node) { }

    #region struct

    public override void EnterStructDef(KermitLangParser.StructDefContext context)
    {
        var structName = GetStructName(context.ID().GetText());
        _currentStruct = new Struct(structName);
        Generator.DeclareStruct(_currentStruct);
    }

    public override void ExitStructMembers(KermitLangParser.StructMembersContext context)
    {
        var types = context.type();
        var ids = context.ID();
        
        for (var i = 0; i < types.Length; i++)
        {
            var type = Util.Util.MapType(types[i].GetText());
            var id = ids[i].GetText();
            _currentStruct.Fields.Add(new Variable(id, type));
        }
        
        Generator.DeclareStructField(_currentStruct, _currentStruct.Fields.ToArray());
    }
    
    public override void ExitStructDef(KermitLangParser.StructDefContext context)
    {
        _structs.Add(_currentStruct.Name, _currentStruct);
    }

    public override void ExitStructEmpty(KermitLangParser.StructEmptyContext context)
    {
        var structName = GetStructName(context.ID(0).GetText());
        var structId = MakeId(context.ID(1).GetText());
        _structs.TryGetValue(structName, out var @struct);
        if (@struct == null)
        {
            AddError(context.Start.Line, $"Struct {structName} is not defined.");
            return;
        }

        Generator.DeclareStructEmpty(structId, @struct);
        _scopedVariables.DeclareVariable(structId, new StructVariable(structId, @struct));
    }

    public override void EnterStructAssign(KermitLangParser.StructAssignContext context)
    {
        var structId = MakeId(context.ID(0).GetText());
        var structVariable = _scopedVariables.LookupVariable(structId);
        if (structVariable == null)
        {
            AddError(context.Start.Line, $"Struct {structId} is not defined.");
            return;
        }

        if (structVariable.Type != VariableType.STRUCT)
        {
            AddError(context.Start.Line, $"Variable {structId} is not a struct.");
            return;
        }
        
        _currentType = ((StructVariable) structVariable).Struct.Fields.FirstOrDefault(x => x.Id == context.ID(1).GetText())!.Type;
    }

    public override void ExitStructAssign(KermitLangParser.StructAssignContext context)
    {
        var structId = MakeId(context.ID(0).GetText());
        var fieldId = context.ID(1).GetText();
        var structVariable = _scopedVariables.LookupVariable(structId);
        if (structVariable == null)
        {
            AddError(context.Start.Line, $"Struct {structId} is not defined.");
            return;
        }

        if (structVariable.Type != VariableType.STRUCT)
        {
            AddError(context.Start.Line, $"Variable {structId} is not a struct.");
            return;
        }

        var structType = ((StructVariable) structVariable).Struct;
        var field = structType.Fields.FirstOrDefault(x => x.Id == fieldId);
        if (field == null)
        {
            AddError(context.Start.Line, $"Field {fieldId} is not defined in struct {structId}.");
            return;
        }

        var value = _stack.Pop();
        if (value.Type != field.Type)
        {
            AddError(context.Start.Line, $"Type mismatch when trying to assign {value.Type} to {field.Type}.");
            return;
        }
        
        var filedIndex = structType.Fields.IndexOf(field);
        
        Generator.AssignStructField(structType, (StructVariable) structVariable, value, filedIndex);
    }

    public override void ExitStructMember(KermitLangParser.StructMemberContext context)
    {
        var structId = MakeId(context.ID(0).GetText());
        var fieldId = context.ID(1).GetText();
        var structVariable = _scopedVariables.LookupVariable(structId);
        if (structVariable == null)
        {
            AddError(context.Start.Line, $"Struct {structId} is not defined.");
            return;
        }

        if (structVariable.Type != VariableType.STRUCT)
        {
            AddError(context.Start.Line, $"Variable {structId} is not a struct.");
            return;
        }

        var structType = ((StructVariable) structVariable).Struct;
        var field = structType.Fields.FirstOrDefault(x => x.Id == fieldId);
        if (field == null)
        {
            AddError(context.Start.Line, $"Field {fieldId} is not defined in struct {structId}.");
            return;
        }
        
        var filedIndex = structType.Fields.IndexOf(field);

        Generator.LoadStructField(structType, (StructVariable) structVariable, filedIndex);
        _stack.Push(new Variable(Generator.GetReg(1), field.Type));
    }

    #endregion

    public override void ExitBoolCompare(KermitLangParser.BoolCompareContext context)
    {
        _stack.Push(new Variable(context.BOOL().GetText(), VariableType.BOOL));
    }

    public override void ExitIdCompare(KermitLangParser.IdCompareContext context)
    {
        var id = MakeId(context.ID().GetText());
        var variable = _scopedVariables.LookupVariable(id);
        if (variable == null)
        {
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
            return;
        }

        Generator.LoadVariable(variable);
        _stack.Push(new Variable(Generator.GetReg(1), variable.Type));
    }

    private void AddError(int line, string msg)
    {
        Errors.Add($"Error in line {line}: {msg}");
    }

    private string MakeId(string id)
    {
        return "%" + id;
    }
    
    private string GetStructName(string id)
    {
        return "%struct." + id;
    }
    
    private Variable CreateEmptyVariable(VariableType type)
    {
        switch (type)
        {
            case VariableType.SHORT:
                return new Variable("0", VariableType.SHORT);
            case VariableType.INT:
                return new Variable("0", VariableType.INT);
            case VariableType.FLOAT:
                return new Variable("0.0", VariableType.FLOAT);
            case VariableType.DOUBLE:
                return new Variable("0.0", VariableType.DOUBLE);
            case VariableType.BOOL:
                return new Variable("false", VariableType.BOOL);
            case VariableType.LOGNLONG:
                return new Variable("0", VariableType.LOGNLONG);
            case VariableType.STRING or VariableType.STRING_CONST:
                return new StringVariable("@str.0", 0, VariableType.STRING);
            default:
                return new Variable("0", VariableType.INT);
        }
    }
}