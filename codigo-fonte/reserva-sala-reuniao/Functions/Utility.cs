using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace reserva_sala_reuniao.Functions
{
    public static class Utility
    {
        /// <summary>
        /// Gera um hash SHA256 para a senha fornecida.
        /// </summary>
        /// <param name="password">Senha a ser hashada</param>
        /// <returns>String com o hash da senha</returns>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", String.Empty).ToLowerInvariant();
            }
        }
    }
}
