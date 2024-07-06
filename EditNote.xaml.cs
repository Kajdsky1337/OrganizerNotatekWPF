using ProjektOrganizerNotatek.Service;
using System.Windows;

namespace ProjektOrganizerNotatek
{
    public partial class EditNote : Window
    {
        private readonly NotesService _notesService;

        public EditNote()
        {
            InitializeComponent();
            _notesService = new NotesService();
        }

        private void EditNote_Button_Clicked(object sender, RoutedEventArgs e)
        {
            string noteTitleToUpdate = NoteTitleTextBox.Text;
            string newTitle = NewTitleTextBox.Text;
            string newContent = NewContentTextBox.Text;

            if (_notesService.UpdateNoteByTitle(noteTitleToUpdate, newTitle, newContent))
            {
                MessageBox.Show("Notatka została pomyślnie zaktualizowana.");
            }
            else
            {
                MessageBox.Show("Notatka o podanym tytule nie istnieje.");
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