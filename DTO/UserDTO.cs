namespace ProjektOrganizerNotatek.DTO
{

    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public UserDto(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }

    }
}

