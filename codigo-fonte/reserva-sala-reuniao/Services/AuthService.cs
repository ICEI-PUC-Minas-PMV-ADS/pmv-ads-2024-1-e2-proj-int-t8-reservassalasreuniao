using reserva_sala_reuniao.Models;
using System.Security.Cryptography;
using System.Text;
using reserva_sala_reuniao.Functions;

namespace reserva_sala_reuniao.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Autentica o usuário com base no e-mail e senha fornecidos.
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="password">Senha fornecida</param>
        /// <returns>Usuário autenticado ou null se a autenticação falhar</returns>
        public Usuario Authenticate(string email, string password)
        {
            var user = _context.Usuario.SingleOrDefault(u => u.Email == email);
            if (user != null && VerifyPassword(password, user.Senha))
            {
                return user;  // Sucesso na autenticação
            }
            return null;  // Falha na autenticação
        }

        /// <summary>
        /// Verifica se a senha fornecida corresponde ao hash da senha armazenada.
        /// </summary>
        /// <param name="enteredPassword">Senha fornecida pelo usuário</param>
        /// <param name="storedHash">Hash da senha armazenada no banco de dados</param>
        /// <returns>True se a senha corresponder ao hash, false caso contrário</returns>
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            var hashOfEnteredPassword = Utility.HashPassword(enteredPassword);
            return hashOfEnteredPassword == storedHash;
        }
    }
}

