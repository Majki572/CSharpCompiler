using System.Globalization;
using Compiler.Grammar.model;

namespace Compiler.Grammar.Util;

public class Util
{
    public static string FloatToHex(string valueStr)
    {
        var value = float.Parse(valueStr, CultureInfo.InvariantCulture);
        var bits = BitConverter.DoubleToInt64Bits(value);
        var hexValue = bits.ToString("X16");
        return $"0x{hexValue}";
    }

    public static string MapType(Variable variable)
    {
        return variable.Type switch
        {
            VariableType.SHORT => "i16",
            VariableType.INT => "i32",
            VariableType.LOGNLONG => "i64",
            VariableType.FLOAT => "float",
            VariableType.DOUBLE => "double",
            VariableType.BOOL => "i1",
            VariableType.STRING => "i8*",
            VariableType.STRING_CONST => "i8*",
            VariableType.STRUCT => "%struct." + variable.Id + "*",
            _ => "void"
        };
    }

    public static string MapType(VariableType? type)
    {
        return type switch
        {
            VariableType.SHORT => "i16",
            VariableType.INT => "i32",
            VariableType.LOGNLONG => "i64",
            VariableType.FLOAT => "float",
            VariableType.DOUBLE => "double",
            VariableType.BOOL => "i1",
            VariableType.STRING => "i8*",
            VariableType.STRING_CONST => "i8*",
            _ => "void"
        };
    }

    public static int MapTypeSize(Variable field)
    {
        return field.Type switch
        {
            VariableType.SHORT => 2,
            VariableType.INT => 4,
            VariableType.LOGNLONG => 8,
            VariableType.FLOAT => 4,
            VariableType.DOUBLE => 8,
            VariableType.BOOL => 1,
            VariableType.STRING => 8,
            VariableType.STRING_CONST => 8,
            VariableType.STRUCT => 8,
            _ => 0
        };
    }

    public static VariableType MapType(string type)
    {
        return type switch
        {
            "short" => VariableType.SHORT,
            "int" => VariableType.INT,
            "long" => VariableType.LOGNLONG,
            "float" => VariableType.FLOAT,
            "double" => VariableType.DOUBLE,
            "bool" => VariableType.BOOL,
            "string" => VariableType.STRING,
            _ => VariableType.STRUCT
        };
    }
}