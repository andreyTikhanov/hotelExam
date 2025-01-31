﻿using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HotelCommon.Model;
using MySqlX.XDevAPI;


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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAddMoney(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbMoney.Text == string.Empty)
                {
                    lbFunc.Foreground = new BrushConverter().ConvertFromString("#ADAABF") as Brush;
                    lbFunc.Content = "Введите сумму для пополнения";
                    return;
                }
                decimal sum = decimal.Parse(tbMoney.Text);
                pageUser.Balance += sum;
                var result = AddMoneyUser(pageUser.Id, pageUser.Balance);
                if (result != null)
                {
                    lbFunc.Content = "Баланс успешно пополнен";
                    tbMoney.Text = "";
                }
                else
                {
                    tbMoney.Text = "Не удалось пополнить баланс";
                }
            }catch (Exception ex) { }
        }

        private async Task<string> AddMoneyUser(int id, decimal balance)
        {
            using (var client = new TcpClient("localhost", 5000))
            using(var stream = client.GetStream())
            {
                string request = $"ADD|{id}|{balance}\n";
                var requestBytes = Encoding.UTF8.GetBytes(request) ;

                await stream.WriteAsync(requestBytes, 0, requestBytes.Length) ;
                var buffer = new byte[1024];
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length) ;
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return response;
            }
        }
    }
}
