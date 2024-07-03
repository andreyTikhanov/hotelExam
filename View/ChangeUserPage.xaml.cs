using MyHotel.Model;
using System.Windows.Controls;
using System.Windows.Media;
using HotelCommon.Model;


namespace MyHotel.View
{
    public partial class ChangeUserPage : Page
    {
        User pageUser;
        public ChangeUserPage(User user)
        {
            this.pageUser = user;
            InitializeComponent();
            tbNameUser.Text = user.UserName;
            tbLoginUser.Text = user.UserLogin;
            pbPasswordUser.Password = user.UserPassword;
            tbEmailUser.Text = user.UserEmail;
            tbPhoneUser.Text = user.UserPhone;
        }

        private async void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (tbNameUser.Text == string.Empty || tbLoginUser.Text == string.Empty || pbPasswordUser.Password == string.Empty) return;

            
            pageUser.UserName = tbNameUser.Text;
            pageUser.UserLogin = tbLoginUser.Text;
            pageUser.UserPassword = Crypto.CryptPassword(pbPasswordUser.Password);
            pageUser.UserEmail = tbEmailUser.Text;
            pageUser.UserPhone = tbPhoneUser.Text;
         
        }

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
