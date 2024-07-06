using ProjektOrganizerNotatek;
using System.Windows;

namespace ProjektOrganizerNotatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        
        private void CreateNote_Button_Clicked(object sender, RoutedEventArgs e)
        {
            CreateNote createNote = new CreateNote();
            createNote.Show();
            this.Close();
        }

        private void ShowNotes_Button_Clicked(object sender, RoutedEventArgs e)
        {
            ShowNotes showNotes = new ShowNotes();
            showNotes.Show();
            this.Close();
        }

        private void DeleteNotes_Button_Clicked(object sender, RoutedEventArgs e)
        {
            DeleteNote delteNote = new DeleteNote();
            delteNote.Show();
            this.Close();
        }

        private void EditNotes_Button_Clicked(object sender, RoutedEventArgs e)
        {
            EditNote editNote = new EditNote();
            editNote.Show();
            this.Close();
        }
    }
}