using MyHotel.Model;
using MySql.Data.MySqlClient;
namespace MyHotel.DataBase
{
    public class HotelRepository : IDisposable
    {
        private const string _connectionString = "server=localhost;user id=root;password=root;database=hotel";
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        protected MySqlConnection _connection;
        public HotelRepository()
        {
            _connection = new MySqlConnection(_connectionString);
        }

        public async Task AddUserAsync(User user)
        {
            await _connection.OpenAsync();
            string query = "insert into users values (null, @name_user, @login_user, @password_user, @email_user, @phone_user)";
            MySqlCommand cmd = new(query, _connection);
            cmd.Parameters.AddWithValue("@name_user", user.UserName);
            cmd.Parameters.AddWithValue("@login_user", user.UserLogin);
            cmd.Parameters.AddWithValue("@password_user", user.UserPassword);
            cmd.Parameters.AddWithValue("@email_user", user.UserEmail);
            cmd.Parameters.AddWithValue("@phone_user", user.UserPhone);
            await cmd.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
        }
        public async Task<User> GetUserAsync(string login, string password)
        {
            User user = null;
            await _connection.OpenAsync();
            string query = "SELECT * FROM users WHERE login_user = @login AND password_user = @password";
            MySqlCommand cmd = new(query, _connection);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);

            using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    user = new User()
                    {
                        Id = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserLogin = reader.GetString(2),
                        UserPassword = reader.GetString(3),
                        UserEmail = reader.GetString(4),
                        UserPhone = reader.GetString(5)
                    };
                }
            }
            await _connection.CloseAsync();
            return user;
        }
        public async Task<bool> IsLoginUser(string login)
        {
            await _connection.OpenAsync();
            string query = "select count(*) from users where login_user = @login";
            MySqlCommand cmd = new(query, _connection);
            cmd.Parameters.AddWithValue("@login", login);
            int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            await _connection.CloseAsync();
            return count > 0;
        }

        
    }
}
