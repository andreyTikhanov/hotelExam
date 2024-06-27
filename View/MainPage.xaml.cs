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

        private void btnRegistation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
