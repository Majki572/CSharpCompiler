using System;
using Compiler.Grammar.model;

public static class OperationManager
{
    public static string EqualsConvertToLLVMOperation(VariableType variableType)
    {
        switch (variableType)
        {
            case VariableType.INT:
                return "icmp eq i32";
            case VariableType.SHORT:
                return "icmp eq i16";
            case VariableType.LOGNLONG:
                return "icmp eq i64";
            case VariableType.FLOAT:
                return "fcmp oeq float";
            case VariableType.DOUBLE:
                return "fcmp oeq double";
            case VariableType.BOOL:
                return "icmp eq i1";
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }

    public static string NotEqualConvertToLLVMOperation(VariableType variableType)
    {
        switch (variableType)
        {
            case VariableType.INT:
                return "icmp ne i32";
            case VariableType.SHORT:
                return "icmp ne i16";
            case VariableType.LOGNLONG:
                return "icmp ne i64";
            case VariableType.FLOAT:
                return "fcmp une float";
            case VariableType.DOUBLE:
                return "fcmp une double";
            case VariableType.BOOL:
                return "icmp ne i1";
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }

    public static string LessThanConvertToLLVMOperation(VariableType variableType)
    {
        switch (variableType)
        {
            case VariableType.INT:
                return "icmp slt i32";
            case VariableType.SHORT:
                return "icmp slt i16";
            case VariableType.LOGNLONG:
                return "icmp slt i64";
            case VariableType.FLOAT:
                return "fcmp olt float";
            case VariableType.DOUBLE:
                return "fcmp olt double";
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }

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
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }

    public static string LessOrEqualConvertToLLVMOperation(VariableType variableType)
    {
        switch (variableType)
        {
            case VariableType.INT:
                return "icmp sle i32";
            case VariableType.SHORT:
                return "icmp sle i16";
            case VariableType.LOGNLONG:
                return "icmp sle i64";
            case VariableType.FLOAT:
                return "fcmp ole float";
            case VariableType.DOUBLE:
                return "fcmp ole double";
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }

    public static string GreaterOrEqualConvertToLLVMOperation(VariableType variableType)
    {
        switch (variableType)
        {
            case VariableType.INT:
                return "icmp sge i32";
            case VariableType.SHORT:
                return "icmp sge i16";
            case VariableType.LOGNLONG:
                return "icmp sge i64";
            case VariableType.FLOAT:
                return "fcmp oge float";
            case VariableType.DOUBLE:
                return "fcmp oge double";
            default:
                throw new ArgumentException("Invalid variable type.");
        }
    }
}