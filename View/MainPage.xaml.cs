using MyHotel.DataBase;
using MyHotel.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MyHotel.View
{
    public partial class MainPage : Page
    {
        User userPage;
        public MainPage()
        {
            InitializeComponent();
            btnSetting.IsEnabled = false;
            btnChoseRoom.IsEnabled = false;
            lbInfo.Content = "Для управления настройками и выбора номера войдите в профиль";
        }
        public MainPage(User user)
        {
            userPage = user;
            InitializeComponent();
            lbNameUser.Content="Привет, " + user.UserName;
            
        }

        private void btnRegistation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingPage(userPage));
        }

        private void btnChose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
