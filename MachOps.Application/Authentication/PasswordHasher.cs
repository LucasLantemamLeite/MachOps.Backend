
using Isopoh.Cryptography.Argon2;

namespace MachOps.Application.Authentication;

public static class PasswordHasher
{
    public static string GenerateHash(this string password) => Argon2.Hash(password);

    public static bool VerifyHash(this string currentPassword, string password) => Argon2.Verify(currentPassword, password);
}