namespace MachOps.Domain.ValueObjects.Validations;

public sealed class EnumException : Exception
{
    public EnumException(string message) : base(message) { }

    public static void ThrowIfNotDefined<T>(int type, string message) where T : Enum
    {
        if (!Enum.IsDefined(typeof(T), type))
            throw new EnumException(message);
    }
}