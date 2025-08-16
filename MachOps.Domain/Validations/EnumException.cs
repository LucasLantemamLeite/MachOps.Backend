namespace MachOps.Domain.ValueObjects.Validations;

public sealed class EnumException(string message) : Exception(message)
{
    public static void ThrowIfNotDefined<T>(int type, string message) where T : Enum
    {
        if (!Enum.IsDefined(typeof(T), type))
            throw new EnumException(message);
    }
}