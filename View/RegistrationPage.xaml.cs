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

        private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(tbNameUser.Text==string.Empty) return;
            User user = new User();
            user.UserName = tbNameUser.Text;
            user.UserPhone = tbPhoneUser.Text;
            user.UserEmail = tbEmailUser.Text;
            HotelRepository repository = new ();
            repository.AddUser(user);
            CongratulationWindow congratulationWindow = new CongratulationWindow();
            congratulationWindow.Show();
            NavigationService.GoBack();
        }
    }
}
