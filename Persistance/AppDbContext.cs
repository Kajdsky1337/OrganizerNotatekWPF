using System.Data.SqlClient;
using Dapper;
using ProjektOrganizerNotatek.DTO;
using System.IO;
using ProjektOrganizerNotatek.Service;
using ProjektOrganizerNotatek.Model;

namespace ProjektOrganizerNotatek.Persistance
{
    public class AppDbContext
    {
        private static readonly string DB_NAME = "OrganizerNotatekDB";
        private readonly SqlConnection _sqlConnection;


        public AppDbContext(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();
            InitDatabase();
        }
        

        private void InitDatabase()
        {
            TestConnection();
            CreateDatabaseIfNotExist();
            CreateTableUsersIfNotExistAndInsertDefaultUser();
        }
        public IEnumerable<T> GetFromDatabase<T>(string query, object param = null)
        {
            return _sqlConnection.Query<T>(query, param);
        }
        
        private void CreateDatabaseIfNotExist()
        {
            
            var command = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '" + DB_NAME + "') BEGIN CREATE DATABASE " + DB_NAME + "; END;";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = _sqlConnection;
            sqlCommand.ExecuteNonQuery();
            ChangeDatabase();
        }
        private void ChangeDatabase()
        {
            _sqlConnection.ChangeDatabase(DB_NAME);
        }
        public bool CreateNewUser(string username, string password)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                var insertUser = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
                var parameters = new { Username = username, PasswordHash = hashedPassword };

                _sqlConnection.Execute(insertUser, parameters);
                return true; 
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error during user registration: " + ex.Message);
                return false; 
            }
        }
        private void CreateTableUsersIfNotExistAndInsertDefaultUser()
        {
            // Polecenie SQL do sprawdzenia istnienia tabeli i jej utworzenia, jeśli nie istnieje
            var createTableCommand = """
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
        BEGIN
            CREATE TABLE Users (
                UserId INT PRIMARY KEY IDENTITY,
                Username NVARCHAR(255) NOT NULL UNIQUE,
                PasswordHash NVARCHAR(255) NOT NULL
            );
        END;
        """;

            // Polecenie SQL do wstawienia domyślnego użytkownika, jeśli tabela jest pusta
            var insertUserCommand = """
        IF NOT EXISTS (SELECT * FROM Users)
        BEGIN
            INSERT INTO Users (Username, PasswordHash)
            VALUES ('Mateusz', '$2y$10$gRdSFErfNWqBrngQBw3tzuaAX0eb46R03YYS1CNn7vH2cW7SYCT76')
        END;
        """;

            
            SqlCommand sqlCommand = new SqlCommand(createTableCommand + insertUserCommand, _sqlConnection);

            try
            {
                
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Obsługa wyjątków dotyczących bazy danych
                Console.WriteLine($"An error occurred while creating the Users table or inserting the default user: {e.Message}");
            }
        }


        public bool TestConnection()
        {
            try
            {
                _sqlConnection.Open();
               //_sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                return false;
            }
        } 
        
        public T QueryFirstOrDefault<T>(string sql,object param=null)
        {
            return _sqlConnection.QueryFirstOrDefault<T>(sql,param);
        }

        public void CreateNewNote(NotesDto notesDTO)
        {
            var query = "INSERT INTO Notes(UserId, Title, Content) " +
                        "VALUES (@UserId, @Title, @Content)";
            _sqlConnection.Execute(query, notesDTO);

        }

        public void DeleteNoteById(int noteId)
        {
            var query = "DELETE FROM Notes WHERE NoteId = @NoteId";
            _sqlConnection.Execute(query, new { NoteId = noteId });
        }
        public void UpdateNote(NotesEntity note)
        {
            var query = "UPDATE Notes SET Title = @Title, Content = @Content, ModificationDate = @ModificationDate WHERE NoteId = @NoteId";
            _sqlConnection.Execute(query, note);
        }






    }
}