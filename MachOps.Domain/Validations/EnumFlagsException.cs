namespace MachOps.Domain.Validations;

public sealed class EnumFlagsException(string message) : Exception(message)
{
    public static void ThrowIfNotFlagDefined<TEnum>(int type, string message) where TEnum : struct, Enum
    {
        var allDefinedValues = Enum.GetValues<TEnum>().Cast<int>().Aggregate((a, b) => a | b);

        if ((type & ~allDefinedValues) != 0)
            throw new EnumFlagsException(message);
    }
}