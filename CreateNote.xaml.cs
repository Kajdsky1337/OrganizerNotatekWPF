using System.ComponentModel;
using ProjektOrganizerNotatek;
using System.Windows;
using ProjektOrganizerNotatek.Service;


namespace ProjektOrganizerNotatek
{
    /// <summary>
    /// Logika interakcji dla klasy CreateNote.xaml
    /// </summary>
    public partial class CreateNote : Window
    {
        //private readonly ShowNotes _showNotes;
        //private MainWindow _mainWindow;
        public string NewNoteName { get; set; }
        public string NewNoteDescription { get; set; }

        public bool IsNoteCreateRequest { get; set; } = false;


        public CreateNote()
        {
            InitializeComponent();
        }

        //back click powrot do mainwindow
        private void Back_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
        
        //Zapis formularza
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ShowNotes showNotes = new ShowNotes();
            IsNoteCreateRequest = true;
            NewNoteName = TxtTitle.Text;
            NewNoteDescription = TxtContent.Text;
            this.Closing += showNotes.CreateNoteEventHandler;
            this.Close();
            showNotes.Show();
            

            
            
        }
    }
}
