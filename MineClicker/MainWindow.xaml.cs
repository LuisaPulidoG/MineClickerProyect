using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ServiceModel;
using System.Media;
using MineClicker.Objetos;
using System.IO;
using MineClicker.Helpers;
using WCFServices.Models;

namespace MineClicker {
    /// <summary>
    /// Lógica de interacción para InicioJuego.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        private Player[] friends; 
        

        //private bool isConnected = false;

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        //public char PasswordChar { get; set; }

        public MainWindow() {
            InitializeComponent();
            friends = PlayerHelper.GetFriends();
            foreach(var friend in friends) {
                FriendsList.Children.Add(new TextBlock {
                    Text = friend.Username,
                    Foreground = Brushes.White,
                    FontSize = 18,
                    Padding = new Thickness(10)
                });
            }
        }

        private void ChatBtn(object sender, RoutedEventArgs e) {
            ChatJugadores chatWindow = new ChatJugadores();
            this.Close();
            chatWindow.ShowDialog();
        }

        private void StoreBtn(object sender, RoutedEventArgs e) {
            Store storeWindow = new Store();
            this.Close();
            storeWindow.CajaDeTextoApodo.Text = UserName;
            storeWindow.ShowDialog();
        }

        private void ConfigBtn(object sender, RoutedEventArgs e) {
            GameConfiguration configurationWindow = new GameConfiguration();
            this.Close();

            configurationWindow.ShowDialog();
        }

        private void ChangeRightBtn(object sender, RoutedEventArgs e) {

        }

        private void ChangeLeftBtn(object sender, RoutedEventArgs e) {

        }

        private void StatsBtn(object sender, RoutedEventArgs e) {
            Stats statsWindow = new Stats();
            this.Close();
            statsWindow.ShowDialog();
        }

        private void MultiplayerBtn(object sender, RoutedEventArgs e) {
            WaitingGameWindow waitingGameWindow = new WaitingGameWindow();
            this.Close();
            waitingGameWindow.ShowDialog();
        }

        private void SendInvitationBtn(object sender, RoutedEventArgs e) {
            SendInvitation invitationWindow = new SendInvitation();
            this.Close();
            invitationWindow.ShowDialog();
        }

        private void BotonChatGeneral(object sender, RoutedEventArgs e) {

        }
    }
}
