namespace MachOps.Domain.ValueObjects.Validations;

public sealed class DomainException(string message) : Exception(message)
{
    public static void ThrowIfFalse(bool condition, string message)
    {
        if (!condition)
            throw new DomainException(message);
    }
}