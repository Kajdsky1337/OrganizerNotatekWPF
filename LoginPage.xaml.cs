using System;
using System.Windows;

using ProjektOrganizerNotatek.Persistance;
using ProjektOrganizerNotatek.Service;

namespace ProjektOrganizerNotatek
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private UserService _userService;
        public LoginPage()
        {
            InitializeComponent();
            AppDbContext appDbContext = new AppDbContext(DatabaseConfig.ConnectionString);


            
            _userService = new UserService(appDbContext);
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (_userService.ValidateLogin(username, password))
            {
            
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                
    
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

            
        }
        private void RegisterBtn_Click(Object sender, RoutedEventArgs e)
        {
            AppDbContext appDbContext = new AppDbContext(DatabaseConfig.ConnectionString);
            RegisterPage registerPage = new RegisterPage(appDbContext);
            registerPage.Show();
            this.Close();

        }
    }
}
