using Antlr4.Runtime.Misc;
using Compiler.Grammar.model;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

namespace Compiler.Grammar.src;

public class BasicLangXListener : KermitLangBaseListener
{
    private readonly Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
    private readonly Dictionary<string, string> _constants = new Dictionary<string, string>();
    private readonly Stack<Variable> _stack = new Stack<Variable>();
    public static List<string> Errors = new List<string>();

    public virtual void ExitStart([NotNull] KermitLangParser.StartContext context) { }
    public virtual void ExitBase_statement([NotNull] KermitLangParser.Base_statementContext context) { }

    public override void ExitDeclare(KermitLangParser.DeclareContext context)
    {
        try
        {
            var id = context.ID().GetText();
            var variable = _stack.Pop();
            var isValid = true;

            if (_variables.ContainsKey(id))
            {
                AddError(context.Start.Line, $"Variable {id} is already defined in this scope.");
                isValid = false;
            }

            if (context.INTEGER_NAME() != null && variable.Type != VariableType.INT)
            {
                AddError(context.Start.Line, $"Value is not an integer.");
                isValid = false;
            }

        if (context.REAL_NAME() != null && variable.Type != VariableType.DOUBLE)
        {
            AddError(context.Start.Line, $"Value is not a real.");
            isValid = false;
        }
        
        if (context.BOOL_NAME() != null && variable.Type != VariableType.BOOL)
        {
            AddError(context.Start.Line, $"Value is not a bool.");
            isValid = false;
        }

            if (context.STRING_NAME() != null &&
                (variable.Type != VariableType.STRING && variable.Type != VariableType.STRING_CONST))
            {
                AddError(context.Start.Line, $"Value is not a string.");
                isValid = false;
            }

            if (context.NUMBER_NAME() != null && variable.Type != VariableType.NUMBER)
            {
                AddError(context.Start.Line, $"Value is not a number.");
                isValid = false;
            }

            if (variable.Type == VariableType.INT && isValid)
            {
                var newVar = new Variable(id, VariableType.INT);
                _variables.Add(id, newVar);
                Generator.AllocateInteger(newVar.Id);
                Generator.AssignInteger(newVar.Id, variable.Id);
            }

        if (variable.Type == VariableType.DOUBLE && isValid)
        {
            var newVar = new Variable(id, VariableType.DOUBLE);
            _variables.Add(id, newVar);
            Generator.AllocateDouble(newVar.Id);
            Generator.AssignDouble(newVar.Id, variable.Id);
        }

            if (variable.Type == VariableType.BOOL && isValid)
            {
                var newVar = new Variable(id, VariableType.BOOL);
                _variables.Add(id, newVar);
                Generator.AllocateBool(newVar.Id);
                Generator.AssignBool(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.STRING && isValid)
            {
                if (variable is not StringVariable stringVariable)
                {
                    Console.WriteLine("error string");
                    return;
                }

                var newVar = new StringVariable(id, stringVariable.Length);
                if (_variables.ContainsKey(id))
                {
                    AddError(context.Start.Line, $"Variable already declared in this scope."); // wrocic do tego
                }

                _variables.Add(id, newVar);
                Generator.AllocateString(id);
                Generator.MallocStringSize(id, newVar.Length.ToString());

                if (variable.Type == VariableType.STRING)
                {
                    Generator.AssignString(id, variable.Id, newVar.Length);
                }
                else
                {
                    Generator.AssignStringConst(id, variable.Id, newVar.Length);
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    public override void ExitAssign(KermitLangParser.AssignContext context)
    {
        try
        {
            var id = context.ID().GetText();
            var newVariable = _stack.Pop();
            var isValid = true;

            if (!_variables.ContainsKey(id))
            {
                AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
                isValid = false;
            }

            var variable = _variables[id];
            if (variable.Type == VariableType.INT && newVariable.Type != VariableType.INT)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type INT for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.DOUBLE && newVariable.Type != VariableType.DOUBLE)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type REAL for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.BOOL && newVariable.Type != VariableType.BOOL)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type BOOL for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.STRING && newVariable.Type != VariableType.STRING)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type STRING for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.NUMBER && newVariable.Type != VariableType.NUMBER)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type NUMBER for variable {id} but found {variable.Type}");
                isValid = false;
            }
            if (variable.Type == VariableType.INT && isValid)
            {
                Generator.AssignInteger(variable.Id, newVariable.Id);
            }
            if (variable.Type == VariableType.DOUBLE && isValid)
            {
                Generator.AssignDouble(variable.Id, newVariable.Id);
            }
            if (variable.Type == VariableType.BOOL && isValid)
            {
                Generator.AssignBool(variable.Id, newVariable.Id);
            }
            if (variable.Type == VariableType.STRING && isValid)
            {
                var stringValue = newVariable.Id;
                var constantValue = stringValue.Substring(1, stringValue.Length - 2);
                var constantId = "str." + _constants.Count;

                var newVar = new StringVariable(constantId, constantValue.Length);
                _variables[id] = newVar;
                Generator.AllocateStringConst(constantId, constantValue, constantValue.Length);
                Generator.MallocStringSize(id, newVar.Length.ToString());
                Generator.AssignString(id, newVar.Id, newVar.Length);
            }

            if (!isValid)
            {
                _stack.Push(variable);
            }
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


            if (_variables.ContainsKey(variable.Id))
            {
                if (variable.Type == VariableType.INT)
                {
                    Generator.LoadInteger(variable.Id);
                }
                if (variable.Type == VariableType.DOUBLE)
                {
                    Generator.LoadDouble(variable.Id);
                }
                if (variable.Type == VariableType.BOOL)
                {
                    Generator.LoadBool(variable.Id);
                }
                if (variable.Type == VariableType.STRING)
                {
                    Generator.LoadString(variable.Id);
                }
                if (variable.Type == VariableType.NUMBER)
                {
                    // TODO Implement number loading
                    //Generator.LoadNumber(variable.Name);
                }
                variable.Id = (Generator.Reg - 1).ToString();
            }

            if (variable.Type == VariableType.INT)
            {
                Generator.PrintInteger(variable.Id);
            }
            if (variable.Type == VariableType.DOUBLE)
            {
                Generator.PrintReal(variable.Id);
            }
            if (variable.Type == VariableType.BOOL)
            {
                Generator.PrintBool(variable.Id);
            }
            if (variable.Type == VariableType.STRING)
            {
                Generator.PrintString(variable.Id);
            }
            if (variable.Type == VariableType.NUMBER)
            {
                Generator.PrintNumber(variable.Id);
            }
        } 
        catch (Exception e)
        {

        }
    }

    public override void ExitRead(KermitLangParser.ReadContext context)
    {
        var id = context.ID().GetText();
        var isValid = true;

        if (!_variables.ContainsKey(id))
        {
            AddError(context.Start.Line, $"Variable is not defined in this scope.");
            isValid = false;
        }

        var variable = _variables[id];
        if (variable.Type == VariableType.INT && isValid)
        {
            Generator.ReadInteger(variable.Id);
        }
        if (variable.Type == VariableType.DOUBLE && isValid)
        {
            Generator.ReadReal(variable.Id);
        }
        if (variable.Type == VariableType.BOOL && isValid)
        {
            Generator.ReadBool(variable.Id);
        }
        if (variable.Type == VariableType.STRING && isValid)
        {
            Generator.ReadString(variable.Id);
        }
        if (variable.Type == VariableType.NUMBER && isValid)
        {
            Generator.ReadNumber(variable.Id);
        }
    }

    public override void ExitExpression_base_add(KermitLangParser.Expression_base_addContext context)
    {
        try
        {
            var right = _stack.Pop();
            var left = _stack.Pop();
            var isValid = true;

            if (!left.Type.Equals(right.Type))
            {
                AddError(context.Start.Line, $"Type mismatch when trying to add {right} to {left}");
                isValid = false;
            }

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadInteger(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadInteger(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AddIntegers(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.INT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadDouble(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadDouble(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

            Generator.AddReals(leftId, rightId);
            _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
        }

            if (left.Type == VariableType.STRING && right.Type == VariableType.STRING && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadString(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadString(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AddStrings(leftId, left as StringVariable, rightId, right as StringVariable);
                _stack.Push(new Variable($"%{Generator.Reg - 1}", VariableType.STRING));
            }

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

    public override void ExitExpression_base_sub(KermitLangParser.Expression_base_subContext context)
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

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadInteger(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadInteger(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.SubIntegers(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.INT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadDouble(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadDouble(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.SubReals(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
            }

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
    public virtual void ExitExpression1Empty([NotNull] KermitLangParser.Expression1EmptyContext context) { }

    public override void ExitExpression_base_mul(KermitLangParser.Expression_base_mulContext context)
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

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadInteger(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadInteger(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.MulIntegers(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.INT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadDouble(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadDouble(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.MulReals(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
            }

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

    public override void ExitExpression_base_div(KermitLangParser.Expression_base_divContext context)
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

            if (left.Type == VariableType.INT && right.Type == VariableType.INT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (right.Id.Equals("0"))
                {
                    AddError(context.Start.Line, "Cannot divide by 0.");
                }

                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadInteger(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadInteger(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.DivIntegers(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.INT));
            }

            if (left.Type == VariableType.DOUBLE && right.Type == VariableType.DOUBLE && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (right.Id.Equals("0"))
                {
                    AddError(context.Start.Line, "Cannot divide by 0.");
                }

                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadDouble(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadDouble(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.DivReals(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
            }

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
    public virtual void ExitExpression2Empty([NotNull] KermitLangParser.Expression2EmptyContext context) { }

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

            if (left.Type == VariableType.BOOL && right.Type == VariableType.BOOL && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadBool(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadBool(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AndBool(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
            }
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

            if (left.Type == VariableType.BOOL && right.Type == VariableType.BOOL && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadBool(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadBool(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.OrBool(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
            }

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

            if (left.Type == VariableType.BOOL && right.Type == VariableType.BOOL && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadBool(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadBool(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.XorBool(leftId, rightId);
                _stack.Push(new Variable((Generator.Reg - 1).ToString(), VariableType.DOUBLE));
            }

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

    public virtual void ExitExpression4Empty([NotNull] KermitLangParser.Expression4EmptyContext context) { }

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
        var isValid = true;

        if (!_variables.ContainsKey(id))
        {
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
            isValid = false;
        }

        switch (_variables[id].Type)
        {
            case VariableType.INT:
                Generator.LoadInteger(id);
                break;
            case VariableType.DOUBLE:
                Generator.LoadDouble(id);
                break;
            case VariableType.BOOL:
                Generator.LoadBool(id);
                break;
            case VariableType.STRING:
                Generator.LoadString(id);
                break;
            case VariableType.NUMBER:
                // TODO Implement number loading
                //Generator.LoadNumber(id);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
    }

    public override void ExitString(KermitLangParser.StringContext context)
    {
        Console.WriteLine("ExitString - " + context.STRING().GetText());
        var value = context.STRING().GetText();
        var constantId = "str." + _constants.Count;
        var constantValue = value.Substring(1, value.Length - 2);
        if (_constants.Any(r => r.Value == value))
        {
            constantId = _constants.First(r => r.Value == value).Key;
        }
        else
        {
            Console.WriteLine("ExitString - add constant");
            _constants.Add(constantId, value);
            Generator.AllocateStringConst(constantId, constantValue, constantValue.Length);
        }
        
        _stack.Push(new StringVariable(constantId, constantValue.Length, VariableType.STRING_CONST));
        Console.WriteLine("ExitString - stack count " + _stack.Count);
    }

    public override void ExitStringId(KermitLangParser.StringIdContext context)
    {
        Console.WriteLine("ExitStringId - " + context.ID().GetText());
        var id = context.ID().GetText();
        if (!_variables.ContainsKey(id))
        {
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
        }

        if (_variables[id].Type != VariableType.STRING)
        {
            AddError(context.Start.Line, $"Variable {id} is not a string.");
        }

        Generator.LoadString(id);
        _stack.Push(new StringVariable((Generator.Reg - 1).ToString(), (_variables[id] as StringVariable).Length));
        Console.WriteLine("ExitStringId - stack count " + _stack.Count);
    }

    public override void ExitString_add(KermitLangParser.String_addContext context)
    {
        var right = _stack.Pop() as StringVariable;
        var left = _stack.Pop() as StringVariable;
        if (left.Type != right.Type)
        {
            AddError(context.Start.Line, $"Type mismatch when trying to add {right} to {left}");
        }

        if (!(left.Type != VariableType.STRING || left.Type != VariableType.STRING_CONST))
        {
            AddError(context.Start.Line, $"Only accept strings.");
            return;
        }
        
        if (!(right.Type != VariableType.STRING || right.Type != VariableType.STRING_CONST))
        {
            AddError(context.Start.Line, $"Only accept strings.");
            return;
        }
        
        var leftId = $"%{left.Id}";
        var rightId = $"%{right.Id}";
        if (_variables.ContainsKey(right.Id) && right.Type == VariableType.STRING)
        {
            Generator.LoadString(right.Id);
            rightId = $"%{Generator.Reg - 1}";
        } 
        else if (right.Type == VariableType.STRING_CONST)
        {
            rightId = Generator.GetConstString(right as StringVariable);
        }

        if (_variables.ContainsKey(left.Id) && left.Type == VariableType.STRING)
        {
            Generator.LoadString(left.Id);
            leftId = $"%{Generator.Reg - 1}";
        }
        else if (left.Type == VariableType.STRING_CONST)
        {
            leftId = Generator.GetConstString(left as StringVariable);
        }
        
        Generator.AddStrings(leftId, left, rightId, right);
        _stack.Push(new StringVariable((Generator.Reg - 1).ToString(), left.Length + right.Length + 1));
    }

    public override void ExitBool(KermitLangParser.BoolContext context)
    {
        _stack.Push(new Variable(context.BOOL().GetText(), VariableType.BOOL));
    }
    public virtual void ExitNumber([NotNull] KermitLangParser.NumberContext context)
    {
        _stack.Push(new Variable(context.NUMBER().GetText(), VariableType.DOUBLE));
    }
    public virtual void ExitExpressionInParens([NotNull] KermitLangParser.ExpressionInParensContext context) { }
    public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
    public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
    public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
    public virtual void VisitErrorNode([NotNull] IErrorNode node) { }

    private void AddError(int line, string msg)
    {
        Errors.Add($"Error in line {line}: {msg}");
    }
}