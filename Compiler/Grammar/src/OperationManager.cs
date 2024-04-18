using System;
using Compiler.Grammar.model;

public static class OperationManager
{
    public static string GreaterThanConvertToLLVMOperation(VariableType variableType)
    {
        switch (variableType)
        {
            case VariableType.INT:
                return "icmp sgt i32";
            case VariableType.SHORT:
                return "icmp sgt i16";
            case VariableType.LOGNLONG:
                return "icmp sgt i64";
            case VariableType.FLOAT:
                return "fcmp ogt float";
            case VariableType.DOUBLE:
                return "fcmp ogt double";
            case VariableType.BOOL:
                return "icmp sgt i1";
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }
}