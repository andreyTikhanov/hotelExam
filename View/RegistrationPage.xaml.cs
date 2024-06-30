using MyHotel.DataBase;
using MyHotel.Model;
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

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HotelRepository repository = new();

            if (tbNameUser.Text == string.Empty || tbLoginUser.Text == string.Empty || pbPasswordUser.Password == string.Empty)
            {
                lbLoginUser.Foreground = new BrushConverter().ConvertFromString("#ADAABF") as Brush;
                lbLoginUser.Content = "Поля имя, логин и пароль обязательны для заполнения";
                return;
            }
            bool isLoginTaken = true;
            while (isLoginTaken)
            {
                isLoginTaken = await repository.IsLoginUser(tbLoginUser.Text);
                if (isLoginTaken)
                {
                    lbLoginUser.Foreground = new BrushConverter().ConvertFromString("#ADAABF") as Brush;
                    lbLoginUser.Content = "Введенный вами логин уже занят. Придумайте новый логин";
                    tbLoginUser.Focus();
                    return;
                }
            }
            User user = new User();
            user.UserName = tbNameUser.Text;
            user.UserLogin = tbLoginUser.Text;
            user.UserPassword = Crypto.CryptPassword(pbPasswordUser.Password);
            user.UserEmail = tbEmailUser.Text;
            user.UserPhone = tbPhoneUser.Text;

            await repository.AddUserAsync(user);
            CongratulationWindow congratulationWindow = new CongratulationWindow();
            congratulationWindow.Show();
            NavigationService.Navigate(new MainPage(user));
        }
    }
}
