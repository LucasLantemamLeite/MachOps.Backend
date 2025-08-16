using System.Text.RegularExpressions;

namespace MachOps.Domain.Validations;

public partial class PhoneRegexException(string message) : Exception(message)
{
    [GeneratedRegex(@"^\+\d{8,15}$")]
    private static partial Regex PhoneNumberRegex();

    public static void ThrowIfNotMatch(string phone, string message)
    {
        if (!PhoneNumberRegex().IsMatch(phone))
            throw new PhoneRegexException(message);
    }
}