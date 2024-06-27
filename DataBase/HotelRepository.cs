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

        public void AddUser(User user)
        {
            _connection.Open();
            string query = "insert into users values (null, @name_user, @email_user, @phone_user)";
            MySqlCommand cmd = new(query, _connection);
            cmd.Parameters.AddWithValue("@name_user", user.UserName);
            cmd.Parameters.AddWithValue("@email_user", user.UserEmail);
            cmd.Parameters.AddWithValue("@phone_user", user.UserPhone);
            cmd.ExecuteNonQuery();
            _connection.Close();
        }


    }
}
