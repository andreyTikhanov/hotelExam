using MyHotel.View;
using System.Windows;
using System.Windows.Navigation;

namespace MyHotel
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MainPage());
           
        }
    }
}