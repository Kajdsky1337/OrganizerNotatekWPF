using ProjektOrganizerNotatek.Service;
using System.Windows;
using ProjektOrganizerNotatek.Model;
using ProjektOrganizerNotatek.Persistance;

    

namespace ProjektOrganizerNotatek
{
    public partial class DeleteNote : Window
    {
        private readonly NotesService _notesService;

        public DeleteNote()
        {
            InitializeComponent();
            _notesService = new NotesService(); 
        }

        
        private void DeleteNote_Button_Clicked(object sender, RoutedEventArgs e)
        {
            string titleToDelete = NoteIdTextBox.Text;
            if (!string.IsNullOrWhiteSpace(titleToDelete))
            {
                if (_notesService.DeleteNoteByTitle(titleToDelete))
                {
                    MessageBox.Show("Notatka została pomyślnie usunięta.");
                }
                else
                {
                    MessageBox.Show("Notatka o podanym tytule nie istnieje.");
                }

                
            }
            else
            {
                MessageBox.Show("Proszę podać tytuł notatki.");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ShowNotes showNotes = new ShowNotes();
            showNotes.Show();
            this.Close();
        }


    }
}