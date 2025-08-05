namespace MachOps.Domain.ValueObjects.Validations;

public sealed class DomainException : Exception
{
    public DomainException(string message) : base(message) { }

    public static void ThrowIfFalse(bool condition, string message)
    {
        if (!condition)
            throw new DomainException(message);
    }
}