using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjektOrganizerNotatek.Persistance;
namespace ProjektOrganizerNotatek
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private readonly AppDbContext _appDbContext;
        public RegisterPage(AppDbContext appDbContext)
        {
            InitializeComponent();
            _appDbContext = appDbContext;
        }
        public void Register_Click(object sender, RoutedEventArgs e)
        {

            var username = txtUsername.Text; 
            var password = txtPassword.Password; 

            bool result = _appDbContext.CreateNewUser(username, password);
            if (result)
            {
                MessageBox.Show("Rejestracja zakończona sukcesem. Możesz się teraz zalogować.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);
                
                
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Rejestracja nieudana. Spróbuj ponownie.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
