using HotelCommon.Model;
using MyHotel.Model;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace MyHotel.View
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbLoginUser.Text == string.Empty || pbPasswordUser.Password == string.Empty) return;
            string userPassword = Crypto.CryptPassword(pbPasswordUser.Password);
            string result = await LoginUser(tbLoginUser.Text, userPassword);
            if (result.StartsWith("true"))
            {
                var parts = result.Split('|');
                var user = new User
                {
                    UserName = parts[1],
                    UserLogin = parts[2],
                    UserPassword = parts[3],
                    UserPhone = parts[4],
                    UserEmail = parts[5]
                };

                NavigationService.Navigate(new MainPage(user));
            }
            else
            {
                lbNameUser.Foreground = new BrushConverter().ConvertFromString("#ADAABF") as Brush;
                lbNameUser.Content = "Вы ввели неверные данные. Попробуйте еще раз";
                tbLoginUser.Text = string.Empty;
                pbPasswordUser.Password = string.Empty;
            }
        }

        private async Task<string> LoginUser(string login, string password)
        {
            try
            {
                using (var client = new TcpClient("localhost", 5000))
                using (var stream = client.GetStream())
                {
                    string request = $"LOGIN|{login}|{password}\n";
                    var requestBytes = Encoding.UTF8.GetBytes(request);
                    await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

                    var buffer = new byte[1024];
                    var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                return $"Ошибка подключения: {ex.Message}";
            }
        }

    }
}
