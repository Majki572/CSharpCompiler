using System.Globalization;

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
}