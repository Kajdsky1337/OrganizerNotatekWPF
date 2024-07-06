using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ProjektOrganizerNotatek.Model;
using ProjektOrganizerNotatek.Persistance;
using ProjektOrganizerNotatek.Service;



namespace ProjektOrganizerNotatek
{
    /// <summary>
    /// Logika interakcji dla klasy ShowNotes.xaml
    /// </summary>
    public partial class ShowNotes : Window
    {
        private readonly NotesService _noteService;
        public readonly AppDbContext _appDbContext;
        public ObservableCollection<NotesEntity> ObservableNotes { get; private set; } 
        public ShowNotes()
        {
            InitializeComponent();
            _appDbContext = new AppDbContext(DatabaseConfig.ConnectionString); 
            _noteService = new NotesService();
            ObservableNotes = new ObservableCollection<NotesEntity>();
            Tasks_ListView.ItemsSource = ObservableNotes;
            UpdateTasks();
        }

        
        public void CreateNoteEventHandler(object sender, CancelEventArgs e)
        {
            CreateNote eventSender = (CreateNote)sender;    
            if (eventSender.IsNoteCreateRequest)
            {
                int userId = GetCurrentUserId(); // Get the current logged-in user's ID
                Console.WriteLine("Creating note for UserId: " + userId);
                _noteService.CreateNote(new DTO.NotesDto(userId, eventSender.NewNoteName,
                    eventSender.NewNoteDescription));
                UpdateTasks();
            }
        }


        private void UpdateTasks()
        {
            ObservableNotes.Clear();
            int userId = GetCurrentUserId();
            var existingNotes = _noteService.GetNotes(userId);
            foreach (var note in existingNotes)
            {
                ObservableNotes.Add(note);
            }
        }
        private int GetCurrentUserId()
        {
            if (SessionManager.Instance.LoggedUser != null)
            {

                int userId = SessionManager.Instance.LoggedUser.UserId;
                Console.WriteLine(userId);
                return userId;
            }
            else
            {
                // Obsłuż przypadek, gdy użytkownik nie jest zalogowany
                // Tutaj możesz np. rzucić wyjątek, zwrócić wartość domyślną, itp.
                throw new Exception("Brak zalogowanego użytkownika.");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

}
