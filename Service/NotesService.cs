using ProjektOrganizerNotatek.DTO;
using ProjektOrganizerNotatek.Model;
using ProjektOrganizerNotatek.Persistance;

namespace ProjektOrganizerNotatek.Service
{
    public class NotesService
    {
        private readonly AppDbContext _appDbContext;
        public NotesService()
        {
            _appDbContext = new AppDbContext(DatabaseConfig.ConnectionString);
        }

        public IEnumerable<NotesEntity> GetNotes(int userId)
        {
            var query = "SELECT * FROM Notes WHERE UserId = @UserId ORDER BY CreationDate";
            return _appDbContext.GetFromDatabase<NotesEntity>(query, new { UserId = userId });
        }

        public void CreateNote(NotesDto notesDTO)
        {
            if (notesDTO == null)
            {
                throw new ArgumentNullException(nameof(notesDTO), "Provided notes data must not be null.");
            }
            _appDbContext.CreateNewNote(notesDTO);
        }
        public void DeleteNote(int noteId)
        {
            _appDbContext.DeleteNoteById(noteId);
        }
        public bool DeleteNoteByTitle(string title)
        {
            var noteToDelete = _appDbContext.GetFromDatabase<NotesEntity>("SELECT * FROM Notes WHERE Title = @Title", new { Title = title }).FirstOrDefault();
            if (noteToDelete != null)
            {
                _appDbContext.DeleteNoteById(noteToDelete.NoteId);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateNoteByTitle(string noteTitle, string newTitle, string newContent)
        {
            var existingNote = _appDbContext.GetFromDatabase<NotesEntity>("SELECT * FROM Notes WHERE Title = @Title", new { Title = noteTitle }).FirstOrDefault();
            if (existingNote != null)
            {
                existingNote.Title = newTitle;
                existingNote.Content = newContent;
                existingNote.ModificationDate = DateTime.Now;
                _appDbContext.UpdateNote(existingNote);
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}