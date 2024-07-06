namespace ProjektOrganizerNotatek.Model
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        // Konstruktor bezparametrowy
       // public UserEntity() { }

        // Pełny konstruktor
        public UserEntity(int userId, string username, string passwordHash)
        {
            UserId = userId;
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}
