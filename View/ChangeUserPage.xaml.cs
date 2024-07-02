using MyHotel.DataBase;
using MyHotel.Model;
using System.Windows.Controls;
using System.Windows.Media;

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
            tbEmailUser.Text = user.UserEmail;
            tbPhoneUser.Text = user.UserPhone;
        }

        private async void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HotelRepository repository = new();
            if (tbNameUser.Text == string.Empty || tbLoginUser.Text == string.Empty || pbPasswordUser.Password == string.Empty) return;

            bool isLoginTaken = true;
            while (isLoginTaken)
            {
                isLoginTaken = await repository.IsLoginUser(tbLoginUser.Text);
                if (isLoginTaken)
                {
                    lbNameUser.Foreground = new BrushConverter().ConvertFromString("#ADAABF") as Brush;
                    lbNameUser.Content = "Введенный вами логин уже занят. Придумайте новый логин";
                    tbLoginUser.Focus();
                    return;
                }
            }
            pageUser.UserName = tbNameUser.Text;
            pageUser.UserLogin = tbLoginUser.Text;
            pageUser.UserPassword= Crypto.CryptPassword(pbPasswordUser.Password);
            pageUser.UserEmail = tbEmailUser.Text;
            pageUser.UserPhone = tbPhoneUser.Text;
            await repository.UpdateUserAsync(pageUser);
        }

        private void btnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }
    }
}
