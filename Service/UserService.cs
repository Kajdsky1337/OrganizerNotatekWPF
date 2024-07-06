using System.Threading.Channels;
using ProjektOrganizerNotatek.Model;
using ProjektOrganizerNotatek.Persistance;



namespace ProjektOrganizerNotatek.Service
{
    public class UserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool ValidateLogin(string username, string password)
        {
            var user = _appDbContext.QueryFirstOrDefault<UserEntity>(
                "SELECT * FROM Users WHERE Username = @Username", new { Username = username });

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                SessionManager.Instance.Login(user); // Zaloguj użytkownika w sesji
                return true;
            }

            return false;
        }






    }
}
