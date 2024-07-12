using HotelCommon.Model;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MyHotel.View
{
    public partial class ChoiceRoom : Page
    {
        List<Room> rooms = new();
        public ChoiceRoom()
        {
            InitializeComponent();
            _ = LoadRoomsAsync();

        }




        private async Task LoadRoomsAsync()
        {
            rooms = await LoadRoomsFromDatabase();
            lbRooms.ItemsSource = rooms.ToList();
        }

        private async Task<List<Room>> LoadRoomsFromDatabase()
        {
            using (var client = new TcpClient("localhost", 5000))
            {
                using (var stream = client.GetStream())
                {
                    string request = "GETROOMS\n";
                    var requestBytes = Encoding.UTF8.GetBytes(request);

                    await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

                    var buffer = new byte[1024];
                    var bufferRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bufferRead);
                    var rooms = JsonConvert.DeserializeObject<List<Room>>(response);
                    return rooms;
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
