namespace ProjektOrganizerNotatek.Model
{
    public class NotesEntity
    {
        public int NoteId { get; set; }  
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

   
        public NotesEntity(int noteId, int userId, string title, string content, DateTime creationDate, DateTime modificationDate)
        {
            NoteId = noteId;
            UserId = userId;
            Title = title;
            Content = content;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
        }

        // Konstruktor bezparametrowy
       // public NotesEntity() { }
    }
}
