using MyHotel.DataBase;
using MyHotel.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MyHotel.View
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(User user)
        {
            InitializeComponent();
            lbNameUser.Content="Привет, "+user.UserName;
            
        }

        private void btnRegistation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
