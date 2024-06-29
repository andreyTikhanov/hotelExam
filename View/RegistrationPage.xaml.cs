using MyHotel.DataBase;
using MyHotel.Model;
using System.Windows.Controls;

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

            if (tbNameUser.Text==string.Empty) return;
            User user = new User();
            user.UserName = tbNameUser.Text;
            user.UserLogin = tbLoginUser.Text;
            user.UserPassword = Crypto.CryptPassword(pbPasswordUser.Password);
            user.UserEmail = tbEmailUser.Text;
            user.UserPhone = tbPhoneUser.Text;

            await repository.AddUserAsync(user);
            CongratulationWindow congratulationWindow = new CongratulationWindow();
            congratulationWindow.Show();
            NavigationService.GoBack();
        }
    }
}
