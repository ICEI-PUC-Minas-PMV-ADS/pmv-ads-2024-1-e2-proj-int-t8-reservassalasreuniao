using reserva_sala_reuniao.Models;

namespace reserva_sala_reuniao.Services
{
    public interface IAuthService
    {
        Usuario Authenticate(string email, string password);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}