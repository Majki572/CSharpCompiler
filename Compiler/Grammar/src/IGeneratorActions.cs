namespace Compiler.Grammar.src;

public interface IGeneratorActions
{
    void Printf(String id, Variable variable);
    void Scanf(String id, VariableType type);
    void Allocate(string id, Variable variable);
    void Store(string id, Variable variable);
    void Load(Variable variable);
    void Add(string val1, string val2, VariableType type);
    void Sub(string val1, string val2, VariableType type);
    void Mul(string val1, string val2, VariableType type);
    void Div(string val1, string val2, VariableType type);
    
    void AllocateString(string id, int length);
    void BitCastString(string id, int length);
    void CreateConstantString(string id, string value);
    void LoadString(string id, int length);
    void PrintString(string id, int length);
    
    string GenerateCode();
}