using MyHotel.Model;
using System.Windows.Controls;

namespace MyHotel.View
{
    public partial class SettingPage : Page
    {
        User pageUser;
        public SettingPage(User user)
        {
            this.pageUser = user;
            InitializeComponent();
        }

        private void btnChangeUserClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeUserPage(pageUser));
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
