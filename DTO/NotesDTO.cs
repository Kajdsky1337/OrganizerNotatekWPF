    using Microsoft.VisualBasic.ApplicationServices;

    namespace ProjektOrganizerNotatek.DTO
{
    public class NotesDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        
        // Konstruktor bezparametrowy

        //public NotesDto() { }

        // Pełny konstruktor
        public NotesDto(int userId,string content, string title)
        {
            UserId = userId;
            Title = title;
            Content = content;
        }
    }
}


