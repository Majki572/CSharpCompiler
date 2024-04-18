namespace Compiler.Grammar.model;

public class ScopedVariables
{
    private Stack<Dictionary<string, Variable>> _scopedVariables = new Stack<Dictionary<string, Variable>>();

    public ScopedVariables()
    {
        _scopedVariables.Push(new Dictionary<string, Variable>());
    }

    public void DeclareVariable(string name, Variable variable)
    {
        if (_scopedVariables.Count == 0) { EnterScope(); }
        Dictionary<string, Variable> currentScope = _scopedVariables.Peek();
        if (currentScope.ContainsKey(name))
        {
            throw new Exception($"Variable '{name}' already declared in this scope.");
        }
        currentScope.Add(name, variable);
    }

    public Variable? LookupVariable(string name)
    {
        foreach (var scope in _scopedVariables.Reverse())
        {
            if (scope.ContainsKey(name))
            {
                return scope[name];
            }
        }
        return null;
    }

    public void EnterScope()
    {
        _scopedVariables.Push(new Dictionary<string, Variable>());
    }

    public void ExitScope()
    {
        _scopedVariables.Pop();
    }

    public void UpdateVariable(string name, Variable newValue)
    {
        foreach (var scope in _scopedVariables.Reverse())
        {
            if (scope.ContainsKey(name))
            {
                scope[name] = newValue;
                break;
            }
        }
    }

    public void Clear()
    {
        _scopedVariables.Clear();
    }

    public void Print()
    {
        foreach (var scope in _scopedVariables)
        {
            foreach (var variable in scope)
            {
                Console.WriteLine($"{variable.Key} : {variable.Value}");
            }
        }
    }

    public void PrintCurrentScope()
    {
        foreach (var variable in _scopedVariables.Peek())
        {
            Console.WriteLine($"{variable.Key} : {variable.Value}");
        }
    }
}