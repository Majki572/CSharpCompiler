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
    private VariableType currentType;
    public static List<string> Errors = new List<string>();

    public virtual void ExitStart([NotNull] KermitLangParser.StartContext context) { }
    public virtual void ExitBase_statement([NotNull] KermitLangParser.Base_statementContext context) { }
    
    public override void EnterDeclare(KermitLangParser.DeclareContext context)
    {
        if (context.SHORT_NAME() != null)
        {
            currentType = VariableType.SHORT;
        }
        if (context.INTEGER_NAME() != null)
        {
            currentType = VariableType.INT;
        }
        if (context.LONG_NAME() != null)
        {
            currentType = VariableType.LOGNLONG;
        }
        if (context.FLOAT_NAME() != null)
        {
            currentType = VariableType.FLOAT;
        }
        if (context.DOUBLE_NAME() != null)
        {
            currentType = VariableType.DOUBLE;
        }
        if (context.BOOL_NAME() != null)
        {
            currentType = VariableType.BOOL;
        }
        if (context.STRING_NAME() != null)
        {
            currentType = VariableType.STRING;
        }
        if (context.NUMBER_NAME() != null)
        {
            currentType = VariableType.NUMBER;
        }
    }

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

            if (context.SHORT_NAME() != null && variable.Type != VariableType.SHORT)
            {
                AddError(context.Start.Line, $"Value is not a short.");
                isValid = false;
            }

            if (context.INTEGER_NAME() != null && variable.Type != VariableType.INT)
            {
                AddError(context.Start.Line, $"Value is not an integer.");
                isValid = false;
            }

            if (context.LONG_NAME() != null && variable.Type != VariableType.LOGNLONG)
            {
                AddError(context.Start.Line, $"Value is not a long.");
                isValid = false;
            }

            if (context.FLOAT_NAME() != null && variable.Type != VariableType.FLOAT)
            {
                AddError(context.Start.Line, $"Value is not a float.");
                isValid = false;
            }

            if (context.DOUBLE_NAME() != null && variable.Type != VariableType.DOUBLE)
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

            if (variable.Type == VariableType.SHORT)
            {
                var newVar = new Variable(id, VariableType.SHORT);
                _variables.Add(id, newVar);
                Generator.AllocateShort(newVar.Id);
                Generator.AssignShort(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.INT)
            {
                var newVar = new Variable(id, VariableType.INT);
                _variables.Add(id, newVar);
                Generator.AllocateInteger(newVar.Id);
                Generator.AssignInteger(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.LOGNLONG)
            {
                var newVar = new Variable(id, VariableType.LOGNLONG);
                _variables.Add(id, newVar);
                Generator.AllocateLong(newVar.Id);
                Generator.AssignLong(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.FLOAT)
            {
                var newVar = new Variable(id, VariableType.FLOAT);
                _variables.Add(id, newVar);
                Generator.AllocateFloat(newVar.Id);
                Generator.AssignFloat(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.DOUBLE)
            {
                var newVar = new Variable(id, VariableType.DOUBLE);
                _variables.Add(id, newVar);
                Generator.AllocateDouble(newVar.Id);
                Generator.AssignDouble(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.BOOL)
            {
                var newVar = new Variable(id, VariableType.BOOL);
                _variables.Add(id, newVar);
                Generator.AllocateBool(newVar.Id);
                Generator.AssignBool(newVar.Id, variable.Id);
            }

            if (variable.Type == VariableType.STRING || variable.Type == VariableType.STRING_CONST)
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
            if (variable.Type == VariableType.SHORT && newVariable.Type != VariableType.SHORT)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type SHORT for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.INT && newVariable.Type != VariableType.INT)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type INT for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.LOGNLONG && newVariable.Type != VariableType.LOGNLONG)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type LONG for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (variable.Type == VariableType.FLOAT && newVariable.Type != VariableType.FLOAT)
            {
                AddError(context.Start.Line,
                    $"Expected a value of type FLOAT for variable {id} but found {variable.Type}");
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

            if (variable.Type == VariableType.STRING && (newVariable.Type != VariableType.STRING &&
                                                         newVariable.Type != VariableType.STRING_CONST))
            {
                AddError(context.Start.Line,
                    $"Expected a value of type STRING for variable {id} but found {variable.Type}");
                isValid = false;
            }

            if (newVariable.Type == VariableType.SHORT)
            {
                Generator.AssignShort(variable.Id, newVariable.Id);
            }

            if (newVariable.Type == VariableType.INT)
            {
                Generator.AssignInteger(variable.Id, newVariable.Id);
            }

            if (newVariable.Type == VariableType.LOGNLONG)
            {
                Generator.AssignLong(variable.Id, newVariable.Id);
            }

            if (newVariable.Type == VariableType.FLOAT)
            {
                Generator.AssignFloat(variable.Id, newVariable.Id);
            }

            if (newVariable.Type == VariableType.DOUBLE)
            {
                Generator.AssignDouble(variable.Id, newVariable.Id);
            }

            if (newVariable.Type == VariableType.BOOL)
            {
                Generator.AssignBool(variable.Id, newVariable.Id);
            }

            if (newVariable.Type == VariableType.STRING || newVariable.Type == VariableType.STRING_CONST)
            {
                if (newVariable is not StringVariable stringVariable)
                {
                    Console.WriteLine("error string");
                    return;
                }

                var newVar = new StringVariable(id, stringVariable.Length);
                Generator.MallocStringSize(id, newVar.Length.ToString());
                if (newVariable.Type == VariableType.STRING)
                {
                    Generator.AssignString(id, newVariable.Id, newVar.Length);
                }
                else
                {
                    Generator.AssignStringConst(id, newVariable.Id, newVar.Length);
                }
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

            if (variable.Type == VariableType.SHORT)
            {
                Generator.PrintShort(variable.Id);
            }

            if (variable.Type == VariableType.INT)
            {
                Generator.PrintInteger(variable.Id);
            }

            if (variable.Type == VariableType.LOGNLONG)
            {
                Generator.PrintLong(variable.Id);
            }

            if (variable.Type == VariableType.FLOAT)
            {
                Generator.PrintFloat(variable.Id);
            }

            if (variable.Type == VariableType.DOUBLE)
            {
                Generator.PrintDouble(variable.Id);
            }

            if (variable.Type == VariableType.BOOL)
            {
                Generator.PrintBool(variable.Id);
            }

            if (variable.Type == VariableType.STRING)
            {
                Generator.PrintString(variable.Id);
            }

            if (variable.Type == VariableType.STRING_CONST)
            {
                var stringVariable = Generator.GetConstString(variable as StringVariable);
                Generator.PrintString(stringVariable);
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
        if (variable.Type == VariableType.SHORT && isValid)
        {
            Generator.ReadShort(variable.Id);
        }
        if (variable.Type == VariableType.INT && isValid)
        {
            Generator.ReadInteger(variable.Id);
        }
        if (variable.Type == VariableType.LOGNLONG && isValid)
        {
            Generator.ReadLong(variable.Id);
        }
        if (variable.Type == VariableType.FLOAT && isValid)
        {
            Generator.ReadFloat(variable.Id);
        }
        if (variable.Type == VariableType.DOUBLE && isValid)
        {
            Generator.ReadDouble(variable.Id);
        }
        if (variable.Type == VariableType.BOOL && isValid)
        {
            Generator.ReadBool(variable.Id);
        }
        if (variable.Type == VariableType.STRING && isValid)
        {
            Generator.ReadString(variable.Id);
        }
    }

    public override void ExitExpression_base_add(KermitLangParser.Expression_base_addContext context)
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
            }

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadShort(right.Id);
                    Generator.MapShort((Generator.Reg - 1).ToString());
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadShort(left.Id);
                    Generator.MapShort((Generator.Reg - 1).ToString());
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AllocateShort(Generator.Reg.ToString());
                Generator.Reg++;
                Generator.AddShorts(leftId, rightId);
                Generator.AssignShort32($"%{Generator.Reg - 2}");
                Generator.LoadShort((Generator.Reg - 3).ToString());
                Generator.MapShort((Generator.Reg - 1).ToString());
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.SHORT));
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
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.INT));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadLong(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadLong(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AddLongs(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.LOGNLONG));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadFloat(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadFloat(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AddFloats(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.FLOAT));
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

                Generator.AddDoubles(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.DOUBLE));
            }

            if ((left.Type == VariableType.STRING || left.Type == VariableType.STRING_CONST) &&
                (right.Type == VariableType.STRING || right.Type == VariableType.STRING_CONST) && isValid)
            {
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

                var leftId = $"{left.Id}";
                var rightId = $"{right.Id}";
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

                Generator.AddStrings(leftId, left as StringVariable, rightId, right as StringVariable);
                var length = (left as StringVariable).Length + (right as StringVariable).Length + 1;
                _stack.Push(new StringVariable($"%{Generator.Reg - 1}", length));
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

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadShort(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadShort(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AllocateShort(Generator.Reg.ToString());
                Generator.Reg++;
                Generator.SubShorts(leftId, rightId);
                Generator.AssignShort32($"%{Generator.Reg - 2}");
                Generator.LoadShort((Generator.Reg - 3).ToString());
                Generator.MapShort((Generator.Reg - 1).ToString());
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.SHORT));
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
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.INT));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadLong(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadLong(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.SubLongs(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.LOGNLONG));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadFloat(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadFloat(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.SubFloats(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.FLOAT));
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

                Generator.SubDoubles(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.DOUBLE));
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

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadShort(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadShort(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AllocateShort(Generator.Reg.ToString());
                Generator.Reg++;
                Generator.MulShorts(leftId, rightId);
                Generator.AssignShort32($"%{Generator.Reg - 2}");
                Generator.LoadShort((Generator.Reg - 3).ToString());
                Generator.MapShort((Generator.Reg - 1).ToString());
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.SHORT));
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
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.INT));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadLong(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadLong(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.MulLongs(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.LOGNLONG));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadFloat(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadFloat(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.MulFloats(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.FLOAT));
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

                Generator.MulDouble(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.DOUBLE));
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

            if (left.Type == VariableType.SHORT && right.Type == VariableType.SHORT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (right.Id.Equals("0"))
                {
                    AddError(context.Start.Line, "Cannot divide by 0.");
                }

                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadShort(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadShort(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.AllocateShort(Generator.Reg.ToString());
                Generator.Reg++;
                Generator.DivShorts(leftId, rightId);
                Generator.AssignShort32($"%{Generator.Reg - 2}");
                Generator.LoadShort((Generator.Reg - 3).ToString());
                Generator.MapShort((Generator.Reg - 1).ToString());
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.SHORT));
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
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.INT));
            }

            if (left.Type == VariableType.LOGNLONG && right.Type == VariableType.LOGNLONG && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (right.Id.Equals("0"))
                {
                    AddError(context.Start.Line, "Cannot divide by 0.");
                }

                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadLong(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadLong(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.DivLongs(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.LOGNLONG));
            }

            if (left.Type == VariableType.FLOAT && right.Type == VariableType.FLOAT && isValid)
            {
                var leftId = left.Id;
                var rightId = right.Id;
                if (right.Id.Equals("0"))
                {
                    AddError(context.Start.Line, "Cannot divide by 0.");
                }

                if (_variables.ContainsKey(right.Id))
                {
                    Generator.LoadFloat(right.Id);
                    rightId = (Generator.Reg - 1).ToString();
                }

                if (_variables.ContainsKey(left.Id))
                {
                    Generator.LoadFloat(left.Id);
                    leftId = (Generator.Reg - 1).ToString();
                }

                Generator.DivFloats(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.FLOAT));
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

                Generator.DivDouble(leftId, rightId);
                _stack.Push(new Variable("%" + (Generator.Reg - 1), VariableType.DOUBLE));
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

    public override void ExitId(KermitLangParser.IdContext context)
    {
        var id = context.ID().GetText();
        var isValid = true;
        
        if (!_variables.ContainsKey(id) && id != "")
        {
            Console.WriteLine(id);
            AddError(context.Start.Line, $"Variable {id} is not declared in this scope.");
            isValid = false;
        }

        Console.WriteLine("ExitId - " + id + " " + _variables[id].Type);
        switch (_variables[id].Type)
        {
            case VariableType.SHORT:
                Generator.LoadShort(id);
                Generator.MapShort($"{Generator.Reg - 1}");
                _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
                break;
            case VariableType.INT:
                Generator.LoadInteger(id);
                _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
                break;
            case VariableType.LOGNLONG:
                Generator.LoadLong(id);
                _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
                break;
            case VariableType.FLOAT:
                Generator.LoadFloat(id);
                _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
                break;
            case VariableType.DOUBLE:
                Generator.LoadDouble(id);
                _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
                break;
            case VariableType.BOOL:
                Generator.LoadBool(id);
                _stack.Push(new Variable($"%{Generator.Reg - 1}", _variables[id].Type));
                break;
            case VariableType.STRING or VariableType.STRING_CONST:
                Generator.LoadString(id);
                _stack.Push(new StringVariable($"%{Generator.Reg - 1}", ((_variables[id] as StringVariable)!).Length));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override void ExitString(KermitLangParser.StringContext context)
    {
        var value = context.STRING().GetText();
        var constantId = "str." + _constants.Count;
        var constantValue = value.Substring(1, value.Length - 2);
        if (_constants.Any(r => r.Value == value))
        {
            constantId = _constants.First(r => r.Value == value).Key;
        }
        else
        {
            _constants.Add(constantId, value);
            Generator.AllocateStringConst(constantId, constantValue, constantValue.Length);
        }
        
        _stack.Push(new StringVariable(constantId, constantValue.Length, VariableType.STRING_CONST));
    }

    public override void ExitBool(KermitLangParser.BoolContext context)
    {
        _stack.Push(new Variable(context.BOOL().GetText(), VariableType.BOOL));
    }
    public override void ExitNumber([NotNull] KermitLangParser.NumberContext context)
    {
        _stack.Push(new Variable(context.NUMBER().GetText(), currentType));
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