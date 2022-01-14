using MineClicker.ChatServiceReference;
using MineClicker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para AddFriendWindow.xaml
    /// </summary>
    public partial class AddFriendWindow : Window {
        private ChatServiceClient client;
        public AddFriendWindow(ChatServiceClient client) {
            this.client = client;
            InitializeComponent();
        }
        public void SendFriendRequest(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text)) {
                return;
            }
            try {
                client.SendFriendRequest(Session.Player.PlayerId, UsernameBox.Text);
                MessageBox.Show(Properties.Resources.FriendRequestSentMessage);
                UsernameBox.Text = "";
            } catch (FaultException) {
                MessageBox.Show(Properties.Resources.SendRequestFailedMessage);
            }
        }

        private void BackButton(object sender, RoutedEventArgs e) {
            MainWindow goMainWindow = new MainWindow();
            this.Close();
            goMainWindow.ShowDialog();
        }
    }
}
