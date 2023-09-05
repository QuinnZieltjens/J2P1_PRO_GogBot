using System;

public static class Util
{
    public static bool BinaryFilter(int _inputValue, int _filter) => (_inputValue & _filter) != 0;

    public static int Range(int _value, int _inclMin, int _inclMax)
    {
        if (IsMin(_value, _inclMin) && IsMax(_value, _inclMax))
            return _value;

        throw new ArgumentOutOfRangeException($"value '{_value}' is out of the bounds, '{_inclMin}' to '{_inclMax}'");
    }

    public static int UpperLimit(int _value, int _inclMax)
    {
        if (IsMax(_value, _inclMax))
            return _value;

        throw new ArgumentOutOfRangeException($"value '{_value}' is out of bounds, (max = '{_inclMax}')");
    }

    public static int LowerLimit(int _value, int _inclMin)
    {
        if (IsMin(_value, _inclMin))
            return _value;
        
        throw new ArgumentOutOfRangeException($"value '{_value}' is out of bounds, (min = '{_inclMin}')");
    }


    public static bool IsMin(int _value, int _inclMin) => _value >= _inclMin;
    public static bool IsMax(int _value, int _inclMax) => _value <= _inclMax;
}
