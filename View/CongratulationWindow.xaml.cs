using System.Windows;

namespace MyHotel.View
{
    public partial class CongratulationWindow : Window
    {
        public CongratulationWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
