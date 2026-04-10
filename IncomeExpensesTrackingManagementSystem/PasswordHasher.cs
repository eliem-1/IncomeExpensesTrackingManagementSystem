using System;
using System.Security.Cryptography;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Provides secure password hashing and verification using PBKDF2 with SHA-256.
    /// Supports automatic hash validation and format detection.
    /// </summary>
    internal static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;
        private const string Prefix = "PBKDF2";

        /// <summary>
        /// Hashes a password using PBKDF2 with SHA-256.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>A hashed password string in the format: PBKDF2$iterations$salt$hash</returns>
        public static string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);
            return $"{Prefix}${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// Verifies a password against a stored hash.
        /// </summary>
        /// <param name="password">The password to verify.</param>
        /// <param name="storedValue">The stored hash value.</param>
        /// <returns>True if the password matches the hash; otherwise, false.</returns>
        public static bool Verify(string password, string? storedValue)
        {
            if (string.IsNullOrWhiteSpace(storedValue))
            {
                return false;
            }

            string[] parts = storedValue.Split('$');
            if (parts.Length != 4 || !string.Equals(parts[0], Prefix, StringComparison.Ordinal))
            {
                return false;
            }

            if (!int.TryParse(parts[1], out int iterations) || iterations <= 0)
            {
                return false;
            }

            byte[] salt;
            byte[] expectedHash;

            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expectedHash = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }

        /// <summary>
        /// Checks if a value is in the hashed password format.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the value matches the hashed format; otherwise, false.</returns>
        public static bool IsHashedFormat(string? value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.StartsWith($"{Prefix}$", StringComparison.Ordinal);
        }
    }
}
