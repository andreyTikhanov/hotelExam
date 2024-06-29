using MyHotel.DataBase;
using MyHotel.Model;
using System.Drawing;
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
            string userPassword = Crypto.CryptPassword((pbPasswordUser.Password));
            HotelRepository repository = new();
            User user = null;
            user = await repository.GetUserAsync(tbLoginUser.Text, userPassword);
            if (user == null)
            {
                tbLoginUser.Background = new SolidColorBrush(Colors.Red);
                tbLoginUser.Text = "Вы ввели не корректные данные";
                return;
            }
            NavigationService.Navigate(new MainPage(user));
        }
    }
}
