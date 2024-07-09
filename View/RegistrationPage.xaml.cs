using HotelCommon.Model;
using MyHotel.Model;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace MyHotel.View
{

    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNameUser.Text) || string.IsNullOrEmpty(tbLoginUser.Text) || string.IsNullOrEmpty(pbPasswordUser.Password))
            {
                lbLoginUser.Foreground = new BrushConverter().ConvertFromString("#ADAABF") as Brush;
                lbLoginUser.Content = "Поля имя, логин и пароль обязательны для заполнения";
                return;
            }
            string password = Crypto.CryptPassword(pbPasswordUser.Password);
            User user = new();
            user.UserName = tbNameUser.Text;
            user.UserLogin = tbLoginUser.Text;
            user.UserPassword = password;
            user.UserPhone = tbPhoneUser.Text;
            user.UserEmail = tbEmailUser.Text;
            string result = await RegisterUser(user.UserName, user.UserLogin, user.UserPassword, user.UserPhone, user.UserEmail, user.Balance);
            if (result == "true")
            {
                CongratulationWindow congratulationWindow = new CongratulationWindow();
                congratulationWindow.Show();
                NavigationService.Navigate(new MainPage(user));
            }
            else if (result == "false")
            {
                lbLoginUser.Foreground = new BrushConverter().ConvertFromString("#F39A9D") as Brush;
                lbLoginUser.Content = "Введенный вами логин уже занят. Придумайте новый логин";
                tbLoginUser.Focus();
            }
        }

        private async Task<string> RegisterUser(string username, string login, string password, string phone, string email, decimal balance)
        {
            try
            {
                using (var client = new TcpClient("localhost", 5000))
                using (var stream = client.GetStream())
                {
                    string request = $"REGISTER|{username}|{login}|{password}|{phone}|{email}|{balance}\n";
                    var requestBytes = Encoding.UTF8.GetBytes(request);
                    await stream.WriteAsync(requestBytes, 0, requestBytes.Length);
                    var buffer = new byte[1024];
                    var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка подключения: {ex.Message}";
            }
        }
    }
}
