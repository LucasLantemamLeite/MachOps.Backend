namespace MachOps.Domain.Validations;

public sealed class EnumFlagsException(string message) : Exception(message)
{
    public static void ThrowIfNotFlagDefined<TEnum>(int type, string message) where TEnum : struct, Enum
    {
        var allDefinedValues = Enum.GetValues<TEnum>().Select((e) => Convert.ToInt32(e)).Aggregate((a, b) => a | b);

        if ((type & ~allDefinedValues) != 0)
            throw new EnumFlagsException(message);
    }
}