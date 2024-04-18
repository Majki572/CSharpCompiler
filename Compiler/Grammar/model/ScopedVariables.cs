namespace Compiler.Grammar.model;

public class ScopedVariables
{
    private readonly Stack<Dictionary<string, Variable>> _scopedVariables = new Stack<Dictionary<string, Variable>>();
    
    public ScopedVariables()
    {
        _scopedVariables.Push(new Dictionary<string, Variable>());
    }
    
    public void AddVariable(string name, Variable variable)
    {
        _scopedVariables.Peek().Add(name, variable);
    }
    
    public Variable? GetVariable(string name)
    {
        foreach (var scope in _scopedVariables)
        {
            if (scope.TryGetValue(name, out var variable))
            {
                return variable;
            }
        }
        return null;
    }
    
    public void PushScope()
    {
        _scopedVariables.Push(new Dictionary<string, Variable>());
    }
    
    public void PopScope()
    {
        _scopedVariables.Pop();
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